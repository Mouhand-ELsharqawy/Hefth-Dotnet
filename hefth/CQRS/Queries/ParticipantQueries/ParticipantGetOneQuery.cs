using hefth.data.Model;
using MediatR;

namespace hefth.CQRS.Queries.ParticipantQueries
{
    public record ParticipantGetOneQuery(int id) : IRequest<Participant>;
    
}
