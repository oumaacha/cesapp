using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
    public class ChefLieu
    {
        [Key]
        public int LieuId { get; set; }
        [Required]
        public string LieuName { get; set;}
        public ICollection<Prefecture> Prefectures { get; set; }
    }
}
