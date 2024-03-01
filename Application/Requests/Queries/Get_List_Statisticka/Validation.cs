using FluentValidation;

namespace Application.Requests.Queries.Get_List_Statisticka
{
    public partial class ListStatistickaGet
    {
        public class Validation : AbstractValidator<Query>
        {
            public Validation()
            {
                RuleFor(x => x.Oprostnik_ID)
                     .NotEmpty().WithMessage("OprostnikID не может быть пустым.");

                RuleFor(x => x.Data_Start);
                   
                RuleFor(x => x.Data_End)
                    .GreaterThanOrEqualTo(x => x.Data_Start).WithMessage("Дата окончания должна быть после или равна дате начала");
            }
        }
    }
}
