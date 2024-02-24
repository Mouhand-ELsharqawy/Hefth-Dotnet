using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hefth.data.DTO
{
    public class SectionDto
    {
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "HefthFullDegree must be a positive number")]
        public double HefthFullDegree { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "HefthPartDegree must be a positive number")]
        public double HefthPartDegree { get; set; }
        public string? HefthNotes { get; set; }


        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "TaguidFullDegree must be a positive number")]
        public double TaguidFullDegree { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "TaguidPartDegree must be a positive number")]
        public double TaguidPartDegree { get; set; }
        public string? TaguidNotes { get; set; }


        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "WaqfFullDegree must be a positive number")]
        public double WaqfFullDegree { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "WaqfPartDegree must be a positive number")]
        public double WaqfPartDegree { get; set; }
        public string? WaqfNotes { get; set; }


        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "AzobaFullDegree must be a positive number")]
        public double AzobaFullDegree { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "AzobaPartDegree must be a positive number")]
        public double AzobaPartDegree { get; set; }
        public string? AzobaNotes { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "EnteqalFullDegree must be a positive number")]
        public double EnteqalFullDegree { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "EnteqalPartDegree must be a positive number")]
        public double EnteqalPartDegree { get; set; }
        public string? EnteqalNotes { get; set; }

        [Required, EmailAddress]
        public string ParticipantEmail { get; set; }

    }
}
