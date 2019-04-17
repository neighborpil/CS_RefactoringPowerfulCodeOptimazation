using System;

namespace Refactoring
{
    public class IntroduceVariableExamples
    {
        public bool CheckCanSignContract(Person person)
        {
            bool isUsa = person.Country.ToUpper().IndexOf("USA") > -1;
            bool isTexas = person.State.ToUpper().IndexOf("TEXAS") > -1;
            bool isAdult = person.Age > 21;
            if (isUsa && isTexas && isAdult)
                return true;
            else
                return false;
        }

        public double GetOrderAmount(Order order)
        {
            var basePrice = order.Quantity * order.Price;
            var discount = Math.Max(0, order.Quantity - 100) * order.Price * 0.06;
            var shipping = Math.Min(order.Quantity * order.Price * 0.1, 100);
            return basePrice - discount + shipping;
        }
    }
}
