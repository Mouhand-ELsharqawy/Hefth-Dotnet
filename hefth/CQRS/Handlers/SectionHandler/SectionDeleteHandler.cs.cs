using hefth.CQRS.Commands.SectionCommands;
using hefth.data;
using hefth.data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hefth.CQRS.Handlers.SectionHandler
{
    public class SectionDeleteHandler : IRequestHandler<SectionDeleteCommand, Section>
    {
        AppDbContext _db;

        public SectionDeleteHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Section> Handle(SectionDeleteCommand request, CancellationToken cancellationToken)
        {
            var section = await _db.Sections.SingleOrDefaultAsync(x => x.Id == request.id);

            if (section == null)
            {
                return null;
            }

            _db.Sections.Remove(section);

            await _db.SaveChangesAsync();

            return await Task.FromResult(section);
        }
    }
}
