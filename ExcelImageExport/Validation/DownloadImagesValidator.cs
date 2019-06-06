using ExcelImageExport.Views;
using FluentValidation;

namespace ExcelImageExport.Validation
{
    public class DownloadImagesValidator : AbstractValidator<IDownloadImages>
    {
        public DownloadImagesValidator()
        {
            RuleFor(z => z.StartRowIndex).NotNull().NotEqual(0);
            RuleFor(z => z.NamesColumnIndex).NotNull().NotEqual(0);
            RuleFor(z => z.ImagesColumnIndex).NotNull().NotEqual(0);

            RuleFor(z => z.FilePath).NotNull().NotEmpty();
            RuleFor(z => z.SaveFolderPath).NotNull().NotEmpty();
        }
    }
}