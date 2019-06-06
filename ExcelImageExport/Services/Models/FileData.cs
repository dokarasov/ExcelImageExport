using System.Collections.Generic;

namespace ExcelImageExport.Services.Models
{
    public class FileData
    {
        public IReadOnlyDictionary<string, string[]> Data { get; }

        public FileData(IReadOnlyDictionary<string, string[]> data)
        {
            Data = data;
        }
    }
}