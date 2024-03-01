using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Queries.Get_List_Statisticka
{
    public partial class ListStatistickaGet
    {
        public class Handler : IRequestHandler<Query, ViewModelList_Statistica>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) { _DbContext = context; }
            Dictionary<int, Info_Answert> dictionary;
            public async Task<ViewModelList_Statistica> Handle(Query request, CancellationToken cancellationToken)
            {
                if (request.Data_End == null)
                {
                    request.Data_End = DateTime.Now;
                }

                var questionType = await _DbContext.Questions.Where(i => i.OprostnikID == request.Oprostnik_ID).Select(i => new
                {
                    QuestioId = i.QuestionID,
                    TypeQuestion = i.TypeQuestion,
                    Name_Question = i.Name_Question,
                    InfoAnswerts = i.Questions_Variants.Select(u => new Answert_List
                    {
                        IDAnswert = u.Questions_VariantID,
                        Count = 0,
                        Name = u.Name
                    }).ToList()
                }).ToDictionaryAsync(
                          id => id.QuestioId,
                          id => new QuestionInfo
                          {
                              TypeQuestion = id.TypeQuestion,
                              Name_Question = id.Name_Question,
                              Info_ListAnswerts = id.InfoAnswerts
                          }, cancellationToken);

                foreach (var question in questionType)
                {
                    if (question.Value.TypeQuestion == EnumCore.TypeQuestion.Choose || question.Value.TypeQuestion == EnumCore.TypeQuestion.MultiChoose)
                        question.Value.Info_DictionaryAnswerts = question.Value.Info_ListAnswerts.ToDictionary(id => id.IDAnswert, id => new Answert_Dictionary { Count = id.Count, Name = id.Name });
                    if (question.Value.TypeQuestion == EnumCore.TypeQuestion.Question5)
                    {
                        question.Value.Info_DictionaryAnswerts = CreateDictionaryFromEntity(question.Value, 5);
                    }
                    if (question.Value.TypeQuestion == EnumCore.TypeQuestion.Question10)
                    {
                        question.Value.Info_DictionaryAnswerts = CreateDictionaryFromEntity(question.Value, 10);
                    }
                    if (question.Value.TypeQuestion == EnumCore.TypeQuestion.TrueFalse)
                    {
                        question.Value.Info_DictionaryAnswerts = new Dictionary<int, Answert_Dictionary> { { 0, new Answert_Dictionary {Count=0, Name="false"}},
                                                                    { 1, new Answert_Dictionary {Count=0, Name="true" }}};
                    }
                }

                foreach (var question in questionType)
                {
                    question.Value.Info_ListAnswerts = null;
                }

                var entity = await _DbContext.Responses.Where(i => (request.Data_Start != null ? i.Data_Creat_Response >= request.Data_Start : true) &&
            (request.Data_End != null ? i.Data_Creat_Response <= request.Data_End : true))
                .Select(i => new View_List_Response
                {
                    Data_Creat_Response = i.Data_Creat_Response,
                    ResponseID = i.ResponseID,
                    Answer_List = i.Answers.Select(u => new Answer_DB
                    {
                        AnswerID = u.AnswerID,
                        Response_Question = ParseIntArray(u.Response_QuestionVariant_ID),
                        QuestionID = u.QuestionID,
                        Name_Question = u.Question.Name_Question,
                    }).ToList()
                }).ToListAsync(cancellationToken);

                entity.ForEach(x =>
                {
                    x.Question_Dictionary = x.Answer_List.ToDictionary(
                    id => id.QuestionID,
                    id => new Answer_DB
                    {
                        AnswerID = id.AnswerID,
                        Response_Question = id.Response_Question,
                        QuestionID = id.QuestionID,
                        Name_Question = id.Name_Question
                    });
                    x.Answer_List = null;
                });

                foreach (var response in entity)
                {
                    foreach (var answert in response.Question_Dictionary)
                    {
                        foreach (var responseQuestion in answert.Value.Response_Question)
                        {
                            if (questionType.ContainsKey(answert.Key) && questionType[answert.Key].Info_DictionaryAnswerts.ContainsKey(responseQuestion))
                            {
                                ++questionType[answert.Key].Info_DictionaryAnswerts[responseQuestion].Count;
                            }

                        }
                    }
                }
                return new ViewModelList_Statistica { Questions_Variants = questionType };

            }
            private Dictionary<int, Answert_Dictionary> CreateDictionaryFromEntity(QuestionInfo entity, int scale)
            {
                var dictionary = new Dictionary<int, Answert_Dictionary>();

                for (int i = 1; i <= scale; i++)
                {
                    dictionary.Add(i, new Answert_Dictionary
                    {
                        Count = 0,
                        Name = i.ToString()
                    });
                }
                return dictionary;
            }

            static int[] ParseIntArray(string input)
            {
                if (string.IsNullOrEmpty(input))
                {
                    return new int[0];
                }

                string[] parts = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                int[] numbers = new int[parts.Length];
                for (int i = 0; i < parts.Length; i++)
                {
                    if (int.TryParse(parts[i], out int number))
                    {
                        numbers[i] = number;
                    }
                    else
                    {
                        throw new FormatException($"Неверный формат числа: {parts[i]}");
                    }
                }
                return numbers;
            }


        }
    }
}


