using System.Linq;

namespace SplitTemp
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
            // 변수를 반복해서 사용하지 말고 각각 분리해라
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
