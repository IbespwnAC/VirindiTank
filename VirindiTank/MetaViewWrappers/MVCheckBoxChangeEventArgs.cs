namespace MetaViewWrappers
{
    using System;

    public class MVCheckBoxChangeEventArgs : MVControlEventArgs
    {
        private bool a;

        internal MVCheckBoxChangeEventArgs(int A_0, bool A_1) : base(A_0)
        {
            this.a = A_1;
        }

        public bool Checked
        {
            get
            {
                return this.a;
            }
        }
    }
}

