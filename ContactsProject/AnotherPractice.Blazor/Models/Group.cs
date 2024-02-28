// See https://aka.ms/new-console-template for more information
public class Group
{
	public List<Contact> Contacts { get; set; }

	public string Title { get; set; }

    public Group()
    {
        Contacts = new List<Contact>();
    }

    public bool AddContact(string name, string phone, string email)
	{
		if (name == null)
			return false;

		if (phone == null && email == null)
			return false;

		var contact = new Contact(name, phone, email);
		Contacts.Add(contact);
		return true;
	}

}