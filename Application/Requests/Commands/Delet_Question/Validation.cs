using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_Question
{
    public partial class Question_Delet
    {
        public class Validation: AbstractValidator<Command>
        {
            public Validation() {
                RuleFor(x => x.Question_ID)
                     .NotEmpty().WithMessage("Question_ID не может быть пустым.")
                     .GreaterThan(0).WithMessage("Question_ID должен быть больше нуля.");
            }
        }
    }
}
