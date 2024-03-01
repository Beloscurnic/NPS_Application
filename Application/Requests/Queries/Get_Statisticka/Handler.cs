using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Queries.Get_Statisticka
{
    public partial class Statisticka_Get
    {
        public class Handler : IRequestHandler<Query, View_Model_Statistica>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) { _DbContext = context; }
            Dictionary<int, InfoAnswert> dictionary;
            public async Task<View_Model_Statistica> Handle(Query request, CancellationToken cancellationToken)
            {
               // DateTime date = DateTime.MinValue;
                if (request.Data_End == null)
                {
                    request.Data_End = DateTime.Now;
                }
                var questionType = await _DbContext.Questions.Select(i => new
                {
                    QuestionID = i.QuestionID,
                    TypeQuestion = i.TypeQuestion,
                    Name_Question = i.Name_Question,
                    Questions_Variants = i.Questions_Variants.Select(u => new { u.Questions_VariantID, u.Name }).ToList()
                }).FirstOrDefaultAsync(i => i.QuestionID == request.QuestionID);

                //Func<Response, bool> dateFilter = (i) =>
                //{
                //    return (request.Data_Start == null || i.Data_Creat_Response >= request.Data_Start) &&
                //           (request.Data_End  == null || i.Data_Creat_Response <= request.Data_End) &&
                //           i.OprostnikID == request.Oprostnik_ID;
                //};

                var entity =await _DbContext.Responses
                    .Where(i=> (request.Data_Start != null ? i.Data_Creat_Response >= request.Data_Start : true) &&
                           (request.Data_End != null ? i.Data_Creat_Response <= request.Data_End : true) &&
                           i.OprostnikID == request.Oprostnik_ID)
                    .Select(i => new View_List_Response
                    {
                        Data_Creat_Response = i.Data_Creat_Response,
                        ResponseID = i.ResponseID,
                        Answer = i.Answers.Select(u => new Answer_DB
                        {
                            AnswerID = u.AnswerID,
                            Response_Question = ParseIntArray(u.Response_QuestionVariant_ID),
                            QuestionID = u.QuestionID,
                            Name_Question = u.Question.Name_Question,
                        }).FirstOrDefault(l => l.QuestionID == request.QuestionID),
                    })
                    .ToListAsync(cancellationToken);

                if (questionType.TypeQuestion == EnumCore.TypeQuestion.MultiChoose || questionType.TypeQuestion == EnumCore.TypeQuestion.Choose)
                {
                    if (questionType.Questions_Variants != null)
                    {
                        dictionary = questionType.Questions_Variants.ToDictionary(
                          id => id.Questions_VariantID,
                          id => new InfoAnswert { Count = 0, Name_QuestionVariant = id.Name });

                        foreach (var item in entity)
                        {
                            if (item.Answer == null)
                            {
                                continue;
                            }
                            foreach (int questionvariant_ID in item.Answer.Response_Question)
                            {
                                dictionary[questionvariant_ID].Count = ++dictionary[questionvariant_ID].Count;
                            }
                        }
                    }
                }
                else if (questionType.TypeQuestion == EnumCore.TypeQuestion.TrueFalse)
                {
                    dictionary = new Dictionary<int, InfoAnswert> { { 0, new InfoAnswert {Count=0, Name_QuestionVariant="false"}},
                                                                    { 1, new InfoAnswert {Count=0, Name_QuestionVariant="true" }}
                                                                                                                                  };
                    foreach (var item in entity)
                    {
                        if (item.Answer == null)
                        {
                            continue;
                        }
                        foreach (int questionvariant_ID in item.Answer.Response_Question)
                        {
                            ++dictionary[questionvariant_ID].Count;
                        }
                    }
                }
                else if (questionType.TypeQuestion == EnumCore.TypeQuestion.Question5)
                {
                    dictionary = CreateDictionaryFromEntity(entity, 5);

                }
                else if (questionType.TypeQuestion == EnumCore.TypeQuestion.Question10)
                {
                    dictionary = CreateDictionaryFromEntity(entity, 10);
                }

                return new View_Model_Statistica
                {
                    QuestionID = request.QuestionID,
                    Name_Question = questionType.Name_Question,
                    Questions_Variants = dictionary,
                    OprostnikID = request.Oprostnik_ID
                };
            }

            private Dictionary<int, InfoAnswert> CreateDictionaryFromEntity(IEnumerable<View_List_Response> entity, int scale)
            {
                var dictionary = new Dictionary<int, InfoAnswert>();

                for (int i = 1; i <= scale; i++)
                {
                    dictionary.Add(i, new InfoAnswert
                    {
                        Count = 0,
                        Name_QuestionVariant = i.ToString()
                    });
                }

                foreach (var item in entity)
                {
                    foreach (int questionvariant_ID in item.Answer.Response_Question)
                    {
                        ++dictionary[questionvariant_ID].Count;
                    }
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


            //static List<string> SplitJsonArray(string jsonArray)
            //{
            //    List<string> result = new List<string>();

            //    int startIndex = jsonArray.IndexOf('{');
            //    while (startIndex != -1)
            //    {
            //        int endIndex = jsonArray.IndexOf('}', startIndex);
            //        if (endIndex == -1)
            //        {
            //            throw new ArgumentException("Invalid JSON format: Missing closing brace '}'");
            //        }

            //        string item = jsonArray.Substring(startIndex, endIndex - startIndex + 1);
            //        result.Add(item);

            //        startIndex = jsonArray.IndexOf('{', endIndex);
            //    }

            //    return result;
            //}
        }
    }
}

