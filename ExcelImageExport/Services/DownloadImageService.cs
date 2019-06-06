using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using ExcelImageExport.Features;
using ExcelImageExport.Services.Models;
using ExcelImageExport.Views;
using NPOI.HSSF.UserModel;
using Serilog;

namespace ExcelImageExport.Services
{
    public class DownloadImageService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private readonly IDownloadImages _downloadImages;

        public DownloadImageService(IDownloadImages downloadImages)
        {
            _downloadImages = downloadImages;
        }

        public FileData GetFileData()
        {
            _downloadImages.ReportCancellationTokenSource.Token.ThrowIfCancellationRequested();
            _downloadImages.ReportProgress(ReportProgressStep.Reading);

            var data = new Dictionary<string, string[]>();
            var file = File.ReadAllBytes(_downloadImages.FilePath);
            using (var memoryStream = new MemoryStream(file))
            {
                var workbook = new HSSFWorkbook(memoryStream);
                var worksheet = workbook.GetSheetAt(0);

                for (var rowIndex = _downloadImages.StartRowIndex - 1; rowIndex <= worksheet.LastRowNum; rowIndex++)
                {
                    var row = worksheet.GetRow(rowIndex);
                    var cellName = row.GetCell(_downloadImages.NamesColumnIndex - 1);
                    var cellImages = row.GetCell(_downloadImages.ImagesColumnIndex - 1);
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
                            $"There is some error reading cell values. NamesColumnIndex: {_downloadImages.NamesColumnIndex}, ImagesColumnIndex: {_downloadImages.ImagesColumnIndex}.");
                    }
                }
            }

            return new FileData(data);
        }

        public ReportData DownloadFiles(FileData fileData)
        {
            _downloadImages.ReportCancellationTokenSource.Token.ThrowIfCancellationRequested();
            _downloadImages.ReportProgress(ReportProgressStep.DownloadingFiles);

            Directory.CreateDirectory(_downloadImages.SaveFolderPath);

            var reportData = new Dictionary<string, IReadOnlyList<string>>();
            foreach (var (fileName, images) in fileData.Data)
            {
                var count = 0;
                var localList = images.Select(image => DownloadFile(fileName, image, count++)).ToList();
                reportData.Add(fileName, localList);
            }

            return new ReportData(reportData);
        }

        public void GenerateReport(ReportData reportData)
        {
            _downloadImages.ReportCancellationTokenSource.Token.ThrowIfCancellationRequested();
            _downloadImages.ReportProgress(ReportProgressStep.GenerateReport);

            HSSFWorkbook workbook;
            using (var fileStream = new FileStream(_downloadImages.FilePath, FileMode.Open, FileAccess.Read))
                workbook = new HSSFWorkbook(fileStream);

            var worksheet = workbook.CreateSheet("Report");
            var mainRowIndex = 0;
            var subRowIndex = 0;
            const int mainColumnIndex = 0;
            const int subColumnIndex = 3;
            foreach (var (fileName, savedItems) in reportData.Data)
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
            }

            using (var fileStream = new FileStream(_downloadImages.FilePath, FileMode.Create, FileAccess.Write))
                workbook.Write(fileStream);

            workbook.Close();
        }

        private string DownloadFile(string fileName, string image, int count)
        {
            try
            {
                _downloadImages.ReportCancellationTokenSource.Token.ThrowIfCancellationRequested();
                _downloadImages.ReportProgress(ReportProgressStep.DownloadingFiles, image);

                var result = _httpClient.GetAsync(image).GetAwaiter().GetResult();
                result.EnsureSuccessStatusCode();
                var content = result.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();

                if (count > 0) fileName += $"_{count}";
                var filePath = SaveFile(fileName, image, content);

                return filePath;
            }
            catch (Exception exception)
            {
                Log.Fatal(exception, $"There is some error downloading file. FileName: {fileName}.");
                return string.Empty;
            }
        }

        private string SaveFile(string fileName, string image, byte[] content)
        {
            try
            {
                var imageFileExtension = Path.GetExtension(image);
                var filePath = Path.Combine(_downloadImages.SaveFolderPath, $"{fileName}{imageFileExtension}");
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    fileStream.Write(content, 0, content.Length);

                return filePath;
            }
            catch (Exception exception)
            {
                Log.Fatal(exception, $"There is some error saving file. FileName: {fileName}.");
                return string.Empty;
            }
        }
    }
}