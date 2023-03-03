using System.Globalization;
using Work.Entities;
using Work.Entities.Enums;

namespace Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter department's name:");
            string deptName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("----- Enter work data -----");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Level(Junior/MidLevel/Senior)");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Base salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();
            Department dept = new Department(deptName);
            Worker worker = new Worker(name,level,salary,dept);

            Console.WriteLine("How many contracts to this worker: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter #"+ i + " Contract Data: ");
                Console.WriteLine("Date (DD/MM/YY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine();
                Console.WriteLine("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                Console.WriteLine();

                HourContract contract = new HourContract(date, valuePerHour, hours);

                worker.addContract(contract);
            }

            Console.WriteLine("Enter month and year to calculate income (MM/YYYY): ");
            string monthYear = Console.ReadLine();
            Console.WriteLine();
            int month = int.Parse(monthYear.Substring(0, 2));
            int year = int.Parse(monthYear.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + monthYear + ": " + worker.income(year,month));

        }
    }
}