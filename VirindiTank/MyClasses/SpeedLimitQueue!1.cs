namespace MyClasses
{
    using System;
    using System.Collections.Generic;

    internal abstract class SpeedLimitQueue<T> : IDisposable
    {
        private int a;
        private int b;
        private e3 c;
        private Queue<T> d;
        private Queue<DateTimeOffset> e;
        private bool f;

        public SpeedLimitQueue(int A_0, int A_1)
        {
            this.c = new e3();
            this.d = new Queue<T>();
            this.e = new Queue<DateTimeOffset>();
            this.a = A_0;
            this.b = A_1;
            this.c.a(new EventHandler(this.a));
            int num = this.b / (this.a * 2);
            if (num < 1)
            {
                num = 1;
            }
            this.c.a(num);
            this.c.d();
        }

        public void a()
        {
            if (!this.f)
            {
                this.f = true;
                GC.SuppressFinalize(this);
                this.c.e();
            }
        }

        protected abstract void a(T A_0);
        private void a(object A_0, EventArgs A_1)
        {
            this.b();
        }

        public void b()
        {
            while ((this.e.Count > 0) && ((DateTimeOffset.Now - this.e.Peek()) > TimeSpan.FromMilliseconds((double) this.b)))
            {
                this.e.Dequeue();
            }
            while ((this.e.Count < this.a) && (this.d.Count > 0))
            {
                T local = this.d.Dequeue();
                this.a(local);
                this.e.Enqueue(DateTimeOffset.Now);
            }
        }

        public void b(T A_0)
        {
            this.d.Enqueue(A_0);
            this.b();
        }

        public int c()
        {
            return this.d.Count;
        }
    }
}

