using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Requests.Commands.Upsert_Question.Question_Upsert;

namespace Application.Requests.Commands.Upsert_QuestionVariant
{
    public partial class QuestionVaraint_Upsert
    {
        public class Validation : AbstractValidator<CommandListQuestionVariant>
        {
            public Validation()
            {
                RuleForEach(command => command.QuestionVariant_Commands).SetValidator(new CommandValidation());

            }
        }
        public class CommandValidation : AbstractValidator<Command>
        {
            public CommandValidation()
            {
                //RuleFor(command => command.QuestionID).NotEmpty();
                //RuleFor(command => command.TypeQuestion).NotEmpty();
                //RuleFor(command => command.Name_Question).NotEmpty();
            }
        }
    }
}
