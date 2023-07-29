using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
    public class MachineType
    {
        [Key]
        public int MachineTypeId { get; set; }
        [Required]
        [MaxLength(200)]
        public string MachineTypeName { get; set; }
        public ICollection<Machine> Machines { get; set; }
    }
}
