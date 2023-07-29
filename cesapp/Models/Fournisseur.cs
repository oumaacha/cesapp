using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
    public class Fournisseur
    {
        [Key]
        public int FournisseurId { get; set; }
        [Required]
        public string FournisseurName { get; set; }
    }
}
