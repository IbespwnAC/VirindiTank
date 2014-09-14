namespace uTank2
{
    using System;

    internal class MyTriple<A, B, C>
    {
        public A a;
        public B b;
        public C c;

        public MyTriple()
        {
        }

        public MyTriple(A A_0, B A_1, C A_2)
        {
            this.a = A_0;
            this.b = A_1;
            this.c = A_2;
        }
    }
}

