using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
	public class Dossier
	{
		[Key]
		public int DossierId { get; set; }
		[Required]
		public string DossierNum { get; set; }
		[Required]
		public DateTime DateOuv { get; set; }
		[Required]
		public string Objet { get; set;}
		[Required]
		public int ResponsableId { get; set; }
		[Required]
		public int ClientId { get; set; }
		public Client Client { get; set; }
		public Responsable Responsable { get; set; }
		public ICollection<Chantier> Chantiers { get; set; }
	}
}
