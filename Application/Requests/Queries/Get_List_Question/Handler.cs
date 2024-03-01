using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Queries.Get_List_Question
{
    public partial class List_Question_Get
    {
        public class Handler : IRequestHandler<Query, List_View_Model_Question>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext dbContext) { _DbContext = dbContext; }

            public async Task<List_View_Model_Question> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Questions.Where(i => i.OprostnikID == request.OprostnikID).Select(i => new View_Model_Question
                {
                    QuestionID = i.QuestionID,
                    Key = i.Key,
                    isDeleted = i.IsDeleted,
                    //Questions_Variants = i.Questions_Variants,
                    TypeQuestion = i.TypeQuestion,
                    Name_Question = i.Name_Question,
                    OprostnikID = i.OprostnikID
                }).OrderBy(i=>i.Key).ToListAsync(cancellationToken);

                var response = new List_View_Model_Question
                {
                    View_List_Model_Question = entity
                };
                return response;
            }

        }
    }
}

