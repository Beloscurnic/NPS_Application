using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Queries.Get_QuestionVariant
{

    public partial class QuestionVariant_Get
    {
        public class Handler : IRequestHandler<Query, ViewModelQuestionVariant>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) { _DbContext = context; }

            public async Task<ViewModelQuestionVariant> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Questions_Variants.Where(i => i.Questions_VariantID == request.QuestionVariant_ID).Select(i => new ViewModelQuestionVariant
                {
                    Questions_VariantID = i.Questions_VariantID,
                    Key = i.Key,
                    IsDeleted = i.IsDeleted,
                    Name = i.Name,
                    QuestionID = i.QuestionID
                }).FirstOrDefaultAsync(cancellationToken);

                if (entity != null)
                {
                    return entity;
                }
                else
                {
                    throw new InvalidOperationException("Entity not found.");
                }
            }
        }
    }
}
