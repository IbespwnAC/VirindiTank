namespace MetaViewWrappers
{
    using System;

    public class MVListSelectEventArgs : MVControlEventArgs
    {
        private int a;
        private int b;

        internal MVListSelectEventArgs(int A_0, int A_1, int A_2) : base(A_0)
        {
            this.a = A_1;
            this.b = A_2;
        }

        public int Column
        {
            get
            {
                return this.b;
            }
        }

        public int Row
        {
            get
            {
                return this.a;
            }
        }
    }
}

