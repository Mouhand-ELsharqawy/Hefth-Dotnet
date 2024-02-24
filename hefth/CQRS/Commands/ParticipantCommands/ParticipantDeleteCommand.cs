using hefth.data.Model;
using MediatR;

namespace hefth.CQRS.Commands.ParticipantCommands
{
    public record ParticipantDeleteCommand(int id) : IRequest<Participant>;
    
}
