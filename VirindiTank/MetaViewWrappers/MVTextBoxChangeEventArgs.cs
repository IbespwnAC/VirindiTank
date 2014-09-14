namespace MetaViewWrappers
{
    using System;

    public class MVTextBoxChangeEventArgs : MVControlEventArgs
    {
        private string a;

        internal MVTextBoxChangeEventArgs(int A_0, string A_1) : base(A_0)
        {
            this.a = A_1;
        }

        public string Text
        {
            get
            {
                return this.a;
            }
        }
    }
}

