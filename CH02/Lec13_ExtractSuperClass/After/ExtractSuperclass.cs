using System;
using System.Collections.Generic;

namespace ExtractSuperclass
{
    abstract class OrganizationItem
    {
        public OrganizationItem(string name)
        {
            Name = name;
        }
        public abstract int CalculateAnnualCost();
        public string Name { get; }
    }
    class SalaryEmployee : OrganizationItem
    {
        int salary;
        public SalaryEmployee(string name, int salary)
            : base(name)
        {
            this.salary = salary;
        }

        public override int CalculateAnnualCost()
        {
            return salary;
        }
    }
    class PieceworkEmployee : OrganizationItem
    {
        int paymentPerDay;
        public PieceworkEmployee(string name, int paymentPerDay)
            : base(name)
        {
            this.paymentPerDay = paymentPerDay;
        }

        public override int CalculateAnnualCost()
        {
            return paymentPerDay * ConsumedDays;
        }
        public void ResigterDays(int days)
        {
            ConsumedDays += days;
        }
        public int ConsumedDays { get; private set; }
    }
    abstract class ComplexOrganizationItem : OrganizationItem
    {
        List<OrganizationItem> items;
        public ComplexOrganizationItem(string name)
            : base(name)
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
        public Department(string name)
            : base(name)
        {
        }
    }
    class Organization : ComplexOrganizationItem
    {
        public Organization(string name)
            : base(name)
        {
        }
    }
}
