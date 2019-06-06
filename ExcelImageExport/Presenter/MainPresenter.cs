using ExcelImageExport.Presenter.Common;
using ExcelImageExport.Views;
using System.Linq;
using ExcelImageExport.Services;
using ExcelImageExport.Services.Models;
using ExcelImageExport.Validation;

namespace ExcelImageExport.Presenter
{
    public class MainPresenter : BasePresenter<IMainView>
    {
        public MainPresenter(IApplicationController controller, IMainView view)
            : base(controller, view)
        {
            View.DownloadImages += DownloadImages;
            View.ValidateReportModel += ValidateReportModel;
            View.ValidateSkuModel += ValidateSkuModel;
            View.UpdateSku += UpdateSku;
        }

        private string[] ValidateReportModel()
        {
            var validator = new DownloadImagesValidator();
            var result = validator.Validate(View);
            return result.Errors.Select(z => $"Property: {z.PropertyName}. Error: {z.ErrorMessage}").ToArray();
        }

        private void DownloadImages()
        {
            var downloadImageService = new DownloadImageService(View);

            var fileData = downloadImageService.GetFileData();
            var reportData = downloadImageService.DownloadFiles(fileData);
            downloadImageService.GenerateReport(reportData);

            View.ReportProgress(ReportProgressStep.Finished);
        }

        private string[] ValidateSkuModel()
        {
            var validator = new SkuUpdaterValidator();
            var result = validator.Validate(View);
            return result.Errors.Select(z => $"Property: {z.PropertyName}. Error: {z.ErrorMessage}").ToArray();
        }

        private void UpdateSku()
        {
            var skuUpdaterService = new SkuUpdaterService(View);
            var skuList = skuUpdaterService.GetSkuListData();
            var productsList = skuUpdaterService.GetProductsListData();
            skuUpdaterService.UpdateProductsData(skuList, productsList);
            skuUpdaterService.UpdateProductsFile(productsList);
            skuUpdaterService.UpdateSkuFile(skuList);

            View.SkuProgress(SkuProgressStep.Finished);
        }
    }
}