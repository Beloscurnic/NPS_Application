using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Answer
{
    public partial class Answer_Get
    {
        public class Handler :IRequestHandler<Query, ViewModelAnswert>

        {
            private readonly I_DbContext _DbContext;
            public Handler(I_DbContext context) { _DbContext = context; }

            public async Task<ViewModelAnswert> Handle(Query request, CancellationToken cancellationToken)
            {
               var entity =await _DbContext.Answers.Select(i=> new ViewModelAnswert
               {
                   AnswerID = i.AnswerID,
                 //  TypeQuestion = i.TypeQuestion,
                   Response_Question = i.Response_QuestionVariant_ID,
                   ResponseID = i.ResponseID,
                   QuestionID = i.QuestionID
               }).FirstOrDefaultAsync(i=>i.AnswerID ==request.AnswertID, cancellationToken);
                return entity;
            }
        }
    }
}
