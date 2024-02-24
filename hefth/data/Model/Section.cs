using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hefth.data.Model
{
    [Index(nameof(ParticipantId), IsUnique = true)]
    public class Section
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double HefthFullDegree { get; set; }
        [Required]
        public double HefthPartDegree { get; set; }
        public string? HefthNotes { get; set; }

        
        [Required]
        public double TaguidFullDegree { get; set; }
        [Required]
        public double TaguidPartDegree { get; set; }
        public string? TaguidNotes { get; set; }

        
        [Required]
        public double WaqfFullDegree { get; set; }
        [Required]
        public double WaqfPartDegree { get; set; }
        public string? WaqfNotes { get; set; }

     
        [Required]
        public double AzobaFullDegree { get; set; }
        [Required]
        public double AzobaPartDegree { get; set; }
        public string? AzobaNotes { get; set; }

        [Required]
        public double EnteqalFullDegree { get; set; }
        [Required]
        public double EnteqalPartDegree { get; set; }
        public string? EnteqalNotes { get; set; }

        public double Average {  get; set; }

        [ForeignKey("Participant")]
        public int ParticipantId { get; set; }

        public Participant? Participant { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User? User { get; set;}

    }
}
