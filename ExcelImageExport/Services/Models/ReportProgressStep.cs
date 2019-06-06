using System.ComponentModel.DataAnnotations;

namespace ExcelImageExport.Services.Models
{
    public enum ReportProgressStep
    {
        [Display(Name = "Reading images from file.")]
        Reading = 1,
        [Display(Name = "Downloading images.")]
        DownloadingFiles = 2,
        [Display(Name = "Generating report.")]
        GenerateReport = 3,
        [Display(Name = "Finished.")]
        Finished = 4
    }
}