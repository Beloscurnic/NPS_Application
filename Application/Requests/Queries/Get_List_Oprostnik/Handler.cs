using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Requests.Queries.Get_List_Oprostnik
{
    public partial class List_Oprostnik_Get
    {
        public class Handler: IRequestHandler<Query, List_View_Model_Oprostnik>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext dbContext)
            {
                _DbContext = dbContext;
            }

            public async Task<List_View_Model_Oprostnik> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Oprostniks.Select(i => new View_Model_Oprostnik
                {
                    OprostnikID = i.OprostnikID,
                    DataCreat_Oprostnik = i.DataCreat_Oprostnik,
                    DataModified_Oprostnik = i.DataModified_Oprostnik,
                    GroupQuestionnaireID = i.GroupQuestionnaireID
                }).ToListAsync(cancellationToken);
                return new List_View_Model_Oprostnik { List_View_Models_Oprostnik = entity };
            }
        }
    }
}
