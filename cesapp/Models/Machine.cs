using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string Nfacteur { get; set; }
        [Required]
        public DateTime DateAcquisition { get; set;}
        [Required]
        public bool isAvailable { get; set; } = true;
        public int situation { get; set; } = 1;
        public int FournisseurId { get; set; }
        public int MachineTypeId { get; set; }
        public int OperateurId { get; set; }
        public int? ChantierId { get; set; }
        public Operateur Operateur { get; set; }
        public Fournisseur Fournisseur { get; set; }
        public MachineType MachineType { get; set; }
        public Chantier Chantier { get; set; }
    }
}
