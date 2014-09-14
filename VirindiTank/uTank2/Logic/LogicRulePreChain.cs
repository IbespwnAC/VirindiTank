namespace uTank2.Logic
{
    using System;
    using System.Text;
    using uTank2;

    public class LogicRulePreChain : ILogicRule
    {
        private ILogicRule a;
        private MyList<ILogicRule> b;
        private int c;
        private ISettingDelegate[] d;
        private bool e;

        public LogicRulePreChain(int pri, ILogicRule mr, params ILogicRule[] pr)
        {
            this.d = new ISettingDelegate[0];
            this.c = pri;
            this.a = mr;
            this.b = new MyList<ILogicRule>(100);
            foreach (ILogicRule rule in pr)
            {
                this.b.Add(rule);
            }
        }

        public LogicRulePreChain(int pri, ILogicRule mr, ISettingDelegate[] reqs)
        {
            this.d = reqs;
            this.c = pri;
            this.a = mr;
            this.b = new MyList<ILogicRule>(100);
        }

        public LogicRulePreChain(int pri, ILogicRule mr, ISettingDelegate[] reqs, params ILogicRule[] pr)
        {
            this.d = reqs;
            this.c = pri;
            this.a = mr;
            this.b = new MyList<ILogicRule>(100);
            foreach (ILogicRule rule in pr)
            {
                this.b.Add(rule);
            }
        }

        public void Dispose()
        {
            if (!this.e)
            {
                this.e = true;
                GC.SuppressFinalize(this);
                if (this.a != null)
                {
                    this.a.Dispose();
                    this.a = null;
                }
                foreach (ILogicRule rule in this.b)
                {
                    rule.Dispose();
                }
                this.b.Clear();
            }
        }

        public string FriendlyName
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("(PreChain: ");
                builder.Append(this.a.FriendlyName);
                builder.Append(", PreActions: ");
                foreach (ILogicRule rule in this.b)
                {
                    builder.Append(rule.FriendlyName);
                    builder.Append(" ");
                }
                builder.Append(")");
                return builder.ToString();
            }
        }

        public int Priority
        {
            get
            {
                return this.c;
            }
        }

        public bool Running
        {
            get
            {
                if (this.a.Running)
                {
                    return true;
                }
                foreach (ILogicRule rule in this.b)
                {
                    if (rule.Running)
                    {
                        return true;
                    }
                }
                return false;
            }
            set
            {
                if (value)
                {
                    foreach (ILogicRule rule in this.b)
                    {
                        if (rule.ValidNow)
                        {
                            rule.Running = true;
                            return;
                        }
                    }
                    if (this.a.ValidNow)
                    {
                        this.a.Running = true;
                    }
                }
                else
                {
                    foreach (ILogicRule rule2 in this.b)
                    {
                        rule2.Running = false;
                    }
                    this.a.Running = false;
                }
            }
        }

        public bool ValidNow
        {
            get
            {
                foreach (ISettingDelegate delegate2 in this.d)
                {
                    if (!delegate2.Current)
                    {
                        return false;
                    }
                }
                return this.a.ValidNow;
            }
        }
    }
}

