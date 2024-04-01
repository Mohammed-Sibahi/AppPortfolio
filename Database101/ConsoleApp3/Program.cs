// See https://aka.ms/new-console-template for more information
using ConsoleApp3;

var dbContext = new AppDbContext();

var customers = dbContext
					.Customers
					.Where(c => c.BirthDate.Year < 1990)
					.ToList();

foreach (var item in customers)
{
	Console.WriteLine($"Id: {item.Id}, Name: {item.FullName}, Age: {item.BirthDate.ToShortDateString()}");
}

var firstCustomer = dbContext.Customers.Find(1); // Get row by ID 
firstCustomer.Salary = 7500;
dbContext.SaveChanges();

var customer = new Customer
{
	FullName = "John",
	Phone = "0583242132",
	BirthDate = new DateTime(1980, 1, 1),
	Salary = 3500,
	Address = "Marina",
	Email = "john@live.com",
	ZipCode = "4434523"
};
//dbContext.Customers.Add(customer);

//dbContext.SaveChanges();


Console.ReadKey();
