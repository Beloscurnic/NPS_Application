using FluentValidation;

namespace Application.Requests.Queries.Get_GroupQuestionnaire
{
    public partial class GroupQuestionnaire_Get
    {
        public class Validation : AbstractValidator<Query>
        {
            public Validation()
            {
                RuleFor(x => x.LincenseID)
                 .NotEmpty().WithMessage("LincenseID не может быть пустым.")
                 .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("LincenseID должен быть в формате GUID.");
            }
        }
    }
}
