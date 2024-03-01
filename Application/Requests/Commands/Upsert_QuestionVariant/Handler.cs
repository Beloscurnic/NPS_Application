using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Commands.Upsert_QuestionVariant
{
    public partial class QuestionVaraint_Upsert
    {
        public class Handler : IRequestHandler<CommandListQuestionVariant, ListViewResponseQuestionVariant>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) { _DbContext = context; }

            public async Task<ListViewResponseQuestionVariant> Handle(CommandListQuestionVariant request, CancellationToken cancellationToken)
            {
                if (request.QuestionVariant_Commands.Count > 0)
                {
                    var list_response = new ListViewResponseQuestionVariant();

                    foreach (var command in request.QuestionVariant_Commands)
                    {
                        if (command.Questions_VariantID == null)
                        {
                            var addQuestionVariant = new Questions_Variant();

                            int? key = await _DbContext.Questions_Variants.Where(i => i.QuestionID == request.QuestionID).Select(i => i.Key).OrderByDescending(i => i).FirstOrDefaultAsync();
                            addQuestionVariant.Key = ++key ?? 0;

                            addQuestionVariant.Name = command.Name;
                            addQuestionVariant.IsDeleted = false;
                            addQuestionVariant.QuestionID = request.QuestionID;

                            var oprostnikModific = await _DbContext.Oprostniks.FirstOrDefaultAsync(i=>i.OprostnikID == request.OprostnikID, cancellationToken);
                            if (oprostnikModific !=null)
                            {
                                oprostnikModific.DataModified_Oprostnik = DateTime.Now;
                            }

                            await _DbContext.Questions_Variants.AddAsync(addQuestionVariant, cancellationToken);
                            await _DbContext.SaveChangesAsync(cancellationToken);

                            var viewresponse = new View_ResponseQuestionVariant
                            {
                                Questions_VariantID = addQuestionVariant.Questions_VariantID,
                                Key = addQuestionVariant.Key,
                                IsDeleted = addQuestionVariant.IsDeleted,
                                Name = addQuestionVariant.Name,
                                QuestionID = addQuestionVariant.QuestionID
                            };
                            list_response.ResultsResponse.Add(viewresponse);
                        }
                        //else
                        //{
                        //    var put_entity = await _DbContext.Questions_Variants.Where(i => i.Questions_VariantID == command.Questions_VariantID).FirstOrDefaultAsync(cancellationToken);
                        //    if (put_entity != null)
                        //    {
                        //        put_entity.Name = command.Name;
                        //        put_entity.IsDeleted = command.IsDeleted ?? put_entity.IsDeleted;

                        //        if (command.Key != null)
                        //        {
                        //            var tempkey = put_entity.Key;
                        //            put_entity.Key = command.Key ?? 0;
                        //            var key = await _DbContext.Questions_Variants.Where(i => i.QuestionID == request.QuestionID && i.Key == command.Key).FirstOrDefaultAsync(cancellationToken);
                        //            if (key != null)
                        //            {
                        //                key.Key = tempkey;
                        //            }
                        //        }
                        //        var viewresponse = new View_ResponseQuestionVariant
                        //        {
                        //            Questions_VariantID = put_entity.Questions_VariantID,
                        //            Key = put_entity.Key,
                        //            IsDeleted = put_entity.IsDeleted,
                        //            Name = put_entity.Name,
                        //            QuestionID = put_entity.QuestionID
                        //        };
                        //        await _DbContext.SaveChangesAsync(cancellationToken);
                        //        list_response.ResultsResponse.Add(viewresponse);
                        //    }
                        //    else
                        //    {
                        //        throw new InvalidOperationException("Entity not found. Questions_Variants");
                        //    }
                        //}

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
