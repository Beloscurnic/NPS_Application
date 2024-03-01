using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Commands.Upsert_Oprostnik
{
    public partial class OprostnikUpsert
    {
        public class Handler : IRequestHandler<Command, View_Response_Oprostn>
        {

            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) { _DbContext = context; }

            public async Task<View_Response_Oprostn> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = new Oprostnik();
                if (request.OprostnikID == null)
                {
                    entity.DataCreat_Oprostnik = DateTime.Now;
                    if (request.GroupQuestionnaireID != null)
                    {
                        if( _DbContext.GroupQuestions.FirstOrDefaultAsync(i=>i.GroupQuestionnaireID == request.GroupQuestionnaireID)== null)
                        {
                            throw new ArgumentNullException($"Искомая группа с ID {request.GroupQuestionnaireID} не найдена в базе данных", nameof(request.GroupQuestionnaireID));
                        } else if ( _DbContext.Oprostniks.FirstOrDefaultAsync(i=>i.GroupQuestionnaireID == request.GroupQuestionnaireID) !=null)
                        {
                            throw new ArgumentNullException($"В базе уже имеется опросник с стаким ID группы {request.GroupQuestionnaireID}.", nameof(request.GroupQuestionnaireID));
                        }
                        entity.GroupQuestionnaireID = request.GroupQuestionnaireID;
                    }
                    if (request.DateRedaction != null)
                    {
                        entity.DataModified_Oprostnik = request.DateRedaction;
                    }
                    await _DbContext.Oprostniks.AddAsync(entity);
                    await _DbContext.SaveChangesAsync(cancellationToken);

                    return new View_Response_Oprostn
                    {
                        OprostnikID = entity.OprostnikID,
                        DataCreat_Oprostnik = entity.DataCreat_Oprostnik,
                        DataModified_Oprostnik = entity.DataModified_Oprostnik,
                        GroupQuestionnaireID = entity.GroupQuestionnaireID
                    };
                }
                else
                {
                    var edit_entity = await _DbContext.Oprostniks.Where(i => i.OprostnikID == request.OprostnikID).FirstOrDefaultAsync(cancellationToken);
                    if (edit_entity == null)
                    {
                        throw new ArgumentNullException($"Не был найдей опросник с ID {request.OprostnikID} в базе данных ", nameof(edit_entity));
                    }
                    if (request.GroupQuestionnaireID != null)
                    {
                        if (_DbContext.GroupQuestions.FirstOrDefaultAsync(i => i.GroupQuestionnaireID == request.GroupQuestionnaireID) == null)
                        {
                            throw new ArgumentNullException($"Искомая группа с ID {request.GroupQuestionnaireID} не найдена в базе данных", nameof(request.GroupQuestionnaireID));
                        }
                        else if (_DbContext.Oprostniks.FirstOrDefaultAsync(i => i.GroupQuestionnaireID == request.GroupQuestionnaireID) != null)
                        {
                            throw new ArgumentNullException($"В базе уже имеется опросник с стаким ID группы {request.GroupQuestionnaireID}.", nameof(request.GroupQuestionnaireID));
                        }
                        edit_entity.GroupQuestionnaireID = request.GroupQuestionnaireID;
                    }
                    if (request.DateRedaction != null)
                    {
                        edit_entity.DataModified_Oprostnik = request.DateRedaction;
                    }
                    await _DbContext.Oprostniks.AddAsync(entity);
                    await _DbContext.SaveChangesAsync(cancellationToken);

                    return new View_Response_Oprostn
                    {
                        OprostnikID = edit_entity.OprostnikID,
                        DataCreat_Oprostnik = edit_entity.DataCreat_Oprostnik,
                        DataModified_Oprostnik = edit_entity.DataModified_Oprostnik,
                        GroupQuestionnaireID = edit_entity.GroupQuestionnaireID
                    };
                }
            }
        }

    }
}
