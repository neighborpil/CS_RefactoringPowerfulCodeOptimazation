namespace Refactoring
{
    public class SimplifyCondition
    {
        public void Or(bool A)
        {
            // true
            var c1 = true;

            // A
            var c2 = A;

            // A
            var c3 = A;

            // true
            var c4 = true;
        }

        public void And(bool A)
        {
            // A
            var c1 = A;

            // false
            var c2 = false;

            // A
            var c3 = A;

            // false
            var c4 = false;
        }

        public void OrAnd(bool A, bool B, bool C)
        {
            // A
            var c1 = A;

            // A || B
            var c2 = A || B;

            // A || B && C
            var c3 = A || B && C;
        }

        public void DeMorgan(bool A, bool B)
        {
            // !A && !B
            var c1 = !A && !B;

            // !A || !B
            var c2 = !A || !B;

            // !(A || B)
            var c3 = A || B;

            // !(A && B)
            var c4 = A && B;
        }
    }
}