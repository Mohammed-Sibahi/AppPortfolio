// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var group = new Group()
{
	Title = "Business Contacts"
};

// Insert
Console.WriteLine($"Welcome to {group.Title}");
Console.WriteLine("Insert the name of the contact");
var name = Console.ReadLine(); 

Console.WriteLine("Insert the phone of the contact");
var phone = Console.ReadLine();

Console.WriteLine("Insert the email of the contact");
var email = Console.ReadLine();

group.AddContact(name, phone, email);

// View
foreach (var contact in group.Contacts)
{
	Console.WriteLine($"Name: {contact.Name}, Phone: {contact.Phone}, Email: {contact.Email}");
}
