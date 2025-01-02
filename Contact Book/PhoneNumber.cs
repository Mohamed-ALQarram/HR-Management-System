using System;

namespace Contact_Book
{
    internal class PhoneNumber
    {
        string phoneNo;
        string type;

        public PhoneNumber()
        {
            phoneNo= string.Empty;
            type= string.Empty;
        }
        public PhoneNumber(string phoneNo, string type)
        {
            this.phoneNo = phoneNo;
            this.type = type;
        }

        public string PhoneNo {  get { return phoneNo; } set { phoneNo = value; } }
        public string Type { get { return type; } set { type = value; } }


    }
}
