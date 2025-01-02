using System;

namespace Contact_Book
{
    internal class Contact
    {
        string firstName;
        string lastName;
        PhoneNumber[] phoneNumbers;
        string email;
        int size;
        public Contact()
        {
        firstName = string.Empty;
        lastName = string.Empty;    
        phoneNumbers = new PhoneNumber[0];
        email = string.Empty;
        size = 0;
        }
        public Contact(string Fname , string Lname , string Email )
        {
            firstName = Fname;
            lastName = Lname;
            phoneNumbers = new PhoneNumber[0];
            email = Email;
            size = 0;
        }

        public string FirstName {  get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Email { get { return email; } set { email = value; } }

        public void addPhoneNo(string phoneNo , string type)
        {
            if(phoneNumbers?.Length == 0)
                phoneNumbers = new PhoneNumber[1];
            else if (phoneNumbers?.Length == size)
            {
                PhoneNumber[] nums = new PhoneNumber[phoneNumbers?.Length * 2 ?? 0];
                for (int i = 0; i < phoneNumbers?.Length; i++)
                {
                    nums[i] = phoneNumbers[i];
                }
                phoneNumbers = nums;
            }
            if (phoneNumbers != null)
            {
                phoneNumbers[size]= new PhoneNumber(phoneNo, type);
                size++;
            }
            else
                Console.WriteLine("Error, Can\'t add this PhoneNo.");
        }
        public void RemovePhoneNo(string number)
        {
            if (phoneNumbers?.Length > 0)
            {
                for (int i = 0;i < phoneNumbers?.Length; i++)
                {
                    if (phoneNumbers[i].PhoneNo == number)
                    {
                        for(int j = i;  j < phoneNumbers?.Length; j++)
                        {
                            phoneNumbers[j] = phoneNumbers[j + 1];
                        }
                        size--;
                        if (size == -1)
                        {
                            phoneNumbers = new PhoneNumber[0];
                            size=0;
                        }
                    }
                }
            }
            else
                Console.WriteLine("Phone List is Empty.");

        }
        public PhoneNumber[] getPhoneNo() { return phoneNumbers; }

    }
}
