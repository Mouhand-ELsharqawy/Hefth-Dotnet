using hefth.CQRS.Commands.ParticipantCommands;
using hefth.data;
using hefth.data.Model;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace hefth.CQRS.Handlers.ParticipantHandler
{
    public class ParticipantInsertHandler : IRequestHandler<ParticipantInsertCommand, Participant>
    {
        AppDbContext _db;

        public ParticipantInsertHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Participant> Handle(ParticipantInsertCommand request, CancellationToken cancellationToken)
        {
            var part = new Participant
            {
                FirstName = request.participantdto.FirstName,
                MiddleName = request.participantdto.MiddleName,
                LastName = request.participantdto.LastName, 
                Email = request.participantdto.Email,
                Phone = request.participantdto.Phone
            };

            await _db.Participants.AddAsync(part);
            _db.SaveChanges();
            return await Task.FromResult(part);
        }
    }
}
