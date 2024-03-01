using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Commands.Delet_Lincense
{
    public partial class Lincense_Delet
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly I_DbContext _dbContext;
            public Handler(I_DbContext dbContext) =>
            _dbContext = dbContext;

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entityToDelete =await _dbContext.Lincenses.Where(i=>i.LincenseID == request.ID).FirstOrDefaultAsync(cancellationToken);

                if (entityToDelete != null)
                {
                    var group =await _dbContext.GroupQuestions.Where(i=>i.LincenseID == entityToDelete.LincenseID).FirstOrDefaultAsync(cancellationToken);
                    if (group != null)
                    {
                        group.Lincense = null;
                        group.LincenseID = null;
                    }
                    _dbContext.Lincenses.Remove(entityToDelete);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    throw new ArgumentNullException($"Удаляемая лицензия {request.ID} не найдена в базе данных ", nameof(entityToDelete)) ;
                }
                return Unit.Value;
            }
        }
    }
}

