using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
    public class Chantier
    {
        [Key]
        public int ChantierId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string ChantierName { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime DateDebut { get; set; }
        [Required]
        public DateTime DateFin { get; set; }
        public double Budget { get; set; }
        public int Progres { get; set; } = 0;
        [Required]
        public int LocalisationId { get; set; }
        public Localisation Localisation { get; set; }
        public ICollection<Machine> Machines { get; set; }
    }
}
