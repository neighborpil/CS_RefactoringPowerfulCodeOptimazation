using System.Collections.Generic;

namespace ExtractSuperclass
{
    class SalaryEmployee
    {
        int salary;
        public SalaryEmployee(string name, int salary)
        {
            Name = name;
            this.salary = salary;
        }

        public int GetSalary()
        {
            return salary;
        }

        public string Name { get; }
    }
    class Department
    {
        List<SalaryEmployee> employees;
        public Department(string name)
        {
            Name = name;
            employees = new List<SalaryEmployee>();
        }
        public int CalculateAnnualCost()
        {
            int totalCost = 0;
            foreach (SalaryEmployee employee in employees)
            {
                totalCost += employee.GetSalary();
            }
            return totalCost;
        }
        public string Name { get; }
    }
    class Organization
    {
        List<Department> departments;
        public Organization(string name)
        {
            Name = name;
            departments = new List<Department>();
        }
        public int CalculateAnnualCost()
        {
            int totalCost = 0;
            foreach (Department department in departments)
            {
                totalCost += department.CalculateAnnualCost();
            }
            return totalCost;
        }
        public string Name { get; }
    }
}