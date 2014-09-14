using System;
using System.Collections.Generic;
using System.IO;
using uTank2;
using VirindiHotkeySystem;

internal class h : IDisposable
{
    public const string a = "Default";
    private string b = "";
    public SortedDictionary<string, List<d8>> c = new SortedDictionary<string, List<d8>>();
    public Dictionary<d8, bool> d = new Dictionary<d8, bool>();
    public Dictionary<string, object> e = new Dictionary<string, object>();
    private string f = "Default";
    public DateTimeOffset g = DateTimeOffset.Now;
    public DateTimeOffset h = DateTimeOffset.Now;
    public Stack<string> i = new Stack<string>();

    public h()
    {
        a2.g();
    }

    private void a()
    {
        bf bf = new bf();
        bf.b(Path.Combine(PluginCore.ci, this.j()));
        this.c.Clear();
        if (!bf.ContainsKey("CondAct"))
        {
            a5.a(eChatType.Errors, "Meta file load: DB format invalid.");
            this.c.Clear();
        }
        else
        {
            a0 a = bf["CondAct"];
            for (int i = 0; i < a.c(); i++)
            {
                fl fl = cl.a((c3) k.e(a.d()[i][0]));
                b3 b = cl.a((ep) k.e(a.d()[i][1]));
                if ((b == null) || (fl == null))
                {
                    a5.a(eChatType.Errors, "Meta file load: unsupported cond/act type.");
                    this.c.Clear();
                    return;
                }
                fl.h(a.d()[i][2]);
                b.h(a.d()[i][3]);
                string key = k.b(a.d()[i][4]);
                if (!this.c.ContainsKey(key))
                {
                    this.c[key] = new List<d8>();
                }
                this.c[key].Add(new d8(fl, b, key));
            }
        }
    }

    public void a(d8 A_0)
    {
        if (this.c.ContainsKey(A_0.c))
        {
            List<d8> list = this.c[A_0.c];
            int index = list.IndexOf(A_0);
            if (index >= 0)
            {
                list.Remove(A_0);
                index++;
                if (index > list.Count)
                {
                    index = list.Count;
                }
                list.Insert(index, A_0);
            }
        }
    }

    public void a(string A_0)
    {
        this.d.Clear();
        this.f = A_0;
        this.g = DateTimeOffset.Now;
        this.h = DateTimeOffset.Now;
        a5.a(eChatType.CommandLine, "Meta transitioning to state: " + A_0);
        l.a(this.f);
    }

    public void a(d8 A_0, string A_1)
    {
        if (this.c.ContainsKey(A_0.c))
        {
            this.c[A_0.c].Remove(A_0);
            if (this.c[A_0.c].Count == 0)
            {
                this.c.Remove(A_0.c);
            }
            A_0.c = A_1;
            this.c(A_0);
            if (this.d.ContainsKey(A_0))
            {
                this.d.Remove(A_0);
            }
        }
    }

    private void a(object A_0, VHotkeyInfo.cEatableFiredEventArgs A_1)
    {
        VHotkeyInfo info = A_0 as VHotkeyInfo;
        if (info != null)
        {
            string str = info.get_HotkeyName().Substring(6);
            this.a(str);
            PluginCore.PC.v();
            A_1.Eat = true;
        }
    }

    private void b()
    {
        SortedDictionary<string, int> dictionary = this.g();
        dictionary["Default"] = 0x270f;
        List<string> list = new List<string>();
        foreach (KeyValuePair<string, object> pair in this.e)
        {
            if (!dictionary.ContainsKey(pair.Key))
            {
                VHotkeyInfo info = pair.Value as VHotkeyInfo;
                if (info != null)
                {
                    VHotkeySystem.get_InstanceReal().RemoveHotkey(info);
                    list.Add(pair.Key);
                }
            }
        }
        foreach (string str in list)
        {
            this.e.Remove(str);
        }
        foreach (KeyValuePair<string, int> pair2 in dictionary)
        {
            if (!this.e.ContainsKey(pair2.Key))
            {
                VHotkeyInfo info2 = new VHotkeyInfo("VTank", true, "Meta: " + pair2.Key, "Activates the meta state \"" + pair2.Key + "\"", 0, false, false, false);
                VHotkeySystem.get_InstanceReal().AddHotkey(info2);
                this.e[pair2.Key] = info2;
                info2.add_Fired2(new EventHandler<VHotkeyInfo.cEatableFiredEventArgs>(this.a));
            }
        }
    }

    public void b(d8 A_0)
    {
        if (this.c.ContainsKey(A_0.c))
        {
            List<d8> list = this.c[A_0.c];
            int index = list.IndexOf(A_0);
            if (index >= 0)
            {
                list.Remove(A_0);
                index--;
                if (index < 0)
                {
                    index = 0;
                }
                list.Insert(index, A_0);
            }
        }
    }

    public void b(string A_0)
    {
        PluginCore.cq.at.g();
        this.b = A_0;
        if (string.IsNullOrEmpty(A_0))
        {
            this.i();
        }
        else
        {
            if (!File.Exists(Path.Combine(PluginCore.ci, A_0)))
            {
                this.i();
                this.k();
            }
            this.a();
        }
        this.c();
        l.a(this.f);
        this.m();
        PluginCore.PC.i();
        PluginCore.PC.v();
        PluginCore.PC.ar();
    }

    private void c()
    {
        this.f = "Default";
        this.g = DateTimeOffset.Now;
        this.h = DateTimeOffset.Now;
        this.i.Clear();
    }

    public void c(d8 A_0)
    {
        if (!this.c.ContainsKey(A_0.c))
        {
            this.c[A_0.c] = new List<d8>();
        }
        this.c[A_0.c].Add(A_0);
    }

    public void c(string A_0)
    {
        this.f = A_0;
        this.h();
    }

    public void d()
    {
        this.k();
        this.m();
        PluginCore.PC.v();
    }

    public void d(d8 A_0)
    {
        if (this.c.ContainsKey(A_0.c))
        {
            this.c[A_0.c].Remove(A_0);
            if (this.c[A_0.c].Count == 0)
            {
                this.c.Remove(A_0.c);
            }
            SortedDictionary<string, int> dictionary = this.g();
            dictionary["Default"] = 0x270f;
            if (!dictionary.ContainsKey(this.f))
            {
                a5.a(eChatType.CommandLine, "Deleted the last rule that referenced state \"" + this.f + "\". Changing current state to Default.");
                this.a("Default");
            }
        }
    }

    public void d(string A_0)
    {
        this.b = A_0;
        PluginCore.PC.ar();
    }

    public void e()
    {
        string f = this.f;
        bool flag = false;
        if (this.c.ContainsKey(f))
        {
            foreach (d8 d in this.c[f])
            {
                if ((!this.d.ContainsKey(d) && string.Equals(this.f, d.c)) && d.a.h())
                {
                    a5.a(eChatType.CommandLine, "Meta executing action: " + d.b.k());
                    this.d[d] = true;
                    flag = true;
                    bool flag2 = !d.b.e();
                    if ((f != this.f) || flag2)
                    {
                        break;
                    }
                }
            }
            if (flag)
            {
                PluginCore.PC.v();
            }
        }
    }

    public void e(string A_0)
    {
        this.b(A_0);
        PluginCore.cq.l.r();
    }

    public string f()
    {
        return this.f;
    }

    public SortedDictionary<string, int> g()
    {
        SortedDictionary<string, int> dictionary = new SortedDictionary<string, int>();
        foreach (KeyValuePair<string, List<d8>> pair in this.c)
        {
            foreach (d8 d in pair.Value)
            {
                List<string> list = d.a.a();
                if (list != null)
                {
                    foreach (string str in list)
                    {
                        if (dictionary.ContainsKey(str))
                        {
                            SortedDictionary<string, int> dictionary2;
                            string str3;
                            (dictionary2 = dictionary)[str3 = str] = dictionary2[str3] + 1;
                        }
                        else
                        {
                            dictionary[str] = 1;
                        }
                    }
                }
                list = d.b.a();
                if (list != null)
                {
                    foreach (string str2 in list)
                    {
                        if (dictionary.ContainsKey(str2))
                        {
                            SortedDictionary<string, int> dictionary3;
                            string str4;
                            (dictionary3 = dictionary)[str4 = str2] = dictionary3[str4] + 1;
                        }
                        else
                        {
                            dictionary[str2] = 1;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(d.c))
                {
                    if (dictionary.ContainsKey(d.c))
                    {
                        SortedDictionary<string, int> dictionary4;
                        string str5;
                        (dictionary4 = dictionary)[str5 = d.c] = dictionary4[str5] + 1;
                    }
                    else
                    {
                        dictionary[d.c] = 1;
                    }
                }
            }
        }
        return dictionary;
    }

    public void h()
    {
        this.d.Clear();
    }

    public void i()
    {
        this.c.Clear();
    }

    public string j()
    {
        return this.b;
    }

    public void k()
    {
        if (!string.IsNullOrEmpty(this.j()))
        {
            bf bf = new bf();
            a0 a = new a0(new string[] { "CType", "AType", "CData", "AData", "State" });
            bf.Add("CondAct", a);
            foreach (KeyValuePair<string, List<d8>> pair in this.c)
            {
                foreach (d8 d in pair.Value)
                {
                    v v = new v(a);
                    v[0] = k.a((int) d.a.f());
                    v[1] = k.a((int) d.b.d());
                    v[2] = d.a.i();
                    v[3] = d.b.i();
                    v[4] = k.a(d.c);
                    a.c(v);
                }
            }
            bf.c(Path.Combine(PluginCore.ci, this.j()));
        }
    }

    public void l()
    {
        this.c.Clear();
        a2.f();
        this.e.Clear();
    }

    public void m()
    {
        if (cy.b())
        {
            this.b();
        }
    }
}

