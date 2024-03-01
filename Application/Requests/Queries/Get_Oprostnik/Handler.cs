using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Queries.Get_OprostnikOne
{
    public partial class Oprostnik_GetOne
    {
        public class Handler : IRequestHandler<Query_Oprostnik, ViewModelOprostnik>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) { _DbContext = context; }
            public async Task<ViewModelOprostnik> Handle(Query_Oprostnik request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Oprostniks.Where(i => i.OprostnikID == request.ID).Select(i=> new ViewModelOprostnik
                {
                    OprostnikID = i.OprostnikID,
                    DataCreat_Oprostnik = i.DataCreat_Oprostnik,
                    DataModified_Oprostnik = i.DataModified_Oprostnik,
                    GroupQuestionnaireID = i.GroupQuestionnaireID
                }).FirstOrDefaultAsync(cancellationToken);

                return entity;
            }
        }
    }
}
