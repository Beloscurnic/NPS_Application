using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_GroupQuestionnaire
{
    public partial class GroupQuestionnaire_Delet
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext dbContext) { _DbContext = dbContext; }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entityToDelete = await _DbContext.GroupQuestions.FindAsync(request.ID_GroupQuestionnaire, cancellationToken);

                if (entityToDelete != null)
                {
                    var oprostnik =await _DbContext.Oprostniks.FirstOrDefaultAsync(i => i.GroupQuestionnaireID == entityToDelete.GroupQuestionnaireID, cancellationToken);
                    if(oprostnik != null)
                    {
                        oprostnik.Group_Questionnaire = null;
                        oprostnik.GroupQuestionnaireID = null;
                    }
                    _DbContext.GroupQuestions.Remove(entityToDelete);
                    await _DbContext.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    throw new ArgumentNullException($"Удаляемая группа {request.ID_GroupQuestionnaire} не найдена в базе данных ", nameof(entityToDelete));
                }
                return Unit.Value;
            }
        }
    }
}