using hefth.data.DTO;
using hefth.data.Model;
using MediatR;

namespace hefth.CQRS.Commands.ParticipantCommands
{
    public record ParticipantInsertCommand(ParticipantDto participantdto): IRequest<Participant>;
    
}
