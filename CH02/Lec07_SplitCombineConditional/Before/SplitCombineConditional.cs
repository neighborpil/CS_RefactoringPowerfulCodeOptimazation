namespace Refactoring
{
    public class SplitConditional
    {
        void SplitAnd(bool A, bool B)
        {
            // and를 2개로 나누기

            //if (A && B)
            //    Statement1();
            //else
            //    Statement2();

            if (A)
            {
                if (B)
                    Statement1();
                else
                    Statement2();
            }
            else
                Statement2();
        }

        void SplitOr(bool A, bool B)
        {
            // or 2개 조건식 나누기

            //if (A || B)
            //    Statement1();
            //else
            //    Statement2();

            if (A)
                Statement1();
            else if (B)
                Statement1();
            else
                Statement2();
        }

        void CombineAnd(bool A, bool B)
        {
            // 조건식 2개 합치기

            //if (A)
            //{
            //    if (B)
            //    {
            //        Statement1();
            //    }
            //    else
            //        Statement2();
            //}
            //else
            //    Statement2();

            if(A && B)
                Statement1();
            else
                Statement2();
        }

        void CombineOr(bool A, bool B)
        {
            // or 조건식 2개 합치기

            //if (A)
            //    Statement1();
            //else if (B)
            //    Statement1();
            //else
            //    Statement2();

            if(A || B)
                Statement1();
            else
                Statement2();
        }

        void CombineOrSameBodies(bool A, bool B)
        {
            //if (A)
            //{
            //    Statement1();
            //    return;
            //}

            //if (B)
            //{
            //    Statement1();
            //    return;
            //}

            if (A || B)
            {
                Statement1();
                return;
            }
        }

        void CombineAndNestedIf(bool A, bool B)
        {
            //if (A)
            //{
            //    if (B)
            //    {
            //        Statement1();
            //    }
            //}

            if (A && B)
                Statement1();
        }

        void Statement1() { }
        void Statement2() { }
    }
}