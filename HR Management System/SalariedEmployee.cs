using System;

namespace HR_Management_System
{
    public class SalariedEmployee : Employee
    {
        double salary;   
        public SalariedEmployee() 
         {
            salary = 0;
        } 
        public SalariedEmployee(int ID, string name, string jobTitle,int deptID, string email, string phoneNo): 
        base(ID, name, jobTitle, deptID, email, phoneNo)
        { 
        }

        public override void setIncome(double income, double mul = 0)
        {
            salary = income;
        }
        public override double GetSalary()
        {
            return salary;
        }

    }
}
