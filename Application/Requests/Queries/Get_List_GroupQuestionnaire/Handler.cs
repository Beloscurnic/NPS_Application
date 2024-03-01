using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Queries.Get_List_GroupQuestionnaire
{
    public partial class Get_List_GrupQuestion
    {
        public class Handler : IRequestHandler<Query, View_Model_List>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context)
            {
                _DbContext = context;
            }

            public async Task<View_Model_List> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.GroupQuestions.Select(u => new View_Model_GrupQuestionare
                {
                    ID = u.GroupQuestionnaireID,
                    Name = u.Name,
                    CompanyOID = u.CompanyOID,
                    LincenseID = (Guid)u.LincenseID,
                }).ToListAsync(cancellationToken);
                
                return new View_Model_List(entity);
            }
        }
    }
}