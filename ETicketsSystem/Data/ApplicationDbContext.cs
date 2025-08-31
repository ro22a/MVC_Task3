using ETicketsSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicketsSystem.Data
{
	class ApplicationDbContext : DbContext
	{
		public DbSet<Actor> Actors { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Cinema> Cinemas { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ETicketsSystem;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			
		}
	}
}
