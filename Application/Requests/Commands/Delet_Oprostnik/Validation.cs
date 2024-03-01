using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_Oprostnik
{
    public partial class Oprostnik_Delet
    {
        public class Validation: AbstractValidator<Command>
        {
            public Validation() {
                RuleFor(x => x.ID_Oprostniks)
        .NotEmpty().WithMessage("ID_Oprostniks не может быть пустым.")
        .GreaterThan(0).WithMessage("ID_Oprostniks должен быть больше нуля.");
            }
        }
    }
}
