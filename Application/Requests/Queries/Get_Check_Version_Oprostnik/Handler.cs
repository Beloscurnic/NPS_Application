using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Queries.Get_Check_Version_Oprostnik
{
    public partial class Check_Version_Oprostnik_Get
    {
        public class Handler : IRequestHandler<Query, bool>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) { _DbContext = context; }

            public async Task<bool> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Oprostniks.FirstOrDefaultAsync(i => i.OprostnikID == request.OprostnikId);
                if (entity != null)
                {
                    if (entity.DataModified_Oprostnik == request.Data_Used)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new ArgumentNullException(nameof(entity));
                }
            }
        }
    }
}
