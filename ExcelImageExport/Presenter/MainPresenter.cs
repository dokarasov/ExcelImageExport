using ExcelImageExport.Presenter.Common;
using ExcelImageExport.Views;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;
using System.Net.Http;
using ExcelImageExport.Features;
using Serilog;
using ExcelImageExport.Validation;

namespace ExcelImageExport.Presenter
{
    public class MainPresenter : BasePresenter<IMainView>
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public MainPresenter(IApplicationController controller, IMainView view)
            : base(controller, view)
        {
            View.DownloadImages += DownloadImages;
            View.ValidateModel += ValidateModel;
        }

        private string[] ValidateModel()
        {
            var validator = new MainViewValidator();
            var result = validator.Validate(View);
            return result.Errors.Select(z => $"Property: {z.PropertyName}. Error: {z.ErrorMessage}").ToArray();
        }

        private void DownloadImages()
        {
            var fileData = GetFileData();
            var reportData = DownloadFiles(fileData);
            GenerateReport(reportData);

            View.ReportProgress(4, "Finished.");
        }

        private IReadOnlyDictionary<string, string[]> GetFileData()
        {
            View.CancellationTokenSource.Token.ThrowIfCancellationRequested();

            View.ReportProgress(1, "Reading files from file.");

            var data = new Dictionary<string, string[]>();
            var file = File.ReadAllBytes(View.FilePath);
            using (var memoryStream = new MemoryStream(file))
            {
                var workbook = new HSSFWorkbook(memoryStream);
                var worksheet = workbook.GetSheetAt(0);

                for (var rowIndex = View.StartRowIndex - 1; rowIndex <= worksheet.LastRowNum; rowIndex++)
                {
                    var row = worksheet.GetRow(rowIndex);
                    var cellName = row.GetCell(View.NamesColumnIndex - 1);
                    var cellImages = row.GetCell(View.ImagesColumnIndex - 1);
                    if (cellName == null || cellImages == null) break;

                    try
                    {
                        var imagesArray = cellImages.StringCellValue
                            .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        switch (cellName.CellType)
                        {
                            case NPOI.SS.UserModel.CellType.Numeric:
                                data.Add(cellName.NumericCellValue.ToString(CultureInfo.InvariantCulture), imagesArray);
                                break;
                            default:
                                data.Add(cellName.StringCellValue, imagesArray);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Fatal(ex,
                            $"There is some error reading cell values. NamesColumnIndex: {View.NamesColumnIndex}, ImagesColumnIndex: {View.ImagesColumnIndex}.");
                    }
                }
            }

            return data;
        }

        private IReadOnlyDictionary<string, IReadOnlyList<string>> DownloadFiles(
            IReadOnlyDictionary<string, string[]> fileData)
        {
            View.CancellationTokenSource.Token.ThrowIfCancellationRequested();

            View.ReportProgress(2, "Downloading files.");

            if (!Directory.Exists(View.SaveFolderPath))
                Directory.CreateDirectory(View.SaveFolderPath);

            var reportData = new Dictionary<string, IReadOnlyList<string>>();
            foreach (var (fileName, images) in fileData)
            {
                var count = 0;
                var localList = new List<string>();
                foreach (var image in images)
                {
                    var filePath = DownloadFile(fileName, image, count++);
                    localList.Add(filePath);
                }

                reportData.Add(fileName, localList);
            }

            return reportData;
        }

        private string DownloadFile(string fileName, string image, int count)
        {
            try
            {
                View.CancellationTokenSource.Token.ThrowIfCancellationRequested();

                View.ReportProgress(2, $"Downloading file: {image}");
                var result = HttpClient.GetAsync(image).GetAwaiter().GetResult();
                result.EnsureSuccessStatusCode();
                var content = result.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();

                if (count > 0) fileName += $"_{count}";
                var filePath = SaveFile(fileName, image, content);

                return filePath;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"There is some error downloading file. FileName: {fileName}.");
                return string.Empty;
            }
        }

        private string SaveFile(string fileName, string image, byte[] content)
        {
            try
            {
                var imageFileExtension = Path.GetExtension(image);
                var filePath = Path.Combine(View.SaveFolderPath, $"{fileName}{imageFileExtension}");
                using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    fs.Write(content, 0, content.Length);

                return filePath;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"There is some error saving file. FileName: {fileName}.");
                return string.Empty;
            }
        }

        private void GenerateReport(IReadOnlyDictionary<string, IReadOnlyList<string>> reportData)
        {
            View.CancellationTokenSource.Token.ThrowIfCancellationRequested();

            View.ReportProgress(3, "Generating report.");

            HSSFWorkbook workbook;
            using (var fileStream = new FileStream(View.FilePath, FileMode.Open, FileAccess.Read))
                workbook = new HSSFWorkbook(fileStream);

            var worksheet = workbook.CreateSheet("Report");

            var mainRowIndex = 0;
            var subRowIndex = 0;
            const int mainColumnIndex = 0;
            const int subColumnIndex = 3;
            foreach (var (fileName, savedItems) in reportData)
            {
                var count = 0;
                foreach (var filePath in savedItems)
                {
                    if (count == 0)
                    {
                        var row = worksheet.GetRow(mainRowIndex) ?? worksheet.CreateRow(mainRowIndex);

                        var primaryCell = row.CreateCell(mainColumnIndex);
                        primaryCell.SetCellValue(fileName);
                        var secondaryCell = row.CreateCell(mainColumnIndex + 1);
                        secondaryCell.SetCellValue(Path.GetFileName(filePath));
                        mainRowIndex++;
                    }
                    else
                    {
                        var row = worksheet.GetRow(subRowIndex) ?? worksheet.CreateRow(subRowIndex);

                        var primaryCell = row.CreateCell(subColumnIndex);
                        primaryCell.SetCellValue(fileName);
                        var secondaryCell = row.CreateCell(subColumnIndex + 1);
                        secondaryCell.SetCellValue(Path.GetFileName(filePath));
                        subRowIndex++;
                    }

                    count++;
                }

                using (var fileStream = new FileStream(View.FilePath, FileMode.Create, FileAccess.Write))
                    workbook.Write(fileStream);
            }
        }
    }
}