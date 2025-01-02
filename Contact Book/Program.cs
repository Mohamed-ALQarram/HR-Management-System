namespace Contact_Book
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ContactBook Contacts = new ContactBook();
            char ch = 'n';
            string Fname , Lname , email , PhoneNo , Type;

            do
            {
                Console.WriteLine("\n*********************************************\n" +
                    "1.ADD NEW CONTACT\n" +
                    "2.DELETE A CONTACT\n" +
                    "3.SEATCH FOR A CONTACT\n" +
                    "4.DISPLAY ALL CONTACTS\n" +
                    "5.EXIT THE PROGRAM\n");
                ch = char.Parse( Console.ReadLine()?? "5");
                switch (ch) 
                {
                    case '1':
                        Console.Write("Enter First Name: ");
                        Fname= Console.ReadLine()??"";
                        Console.Write("Enter Last Name: ");
                        Lname = Console.ReadLine() ?? "";
                        Console.Write("Enter Email: ");
                        email = Console.ReadLine() ?? "";
                        Console.Write("Enter PhoneNo.: ");
                        PhoneNo = Console.ReadLine() ?? "";
                        Console.Write("Enter PhoneNo Type (Home - Mobile - Work - ETC): ");
                        Type = Console.ReadLine() ?? "";
                        Contacts.AddContact(Fname, Lname, email , PhoneNo, Type);
                        break;
                    case '2':
                        Console.Write("Enter Contact Name: ");
                        Fname = Console.ReadLine() ?? "";
                        Contacts.RemoveContact(Fname);
                        break;
                    case '3':
                        Console.Write("Enter Contact Name: ");
                        Fname = Console.ReadLine() ?? "";
                        Contacts.displayContact(Fname);
                        break;
                    case '4':
                        Contacts.displayAll();
                        break;
                    case '5':
                        break;
                    default:
                        Console.WriteLine("Invalied Option Chose from (1-5)");
                        break;

                }
                Console.WriteLine("Again? (y/n)");
                ch = char.Parse(Console.ReadLine() ?? "n");

            }
            while (ch =='y' || ch == 'Y');

        }
    }
}
