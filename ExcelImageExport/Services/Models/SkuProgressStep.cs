using System.ComponentModel.DataAnnotations;

namespace ExcelImageExport.Services.Models
{
    public enum SkuProgressStep
    {
        [Display(Name = "Reading sku data from file.")]
        ReadingSku = 1,
        [Display(Name = "Reading products data from file.")]
        ReadingProducts = 2,
        [Display(Name = "Update products data.")]
        UpdateProductsData = 3,
        [Display(Name = "Save updated products data.")]
        UpdateProductsFile = 4,
        [Display(Name = "Save unused sku data.")]
        UpdateSkuFile = 5,
        [Display(Name = "Finished.")]
        Finished = 6
    }
}