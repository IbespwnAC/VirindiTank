namespace MetaViewWrappers
{
    using System;

    public class MVTextBoxEndEventArgs : MVControlEventArgs
    {
        private bool a;

        internal MVTextBoxEndEventArgs(int A_0, bool A_1) : base(A_0)
        {
            this.a = A_1;
        }

        public bool Success
        {
            get
            {
                return this.a;
            }
        }
    }
}

