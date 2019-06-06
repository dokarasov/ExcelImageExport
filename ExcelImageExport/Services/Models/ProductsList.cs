using System.Collections.Generic;

namespace ExcelImageExport.Services.Models
{
    public class ProductsList
    {
        public IReadOnlyList<ProductItem> List { get; }

        public ProductsList(IReadOnlyList<ProductItem> list)
        {
            List = list;
        }
    }

    public class ProductItem
    {
        public int Index { get; set; }
        public string Sku { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool Updated { get; set; }
    }
}