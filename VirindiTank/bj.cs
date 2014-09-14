using MetaViewWrappers;
using System;
using System.Collections.Generic;
using System.Drawing;
using uTank2;

internal class bj : IDisposable
{
    private bool a;
    private ITextBox b;
    private IStaticText c;
    private IList d;
    private IList e;
    private IView f;
    private List<eSettingCategories> g = new List<eSettingCategories>();
    private bool h;
    private eSettingValueType i = eSettingValueType.tEnum;
    private bool j;
    private int k = -1;

    private void a()
    {
        if (this.k != -1)
        {
            this.d[this.k][0].ResetColor();
            this.k = -1;
            this.c.Text = string.Empty;
            this.b.Text = string.Empty;
            this.j = false;
        }
    }

    public void a(bool A_0)
    {
        if (this.h != A_0)
        {
            this.h = A_0;
            if (A_0)
            {
                this.i = eSettingValueType.tEnum;
                this.j = false;
                this.k = -1;
                this.f = ff.f(PluginCore.cq.ax, "uTank2.ViewXML.AdvancedOptionsView.xml");
                this.d = (IList) this.f["lOptionList"];
                this.c = (IStaticText) this.f["txtInfo"];
                this.b = (ITextBox) this.f["txtEditbox"];
                this.e = (IList) this.f["lFilterList"];
                this.g.Clear();
                foreach (string str in Enum.GetNames(typeof(eSettingCategories)))
                {
                    IListRow row = this.e.Add();
                    row[0][0] = false;
                    row[1][0] = str;
                    this.g.Add((eSettingCategories) Enum.Parse(typeof(eSettingCategories), str));
                }
                this.b();
                this.e.Click += new dClickedList(this.b);
                this.d.Click += new dClickedList(this.a);
                this.b.Change_Old += new EventHandler(this.a);
                this.f.Visible = true;
            }
            else
            {
                this.e.Click -= new dClickedList(this.b);
                this.d.Click -= new dClickedList(this.a);
                this.b.Change_Old -= new EventHandler(this.a);
                this.d = null;
                this.c = null;
                this.b = null;
                this.e = null;
                this.f.Dispose();
                this.f = null;
            }
        }
    }

    private void a(int A_0)
    {
        int k = this.k;
        this.a();
        if (k != A_0)
        {
            this.j = false;
            this.k = A_0;
            this.d[this.k][0].Color = Color.BlueViolet;
            string str = er.c((string) this.d[this.k][0][0]);
            if (string.IsNullOrEmpty(str))
            {
                this.c.Text = "[No Description]";
            }
            else
            {
                this.c.Text = str;
            }
            string str2 = (string) this.d[this.k][0][0];
            this.i = er.b(str2);
            switch (this.i)
            {
                case eSettingValueType.tDouble:
                    this.j = true;
                    this.b.Text = er.h(str2).ToString();
                    return;

                case eSettingValueType.tInt:
                    this.j = true;
                    this.b.Text = er.i(str2).ToString();
                    break;

                default:
                    return;
            }
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
        try
        {
            if (!this.j)
            {
                this.b.Text = string.Empty;
            }
            else
            {
                switch (this.i)
                {
                    case eSettingValueType.tDouble:
                        goto Label_00CB;

                    case eSettingValueType.tInt:
                        try
                        {
                            int num = Convert.ToInt32(this.b.Text);
                            er.b((string) this.d[this.k][0][0], k.a(num));
                            this.d[this.k][1][0] = er.i((string) this.d[this.k][0][0]);
                        }
                        catch (Exception)
                        {
                        }
                        break;
                }
            }
            return;
        Label_00CB:
            try
            {
                double num2 = Convert.ToDouble(this.b.Text);
                er.b((string) this.d[this.k][0][0], k.a(num2));
                this.d[this.k][1][0] = er.h((string) this.d[this.k][0][0]).ToString();
            }
            catch (Exception)
            {
                return;
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    private void a(object A_0, int A_1, int A_2)
    {
        try
        {
            if (A_2 == 0)
            {
                this.a(A_1);
            }
            else if (A_2 == 1)
            {
                string str = (string) this.d[A_1][0][0];
                switch (er.b(str))
                {
                    case eSettingValueType.tBool:
                    {
                        bool flag = er.j(str);
                        er.b(str, k.a(!flag));
                        return;
                    }
                    case eSettingValueType.tDouble:
                    case eSettingValueType.tInt:
                        this.a(A_1);
                        return;

                    case eSettingValueType.tSingle:
                    case eSettingValueType.tString:
                        return;

                    case eSettingValueType.tEnum:
                    {
                        int num = er.e(str);
                        num = er.a(str, num);
                        er.b(str, k.a(num));
                        return;
                    }
                }
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    private void b()
    {
        this.a();
        this.d.Clear();
        eSettingCategories categories = 0;
        for (int i = 0; i < this.g.Count; i++)
        {
            if ((bool) this.e[i][0][0])
            {
                categories |= (eSettingCategories) this.g[i];
            }
        }
        foreach (string str in er.a(categories))
        {
            switch (er.b(str))
            {
                case eSettingValueType.tBool:
                {
                    bool flag = er.j(str);
                    IListRow row = this.d.AddRow();
                    row[0][0] = str;
                    row[1][0] = flag.ToString();
                    break;
                }
                case eSettingValueType.tDouble:
                {
                    double num4 = er.h(str);
                    IListRow row4 = this.d.AddRow();
                    row4[0][0] = str;
                    row4[1][0] = num4.ToString();
                    break;
                }
                case eSettingValueType.tInt:
                {
                    int num3 = er.i(str);
                    IListRow row3 = this.d.AddRow();
                    row3[0][0] = str;
                    row3[1][0] = num3.ToString();
                    break;
                }
                case eSettingValueType.tEnum:
                {
                    int num2 = er.e(str);
                    IListRow row2 = this.d.AddRow();
                    row2[0][0] = str;
                    row2[1][0] = er.b(str, num2);
                    break;
                }
            }
        }
    }

    private void b(object A_0, int A_1, int A_2)
    {
        this.b();
    }

    public void c()
    {
        if (!this.a)
        {
            this.a = true;
            GC.SuppressFinalize(this);
            this.a(false);
        }
    }

    public void d()
    {
        if (this.f())
        {
            for (int i = 0; i < this.d.RowCount; i++)
            {
                string str = (string) this.d[i][0][0];
                switch (er.b(str))
                {
                    case eSettingValueType.tBool:
                        this.d[i][1][0] = er.j(str).ToString();
                        break;

                    case eSettingValueType.tDouble:
                        this.d[i][1][0] = er.h(str).ToString();
                        break;

                    case eSettingValueType.tInt:
                        this.d[i][1][0] = er.i(str).ToString();
                        break;

                    case eSettingValueType.tEnum:
                        string str2;
                        try
                        {
                            str2 = er.b(str, er.e(str));
                        }
                        catch (Exception)
                        {
                            str2 = "UNK??";
                        }
                        this.d[i][1][0] = str2;
                        break;
                }
            }
        }
    }

    protected override void e()
    {
        try
        {
            this.c();
        }
        finally
        {
            base.Finalize();
        }
    }

    public bool f()
    {
        return this.h;
    }
}

