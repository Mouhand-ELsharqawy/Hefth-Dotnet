using hefth.data.Model;
using MediatR;

namespace hefth.CQRS.Queries.SectionQueries
{
    public record SectionGetOneQuery(int id) : IRequest<Section>;
}
