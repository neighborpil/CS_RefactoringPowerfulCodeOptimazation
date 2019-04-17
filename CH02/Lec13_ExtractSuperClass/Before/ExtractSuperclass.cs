using System.Collections.Generic;

namespace ExtractSuperclass
{
    abstract class OrganizationItem
    {
        public string Name { get; }

        public OrganizationItem(string name)
        {
            Name = name;
        }

        public abstract int CalculateAnnualCost();
    }

    

    class SalaryEmployee : OrganizationItem
    {
        int salary;

        public SalaryEmployee(string name, int salary) : base(name)
        {
            this.salary = salary;
        }

        public override int CalculateAnnualCost()
        {
            return salary;
        }

        

    }

    abstract class ComplexOrganizationItem : OrganizationItem
    {
        List<OrganizationItem> items;

        public ComplexOrganizationItem(string name) : base(name)
        {
            items = new List<OrganizationItem>();
        }

        public override int CalculateAnnualCost()
        {
            int totalCost = 0;
            foreach (OrganizationItem item in items)
            {
                totalCost += item.CalculateAnnualCost();
            }
            return totalCost;
        }
    }

    class Department : ComplexOrganizationItem
    {
        public Department(string name) : base(name)
        {
        }
    }
    class Organization : ComplexOrganizationItem
    {
        public Organization(string name) : base(name)
        {
        }
    }

    class PieceworkEmplyee : OrganizationItem
    {
        private readonly int _paymentPerDay;
        public int ConsumnedDays { get; set; }

        public PieceworkEmplyee(string name, int paymentPerDay) : base(name)
        {
            _paymentPerDay = paymentPerDay;
        }

        public void RegisterDays(int days)
        {
            ConsumnedDays += days;
        }

        public override int CalculateAnnualCost()
        {
            return _paymentPerDay * ConsumnedDays;
        }
    }
}