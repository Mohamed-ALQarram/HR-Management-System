using System;
using System.Threading.Channels;

namespace Contact_Book
{
    internal class ContactBook
    {
        Contact[] ContactList;
        int size;
        public ContactBook()
        {
            ContactList = new Contact[0];
            size = 0;
        }
        public ContactBook(Contact[] contactList, int size)
        {
            this.ContactList = contactList;
            this.size = size;
        }

        public void AddContact(String Fname , String Lname , String Email , string PhoneNo="" , string type= "") 
        {
            if (ContactList?.Length == 0)
            {
                ContactList = new Contact[10];
            }
            else if (ContactList?.Length == size) 
            {
                Contact[] newList = new Contact[ContactList?.Length * 2 ?? 0];
                for (int i = 0; i < ContactList?.Length; i++) 
                {
                    newList[i] = ContactList[i];
                }
                ContactList = newList;
            }
            if (ContactList != null)
            {
                ContactList[size] = new Contact(Fname , Lname , Email );
                ContactList[size].addPhoneNo(PhoneNo, type);
                size++;
            }
            else
                Console.WriteLine("Error, Contact list is Empty");
        }
        public void RemoveContact(string name)
        {
            if (ContactList?.Length > 0)
            {
                int index = Search(name);
                if (index > 0)
                {
                    for (int j = index; j < size; j++)
                        ContactList[j] = ContactList[j + 1];
                    size--;
                    if (size == -1)
                    {
                        ContactList = new Contact[0];
                        size = 0;
                    }
                }
                else Console.WriteLine("Contact Not Founded");

            }
            else
                Console.WriteLine("Contact List is Empty.");
        }

         int Search(string name)
        {
            for(int i = 0;i< size; i++)
            {
                if((ContactList[i].FirstName +" "+ ContactList[i].LastName) == name)
                {
                    return i;
                }
            }

            return -1;
        }

        public void displayContact(string name)
        {
            int index = Search(name);
            if (index < 0)
            {
                Console.WriteLine("***************************************");
                Console.WriteLine($"Name: {ContactList[index].FirstName} {ContactList[index].LastName} \n" +
                    $"Email: {ContactList[index].Email} \nPhoneNumbers: ");
                var Numbers = ContactList[index].getPhoneNo();
                for (int j = 0; j < Numbers?.Length; j++)
                {
                    Console.WriteLine($"Num{j + 1}: {Numbers[j].PhoneNo}\t type: {Numbers[j].Type} \n");
                }
            }
            else Console.WriteLine("Contact not founded");

        }
        
        public void displayAll()
        {
            if (ContactList?.Length > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine("***************************************");
                    Console.WriteLine($"Contact{i + 1}: ");
                    Console.WriteLine($"Name: {ContactList[i].FirstName} {ContactList[i].LastName} \n" +
                        $"Email: {ContactList[i].Email} \nPhoneNumbers: ");
                    var Numbers = ContactList[i].getPhoneNo();
                    for (int j = 0; j < Numbers?.Length; j++)
                    {
                        Console.WriteLine($"Num{j + 1}: {Numbers[j].PhoneNo}\t type: {Numbers[j].Type} \n");
                    }
                }
            }
            else Console.WriteLine("Contact List is Empty.");
        }

    }
}
