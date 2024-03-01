using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Commands.Upsert_GroupQuestionnaire
{
    public partial class GroupQuestionnaire_Add
    {
        public class Handler : IRequestHandler<Command, View_Response_GroupQuestionnaire>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context)
            {
                _DbContext = context;
            }
            public async Task<View_Response_GroupQuestionnaire> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.GroupQuestionnaireID == null)
                {
                    var entityGroupQuestionnaire = new GroupQuestionnaire();
                    if (request.LincenseID != null)
                    {
                        var entityLincenses = await _DbContext.Lincenses
                            .FirstOrDefaultAsync(i => i.LincenseID == request.LincenseID, cancellationToken);

                        if (entityLincenses != null)
                        {
                            entityGroupQuestionnaire.LincenseID = entityLincenses.LincenseID;
                            entityGroupQuestionnaire.CompanyOID = entityLincenses.CompanyOID;
                            entityGroupQuestionnaire.Name = request.Name;
                        }
                        else
                        {
                            throw new ArgumentNullException($"Переданая лицензии {request.LincenseID} нет в базе данных", nameof(request.LincenseID));
                        }
                    }
                    else
                    {
                        entityGroupQuestionnaire.Name = request.Name;
                    }
                    await _DbContext.GroupQuestions.AddAsync(entityGroupQuestionnaire);
                    await _DbContext.SaveChangesAsync(cancellationToken);

                    return new View_Response_GroupQuestionnaire(entityGroupQuestionnaire.GroupQuestionnaireID, entityGroupQuestionnaire.Name, entityGroupQuestionnaire.CompanyOID, entityGroupQuestionnaire.LincenseID);
                }
                else
                {
                    var edit_entityGroupQuestionnaire = await _DbContext.GroupQuestions.Where(i => i.GroupQuestionnaireID == request.GroupQuestionnaireID).FirstOrDefaultAsync(cancellationToken);
                    if (edit_entityGroupQuestionnaire != null)
                    {
                        if (request.LincenseID != null)
                        {
                            var entityLincenses = await _DbContext.Lincenses.Where(i => i.LincenseID == request.LincenseID).FirstOrDefaultAsync(cancellationToken);
                            if (entityLincenses != null)
                            {
                                edit_entityGroupQuestionnaire.Lincense = entityLincenses;
                                edit_entityGroupQuestionnaire.CompanyOID = entityLincenses.CompanyOID;
                                edit_entityGroupQuestionnaire.LincenseID = request.LincenseID;
                            }
                            else if (entityLincenses == null)
                            {
                                throw new ArgumentNullException($"Переданая лицензии {request.LincenseID} нет в базе данных", nameof(request.LincenseID));
                            }
                            else if (await _DbContext.GroupQuestions.FirstOrDefaultAsync(i => i.LincenseID == request.LincenseID) != null)
                            {
                                throw new ArgumentNullException($"В базе уже имеется группа с стакой ID лицензией {request.GroupQuestionnaireID}.", nameof(request.GroupQuestionnaireID));
                            }
                        }
                        if (request.Name != null)
                        {
                            edit_entityGroupQuestionnaire.Name = request.Name;
                        }
                    }
                    else
                    {
                        throw new ArgumentNullException($"Переданый ID группы {request.GroupQuestionnaireID} нет в базе данных", nameof(edit_entityGroupQuestionnaire));
                    }
                    await _DbContext.SaveChangesAsync(cancellationToken);
                    return new View_Response_GroupQuestionnaire(edit_entityGroupQuestionnaire.GroupQuestionnaireID, edit_entityGroupQuestionnaire.Name, edit_entityGroupQuestionnaire.CompanyOID, edit_entityGroupQuestionnaire.LincenseID);
                }
            }
        }
    }
}