using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_OprostnikOne
{
    public partial class Oprostnik_GetOne
    {
        public class Validation : AbstractValidator<Query_Oprostnik>
        {
            public Validation()
            {
                RuleFor(x => x.ID)
            .NotEmpty().WithMessage("OprostnikID не может быть пустым.");
            }
        }
    }
}
