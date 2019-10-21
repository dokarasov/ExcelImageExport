using System;
using System.Globalization;
using NPOI.SS.UserModel;

namespace ExcelImageExport.Features
{
    public static class NpoiExtensions
    {
        public static string GetFormattedCellValue(this ICell cell, IFormulaEvaluator eval = null)
        {
            if (cell == null) return string.Empty;

            switch (cell.CellType)
            {
                case CellType.String:
                    return cell.StringCellValue;

                case CellType.Numeric:
                    if (DateUtil.IsCellDateFormatted(cell))
                    {
                        var date = cell.DateCellValue;
                        var style = cell.CellStyle;
                        // Excel uses lowercase m for month whereas .Net uses uppercase
                        var format = style.GetDataFormatString().Replace('m', 'M');
                        return date.ToString(format);
                    }
                    else
                    {
                        return cell.NumericCellValue.ToString(CultureInfo.InvariantCulture);
                    }

                case CellType.Boolean:
                    return cell.BooleanCellValue ? "TRUE" : "FALSE";

                case CellType.Formula:
                    return eval != null ? GetFormattedCellValue(eval.EvaluateInCell(cell)) : cell.CellFormula;

                case CellType.Error:
                    return FormulaError.ForInt(cell.ErrorCellValue).String;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}