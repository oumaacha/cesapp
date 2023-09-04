using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
	public class ConsommationType
	{
		[Key]
		public int ConsommationTypeId { get; set; }
		public string Type { get; set; }
	}
}
