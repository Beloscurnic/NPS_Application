using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Queries.Get_Lincense
{
    public partial class Lincense
    {
        public class Handler : IRequestHandler<Query, View_Model_Lincense>
        {
            private readonly I_DbContext _DbContext;

            public Handler(I_DbContext dbContext)
            {
                _DbContext = dbContext;
            }

            public async Task<View_Model_Lincense> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Lincenses.Where(i => i.LincenseID == request.ID).FirstOrDefaultAsync(cancellationToken);
                var result = new View_Model_Lincense
                {
                    ID = entity.LincenseID,
                    CompanyOID = entity.CompanyOID,
                   // Group_Questionnaire = entity?.Group_Questionnaire,
                    ActivationCode = entity.ActivationCode,
                    Lincense_Activated = entity.Lincense_Activated,
                    License_Status = entity.License_Status,
                    Device_Name = entity?.Device_Name
                };
                return result;
            }
        }

    }
}