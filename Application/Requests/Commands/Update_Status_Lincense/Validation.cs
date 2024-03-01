using FluentValidation;

namespace Application.Requests.Commands.Update_Status_Lincense
{
    public partial class Status_Updata
    {
        public class Validation : AbstractValidator<Command>
        {
            public Validation()
            {
                RuleFor(x => x.License_Status)
                   .IsInEnum()
                   .WithMessage("License_Status должен быть допустимым значением перечисления LicenseStatus.");

                RuleFor(x => x.ID)
                  .NotEmpty().WithMessage("ID не может быть пустым.")
                  .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("ID должен быть в формате GUID.");
            }
        }
    }
}

