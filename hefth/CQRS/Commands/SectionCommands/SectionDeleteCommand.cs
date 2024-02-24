using hefth.data.Model;
using MediatR;

namespace hefth.CQRS.Commands.SectionCommands
{
    public record SectionDeleteCommand(int id) : IRequest<Section>;
    
}
