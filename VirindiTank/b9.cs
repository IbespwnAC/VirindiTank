using MetaViewWrappers;
using System;
using System.Collections;
using System.Collections.Generic;
using uTank2;

internal class b9 : IDisposable
{
    private bool a;
    private List<MySpell> b;
    private List<MySpell> c = new List<MySpell>();
    private IView d;
    private IList e;
    private ITextBox f;
    private bool g;

    public b9()
    {
        PluginCore.PC.ProfileChanged += new PluginCore.EmptyDelegate(this.a);
    }

    private void a()
    {
        if (this.f())
        {
            this.b();
        }
    }

    public void a(bool A_0)
    {
        if (this.g == A_0)
        {
            if (this.g)
            {
                this.d.Visible = true;
            }
        }
        else
        {
            this.g = A_0;
            if (A_0)
            {
                this.c();
                this.d = ff.f(PluginCore.cq.ax, "uTank2.ViewXML.SelfBuffChoiceView.xml");
                this.d.Title = "Virindi Tank - Choose Blacklisted Buffs";
                this.e = (IList) this.d["lExemplarList"];
                this.f = (ITextBox) this.d["txtSearch"];
                this.f.Text = "";
                this.b();
                this.f.Change += new EventHandler<MVTextBoxChangeEventArgs>(this.a);
                this.e.Click += new dClickedList(this.a);
                this.d.Visible = true;
            }
            else
            {
                this.d.Dispose();
                this.d = null;
            }
        }
    }

    private void a(object A_0, MVTextBoxChangeEventArgs A_1)
    {
        this.b();
    }

    private void a(object A_0, int A_1, int A_2)
    {
        PluginCore.cq.l.j.Add(this.c[A_1].Id);
        PluginCore.cq.l.d();
        er.a();
    }

    private void b()
    {
        int scrollPosition = this.e.ScrollPosition;
        string str = this.f.Text.ToLowerInvariant();
        this.e.Clear();
        this.c.Clear();
        if (string.IsNullOrEmpty(str))
        {
            foreach (MySpell spell in this.b)
            {
                if (!PluginCore.cq.l.j.Contains(spell.Id))
                {
                    this.e.AddRow()[0][0] = spell.FriendlyName;
                    this.c.Add(spell);
                }
            }
        }
        else
        {
            foreach (MySpell spell2 in this.b)
            {
                string friendlyName = spell2.FriendlyName;
                if (friendlyName.ToLowerInvariant().Contains(str) && !PluginCore.cq.l.j.Contains(spell2.Id))
                {
                    this.e.AddRow()[0][0] = friendlyName;
                    this.c.Add(spell2);
                }
            }
        }
        this.e.ScrollPosition = scrollPosition;
    }

    private void c()
    {
        if (this.b == null)
        {
            this.b = new List<MySpell>();
            Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
            using (IEnumerator enumerator = PluginCore.cq.e.c())
            {
                while (enumerator.MoveNext())
                {
                    MySpell current = (MySpell) enumerator.Current;
                    if ((!dictionary.ContainsKey(current.RealFamily) && current.isUntargetted) && ((current.Duration >= 1.0) && !current.isOffensive))
                    {
                        this.b.Add(current);
                        dictionary.Add(current.RealFamily, false);
                    }
                }
            }
        }
    }

    public void d()
    {
        if (!this.a)
        {
            this.a = true;
            GC.SuppressFinalize(this);
            this.a(false);
        }
    }

    protected override void e()
    {
        try
        {
        }
        finally
        {
            base.Finalize();
        }
    }

    public bool f()
    {
        return this.g;
    }
}

