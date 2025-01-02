using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management_System
{
    public class HourlyEmployee : Employee
    {
        double hoursWorked;
        double rate;

        public HourlyEmployee()
        {
            hoursWorked = 0;    
            rate = 0;   
        }
        public double HoursWorked { set { hoursWorked = value; } get { return hoursWorked; } }
        public double Rate { set { rate = value; } get { return rate; } }

        public HourlyEmployee(int ID , string name , string jobTitle, int deptID , string email , string phoneNo):
            base(ID, name, jobTitle, deptID, email, phoneNo) { }
        public void addHours(int MoreHours)
        {
            HoursWorked += MoreHours;
        }
        public override string getDetails()
        {
            return base.getDetails() +$"HoursWorked: {HoursWorked}\nRate: {rate}\n" ;
        }
        public override void setIncome(double income, double mul = 0)
        {
            hoursWorked = income;
            rate = mul;
        }

        public override double GetSalary()
        {
            return hoursWorked * rate;
        }
    }
}
