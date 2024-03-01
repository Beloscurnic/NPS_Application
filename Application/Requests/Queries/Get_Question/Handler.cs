using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Queries.Get_Question
{
    public partial class Question_Get
    {
        public class Handler : IRequestHandler<Query, ViewModelQuestion>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) { _DbContext = context; }

            public async Task<ViewModelQuestion> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var entity = await _DbContext.Questions
                        .Where(i => i.QuestionID == request.Question_ID)
                        .Include(i => i.Questions_Variants)
                        .Select(i => new ViewModelQuestion
                        {
                            QuestionID = i.QuestionID,
                            Key = i.Key,
                            isDeleted = i.IsDeleted,
                            TypeQuestion = i.TypeQuestion,
                            Name_Question = i.Name_Question,
                            Questions_Variants =  i.Questions_Variants.ToList(),
                            OprostnikID = i.OprostnikID
                        })
                        .FirstOrDefaultAsync(cancellationToken);
                    if (entity == null)
                    {
                        throw new InvalidOperationException("Entity not found.");
                    }

                    return entity;
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while processing the request.", ex);
                }
            }
        }
    }
}
