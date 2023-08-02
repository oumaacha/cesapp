using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
    public class Prefecture
    {
        [Key]
        public int PrefectureId { get; set; }
        [Required]
        public string PrefectureName { get; set; }
        public int ChefLieuId { get; set; }
        public ChefLieu ChefLieu { get; set; }
    }
}
