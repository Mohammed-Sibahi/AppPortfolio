using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
	public class AppDbContext : DbContext
	{
		
		// Override 
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.LogTo(Console.WriteLine);
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=CustomersDb;Integrated Security=true");
		}

		public DbSet<Customer> Customers { get; set; }

	}
}
