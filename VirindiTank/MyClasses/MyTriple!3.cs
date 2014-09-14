namespace MyClasses
{
    using System;

    internal class MyTriple<A, B, C> : IEquatable<MyTriple<A, B, C>>
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

        public override int a()
        {
            return ((this.a.GetHashCode() ^ this.b.GetHashCode()) ^ this.c.GetHashCode());
        }

        public override bool a(object A_0)
        {
            MyTriple<A, B, C> triple = A_0 as MyTriple<A, B, C>;
            if (triple == null)
            {
                throw new Exception("Cannot equate dissimilar MyTriple objects");
            }
            return this.Equals(triple);
        }

        private bool a(MyTriple<A, B, C> A_0)
        {
            return ((A_0.a.Equals(this.a) && A_0.b.Equals(this.b)) && A_0.c.Equals(this.c));
        }

        public static bool a(MyTriple<A, B, C> A_0, MyTriple<A, B, C> A_1)
        {
            return !A_0.Equals(A_1);
        }

        public static bool b(MyTriple<A, B, C> A_0, MyTriple<A, B, C> A_1)
        {
            return A_0.Equals(A_1);
        }
    }
}

