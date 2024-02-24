using hefth.CQRS.Queries.SectionQueries;
using hefth.data;
using hefth.data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hefth.CQRS.Handlers.SectionHandler
{
    public class SectionGetOneHandler : IRequestHandler<SectionGetOneQuery, Section>
    {
        AppDbContext _db;

        public SectionGetOneHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Section> Handle(SectionGetOneQuery request, CancellationToken cancellationToken)
        {
            var section = await _db.Sections
                .Include(x => x.Participant)
                .Include(y => y.User)
                .SingleOrDefaultAsync(x => x.Id == request.id);
            if(section == null)
            {
                return null;
            }

            return await Task.FromResult(section);
        }
    }
}
