using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExcelImageExport.Services.Models;
using ExcelImageExport.Views;
using NPOI.XSSF.UserModel;
using Serilog;

namespace ExcelImageExport.Services
{
    public class SkuUpdaterService
    {
        private readonly ISkuUpdater _skuUpdater;

        public SkuUpdaterService(ISkuUpdater skuUpdater)
        {
            _skuUpdater = skuUpdater;
        }

        public SkuList GetSkuListData()
        {
            _skuUpdater.SkuCancellationTokenSource.Token.ThrowIfCancellationRequested();
            _skuUpdater.SkuProgress(SkuProgressStep.ReadingSku);

            var list = new List<SkuItem>();
            var file = File.ReadAllBytes(_skuUpdater.SkuFilePath);
            using (var memoryStream = new MemoryStream(file))
            {
                var workbook = new XSSFWorkbook(memoryStream);
                var worksheet = workbook.GetSheetAt(0);

                const int skuColumnIndex = 0;
                const int priceColumnIndex = 1;
                const int quantityColumnIndex = 2;
                for (var rowIndex = 1; rowIndex <= worksheet.LastRowNum; rowIndex++)
                {
                    var row = worksheet.GetRow(rowIndex);
                    try
                    {
                        list.Add(new SkuItem
                        {
                            Sku = row.GetCell(skuColumnIndex).StringCellValue,
                            Price = row.GetCell(priceColumnIndex).NumericCellValue,
                            Quantity = Convert.ToInt32(row.GetCell(quantityColumnIndex).NumericCellValue)
                        });
                    }
                    catch (Exception ex)
                    {
                        Log.Fatal(ex, "There is some error reading cell values.");
                    }
                }

                workbook.Close();
            }

            return new SkuList(list);
        }

        public ProductsList GetProductsListData()
        {
            _skuUpdater.SkuCancellationTokenSource.Token.ThrowIfCancellationRequested();
            _skuUpdater.SkuProgress(SkuProgressStep.ReadingProducts);

            var list = new List<ProductItem>();
            var file = File.ReadAllBytes(_skuUpdater.ProductsFilePath);
            using (var memoryStream = new MemoryStream(file))
            {
                var workbook = new XSSFWorkbook(memoryStream);
                var worksheet = workbook.GetSheetAt(0);

                const int skuColumnIndex = 4;
                const int priceColumnIndex = 16;
                const int quantityColumnIndex = 11;
                for (var rowIndex = 1; rowIndex <= worksheet.LastRowNum; rowIndex++)
                {
                    var row = worksheet.GetRow(rowIndex);
                    try
                    {
                        list.Add(new ProductItem
                        {
                            Index = rowIndex,
                            Sku = row.GetCell(skuColumnIndex).StringCellValue,
                            Price = row.GetCell(priceColumnIndex).NumericCellValue,
                            Quantity = Convert.ToInt32(row.GetCell(quantityColumnIndex).NumericCellValue)
                        });
                    }
                    catch (Exception ex)
                    {
                        Log.Fatal(ex, "There is some error reading cell values.");
                    }
                }

                workbook.Close();
            }

            return new ProductsList(list);
        }

        public void UpdateProductsData(SkuList skuList, ProductsList productsList)
        {
            _skuUpdater.SkuCancellationTokenSource.Token.ThrowIfCancellationRequested();
            _skuUpdater.SkuProgress(SkuProgressStep.UpdateProductsData);

            foreach (var skuItem in skuList.List)
            {
                var product = productsList.List.FirstOrDefault(z => z.Sku == skuItem.Sku);
                if (product == null)
                {
                    skuItem.Unused = true;
                    continue;
                }

                product.Price = skuItem.Price;
                product.Quantity = skuItem.Quantity;
                product.Updated = true;
            }
        }

        public void UpdateProductsFile(ProductsList productsList)
        {
            if (!productsList.List.Any(z => z.Updated)) return;

            _skuUpdater.SkuCancellationTokenSource.Token.ThrowIfCancellationRequested();
            _skuUpdater.SkuProgress(SkuProgressStep.UpdateProductsFile);

            XSSFWorkbook workbook;
            using (var fileStream = new FileStream(_skuUpdater.ProductsFilePath, FileMode.Open, FileAccess.Read))
                workbook = new XSSFWorkbook(fileStream);
            var worksheet = workbook.GetSheetAt(0);

            const int priceColumnIndex = 16;
            const int quantityColumnIndex = 11;
            foreach (var product in productsList.List.Where(z => z.Updated))
            {
                var row = worksheet.GetRow(product.Index);
                row.GetCell(priceColumnIndex).SetCellValue(product.Price);
                row.GetCell(quantityColumnIndex).SetCellValue(product.Quantity);
            }

            using (var fileStream = new FileStream(_skuUpdater.ProductsFilePath, FileMode.Create, FileAccess.Write))
                workbook.Write(fileStream);

            workbook.Close();
        }

        public void UpdateSkuFile(SkuList skuList)
        {
            if (!skuList.List.Any(z => z.Unused)) return;

            _skuUpdater.SkuCancellationTokenSource.Token.ThrowIfCancellationRequested();
            _skuUpdater.SkuProgress(SkuProgressStep.UpdateSkuFile);

            XSSFWorkbook workbook;
            using (var fileStream = new FileStream(_skuUpdater.SkuFilePath, FileMode.Open, FileAccess.Read))
                workbook = new XSSFWorkbook(fileStream);

            var worksheet = workbook.CreateSheet("Unused");
            var rowIndex = 0;
            const int skuColumnIndex = 0;
            const int priceColumnIndex = 1;
            const int quantityColumnIndex = 2;
            foreach (var product in skuList.List.Where(z => z.Unused))
            {
                var row = worksheet.GetRow(rowIndex) ?? worksheet.CreateRow(rowIndex);

                var skuCell = row.CreateCell(skuColumnIndex);
                skuCell.SetCellValue(product.Sku);

                var priceCell = row.CreateCell(priceColumnIndex);
                priceCell.SetCellValue(product.Price);

                var quantityCell = row.CreateCell(quantityColumnIndex);
                quantityCell.SetCellValue(product.Quantity);

                rowIndex++;
            }

            using (var fileStream = new FileStream(_skuUpdater.SkuFilePath, FileMode.Create, FileAccess.Write))
                workbook.Write(fileStream);

            workbook.Close();
        }
    }
}