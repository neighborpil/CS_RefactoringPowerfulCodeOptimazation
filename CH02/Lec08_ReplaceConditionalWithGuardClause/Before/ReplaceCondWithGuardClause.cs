using System;
using System.Linq;
using System.Collections.Generic;

namespace ReplaceCondWithGuardClause
{
    class BAD_CODE_Example
    {
        public double GetSomeValue()
        {
            // 고차원의 조건식은 안좋다, 이해하기 어렵다
            //double emptyValue = GetEmptyValue();
            //var val1 = GetValue1();
            //if (Check(val1))
            //{
            //    var val2 = GetValue2();
            //    if (Check(val2))
            //    {
            //        var val3 = GetValue3();
            //        if (Check(val3))
            //        {
            //            var val4 = GetValue4();
            //            if (Check(val4))
            //            {
            //                var val5 = GetValue5();
            //                if (Check(val5))
            //                {
            //                    return GetResult();
            //                }
            //            }
            //        }
            //    }
            //}
            //return emptyValue;

            double emptyValue = GetEmptyValue();

            var val1 = GetValue1();
            if (!Check(val1))
                return emptyValue;

            var val2 = GetValue2();
            if (!Check(val2))
                return emptyValue;

            var val3 = GetValue3();
            if (!Check(val3))
                return emptyValue;

            var val4 = GetValue4();
            if (!Check(val4))
                return emptyValue;

            var val5 = GetValue5();
            if (!Check(val5))
                return emptyValue;

            return GetResult();
        }

        double GetEmptyValue()
        {
            return 0.0d;
        }
        bool Check(double value)
        {
            return true;
        }
        double GetValue1()
        {
            return 1.0d;
        }
        double GetValue2()
        {
            return 2.0d;
        }
        double GetValue3()
        {
            return 3.0d;
        }
        double GetValue4()
        {
            return 4.0d;
        }
        double GetValue5()
        {
            return 5.0d;
        }
        double GetResult()
        {
            return 10.0d;
        }
    }

    class GOOD_CODE_Example
    {
        public double GetSomeValue()
        {
            double emptyValue = GetEmptyValue();

            var val1 = GetValue1();
            if (!Check(val1))
                return emptyValue;

            var val2 = GetValue2();
            if (!Check(val2))
                return emptyValue;

            var val3 = GetValue3();
            if (!Check(val3))
                return emptyValue;

            var val4 = GetValue4();
            if (!Check(val4))
                return emptyValue;

            var val5 = GetValue5();
            if (!Check(val5))
                return emptyValue;

            return GetResult();
        }

        double GetEmptyValue()
        {
            return 0.0d;
        }
        bool Check(double value)
        {
            return true;
        }
        double GetValue1()
        {
            return 1.0d;
        }
        double GetValue2()
        {
            return 2.0d;
        }
        double GetValue3()
        {
            return 3.0d;
        }
        double GetValue4()
        {
            return 4.0d;
        }
        double GetValue5()
        {
            return 5.0d;
        }
        double GetResult()
        {
            return 10.0d;
        }
    }

    class Employee
    {
        public Employee(string name)
        {
            Name = name;
        }
        public string Name { get; }
        public float Salary { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime LastBonusDate { get; set; }
    }
    class BonusCalculator
    {
        public float CalculateBonusCoefficient(int years)
        {
            float coefficient = 1;
            if (years < 5)
                coefficient = 1;
            else if (years < 10)
                coefficient = 1.5f;
            else
                coefficient = 2.0f;
            return coefficient;
        }
        public float CalculateBonus(IEnumerable<Employee> employees, string employeeName)
        {
            float zeroBonus = 0;

            if (employees == null)
                return zeroBonus;

            var employee = employees.FirstOrDefault(em => string.Compare(em.Name, employeeName) == 0);
            if (employee == null)
                return zeroBonus;

            var daysFromLastBonus = (DateTime.Today - employee.LastBonusDate).Days;
            if (daysFromLastBonus <= 150)
                return zeroBonus;

            var passedDays = (DateTime.Today - employee.HireDate).Days;
            var workedYears = passedDays / 365;
            var coefficient = CalculateBonusCoefficient(workedYears);
            if (coefficient <= 0)
                return zeroBonus;

            return zeroBonus;
        }
    }
}
