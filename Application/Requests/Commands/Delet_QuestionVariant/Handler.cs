using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_QuestionVariant
{
    public partial class QuestionVariant_Delet
    {
        public class Handler :IRequestHandler<Command>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext dbContext)
            {
                _DbContext = dbContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Questions_Variants.FirstOrDefaultAsync(i=>i.Questions_VariantID ==request.QuestionVariantID,cancellationToken);
                if (entity != null)
                {
                    _DbContext.Questions_Variants.Remove(entity);
                    var oprostnikModific = await _DbContext.Oprostniks.FirstOrDefaultAsync(i => i.OprostnikID == request.OprostnikID, cancellationToken);
                    if (oprostnikModific != null)
                    {
                        oprostnikModific.DataModified_Oprostnik = DateTime.Now;
                    }
                    await _DbContext.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    throw new ArgumentNullException($"Удаляемый вариант выбор {request.QuestionVariantID} в вопросе не найдена в базе данных ", nameof(entity));
                }
                return Unit.Value;
            }
        }
    }
}
