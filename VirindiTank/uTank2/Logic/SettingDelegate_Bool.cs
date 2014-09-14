namespace uTank2.Logic
{
    using System;

    public class SettingDelegate_Bool : ISettingDelegate
    {
        private string a;
        private bool b;

        public SettingDelegate_Bool(string psetting, bool preqvalue)
        {
            this.a = psetting;
            this.b = preqvalue;
        }

        public bool Current
        {
            get
            {
                return (er.j(this.a) == this.b);
            }
        }
    }
}

