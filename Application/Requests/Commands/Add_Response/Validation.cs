using FluentValidation;

namespace Application.Requests.Commands.Add_Response
{
    public partial class Response_Add
    {

        public class Validation : AbstractValidator<Command>
        {
            public Validation()
            {
                RuleForEach(command => command.Answers).SetValidator(new CommandValidation());
             
            }
        }
        public class CommandValidation : AbstractValidator<CommandAnswert>
        {
            public CommandValidation()
            {
                RuleFor(x => x.Response_Question_ID)
                            .NotEmpty().WithMessage("Response_Question_ID не может быть пустым.");
                          
                RuleFor(x => x.QuestionID)
                    .GreaterThan(0).WithMessage("QuestionID должен быть больше нуля.");
            }

        }
    }
}
