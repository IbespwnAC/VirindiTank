namespace MyClasses
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    [DefaultMember("Item")]
    internal class TypedHashtable<tKey, tValue> : IEnumerable
    {
        private Hashtable a;

        public TypedHashtable()
        {
            this.a = new Hashtable();
        }

        private IEnumerator a()
        {
            return new THEnumerator<tKey, tValue>(this.a);
        }

        public tValue a(tKey A_0)
        {
            return (tValue) this.a[A_0];
        }

        public void a(tKey A_0, tValue A_1)
        {
            if (!this.a.ContainsKey(A_0))
            {
                this.a.Add(A_0, A_1);
            }
            else
            {
                this.a[A_0] = A_1;
            }
        }

        public void b(tKey A_0)
        {
            this.a.Remove(A_0);
        }

        public bool c(tKey A_0)
        {
            return this.a.ContainsKey(A_0);
        }

        public class THEnumerator : IEnumerator
        {
            private IDictionaryEnumerator a;

            public THEnumerator(Hashtable A_0)
            {
                this.a = A_0.GetEnumerator();
            }

            public void a()
            {
                this.a.Reset();
            }

            public bool c()
            {
                return this.a.MoveNext();
            }

            [__DynamicallyInvokable]
            public object System.Collections.IEnumerator.Current
            {
                get
                {
                    return new KeyValuePair<tKey, tValue>((tKey) this.a.Key, (tValue) this.a.Value);
                }
            }
        }
    }
}

