using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
    public class Localisation
    {
        [Key]
        public int  LocalisationId { get; set; }
        [Required]
        public double X { get; set; }
        [Required]    
        public double Y { get; set; }
        public int PrefectureId { get; set; }
        public Prefecture Prefecture { get; set; }
    }
}
