using System.Collections.Generic;
using Work.Entities.Enums;

namespace Work.Entities
{
    internal class Worker
    {
        public String Name { get; set; }
        public WorkerLevel level { get; set; }
        public double baseSalary { get; set; }

        public Department Department { get; set; }
        
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();//Instanciar para não ser nula

        public Worker()
        {

        }
        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            this.level = level;
            this.baseSalary = baseSalary;
            Department = department;
        }

        public void addContract(HourContract contract)
        {
            //Adicionando a lista
            Contracts.Add(contract);
        }

        public void removeContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double income(int year, int month)
        {
            double sum = baseSalary;
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.totalValue();
                }
            }
            return sum;
        }
    }
}
