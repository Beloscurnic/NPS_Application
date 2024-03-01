using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_GroupQuestionnaire
{
    public partial class GroupQuestionnaire_Delet
    {
        public class Validation: AbstractValidator<Command>
        {
            public Validation() {
                RuleFor(x => x.ID_GroupQuestionnaire)
        .NotEmpty().WithMessage("ID_GroupQuestionnaire не может быть пустым.")
        .GreaterThan(0).WithMessage("ID_GroupQuestionnaire должен быть больше нуля.");
            } 
        }
    }
}
