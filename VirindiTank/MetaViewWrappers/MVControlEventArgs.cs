namespace MetaViewWrappers
{
    using System;

    public class MVControlEventArgs : EventArgs
    {
        private int a;

        internal MVControlEventArgs(int A_0)
        {
            this.a = A_0;
        }

        public int Id
        {
            get
            {
                return this.a;
            }
        }
    }
}

