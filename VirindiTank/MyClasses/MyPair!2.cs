namespace MyClasses
{
    using System;

    internal class MyPair<A, B> : IEquatable<MyPair<A, B>>
    {
        public A a;
        public B b;

        public MyPair()
        {
        }

        public MyPair(A A_0, B A_1)
        {
            this.a = A_0;
            this.b = A_1;
        }

        public override string a()
        {
            return ("[" + this.a.ToString() + "," + this.b.ToString() + "]");
        }

        public override bool a(object A_0)
        {
            MyPair<A, B> pair = A_0 as MyPair<A, B>;
            if (pair == null)
            {
                throw new Exception("Cannot equate dissimilar MyPair objects");
            }
            return this.a(pair);
        }

        public bool a(MyPair<A, B> A_0)
        {
            return (A_0.a.Equals(this.a) && A_0.b.Equals(this.b));
        }

        public static bool a(MyPair<A, B> A_0, MyPair<A, B> A_1)
        {
            return !A_0.a(A_1);
        }

        public override int b()
        {
            return (this.a.GetHashCode() ^ this.b.GetHashCode());
        }

        public static bool b(MyPair<A, B> A_0, MyPair<A, B> A_1)
        {
            return A_0.a(A_1);
        }
    }
}

