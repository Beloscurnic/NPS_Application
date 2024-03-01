using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Response
{
    public partial class Response_Get
    {
        public class Handler:IRequestHandler<Query, ViewModelResponse>
        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) { _DbContext = context; }

            public async Task<ViewModelResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _DbContext.Responses.Where(i => i.ResponseID == request.Response_ID)
                     .Select(i => new ViewModelResponse
                     {
                         ResponseID = i.ResponseID,
                         CompanyOID = i.CompanyOID,
                         Data_Creat_Response = i.Data_Creat_Response,
                         Answers = i.Answers.Select(iAnswer => new Answer_Model
                         {
                             AnswerID = iAnswer.AnswerID,
                          //   TypeQuestion = iAnswer.TypeQuestion,
                             Response_Question = iAnswer.Response_QuestionVariant_ID,
                             QuestionID = iAnswer.QuestionID
                         }).ToList(),
                         OprostnikID = i.OprostnikID
                     })
                     .FirstOrDefaultAsync(cancellationToken);
                if (entity !=null)
                {
                    return entity;
                }
                else throw new ArgumentNullException(nameof(entity));
            }
        }
    }
}
