using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Queries.Get_GroupQuestionnaire
{
    public partial class GroupQuestionnaire_Get
    {
        public class Handler : IRequestHandler<Query, View_Model_GroupQuestionnaire>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext dbContext) { _DbContext = dbContext; }

            public async Task<View_Model_GroupQuestionnaire> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.GroupQuestions.Where(i => i.LincenseID == request.LincenseID).Select(i => new View_Model_GroupQuestionnaire(i.GroupQuestionnaireID, i.Name, i.CompanyOID, (Guid)i.LincenseID))
                    .FirstOrDefaultAsync(cancellationToken);

                return entity ?? throw new NullReferenceException("The value of 'entity?.ID' should not be null");
            }
        }
    }

}