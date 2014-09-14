namespace MetaViewWrappers
{
    using System;

    public class MVIndexChangeEventArgs : MVControlEventArgs
    {
        private int a;

        internal MVIndexChangeEventArgs(int A_0, int A_1) : base(A_0)
        {
            this.a = A_1;
        }

        public int Index
        {
            get
            {
                return this.a;
            }
        }
    }
}

