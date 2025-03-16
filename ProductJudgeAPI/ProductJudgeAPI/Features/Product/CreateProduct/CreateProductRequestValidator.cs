using FluentValidation;

namespace ProductJudgeAPI.Features.Product.CreateProduct
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotEmpty();
        }
    }
}
