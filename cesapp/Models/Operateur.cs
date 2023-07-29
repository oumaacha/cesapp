using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
    public class Operateur
    {
        [Key]
        public int OperateurId { get; set; }
        [Required]
        public string OperateurName { get; set; }
        public string OperateurPhone { get; set; }
        public bool isAvailable { get; set; } = true;
        public ICollection<Worker> Workers { get; set; }
    }
}
