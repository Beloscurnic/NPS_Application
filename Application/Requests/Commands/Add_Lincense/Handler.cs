using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Requests.Commands.Add_Lincense
{
    public partial class Creat_Lincense
    {
        public class Handler : IRequestHandler<Command, View_Response>
        {
            private readonly I_DbContext _dbContext;
            public Handler(I_DbContext dbContext) =>
            _dbContext = dbContext;

            public async Task<View_Response> Handle(Command request, CancellationToken cancellationToken)
            {

                var entity_Lincense = new Lincense
                {
                    LincenseID = Guid.NewGuid(),
                    CompanyOID = request.CompanyOID,
                    ActivationCode = request.ActivationCode,
                    Lincense_Activated = request.Lincense_Activated,
                    License_Status = request.License_Status,
                    Device_Name = request.Device_Name
                };

                await _dbContext.Lincenses.AddAsync(entity_Lincense);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return new View_Response(entity_Lincense);

            }
        }
    }
}