using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_Answert
{
    public partial class Answert_Delet
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) { _DbContext = context; }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Answers.FirstOrDefaultAsync(i=>i.AnswerID ==request.AnswertId);
                if (entity != null) 
                {
                    _DbContext.Answers.Remove(entity);
                    await _DbContext.SaveChangesAsync(cancellationToken);
                    return Unit.Value;
                }
                else
                {
                    throw new ArgumentNullException($"Удаляемая ответ {request.AnswertId} не найдена в базе данных ", nameof(entity));
                }
            }
        }
    }
}
