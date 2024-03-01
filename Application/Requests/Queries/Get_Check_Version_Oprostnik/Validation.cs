using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Check_Version_Oprostnik
{
    public partial class Check_Version_Oprostnik_Get
    {
        public class Validation: AbstractValidator<Query>
        {
            public Validation() {
                RuleFor(i => i.OprostnikId).NotEmpty().WithMessage("AnswertID не может быть пустым.");
                RuleFor(x => x.Data_Used).NotEmpty().WithMessage("Дата лицензии не должна быть пустой");
            }
        }
    }
}
