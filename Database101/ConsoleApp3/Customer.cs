using System.ComponentModel.DataAnnotations;

namespace ConsoleApp3
{
	public class Customer
	{
		public int Id { get; set; } // By convention 

		public string FullName { get; set; }

		public decimal Salary { get; set; }

		public DateTime BirthDate { get; set; }

		public string Address { get; set; }

		public string Phone { get; set; }

		public string Email { get; set; }

		public string ZipCode { get; set; }

	}

}
