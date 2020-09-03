using CatMash.Api.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Api.Validation
{
    public class CatModelValidator : AbstractValidator<CatModel>
    {
        public CatModelValidator()
        {
            RuleFor(m => m.Url)
             .NotEmpty()
             .MaximumLength(1000);
        }
    }
}
