using FluentValidation;

namespace Application.Requests.Commands.Delet_QuestionVariant
{
    public partial class QuestionVariant_Delet
    {
        public class Validation : AbstractValidator<Command>
        {
            public Validation()
            {
                RuleFor(x => x.QuestionVariantID)
          .NotEmpty().WithMessage("QuestionVariantID не может быть пустым.")
          .GreaterThan(0).WithMessage("QuestionVariantID должен быть больше нуля.");

                RuleFor(x => x.OprostnikID)
                    .NotEmpty().WithMessage("OprostnikID не может быть пустым.")
                    .GreaterThan(0).WithMessage("OprostnikID должен быть больше нуля.");
            }

        }
    }
}
