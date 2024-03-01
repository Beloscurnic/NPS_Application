using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Statisticka
{
    public partial class Statisticka_Get
    {
        public class Validation: AbstractValidator<Query>
        {
            public Validation()
            {

                RuleFor(x => x.Oprostnik_ID)
                    .NotEmpty().WithMessage("Идентификатор Oprostnik обязателен.");

                RuleFor(x => x.QuestionID)
                    .NotEmpty().WithMessage("Идентификатор вопроса обязателен.");

                RuleFor(x => x.Data_Start);
                  
                RuleFor(x => x.Data_End)
                    .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Дата окончания должна быть в будущем или сегодня.")
                    .When(x => x.Data_End.HasValue);
            }
        }
    }
}
