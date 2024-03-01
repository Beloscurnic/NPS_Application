using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_Answert
{
    public partial class Answert_Delet
    {
        public class Validation: AbstractValidator<Command>
        {
            public Validation() {
                RuleFor(x => x.AnswertId)
                        .NotEmpty().WithMessage("AnswertId не может быть пустым.")
                        .GreaterThan(0).WithMessage("AnswertId должен быть больше нуля.");
            }
        }
    }
}
