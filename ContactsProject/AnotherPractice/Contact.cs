// See https://aka.ms/new-console-template for more information
public class Contact
{
	public string Id { get; set; }

	public string Name { get; set; }

	public string Phone { get; set; }

	public string Email { get; set; }


    public Contact(string name, string phone, string email)
    {
		Id = Guid.NewGuid().ToString();
		Name = name;
		Phone = phone;
		Email = email;
    }
}
