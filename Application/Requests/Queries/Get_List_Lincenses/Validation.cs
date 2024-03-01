using FluentValidation;

namespace Application.Requests.Queries.Get_List_Lincenses
{
    public partial class List_Lincenses
    {
        public class Validation : AbstractValidator<Query>
        {
            public Validation()
            {
            }
        }
    }
}
