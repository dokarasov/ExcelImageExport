using System.Collections.Generic;

namespace ExcelImageExport.Services.Models
{
    public class ReportData
    {
        public IReadOnlyDictionary<string, IReadOnlyList<string>> Data { get; }

        public ReportData(IReadOnlyDictionary<string, IReadOnlyList<string>> data)
        {
            Data = data;
        }
    }
}