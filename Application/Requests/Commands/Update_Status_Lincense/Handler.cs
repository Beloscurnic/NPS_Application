using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Update_Status_Lincense
{
    public partial class Status_Updata
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly I_DbContext _dbContext;
            public Handler(I_DbContext dbContext) =>
            _dbContext = dbContext;

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _dbContext.Lincenses.Where(i => i.LincenseID == request.ID).FirstOrDefaultAsync(cancellationToken);
                if (entity != null)
                {
                    entity.License_Status = request.License_Status;
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    throw new ArgumentNullException($"Соотвествующая лицензи {request.ID} небыла найдена в базе данных.", nameof(entity));
                }
                return Unit.Value;
            }
        }
    }
}