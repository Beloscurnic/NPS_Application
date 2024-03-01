using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_Lincense
{
    public partial class Lincense_Delet
    {
        public class Validation :AbstractValidator<Command>
        {
            public Validation()
            {
                RuleFor(x => x.ID)
                    .NotEmpty().WithMessage("ID не может быть пустым.")
                    .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("ID должен быть в формате GUID.");
            }
        }
    }
}
