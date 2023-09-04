using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
	public class Responsable
	{
		[Key]
		public int ResponsableId { get; set; }
		[Required]
		public string ResponsableFName { get; set; }
		[Required]
		public string ResponsableLName { get; set; }
		public ICollection<Dossier> Dossiers { get; set; }
	}
}
