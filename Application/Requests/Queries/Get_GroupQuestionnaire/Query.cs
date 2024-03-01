using MediatR;

namespace Application.Requests.Queries.Get_GroupQuestionnaire
{
    public partial class GroupQuestionnaire_Get
    {
  
        public class Query : IRequest<View_Model_GroupQuestionnaire>
        {
            public Guid LincenseID { get; set; }
            public Query(Guid lincenseID)
            {
                LincenseID = lincenseID;
            }
        }
    }
}
