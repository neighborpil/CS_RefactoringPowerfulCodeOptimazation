namespace Refactoring
{
    public class SplitConditional
    {
        void SplitAnd(bool A, bool B)
        {
            if (A)
            {
                if (B)
                {
                    Statement1();
                }
                else
                    Statement2();
            }
            else
                Statement2();
        }

        void SplitOr(bool A, bool B)
        {
            if (A)
                Statement1();
            else if (B)
                Statement1();
            else
                Statement2();
        }

        void CombineAnd(bool A, bool B)
        {
            if (A && B)
            {
                Statement1();
            }
            else
                Statement2();
        }

        void CombineOr(bool A, bool B)
        {
            if (A || B)
                Statement1();
            else
                Statement2();
        }

        void CombineOrSameBodies(bool A, bool B)
        {
            if (A || B)
            {
                Statement1();
                return;
            }
        }

        void CombineAndNestedIf(bool A, bool B)
        {
            if (A && B)
            {
                Statement1();
            }
        }

        void Statement1() { }
        void Statement2() { }
    }
}