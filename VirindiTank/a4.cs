using System;
using System.Globalization;
using System.IO;
using uTank2;

internal class a4
{
    public const string a = "uTank2 NAV 1.2";
    public MyList<ef> b = new MyList<ef>(0x19);
    public eNavType c = eNavType.Circular;
    public int d = 0;
    public string e = "";
    private bool f;

    public void a()
    {
        foreach (ef ef in this.b)
        {
            ef.Dispose();
        }
        this.b.Clear();
        PluginCore.cq.n.l = 0;
    }

    public void a(bool A_0)
    {
        if (A_0 != this.f)
        {
            if (!A_0)
            {
                PluginCore.cq.l.g();
                PluginCore.cq.ay.ak();
                PluginCore.cq.n.c();
            }
            this.f = A_0;
        }
    }

    public void a(int A_0)
    {
        if ((A_0 >= 0) && (A_0 < PluginCore.cq.l.k.b.Count))
        {
            this.b[A_0].Dispose();
            this.b.RemoveAt(A_0);
            if (!this.d())
            {
                PluginCore.cq.l.g();
                PluginCore.cq.ay.ak();
                PluginCore.cq.n.c();
            }
        }
    }

    public bool a(TextReader A_0)
    {
        this.b();
        if (A_0.ReadLine() != "uTank2 NAV 1.2")
        {
            a5.a(eChatType.Errors, "Nav file version does not match current plugin version.");
            return false;
        }
        switch (Convert.ToInt32(A_0.ReadLine(), CultureInfo.InvariantCulture))
        {
            case 1:
                this.c = eNavType.Circular;
                break;

            case 2:
                this.c = eNavType.Linear;
                break;

            case 3:
                this.c = eNavType.Target;
                break;

            case 4:
                this.c = eNavType.Once;
                break;
        }
        if (this.c == eNavType.Target)
        {
            this.e = A_0.ReadLine();
            this.d = Convert.ToInt32(A_0.ReadLine(), CultureInfo.InvariantCulture);
            if (this.d != 0)
            {
                this.b.Add(new cg(this.d, PluginCore.cq));
            }
        }
        else
        {
            int num2 = Convert.ToInt32(A_0.ReadLine(), CultureInfo.InvariantCulture);
            for (int i = 0; i < num2; i++)
            {
                ef ef;
                int num4 = Convert.ToInt32(A_0.ReadLine(), CultureInfo.InvariantCulture);
                sCoord coord = new sCoord {
                    x = Convert.ToDouble(A_0.ReadLine(), CultureInfo.InvariantCulture),
                    y = Convert.ToDouble(A_0.ReadLine(), CultureInfo.InvariantCulture),
                    z = Convert.ToDouble(A_0.ReadLine(), CultureInfo.InvariantCulture)
                };
                A_0.ReadLine();
                switch (num4)
                {
                    case 0:
                        ef = new d5(coord);
                        ef.e(A_0);
                        this.b.Add(ef);
                        break;

                    case 1:
                        ef = new fv(coord);
                        ef.e(A_0);
                        this.b.Add(ef);
                        break;

                    case 2:
                        ef = new fd(coord);
                        ef.e(A_0);
                        this.b.Add(ef);
                        break;

                    case 3:
                        ef = new i(coord);
                        ef.e(A_0);
                        this.b.Add(ef);
                        break;

                    case 4:
                        ef = new n(coord);
                        ef.e(A_0);
                        this.b.Add(ef);
                        break;

                    case 5:
                        ef = new af(coord);
                        ef.e(A_0);
                        this.b.Add(ef);
                        break;

                    case 6:
                        ef = new c2(coord);
                        ef.e(A_0);
                        this.b.Add(ef);
                        break;
                }
            }
        }
        return true;
    }

    public void a(TextWriter A_0)
    {
        A_0.WriteLine("uTank2 NAV 1.2");
        int num = 0;
        switch (this.c)
        {
            case eNavType.Linear:
                num = 2;
                break;

            case eNavType.Circular:
                num = 1;
                break;

            case eNavType.Target:
                num = 3;
                break;

            case eNavType.Once:
                num = 4;
                break;
        }
        A_0.WriteLine(Convert.ToString(num, CultureInfo.InvariantCulture));
        if (this.c == eNavType.Target)
        {
            A_0.WriteLine(this.e);
            A_0.WriteLine(Convert.ToString(this.d, CultureInfo.InvariantCulture));
        }
        else
        {
            A_0.WriteLine(Convert.ToString(this.b.Count, CultureInfo.InvariantCulture));
            foreach (ef ef in this.b)
            {
                A_0.WriteLine(Convert.ToString((int) ef.a(), CultureInfo.InvariantCulture));
                A_0.WriteLine(Convert.ToString(ef.e().x, CultureInfo.InvariantCulture));
                A_0.WriteLine(Convert.ToString(ef.e().y, CultureInfo.InvariantCulture));
                A_0.WriteLine(Convert.ToString(ef.e().z, CultureInfo.InvariantCulture));
                A_0.WriteLine(Convert.ToString((double) 0.0, (IFormatProvider) CultureInfo.InvariantCulture));
                ef.f(A_0);
            }
        }
    }

    public bool a(string A_0)
    {
        try
        {
            StreamWriter writer = new StreamWriter(Path.Combine(PluginCore.ci, A_0), false);
            this.a(writer);
            writer.Close();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void a(eNavType A_0)
    {
        if ((A_0 == eNavType.Target) && (((this.c == eNavType.Circular) || (this.c == eNavType.Linear)) || (this.c == eNavType.Once)))
        {
            this.b();
        }
        else if ((this.c == eNavType.Target) && (((A_0 == eNavType.Circular) || (A_0 == eNavType.Linear)) || (A_0 == eNavType.Once)))
        {
            this.b();
        }
        this.c = A_0;
    }

    public void a(int A_0, string A_1)
    {
        this.b();
        this.d = A_0;
        this.e = A_1;
        this.c = eNavType.Target;
        this.b.Add(new cg(this.d, PluginCore.cq));
    }

    public void a(sCoord A_0, int A_1)
    {
        int index = A_1;
        if (index < 0)
        {
            index = 0;
        }
        if (index > this.b.Count)
        {
            index = this.b.Count;
        }
        this.b.Insert(index, new d5(A_0));
        if (!this.d())
        {
            PluginCore.cq.l.g();
            PluginCore.cq.ay.ak();
            PluginCore.cq.n.c();
        }
    }

    public void a(int A_0, eWaypointType A_1, sCoord A_2, int A_3)
    {
        if ((A_0 >= 0) && (A_0 < this.b.Count))
        {
            bool flag = false;
            switch (A_1)
            {
                case eWaypointType.Point:
                    PluginCore.cq.l.k.b[A_0].Dispose();
                    PluginCore.cq.l.k.b[A_0] = new d5(A_2);
                    flag = true;
                    break;

                case eWaypointType.Portal:
                    PluginCore.cq.l.k.b[A_0].Dispose();
                    PluginCore.cq.l.k.b[A_0] = new fv(A_2, A_3);
                    flag = true;
                    break;

                case eWaypointType.Recall:
                    PluginCore.cq.l.k.b[A_0].Dispose();
                    PluginCore.cq.l.k.b[A_0] = new fd(A_2, A_3);
                    flag = true;
                    break;
            }
            if (flag && !this.d())
            {
                PluginCore.cq.l.g();
                PluginCore.cq.ay.ak();
                PluginCore.cq.n.c();
            }
        }
    }

    public void b()
    {
        this.a();
        this.c = eNavType.Circular;
        this.e = "";
        this.d = 0;
        PluginCore.cq.n.m = false;
    }

    public bool b(string A_0)
    {
        this.b();
        try
        {
            string path = Path.Combine(PluginCore.ci, A_0);
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                bool flag = this.a(reader);
                reader.Close();
                PluginCore.cq.n.c();
                return flag;
            }
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public int c()
    {
        return this.b.Count;
    }

    public bool d()
    {
        return this.f;
    }
}

