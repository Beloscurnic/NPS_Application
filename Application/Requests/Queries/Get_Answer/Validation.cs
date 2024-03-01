using FluentValidation;

namespace Application.Requests.Queries.Get_Answer
{
    public partial class Answer_Get
    {
        public class Validation : AbstractValidator<Query>
        {
            public Validation()
            {
                RuleFor(i => i.AnswertID).NotEmpty().WithMessage("AnswertID не может быть пустым.");
            }
        }
    }
}
