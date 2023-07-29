using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        [Required]
        public string WorkerName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public TypeWorker Type { get; set; }
        public int OperateurId { get; set; }
        public Operateur Operateur { get; set; }
    }
}
