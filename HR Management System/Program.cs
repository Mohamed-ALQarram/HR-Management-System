using System.Threading.Channels;

namespace HR_Management_System
{
    internal class Program
    {
        static void addBenefit(HRsystem HRSystem , int ID)
        {
            Console.Write("Enter Benefit Type (Health , Dental): ");
            string Type = Console.ReadLine() ?? string.Empty;
            HRSystem.addBenefit(ID, Type);

        }
        static void Main(string[] args)
        {
            HRsystem HRSystem = new HRsystem();
            char ch='0';
            int ID;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            do
            {
                Console.WriteLine($"1. Employee Information Management.\n" +
                    $"2. Benefits Management.\n" +
                    $"3. Salary Calculation.\n" +
                    $"4. Reporting.\n" +
                    $"5. Search.\n" +
                    $"6. Display All Employees.\n" +
                    $"7. Show Department. \n" +
                    $"8. Exit The Program\n");
                Console.Write("Enter Your Choice: ");
                if (char.TryParse(Console.ReadLine(), out char CH))
                    ch = CH;
                else
                    ch='0';
                Console.Clear();
                switch (ch)
                {
                    case '1':
                        Console.WriteLine($"1. Add Employee.\n" +
                            $"2. Delete Employee. \n" +
                            $"3. Modify Employee.\n" +
                            $"4. Exit.\n");
                        Console.Write("Enter Your Choice: ");

                        ch = char.Parse (Console.ReadLine()??"4");
                        Console.Clear();
                        switch (ch)
                        {
                            case'1':
                                int  DeptID ;
                                string Name,Type ,JobTitle , phoneNO , Email;
                                Console.WriteLine("Enter Employee ID");
                                ID = int.Parse(Console.ReadLine() ?? "0");

                                Console.WriteLine("Enter Employee Name");
                                Name = Console.ReadLine() ?? string.Empty;

                                Console.WriteLine("Enter Employee Type (Manager - Salaried - Hourly - Commission)");
                                Type = Console.ReadLine() ?? string.Empty;

                                Console.WriteLine("Enter Job Title");
                                JobTitle = Console.ReadLine() ?? string.Empty;

                                Console.WriteLine("Enter Department ID (1.IT  2.Sales  3.Marketing  4.Administration  5.General )");
                                DeptID = int.Parse(Console.ReadLine() ?? "5");

                                Console.WriteLine("Enter Employee PhoneNo");
                                phoneNO = Console.ReadLine() ?? string.Empty;

                                Console.WriteLine("Enter Employee Email");
                                Email = Console.ReadLine() ?? string.Empty;

                                HRSystem.addEmployee(ID  ,Name , Type , JobTitle , DeptID , phoneNO , Email);

                                Console.WriteLine("Add Benefits? (Y / N)\n");
                                Console.Write("Enter Your Choice: ");
                                ch = char.Parse(Console.ReadLine() ?? "N");
                                if(ch =='Y')
                                    addBenefit(HRSystem, ID);
                                break;
                            case '2':
                                Console.Write("Enter Employee ID: ");
                                ID = int.Parse(Console.ReadLine() ?? "0");
                                HRSystem.DeleteEmployee(ID);
                                break;
                            case '3':
                                //soon
                                break;
                            case '4':
                                break;
                        }
                        break;
                    case '2':
                        Console.WriteLine($"1. Add Benefit.\n" +
                            $"2. Delete Benefit. \n" +
                            $"3. Modify Benefit.\n" +
                            $"4. Exit.\n");
                        Console.Write("Enter Your Choice: ");
                        ch = char.Parse(Console.ReadLine() ?? "4");
                        Console.Clear();
                        switch (ch)
                        {
                            case '1':
                                Console.Write("Enter Employee ID to Add Benefit: ");
                                ID = int.Parse(Console.ReadLine() ?? "0");
                                addBenefit(HRSystem, ID);
                                    break;
                            case '2':
                                // soon
                                break;
                            case '3':
                                // soon
                                break;
                            case '4':
                                break;
                        }
                        break;
                    case '3':
                        double TotalPay = 0;
                        Console.Write("Enter Employee ID: ");
                         ID = int.Parse(Console.ReadLine() ?? "0");
                        string type = HRSystem.getType(ID);
                        if(type == "HourlyEmployee")
                        {
                            int hours, rate;
                            Console.Write("Enter Worked Hours: ");
                            hours = int.Parse(Console.ReadLine()??"0");
                            Console.Write("Enter Rate: ");
                            rate = int.Parse(Console.ReadLine()??"0");
                         TotalPay=HRSystem.CalcTotalPayroll(ID , hours , rate);
                        }
                        else if(type == "CommissionEmployee")
                        {
                            double target, rate;
                            Console.Write("Enter Target: ");
                            target = int.Parse(Console.ReadLine() ?? "0");
                            Console.Write("Enter Rate: ");
                            rate = double.Parse(Console.ReadLine() ?? "0");
                            TotalPay = HRSystem.CalcTotalPayroll(ID, target, rate);
                        }
                        else if (type == "ManagerEmployee")
                        {
                            int Salary, Bouns;
                            Console.Write("Enter Salary: ");
                            Salary = int.Parse(Console.ReadLine() ?? "0");
                            Console.Write("Enter Bouns: ");
                            Bouns = int.Parse(Console.ReadLine() ?? "0");
                            TotalPay = HRSystem.CalcTotalPayroll(ID, Salary, Bouns);
                        }
                        else 
                        {
                            int Salary;
                            Console.Write("Enter Salary: ");
                            Salary = int.Parse(Console.ReadLine() ?? "0");
                            TotalPay = HRSystem.CalcTotalPayroll(ID, Salary);
                        }
                        Console.WriteLine($"Total pay for Employee: {TotalPay}");
                        break;
                    case '4':
                        //soon
                        break;
                    case '5':
                        Console.Write("Enter Employee ID Or Name: " );
                        string input= Console.ReadLine()??"";
                        if(int.TryParse(input , out int result))
                            Console.WriteLine(HRSystem.displayEmployee(result)); 
                        else 
                            Console.WriteLine(HRSystem.displayEmployee(-1, input));
                        break;
                    case '6':
                        HRSystem.DisplayAll();
                        break;
                    case '7':
                        Console.WriteLine("Enter Department ID");
                        ID = int.Parse(Console.ReadLine() ?? "0");
                        HRSystem.ShowDepartment(ID);
                        break;
                    case '8':
                        break;
                    default:
                        Console.WriteLine("\nInvalied Input, Enter Number From 1 to 6\n");
                        continue;

                }
            }
            while (ch != '8');
            Console.WriteLine("Thank You :)");
        }
    }
}
