using hefth.CQRS.Commands.ParticipantCommands;
using hefth.data;
using hefth.data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hefth.CQRS.Handlers.ParticipantHandler
{
    public class ParticipantUpdateHandler : IRequestHandler<ParticipantUpdateCommand, Participant>
    {
        AppDbContext _db;

        public ParticipantUpdateHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Participant> Handle(ParticipantUpdateCommand request, CancellationToken cancellationToken)
        {
            var participant = await _db.Participants.SingleOrDefaultAsync(x => x.Id == request.id);

            if (participant == null)
            {
                return null;
            }



            participant.FirstName = request.participantdto.FirstName;
            participant.MiddleName = request.participantdto.MiddleName;
            participant.LastName = request.participantdto.LastName;
            participant.Email = request.participantdto.Email;
            participant.Phone = request.participantdto.Phone;

            _db.SaveChanges();

            return await Task.FromResult(participant);
            
        }
    }
}
