using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Queries.Get_List_Response
{
    public partial class List_Response_Get
    {
        public class Handler : IRequestHandler<Query, List_View_Model_Response>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) { _DbContext = context; }

            public async Task<List_View_Model_Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Responses.Where(i => i.OprostnikID == request.OprostnikID).Select(i => new View_Model_Response
                {
                    ResponseID = i.ResponseID,
                    CompanyOID = i.CompanyOID,
                    Data_Creat_Response = i.Data_Creat_Response,
                    OprostnikID = i.OprostnikID
                }).ToListAsync(cancellationToken);

                if (entity != null)
                {
                    return new List_View_Model_Response { view_Model_Responses = entity };
                }
                else throw new ArgumentNullException(nameof(entity));
            }
        }
    }
}
