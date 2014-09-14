using Decal.Filters;
using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using uTank2;

[DefaultMember("Item")]
internal class cd : IEnumerable, IDisposable
{
    public MyList<cd.c> a = new MyList<cd.c>(3);
    public MyDictionary<string, cd.c> b = new MyDictionary<string, cd.c>(4);
    public MyDictionary<int, cd.c> c = new MyDictionary<int, cd.c>(5);
    public MyDictionary<string, cd.c> d = new MyDictionary<string, cd.c>(6);
    public MyDictionary<cd.a, cd.c> e = new MyDictionary<cd.a, cd.c>(7);
    public MyDictionary<int, MyList<cd.c>> f = new MyDictionary<int, MyList<cd.c>>(8);
    public MyDictionary<int, cd.d> g = new MyDictionary<int, cd.d>(0x270f);
    private FileService h;
    private ev i;
    private bool j;
    private Regex k = new Regex("^Incantation of .* Arc$");

    public cd(FileService A_0, ev A_1)
    {
        this.h = A_0;
        this.i = A_1;
        for (int i = 0; i < A_0.get_ComponentTable().get_Length(); i++)
        {
            cd.d d;
            Component component = A_0.get_ComponentTable().get_Item(i);
            d = new cd.d {
                a = component.get_Id(),
                d = component.get_Type(),
                b = component.get_Word(),
                c = d.b.ToLowerInvariant(),
                e = component.get_Name()
            };
            this.g[d.a] = d;
        }
        for (int j = 0; j < A_0.get_SpellTable().get_Length(); j++)
        {
            Spell spell = A_0.get_SpellTable().get_Item(j);
            cd.c c = new cd.c {
                a = new MySpell.SchoolRetInfo(),
                h = new MyList<int>(9),
                b = spell.get_Name(),
                c = spell.get_Id(),
                d = spell.get_Family(),
                f = spell.get_Difficulty(),
                g = spell.get_Duration()
            };
            StringBuilder builder = new StringBuilder();
            for (int k = 0; k < spell.get_ComponentIDs().get_Length(); k++)
            {
                c.h.Add(spell.get_ComponentIDs().get_Item(k));
                if (this.g.ContainsKey(spell.get_ComponentIDs().get_Item(k)))
                {
                    try
                    {
                        builder.Append(this.g[spell.get_ComponentIDs().get_Item(k)].c);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            if (spell.get_School() == null)
            {
                c.a.Id = 5;
                c.a.Name = "Void Magic";
            }
            else
            {
                c.a.Id = spell.get_School().get_Id();
                c.a.Name = spell.get_School().get_Name();
            }
            if (c.b == "Curse of Raven Fury")
            {
                c.i = "tugakquati";
            }
            else
            {
                c.i = builder.ToString();
            }
            c.j = this.a(c);
            c.l = spell.get_IsUntargetted();
            c.k = spell.get_IsFellowship();
            c.m = spell.get_IsOffensive();
            c.e = this.b(c);
            if (!this.f.ContainsKey(c.e))
            {
                this.f.Add(c.e, new MyList<cd.c>(10));
            }
            this.f[c.e].Add(c);
            try
            {
                this.a.Add(c);
            }
            catch (Exception)
            {
            }
            try
            {
                if (!this.c.ContainsKey(c.c))
                {
                    this.c.Add(c.c, c);
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (!this.b.ContainsKey(c.b))
                {
                    this.b.Add(c.b, c);
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (!this.d.ContainsKey(c.i))
                {
                    this.d.Add(c.i, c);
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (!this.e.ContainsKey(c.j))
                {
                    this.e.Add(c.j, c);
                }
            }
            catch (Exception)
            {
            }
            spell = null;
        }
    }

    public void a()
    {
        if (!this.j)
        {
            this.j = true;
            GC.SuppressFinalize(this);
            this.h = null;
            this.i = null;
        }
    }

    private cd.a a(cd.c A_0)
    {
        cd.a a = new cd.a {
            a = 0,
            b = 0,
            c = 0,
            d = 0
        };
        for (int i = 0; i < A_0.h.Count; i++)
        {
            try
            {
                int key = A_0.h[i];
                if (this.g.ContainsKey(key))
                {
                    switch (this.g[key].d.get_Id())
                    {
                        case 1:
                        {
                            a.a = A_0.h[i];
                            continue;
                        }
                        case 2:
                        {
                            a.b = A_0.h[i];
                            continue;
                        }
                        case 3:
                        {
                            a.c = A_0.h[i];
                            continue;
                        }
                        case 4:
                        {
                            a.d = A_0.h[i];
                            continue;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        return a;
    }

    public cd.b a(int A_0)
    {
        if (this.f.ContainsKey(A_0))
        {
            return new cd.b(this.f[A_0], this.i);
        }
        return new cd.b(new MyList<cd.c>(0x270f), this.i);
    }

    public MySpell a(string A_0)
    {
        if (!this.b.ContainsKey(A_0))
        {
            throw new Exception("Expected spell name \"" + A_0 + "\" not in the spelltable.");
        }
        return new MySpell(this.b[A_0], this.i);
    }

    protected override void b()
    {
        try
        {
            this.a();
        }
        finally
        {
            base.Finalize();
        }
    }

    private int b(cd.c A_0)
    {
        if (A_0.b.Contains(" Arc "))
        {
            return (A_0.d + 0x186a0);
        }
        if (this.k.IsMatch(A_0.b))
        {
            return (A_0.d + 0x186a0);
        }
        if (A_0.b.Contains(" Hecatomb "))
        {
            return (A_0.d + 0x186a0);
        }
        return A_0.d;
    }

    public MySpell b(int A_0)
    {
        if (!this.c.ContainsKey(A_0))
        {
            return null;
        }
        return new MySpell(this.c[A_0], this.i);
    }

    public MySpell b(string A_0)
    {
        return new MySpell(this.d[A_0.ToLowerInvariant().Replace(" ", "")], this.i);
    }

    public IEnumerator c()
    {
        return new cd.e(this);
    }

    public bool c(int A_0)
    {
        return this.c.ContainsKey(A_0);
    }

    public MySpell d(int A_0)
    {
        return new MySpell(this.a[A_0], this.i);
    }

    public class a : IComparable
    {
        public int a;
        public int b;
        public int c;
        public int d;

        public int a(object A_0)
        {
            cd.a a = (cd.a) A_0;
            if (this.a != a.a)
            {
                return (this.a - a.a);
            }
            if (this.b != a.b)
            {
                return (this.b - a.b);
            }
            if (this.c != a.c)
            {
                return (this.c - a.c);
            }
            if (this.d != a.d)
            {
                return (this.d - a.d);
            }
            return 0;
        }
    }

    [DefaultMember("Item")]
    public class b : ReadOnlyCollectionBase
    {
        public b(IList A_0, ev A_1)
        {
            foreach (cd.c c in A_0)
            {
                base.InnerList.Add(new MySpell(c, A_1));
            }
        }

        public MySpell a(int A_0)
        {
            return (MySpell) base.InnerList[A_0];
        }

        public int a(object A_0)
        {
            return base.InnerList.IndexOf(A_0);
        }

        public bool b(object A_0)
        {
            return base.InnerList.Contains(A_0);
        }
    }

    public class c
    {
        public MySpell.SchoolRetInfo a;
        public string b;
        public int c;
        public int d;
        public int e;
        public int f;
        public double g;
        public MyList<int> h;
        public string i;
        public cd.a j;
        public bool k;
        public bool l;
        public bool m;
    }

    public class d
    {
        public int a;
        public string b;
        public string c;
        public ComponentType d;
        public string e;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct e : IEnumerator
    {
        private cd a;
        private int b;
        public e(cd A_0)
        {
            this.a = A_0;
            this.b = -1;
        }

        [__DynamicallyInvokable]
        public object System.Collections.IEnumerator.Current
        {
            get
            {
                return new MySpell(this.a.a[this.b], this.a.i);
            }
        }
        public bool c()
        {
            if (++this.b >= this.a.a.Count)
            {
                return false;
            }
            return true;
        }

        public void a()
        {
            this.b = -1;
        }
    }
}

