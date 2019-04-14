using ExcelImageExport.Views;
using FluentValidation;

namespace ExcelImageExport.Validation
{
    public class MainViewValidator : AbstractValidator<IMainView>
    {
        public MainViewValidator()
        {
            RuleFor(z => z.StartRowIndex).NotNull().NotEqual(0);
            RuleFor(z => z.NamesColumnIndex).NotNull().NotEqual(0);
            RuleFor(z => z.ImagesColumnIndex).NotNull().NotEqual(0);

            RuleFor(z => z.FilePath).NotNull().NotEmpty();
            RuleFor(z => z.SaveFolderPath).NotNull().NotEmpty();
        }
    }
}