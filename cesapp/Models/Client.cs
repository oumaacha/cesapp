using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
	public class Client
	{
		[Key]
		public int ClientId { get; set; }
		[Required]
		public string ClientName { get; set; }
	}
}
