using hefth.CQRS.Commands.SectionCommands;
using hefth.data;
using hefth.data.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hefth.CQRS.Handlers.SectionHandler
{
    public class SectionUpdateHandler : IRequestHandler<SectionUpdateCommand, Section>
    {
        AppDbContext _db;

        public SectionUpdateHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Section> Handle(SectionUpdateCommand request, CancellationToken cancellationToken)
        {
            var section = await _db.Sections.SingleOrDefaultAsync(x => x.Id == request.id);

            var part = await _db.Participants.SingleOrDefaultAsync(x => x.Email ==
            request.sectiondto.ParticipantEmail);

            section.HefthFullDegree = request.sectiondto.HefthFullDegree;
            section.HefthPartDegree = request.sectiondto.HefthPartDegree;
            section.HefthNotes = request.sectiondto.HefthNotes;
            section.TaguidFullDegree = request.sectiondto.TaguidFullDegree;
            section.TaguidPartDegree = request.sectiondto.TaguidPartDegree;
            section.TaguidNotes = request.sectiondto.TaguidNotes;
            section.WaqfFullDegree = request.sectiondto.WaqfFullDegree;
            section.WaqfPartDegree = request.sectiondto.WaqfPartDegree;
            section.WaqfNotes = request.sectiondto.WaqfNotes;
            section.AzobaFullDegree = request.sectiondto.AzobaFullDegree;
            section.AzobaPartDegree = request.sectiondto.AzobaPartDegree;
            section.AzobaNotes = request.sectiondto.AzobaNotes;
            section.EnteqalFullDegree = request.sectiondto.EnteqalFullDegree;
            section.EnteqalPartDegree = request.sectiondto.EnteqalPartDegree;
            section.EnteqalNotes = request.sectiondto.EnteqalNotes;
            section.ParticipantId = part.Id;
            section.Participant = part;

            _db.SaveChanges();
            return await Task.FromResult(section);
        }
    }
}
