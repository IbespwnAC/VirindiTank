namespace uTank2.Logic
{
    using System;

    public class LogicRuleSentinel : ILogicRule
    {
        private int a;
        private string b;

        public LogicRuleSentinel(string marker, int pri)
        {
            this.a = pri;
            this.b = marker;
        }

        public void Dispose()
        {
        }

        public string FriendlyName
        {
            get
            {
                return ("Sentinel " + this.b);
            }
        }

        public string Marker
        {
            get
            {
                return this.b;
            }
        }

        public int Priority
        {
            get
            {
                return this.a;
            }
        }

        public bool Running
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        public bool ValidNow
        {
            get
            {
                return false;
            }
        }
    }
}

