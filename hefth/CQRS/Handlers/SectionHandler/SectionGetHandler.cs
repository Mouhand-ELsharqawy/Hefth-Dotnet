using hefth.CQRS.Queries.SectionQueries;
using hefth.data;
using hefth.data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hefth.CQRS.Handlers.SectionHandler
{
    public class SectionGetHandler : IRequestHandler<SectionGetQuery, List<Section>>
    {
        AppDbContext _db;

        public SectionGetHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<Section>> Handle(SectionGetQuery request, CancellationToken cancellationToken)
        {
            var data = await _db.Sections
                .Include(x => x.Participant)
                .Include(y => y.User)
                .ToListAsync();


            return await Task.FromResult( 
                data.GroupBy(g => g.ParticipantId)
                .Select(group => group.OrderByDescending(item => item.Average).First())
                .Take(3)
                .ToList()
                );
        }
    }
}
