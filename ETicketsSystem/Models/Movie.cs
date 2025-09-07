using ETicketsSystem.Data.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicketsSystem.Models
{
	public class Movie
	{
		public int Id { get; set; }
		[Required]
		[MinLength(2)]
		[MaxLength(255)]
		public string Name { get; set; } = string.Empty;
		
		public string? Description { get; set; }
		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
		public double Price { get; set; }
		[Required]
		public string? ImgUrl { get; set; }
		public string? TrailerUrl { get; set; }
		[Required]
		public DateTime StartDate { get; set; }
		[Required]
		public DateTime EndDate { get; set; }
		public MovieStatus? MovieStatus { get; set; }
		[Required]
		public int CinemaId { get; set; }
		[Required]
		public int CategoryId { get; set; }

		public Cinema Cinema { get; set; }
		public Category Category { get; set; }

		public List<Actor>? Actors { get; set; }


		//public List<OrderItem> OrderItems { get; set; } 

	}
}
