using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Application.Requests.Commands.Add_Response
{
    public partial class Response_Add
    {
        public class Handler : IRequestHandler<Command, ViewCreatResponse>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) { _DbContext = context; }

            public async Task<ViewCreatResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                AsyncLocal<TransactionScope> transactionScopeLocal = new AsyncLocal<TransactionScope>();
                transactionScopeLocal.Value = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

                var view = new ViewCreatResponse();
                try
                {
                    var creatresponse = new Response
                    {
                        //   CompanyOID = request.CompanyOID,
                        OprostnikID = request.OprostnikID,
                        Data_Creat_Response = DateTime.Now,
                    };

                    await _DbContext.Responses.AddAsync(creatresponse);
                    await _DbContext.SaveChangesAsync(cancellationToken);

                    // view.CompanyOID = request.CompanyOID;
                    view.OprostnikID = request.OprostnikID;
                    view.Data_Creat_Response = creatresponse.Data_Creat_Response;
                    view.ResponseID = creatresponse.ResponseID;

                    var count_Question = await _DbContext.Questions.Where(i => i.OprostnikID == request.OprostnikID).CountAsync();
                   
                    if (request.Answers != null)
                    {
                        if (request.Answers.Count() == count_Question)
                        {
                            foreach (var answert in request.Answers)
                            {
                                var question = await _DbContext.Questions.Where(i => i.QuestionID == answert.QuestionID).Include(i=>i.Questions_Variants).FirstOrDefaultAsync(cancellationToken);
                                if ((question.TypeQuestion == EnumCore.TypeQuestion.Choose || question.TypeQuestion == EnumCore.TypeQuestion.MultiChoose) && question!=null)
                                {
                                    var list_exception = answert.Response_Question_ID.Except(question.Questions_Variants.Select(i => i.Questions_VariantID).ToList());
                                    if (list_exception.Count() != 0)
                                    {
                                        throw new ArgumentException($"Передан(ы) не существующий(ие) ID варианта(ы) ответа {string.Join(", ", answert.Response_Question_ID)} на вопрос {answert.QuestionID}");
                                    }
                                }
                                var creatAnswert = new Answer
                                {
                                 
                                    Response_QuestionVariant_ID = string.Join(", ", answert.Response_Question_ID),
                                    QuestionID = answert.QuestionID,
                                    ResponseID = creatresponse.ResponseID,
                                };

                                await _DbContext.Answers.AddAsync(creatAnswert);
                                view.Answers.Add(new ViewAnswertResponse
                                {
                                    AnswerID = creatAnswert.AnswerID,
                                    Response_Question = creatAnswert.Response_QuestionVariant_ID,
                                    ResponseID = creatAnswert.ResponseID,
                                    QuestionID = creatAnswert.QuestionID
                                });

                            }
                            await _DbContext.SaveChangesAsync(cancellationToken);
                        }
                        else
                        {
                            throw new Exception("Не соотвествие количества задаваемых вопросов с количеством ответов");
                        }
                    }
                    else
                    {
                        throw new ArgumentNullException($"Не удалось подсчитать количество вопрос в указаном опроснике {request.OprostnikID}", nameof(count_Question));
                    }
                    transactionScopeLocal.Value.Complete();
                }
                catch (Exception ex)
                {
                    
                    throw;
                }
                finally
                {
                    transactionScopeLocal.Value?.Dispose();
                }

                return view;
            }
        }
    }
}
