using hefth.CQRS.Queries.ParticipantQueries;
using hefth.data;
using hefth.data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hefth.CQRS.Handlers.ParticipantHandler
{
    public class ParticipantGetHandler : IRequestHandler<ParticipantGetQuery, List<Participant>>
    {
        AppDbContext _db;

        public ParticipantGetHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<Participant>> Handle(ParticipantGetQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult( _db.Participants.ToList());
        }
    }
}
