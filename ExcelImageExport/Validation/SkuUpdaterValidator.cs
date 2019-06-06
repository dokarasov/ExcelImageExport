using ExcelImageExport.Views;
using FluentValidation;

namespace ExcelImageExport.Validation
{
    public class SkuUpdaterValidator : AbstractValidator<ISkuUpdater>
    {
        public SkuUpdaterValidator()
        {
            RuleFor(z => z.SkuFilePath).NotNull().NotEmpty();
            RuleFor(z => z.ProductsFilePath).NotNull().NotEmpty();
        }
    }
}