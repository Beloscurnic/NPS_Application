using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Queries.Get_List_QuestionVariant
{
    public partial class QuestionVariant_Get_List
    {
        public class Handler : IRequestHandler<Query, List_ViewModelQuestionVariant>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) {  _DbContext = context; }

            public async Task<List_ViewModelQuestionVariant> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Questions_Variants.Where(i=>i.QuestionID==request.QuestionID).Select(i=> new View_ModelQuestionVariant
                {
                    Questions_VariantID = i.Questions_VariantID,
                    Key = i.Key,
                    IsDeleted = i.IsDeleted,
                    Name = i.Name,
                    QuestionID = i.QuestionID
                }).OrderByDescending(i => i.Key).ToListAsync(cancellationToken);
                if (entity != null)
                {
                    return new List_ViewModelQuestionVariant { ListModelQuestionVariant = entity };
                }
                else
                {
                    throw new InvalidOperationException("Entity not found.");
                }
            }
        }

    }
}
