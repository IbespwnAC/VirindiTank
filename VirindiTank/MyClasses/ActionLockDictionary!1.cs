namespace MyClasses
{
    using System;
    using System.Collections.Generic;

    internal class ActionLockDictionary<T>
    {
        private Dictionary<T, List<DateTimeOffset>> a;
        private TimeSpan b;
        private int c;

        public ActionLockDictionary(TimeSpan A_0, int A_1)
        {
            this.a = new Dictionary<T, List<DateTimeOffset>>();
            this.b = A_0;
            this.c = A_1;
        }

        private void a()
        {
            List<T> list = new List<T>();
            foreach (KeyValuePair<T, List<DateTimeOffset>> pair in this.a)
            {
                while (pair.Value.Count > 0)
                {
                    if (this.a(pair.Value[0]))
                    {
                        break;
                    }
                    pair.Value.RemoveAt(0);
                }
                if (pair.Value.Count == 0)
                {
                    list.Add(pair.Key);
                }
            }
            foreach (T local in list)
            {
                this.a.Remove(local);
            }
        }

        private bool a(DateTimeOffset A_0)
        {
            return ((DateTimeOffset.Now - A_0) < this.b);
        }

        public void a(T A_0)
        {
            if (!this.a.ContainsKey(A_0))
            {
                this.a.Add(A_0, new List<DateTimeOffset>());
            }
            this.a[A_0].Add(DateTimeOffset.Now);
            this.a();
        }

        public bool b(T A_0)
        {
            return (this.c(A_0) >= this.c);
        }

        public int c(T A_0)
        {
            this.a();
            if (!this.a.ContainsKey(A_0))
            {
                return 0;
            }
            return this.a[A_0].Count;
        }
    }
}

