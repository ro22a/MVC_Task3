using System.ComponentModel.DataAnnotations;

namespace ETicketsSystem.Models
{
	public class Category
	{
		public int Id { get; set; }
		[Required]
		[MinLength(2)]
		[MaxLength(255)]
		public string Name { get; set; } = string.Empty;
		public List<Movie>?	Movies { get; set; }

	}
}
