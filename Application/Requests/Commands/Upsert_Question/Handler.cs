using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Commands.Upsert_Question
{
    public partial class Question_Upsert
    {
        public class Handler : IRequestHandler<Command_List, List_ViewResponseQuestion>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) { _DbContext = context; }

            public async Task<List_ViewResponseQuestion> Handle(Command_List request, CancellationToken cancellationToken)
            {

                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                if (request.Commands == null || !request.Commands.Any())
                {
                    throw new ArgumentException("Command_List must contain at least one command", nameof(request.Commands));
                }

                if (request.Commands.Count > 0)
                {
                    var list_response = new List_ViewResponseQuestion();

                    foreach (var command in request.Commands)
                    {
                        int? last_key = await _DbContext.Questions.Where(i => i.OprostnikID == request.OprostnikID).Select(i => i.Key).OrderByDescending(i => i).FirstOrDefaultAsync();
                        if (command.QuestionID == null)
                        {
                            var addQuestion = new Question();

                            if (!command.Insert_before || command.Key == null)
                            {
                                addQuestion.Key = ++last_key ?? 0;
                            }
                            else if (command.Key != null && command.Insert_before)
                            {
                                var replacedItems = await _DbContext.Questions
                                    .Select(i => (i.Key > command.Key) ? i.Key + 1 : i.Key)
                                    .ToListAsync(cancellationToken);
                                addQuestion.Key = ++command.Key ?? 0;

                            }

                            addQuestion.IsDeleted = EnumCore.Status_Question.New;
                            addQuestion.Name_Question = command.Name_Question;
                            addQuestion.TypeQuestion = command.TypeQuestion;
                            addQuestion.OprostnikID = request.OprostnikID;

                            var oprostink_Modific = await _DbContext.Oprostniks.FirstOrDefaultAsync(i => i.OprostnikID == request.OprostnikID, cancellationToken);
                            if (oprostink_Modific != null)
                            {
                                oprostink_Modific.DataModified_Oprostnik = DateTime.Now;
                            }
                            await _DbContext.Questions.AddAsync(addQuestion);
                            await _DbContext.SaveChangesAsync(cancellationToken);

                            var viewresponse = new ViewResponseQuestion
                            {
                                QuestionID = addQuestion?.QuestionID,
                                TypeQuestion = addQuestion.TypeQuestion,
                                Name_Question = addQuestion?.Name_Question,
                                Key = addQuestion.Key,
                                OprostnikID = addQuestion?.OprostnikID
                            };
                            list_response.List_Response.Add(viewresponse);
                        }
                        else
                        {
                            var put_entity = await _DbContext.Questions.Where(i => i.QuestionID == command.QuestionID).FirstOrDefaultAsync(cancellationToken);
                            if (put_entity != null)
                            {
                                if (command.Name_Question != null)
                                    put_entity.Name_Question = command.Name_Question;

                                if (command.Key != null)
                                {
                                    if (await _DbContext.Questions.FirstOrDefaultAsync(i => i.Key == command.Key && i.OprostnikID == request.OprostnikID)==null)
                                    {
                                        throw new Exception($"Такого ключа {command.Key} нет в базе данных");
                                    }
                                    if (!command.Insert_before)
                                    {
                                        var tempkey = put_entity.Key;
                                        put_entity.Key = command.Key ?? 0;
                                        var keySWAP = await _DbContext.Questions.Where(i => i.OprostnikID == request.OprostnikID && i.Key == command.Key).FirstOrDefaultAsync(cancellationToken);
                                        if (keySWAP != null)
                                        {
                                            keySWAP.Key = tempkey;
                                        }
                                    }
                                    else if (command.Insert_before)
                                    {
                                        int? upperKey, lowerKey;
                                        if (put_entity.Key < command.Key)
                                        {
                                            upperKey = ++command.Key;
                                            lowerKey = put_entity.Key;

                                            await _DbContext.Questions
                                                .Where(i => i.Key > lowerKey && i.Key <= upperKey)
                                                .ForEachAsync(i => --i.Key);
                                            put_entity.Key = upperKey ?? 0;
                                        }
                                        else
                                        {
                                            lowerKey = ++command.Key;
                                            upperKey = put_entity.Key;

                                            await _DbContext.Questions
                                                  .Where(i => i.Key >= lowerKey && i.Key < upperKey)
                                                  .ForEachAsync(i => ++i.Key);
                                            put_entity.Key = lowerKey ?? 0;
                                        }
                                    }
                                }

                                var viewresponse = new ViewResponseQuestion
                                {
                                    QuestionID = put_entity?.QuestionID,
                                    TypeQuestion = put_entity.TypeQuestion,
                                    Name_Question = put_entity?.Name_Question,
                                    OprostnikID = put_entity?.OprostnikID,
                                    Key = put_entity.Key,
                                };

                                var oprostink_Modific = await _DbContext.Oprostniks.FirstOrDefaultAsync(i => i.OprostnikID == request.OprostnikID, cancellationToken);
                                if (oprostink_Modific != null)
                                {
                                    oprostink_Modific.DataModified_Oprostnik = DateTime.Now;
                                }

                                await _DbContext.SaveChangesAsync(cancellationToken);
                                list_response.List_Response.Add(viewresponse);
                            }
                            else
                            {
                                throw new InvalidOperationException("Entity not found. Questions_Variants");
                            }
                        }
                    }
                    return list_response;
                }
                else
                {
                    throw new InvalidOperationException("Entity not found. Command_List ");
                }
            }
        }
    }
}
