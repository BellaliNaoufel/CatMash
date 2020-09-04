using CatMash.Api.Models.Requests;
using FluentValidation;

namespace CatMash.Api.Validation
{
    public class CatModelValidator : AbstractValidator<CatRequestModel>
    {
        public CatModelValidator()
        {
            RuleFor(m => m.Url)
                .NotEmpty()
                .MaximumLength(1000);

            RuleFor(m => m.Score)
                .NotEmpty()
                .GreaterThanOrEqualTo(0).WithMessage("'Score' doit etre un nombre supérieur ou égal à 0");
        }
    }
}