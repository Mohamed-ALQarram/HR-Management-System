using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management_System
{
    public class CommissionEmployee : Employee
    {
        double target;
        double rate;

        public CommissionEmployee()
        {
            target = 0;
            rate = 0;
        }
        public CommissionEmployee(int ID, string name, string jobTitle,int deptID, string email, string phoneNo) :
            base(ID , name , jobTitle, deptID, email , phoneNo)
        {
        }
        public double Target { set { target = value; } get { return target; } }
        public double Rate { set { rate = value; } get { return rate; } }



        public override string getDetails()
        {
            return base.getDetails() + $"Target: {Target}\nRate: {rate}\n";
        }
        public override void setIncome(double income, double mul = 0)
        {
            target = income;
            rate = mul;
        }
        public override double GetSalary()
        {
            return target * rate;
        }
    }
}
