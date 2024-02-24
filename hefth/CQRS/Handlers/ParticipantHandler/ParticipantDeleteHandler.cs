using hefth.CQRS.Commands.ParticipantCommands;
using hefth.data;
using hefth.data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hefth.CQRS.Handlers.ParticipantHandler
{
    public class ParticipantDeleteHandler : IRequestHandler<ParticipantDeleteCommand, Participant>
    {
        AppDbContext _db;
        public ParticipantDeleteHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Participant> Handle(ParticipantDeleteCommand request, CancellationToken cancellationToken)
        {
            var part = await _db.Participants.SingleOrDefaultAsync(x => x.Id == request.id);
                if(part != null)
            {
                _db.Participants.Remove(part);
                await _db.SaveChangesAsync();
                return part;
            }

            return null;
        }
    }
}
