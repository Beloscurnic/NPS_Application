using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Question
{
    public partial class Question_Get
    {
        public class Validation: AbstractValidator<Query>
        {
            public Validation()
            {
                RuleFor(x => x.Question_ID)
            .NotEmpty().WithMessage("Question_ID не может быть пустым.");
            }
        }
    }
}
