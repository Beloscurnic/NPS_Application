using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_QuestionVariant
{
    public partial class QuestionVariant_Get_List
    {
        public class Validation: AbstractValidator<Query>
        {
            public Validation() {
                RuleFor(x => x.QuestionID)
                          .NotEmpty().WithMessage("QuestionID не может быть пустым.");
            }
        }
    }
}
