using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Response
{
    public partial class List_Response_Get
    {
        public class Validation : AbstractValidator<Query>
        {
            public Validation() {
                RuleFor(x => x.OprostnikID)
              .NotEmpty().WithMessage("OprostnikID не может быть пустым.");
            }
        }
    }
}
