using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
	public class Consommation
	{
		[Key]
		public int ConsommationId { get; set; }
		[Required]
		public decimal MontantEnDh { get; set; }
		[Required]
		public DateTime Date { get; set; }
		[Required]
		public int OperateurId { get; set; }
		public int ConsommationTypeId { get; set; }
		public int MachineId { get; set; }
		public Operateur Operateur { get; set; }
		public ConsommationType consommationType { get; set; }
		public Machine Machine { get; set; }
	}
}
