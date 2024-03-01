using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Commands.Update_Status_Question
{
    public partial class Status_Question_Update
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) { _DbContext = context; }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Questions.FirstOrDefaultAsync(i => i.QuestionID == request.QuestionID, cancellationToken);
                if (entity != null)
                {
                    var oprostnik_modofic = await _DbContext.Oprostniks.FirstOrDefaultAsync(i => i.OprostnikID == entity.OprostnikID, cancellationToken);
                    if (oprostnik_modofic != null)
                    {
                        oprostnik_modofic.DataModified_Oprostnik = DateTime.Now;
                    }
                    entity.IsDeleted = request.Status_Question;
                    await _DbContext.SaveChangesAsync(cancellationToken);
                    return Unit.Value;
                }
                else
                {
                    throw new ArgumentNullException($"Не был найдей вопрос с ID {request.QuestionID} в базе данных ", nameof(entity));
                }
            }
        }
    }
}
