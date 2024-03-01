using MediatR;

namespace Application.Requests.Queries.Get_Lincense
{
    public partial class Lincense
    {
        public class Query : IRequest<View_Model_Lincense>
        {
            public  Guid ID { get;  }
            public Query(Guid id)
            {
                ID = id;
            }
        }
    }
}
