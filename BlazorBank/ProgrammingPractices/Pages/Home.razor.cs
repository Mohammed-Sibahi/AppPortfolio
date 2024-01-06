namespace ProgrammingPractices.Pages
{
	public partial class Home
	{

		private string _name;
		private string _email;
		private string _address;
		private string _mobileNumber;
		private string _occupation;
		private string _companyName;
		private decimal _monthlySalary;
		private int _age;
		private string? _errorMessage = null;

		private bool _isBusy = false;


		private Account? _account = null;
		private Customer? _customer = null; 

		private async Task Submit()
		{
			_errorMessage = null;

			if (string.IsNullOrWhiteSpace(_name))
			{
				_errorMessage = "Name is required";
				return;
			}

			if (string.IsNullOrWhiteSpace(_email))
			{
				_errorMessage = "Email is required";
				return;
			}

			if (string.IsNullOrWhiteSpace(_address))
			{
				_errorMessage = "Address is required";
				return;
			}

			if (string.IsNullOrWhiteSpace(_mobileNumber))
			{
				_errorMessage = "Mobile Number is required";
				return;
			}

			if (string.IsNullOrWhiteSpace(_occupation))
			{
				_errorMessage = "Occupation is required";
				return;
			}

			if (string.IsNullOrWhiteSpace(_companyName))
			{
				_errorMessage = "Company Name is required";
				return;
			}

			if (_monthlySalary <= 0)
			{
				_errorMessage = "Monthly Salary must be greater than 0";
				return;
			}
			else if (_monthlySalary < 5000)
			{
				_errorMessage = "Monthly Salary must be at least 5,000";
				return;
			}

			if (_age <= 17)
			{
				_errorMessage = "Age must be greater than 17";
				return;
			}

			_customer = new Customer(_name, _occupation, _companyName, _monthlySalary, _age, _email, _address, _mobileNumber);

			_isBusy = true;
			// TODO: Actions happening
			await Task.Delay(5000);
			
			_isBusy = false;

			_account = new Account(_customer);
		}

	}

	public class Account
	{
		// Properties for account number, balance, interest rate, and associated customer
		public string AccountNumber { get; set; }
		public decimal Balance { get; set; }
		public double InterestRate { get; set; }
		public Customer Customer { get; set; }

		// Constructor to initialize an account with a customer
		public Account(Customer customer)
		{
			AccountNumber = GenerateAccountNumber(); // Generate a unique account number
			Balance = 0;
			InterestRate = 0.02;
			Customer = customer;
		}

		// Static counter for generating unique account numbers
		private static long accountNumberCounter = 1000000000000000;

		// Method to generate a unique 16-digit account number
		private string GenerateAccountNumber()
		{
			return (accountNumberCounter++).ToString("D16");
		}

		// Method to deposit money into the account
		public string Deposit(decimal amount)
		{
			Balance += amount;
			return $"Deposited {amount:C} into account {AccountNumber}. New Balance: {Balance:C}.";
		}

		// Method to withdraw money from the account
		public string Withdraw(decimal amount)
		{
			// Check if withdrawal amount is valid based on account balance
			if (amount <= Balance)
			{
				Balance -= amount;
				return $"Withdrawn {amount:C} from account {AccountNumber}. New Balance: {Balance:C}.";
			}
			else
			{
				return "Insufficient funds.";
			}
		}
	}

	public class Customer
	{
		// Properties for customer ID and personal information
		public int CustomerId { get; private set; }
		public string Name { get; private set; }
		public string Occupation { get; private set; }
		public string CompanyName { get; private set; }
		public decimal MonthlySalary { get; private set; }
		public int Age { get; private set; }
		public string EmailAddress { get; private set; }
		public string Address { get; private set; }
		public string MobileNumber { get; private set; }

		// Constructor to initialize a customer with personal information
		public Customer(string name, string occupation, string companyName, decimal monthlySalary, int age, string emailAddress, string address, string mobileNumber)
		{
			CustomerId = GenerateCustomerId(); // Generate a unique customer ID
			Name = name;
			Occupation = occupation;
			CompanyName = companyName;
			MonthlySalary = monthlySalary;
			Age = age;
			EmailAddress = emailAddress;
			Address = address;
			MobileNumber = mobileNumber;
		}

		// Static counter for generating unique customer IDs
		private static int customerIdCounter = 1;

		// Method to generate a unique customer ID
		private int GenerateCustomerId()
		{
			return customerIdCounter++;
		}
	}
}