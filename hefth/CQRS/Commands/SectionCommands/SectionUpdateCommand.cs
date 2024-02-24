using hefth.data.DTO;
using hefth.data.Model;
using MediatR;

namespace hefth.CQRS.Commands.SectionCommands
{
    public record SectionUpdateCommand(SectionDto sectiondto,int id) : IRequest<Section>;
    
}
