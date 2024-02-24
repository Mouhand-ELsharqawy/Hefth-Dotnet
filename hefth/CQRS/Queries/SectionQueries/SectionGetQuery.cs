using hefth.data.Model;
using MediatR;

namespace hefth.CQRS.Queries.SectionQueries
{
    public record SectionGetQuery : IRequest<List<Section>>;


}
