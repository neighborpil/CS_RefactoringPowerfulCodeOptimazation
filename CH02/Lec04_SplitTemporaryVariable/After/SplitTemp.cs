using System.Linq;

namespace SplitTemp_Result
{
    abstract class Fruit
    {
        public abstract float Weight { get; }
        public abstract float Price { get; }
    }
    class Apple : Fruit
    {
        public override float Weight => 10;
        public override float Price => 5;
    }
    class Pear : Fruit
    {
        public override float Weight => 10;
        public override float Price => 5;
    }
    class Plum : Fruit
    {
        public override float Weight => 3;
        public override float Price => 4;
    }
    
    public class SplitTempExamples
    {
        int GetAppleCount() => 10;
        int GetPearCount() => 20;
        int GetPlumCount() => 100;
        public float CalculatePurchasePrice()
        {
            var appleCount = GetAppleCount();
            var apples = new Apple[appleCount];
            var totalPrice = apples.Sum(fruit=>fruit.Price);
            
            var pearCount = GetPearCount();
            var pears = new Pear[pearCount];
            totalPrice += pears.Sum(fruit=>fruit.Price);

            var plumCount = GetPlumCount();
            var plums = new Plum[plumCount];
            totalPrice += plums.Sum(fruit=>fruit.Price);

            return totalPrice;
        }
    }
}
