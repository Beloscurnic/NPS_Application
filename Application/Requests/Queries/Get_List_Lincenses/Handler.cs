using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Queries.Get_List_Lincenses
{
    public partial class List_Lincenses
    {
        public class Handler : IRequestHandler<Query, List_View_Model>
        {
            private readonly I_DbContext _DbContext;

            public Handler(I_DbContext dbContext)
            {
                _DbContext = dbContext;
            }

            public async Task<List_View_Model> Handle(Query request, CancellationToken cancellationToken)
            {
                var entities = await _DbContext.Lincenses.Select(entity => new View_Model
                 {
                     ID = entity.LincenseID,
                     CompanyOID = entity.CompanyOID,
                     ActivationCode = entity.ActivationCode,
                     Lincense_Activated = entity.Lincense_Activated,
                     License_Status = entity.License_Status,
                     Device_Name = entity.Device_Name
                 }).ToListAsync(cancellationToken);

                var listViewModel = new List_View_Model
                {
                    View_Models = entities
                };

                return listViewModel;
            }
        }
    }
}