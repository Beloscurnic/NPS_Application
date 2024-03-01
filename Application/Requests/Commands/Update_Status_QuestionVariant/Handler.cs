using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Commands.Update_Status_QuestionVariant
{
    public partial class QuestionVariant_Status_Update
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext dbContext)
            {
                _DbContext = dbContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Questions_Variants.FindAsync(request.QuestionVariant_ID, cancellationToken);
                if (entity != null)
                {
                    if (entity.IsDeleted)
                    {
                        entity.IsDeleted = false;
                    }
                    else
                    {
                        entity.IsDeleted = true;
                    }
                    var oprostnikmodific = await _DbContext.Oprostniks.FirstOrDefaultAsync(i => i.OprostnikID == request.Oprostnik_ID, cancellationToken);
                    if (oprostnikmodific != null)
                    {
                        oprostnikmodific.DataModified_Oprostnik = DateTime.Now;
                    }
                    await _DbContext.SaveChangesAsync(cancellationToken);
                    return Unit.Value;
                }
                else
                {
                    throw new ArgumentNullException($"Не был найдей вариант выборка с ID {request.QuestionVariant_ID} в вопросе c ID {request.Oprostnik_ID}", nameof(entity));
                }
            }
        }
    }
}
