using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_Question
{
    public partial class Question_Delet
    {
        public class Handler :IRequestHandler<Command>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) {  _DbContext = context; }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Questions.FindAsync(request.Question_ID, cancellationToken);

                if (entity != null)
                {
                    var questions_Variants = await _DbContext.Questions_Variants.Where(i => i.QuestionID == entity.QuestionID).ToListAsync(cancellationToken);
                    if (questions_Variants != null)
                    {
                       questions_Variants.Select(i =>
                        {
                            i.QuestionID = null;
                            i._Question = null;
                            return i;
                        });
                    }
                    var oprostnik_Modific = await _DbContext.Oprostniks.FirstOrDefaultAsync(i => i.OprostnikID == entity.OprostnikID, cancellationToken);
                    if (oprostnik_Modific != null)
                    {
                        oprostnik_Modific.DataModified_Oprostnik = DateTime.Now;
                    }
                    _DbContext.Questions.Remove(entity);
                    await _DbContext.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    throw new ArgumentNullException($"Удаляемый вопрос {request.Question_ID} не найдена в базе данных ", nameof(entity));
                }
                return Unit.Value;
            }
        }
    }
}