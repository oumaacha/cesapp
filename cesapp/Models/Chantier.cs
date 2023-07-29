using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
    public class Chantier
    {
        [Key]
        public int ChantierId { get; set; }
        [Required]
        public string ChantierName { get; set; }
        public string Description { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public double Budget { get; set; }
        public int Progres { get; set; } = 0;
        [Required]
        public int EmplacementId { get; set; }
        public Emplacement Emplacement { get; set; }
        public ICollection<Machine> Machines { get; set; }
    }
}
