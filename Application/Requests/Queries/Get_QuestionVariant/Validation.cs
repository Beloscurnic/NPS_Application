using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_QuestionVariant
{
    public partial class QuestionVariant_Get
    {
        public class Validation: AbstractValidator<Query>
        {
            public Validation() {
                RuleFor(x => x.QuestionVariant_ID)
               .NotEmpty().WithMessage("QuestionVariant_ID не может быть пустым.");
            }
        }
    }
}
