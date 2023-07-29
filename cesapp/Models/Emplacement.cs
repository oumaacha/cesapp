using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
    public class Emplacement
    {
        [Key]
        public int EmplacementId { get; set; }
        [Required]
        [MaxLength(200)]
        public string EmplacementName { get; set; }
        public ICollection<Machine> Machines { get; set; }
    }
}