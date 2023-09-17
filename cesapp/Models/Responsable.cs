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
		[Required]
		public string Matricule { get; set; }
		public string CodeTelephone { get; set; }
        public string NumeroTelephone { get; set; }
		public string Mail { get; set; }
        public ICollection<Dossier> Dossiers { get; set; }
	}
}
