using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_Response
{
    public partial class Response_Delit
    {
        public class Validation: AbstractValidator<Command>
        {
            public Validation() {
                RuleFor(x => x.Response_ID)
                      .NotEmpty().WithMessage("Response_ID не может быть пустым.");
            } 
        }
    }
}
