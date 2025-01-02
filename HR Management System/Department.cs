using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management_System
{
    internal class Department
    {
        string deptName;
        int deptID;
        Employee[] employees;
        int size;

        public Department()
        {
            deptName = string.Empty;
            deptID = 0;
            employees = [];
            size = 0;
        }
        public Department(int ID, string Name)
        {
            deptID = ID;
            deptName = Name;
            employees = [];
            size = 0;
        }

        public int DepartmentID { set { deptID = value; } get { return deptID; } }
        public string DepartmentName { set { deptName = value; } get { return deptName; } }

        public void addEmployeeToDept(Employee employee)
        {

            if (employees?.Length == 0)
                employees = new Employee[5];

             if (size == employees?.Length)
            {
                Employee[] newEmployees = new Employee[employees.Length * 2];
                for (int i = 0; i < size; i++)
                {
                    newEmployees[i] = employees[i];
                }
                employees = newEmployees;
            }
            
                if (employees != null)
                    employees[size++] = employee;
        }

        public void displayAll()
        {
            Console.WriteLine("****************************************************************\n");
            Console.WriteLine($"Department ID: {deptID}\t\tDepartment Name: {deptName}\n");
            Console.WriteLine("****************************************************************\n");
            if (employees.Length > 0)
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine($"Employee {i+1}: ");
                    Console.WriteLine(employees[i].getDetails());
                }
            else
                Console.WriteLine("Department is Empty\n");
        }
    }

}
