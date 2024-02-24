using hefth.data.Model;
using MediatR;

namespace hefth.CQRS.Queries.ParticipantQueries
{
    public record ParticipantGetQuery : IRequest<List<Participant>>;
    
}
