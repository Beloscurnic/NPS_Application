using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_Oprostnik
{
    public partial class Oprostnik_Delet
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) { _DbContext = context; }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Oprostniks.FindAsync(request.ID_Oprostniks,cancellationToken);
              
                if (entity != null)
                {
                    var question = await _DbContext.Questions.Where(i => i.OprostnikID == entity.OprostnikID).FirstOrDefaultAsync(cancellationToken);
                    if (question != null)
                    {
                        question.OprostnikID = null;
                        question.Oprostnik = null;
                    }
                    _DbContext.Oprostniks.Remove(entity);
                    await _DbContext.SaveChangesAsync(cancellationToken);
                   
                }
                else
                {
                    throw new ArgumentNullException($"Удаляемый Опросник {request.ID_Oprostniks} не найдена в базе данных ", nameof(entity));
                }
                return Unit.Value;
            }
        }
    }
}
