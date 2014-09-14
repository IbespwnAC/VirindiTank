namespace uTank2.Logic
{
    using System;
    using System.Runtime.CompilerServices;

    public class SettingDelegate_Custom : ISettingDelegate
    {
        private dBoolDelegate a;

        public SettingDelegate_Custom(dBoolDelegate pDel)
        {
            this.a = pDel;
        }

        public bool Current
        {
            get
            {
                return this.a();
            }
        }

        public delegate bool dBoolDelegate();
    }
}

