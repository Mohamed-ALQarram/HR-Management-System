using System;

namespace HR_Management_System
{
    public class HRsystem
    {
        Employee[] employees;
        Department[] departments;
        int size;
        public HRsystem() 
        {
        departments = new Department[5];
        departments[0] = new Department(1, "IT");
        departments[1] = new Department(2, "Sales");
        departments[2] = new Department(3, "Marketing");
        departments[3] = new Department(4, "Administration");
        departments[4] = new Department(5, "General");

            employees = new Employee[10];
        size = 0;
        }
        
        void Resize(int index=-1)
        {
            if (size == employees?.Length)
            {
                Employee[] newList = new Employee[employees.Length * 2];
                for (int i = 0; i < employees.Length; i++)
                {
                    newList[i] = employees[i];
                }
                employees = newList;
            }
            if (index >=0)
            {
                if(employees != null)
                for (int i = index; i< size; i++) 
                {
                    employees[i] = employees[i + 1];
                }
            }
        }
        int FindEmployee(int ID = 0, string name = "")
        {
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    if (employees[i].EmpID == ID || employees[i].EmpName == name)
                        return i;
                }
            }
            return -1;
        }

        public void addEmployee(int ID , string Name , string EmpType ,string JobTitle ,int deptID=5, string phone="", string email="")
        {
            if (size == employees.Length) 
                Resize();


            if (EmpType == "Manager" || EmpType == "manager") 
                employees[size] = new ManagerEmployee(ID, Name, JobTitle, deptID, email, phone);
            else if(EmpType == "hourly" || EmpType == "Hourly")
                employees[size] = new HourlyEmployee(ID, Name, JobTitle, deptID, email, phone);
            else if (EmpType == "commission" || EmpType == "Commission")
                employees[size] = new CommissionEmployee(ID, Name, JobTitle, deptID, email, phone);
            else
                employees[size] = new SalariedEmployee(ID, Name, JobTitle, deptID, email, phone);
            for (int i = 0; i < departments?.Length; i++) 
            {
                if (departments[i].DepartmentID == deptID)
                {
                    departments[i].addEmployeeToDept(employees[size]);
                    break;
                }
            }
            size++;
        }
        public string getType(int ID)
        {
            return employees[FindEmployee(ID)].GetType().Name;
        }
        public void addBenefit(int ID, string type , string info = "" , string coverage = "")
        {
           int index = FindEmployee(ID );
            if (index > -1)
            {
                employees[index].addBenefit(type, employees[index].GetSalary(), info, coverage);
            }
            else
                Console.WriteLine("This employee doen't exist.");
        }
        public void DeleteEmployee(int ID = 0, string name = "")
        {
            int index = FindEmployee(ID, name);
            if (index > -1)
                Resize(index);
            size--;
        }

        //public void EditEmployee(int ID)
        //{
        //    int index = FindEmployee(ID);
        //    if (index > -1)
        //    {
        //        //edit();
        //    }
        //}
        public string displayEmployee(int ID = 0, string name = "")
        {
            int index = FindEmployee(ID, name);

            if (index > -1)
            return employees[index].getDetails();

            return "";
        }
        public double CalcTotalPayroll(int ID ,double income = 0 , double factor =0  )
        {
            int index = FindEmployee(ID);
            if (index > -1)
            {
                if (employees[index].GetType().Name == "ManagerEmployee")
                    employees[index].setIncome(income, factor);
                else if (employees[index].GetType().Name == "HourlyEmployee")
                    employees[index].setIncome(income, factor);
                else if (employees[index].GetType().Name == "CommissionEmployee")
                    employees[index].setIncome(income, factor);
                else
                    employees[index].setIncome(income);

                return employees[index].CalculatePay();

            }
                return -1;
        }
        public void DisplayAll() 
        {
            if (size > 0)
            {
                for(int i = 0;i < size; i++)
                {
                    Console.WriteLine($"***************************Employee{i+1}***************************");
                    Console.WriteLine(employees[i].getDetails());
                }
            }
        }

        public void ShowDepartment( int deptID)
        {
            foreach (var item in departments)
            {
                if (item.DepartmentID == deptID)
                {
                    item.displayAll();
                }
            }
        }
    }
}
