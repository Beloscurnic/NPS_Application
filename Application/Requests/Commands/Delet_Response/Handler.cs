using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_Response
{
    public partial class Response_Delit
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) { _DbContext = context; }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Responses.FirstOrDefaultAsync(i => i.ResponseID == request.Response_ID);
                if (entity != null)
                {
                    _DbContext.Responses.Remove(entity);
                    await _DbContext.SaveChangesAsync(cancellationToken);
                    return Unit.Value;
                }
                else
                {
                    throw new ArgumentNullException($"Удаляемый ответ {request.Response_ID} не найдена в базе данных ", nameof(entity));
                }
            }
        }
    }
}
