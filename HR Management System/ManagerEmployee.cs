using System;

namespace HR_Management_System
{
    internal class ManagerEmployee : Employee
    {
        double salary;
        int  bouns;
        
        public ManagerEmployee()
        {
            bouns = 0;
        }
        public ManagerEmployee(int ID, string Name,string JobTitle,int deptID ,string phone, string email):
            base(ID, Name, JobTitle, deptID, email, phone)
        {
        }
        public void addBouns(int bouns)
        {
        this.bouns += bouns; 
        }
        public override string getDetails()
        {
            return base.getDetails() + $"Bouns: {bouns}\n";
        }

        public override void setIncome(double income, double mul = 0)
        {
            salary = income;
            bouns =(int) mul;
        }
        public override double GetSalary()
        {
            return salary + bouns;
        }


    }
}
