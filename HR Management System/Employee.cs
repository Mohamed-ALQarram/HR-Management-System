using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace HR_Management_System
{
    public abstract class Employee
    {
        protected int empID;
        protected string empName;
        protected string jobTitle;
        protected int deptID;
        protected string phoneNo;
        protected string email;
        protected Benefit[] BenefitList;
        int BenefitSize;
        int size;

        public Employee()
        {
            empID = 0;
            deptID = 5;
            empName = string.Empty;
            jobTitle = string.Empty;
            phoneNo = string.Empty;
            email = string.Empty;
            BenefitList = new Benefit[2];
            size = 0;
            BenefitSize = 0;

        }
        public Employee(int ID, string name, string jobTitle, int deptID, string email, string phoneNo)

        {
            this.empID = ID;
            this.deptID = deptID;
            this.empName = name;
            this.jobTitle = jobTitle;
            this.phoneNo = email;
            this.email = phoneNo;
            BenefitList = new Benefit[2];
            size = 0;
            BenefitSize = 0;
        }
        public int DeptID { get { return deptID; } }
        public int EmpID { get { return empID; } }
        public string EmpName { get { return empName; } }

        public abstract double GetSalary();

        public virtual void addBenefit(string type, double amount, string info = "", string Coverage = "")
        {
            if (size == BenefitList?.Length)
            {
                Console.WriteLine("index out of range!");
                return;
            }
            if (BenefitList != null)
            {
                if (type == "Health")
                    BenefitList[size++] = new HealthBenefit(amount, info, Coverage);
                else
                    BenefitList[size++] = new DentalBenefit(amount, info);
                BenefitSize++;
            }
            else
                Console.WriteLine("Benefit list is null");

        }

        public virtual string getDetails() 
        {
            return $"ID: {empID}\n" +
                $"Name: {empName}\n" +
                $"type: {this.GetType().Name}\n" +
                $"Job Title: {jobTitle}\n" +
                $"Department ID: {deptID}\n" +
                $"Net Salary {this.GetSalary()}\n" +
                $"PhoneNo: {phoneNo}\n" +
                $"Email: {email}\n" +
                $"Benefits: {BenefitList[0]?.CalculateBenefit(GetSalary())}\n\t {BenefitList[1]?.CalculateBenefit(GetSalary())}\n ";

        }

        public virtual double CalculatePay()
        {
            if (BenefitList.Length > 0)
            {
                double Benefit = 0;
                for (int i = 0; i <BenefitSize; i++)
                {
                    Benefit += BenefitList[i].CalculateBenefit(GetSalary());
                }
                return Benefit + (GetSalary());
            }
            return 0;
        }

        public abstract void setIncome(double income, double factor = 0);
    }
}
