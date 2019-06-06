using System.Collections.Generic;

namespace ExcelImageExport.Services.Models
{
    public class SkuList
    {
        public IReadOnlyList<SkuItem> List { get; }

        public SkuList(IReadOnlyList<SkuItem> list)
        {
            List = list;
        }
    }

    public class SkuItem
    {
        public string Sku { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool Unused { get; set; }
    }
}