using System;
using Microsoft.EntityFrameworkCore;

namespace ubc.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
		{
		}

		public DbSet<Musica>? Musicas { get; set; }
	}
}

