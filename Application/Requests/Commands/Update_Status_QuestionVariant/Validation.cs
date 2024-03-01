using FluentValidation;

namespace Application.Requests.Commands.Update_Status_QuestionVariant
{
    public partial class QuestionVariant_Status_Update
    {
        public class Validation : AbstractValidator<Command>
        {
            public Validation()
            {
                RuleFor(x => x.QuestionVariant_ID)
                    .GreaterThan(0).WithMessage("QuestionVariant_ID должен быть больше нуля.");

                RuleFor(x => x.Oprostnik_ID)
                    .GreaterThan(0).WithMessage("Oprostnik_ID должен быть больше нуля.");
            }
        }
    }
}
