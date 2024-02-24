using hefth.CQRS.Queries.ParticipantQueries;
using hefth.data;
using hefth.data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hefth.CQRS.Handlers.ParticipantHandler
{
    public class ParticipantGetOneHandler : IRequestHandler<ParticipantGetOneQuery, Participant>
    {
        AppDbContext _db;

        public ParticipantGetOneHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Participant> Handle(ParticipantGetOneQuery request, CancellationToken cancellationToken)
        {
            var part = await _db.Participants.SingleOrDefaultAsync(x => x.Id == request.id);
            if (part == null)
            {
                return null;
            }
            return await Task.FromResult(part);
        }
    }
}
