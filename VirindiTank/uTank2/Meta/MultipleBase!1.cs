namespace uTank2.Meta
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using uTank2;
    using VirindiViewService;
    using VirindiViewService.Controls;

    internal abstract class MultipleBase<T> : b1 where T: b1
    {
        protected List<T> a;
        protected HudView b;
        private HudList c;
        private HudFixedLayout d;
        private HudFixedLayout e;
        private HudCombo f;
        private List<int> g;
        private b1 h;

        protected MultipleBase()
        {
            this.a = new List<T>();
            this.g = new List<int>();
        }

        private void a()
        {
            int num = this.c.get_ScrollPosition();
            this.c.ClearRows();
            foreach (T local in this.a)
            {
                HudList.HudListRowAccessor accessor = this.c.AddRow();
                ((HudPictureBox) accessor.get_Item(0)).set_Image(new ACImage(0x60011f8));
                ((HudStaticText) accessor.get_Item(1)).set_Text(local.k());
            }
            this.c.set_ScrollPosition(num);
        }

        private static string a(b1 A_0)
        {
            if (A_0 == null)
            {
                return "";
            }
            return (MultipleBase<T>.a(A_0.b()) + " > " + A_0.g());
        }

        public void a(k A_0)
        {
            this.a.Clear();
            a0 a = A_0.c() as a0;
            if (a != null)
            {
                foreach (v v in a.d())
                {
                    T item = cl.Create<T>(k.e(v[0]));
                    item.h(v[1]);
                    item.a(this);
                    this.a.Add(item);
                }
            }
        }

        public void a(object A_0)
        {
            HudFixedLayout layout = A_0 as HudFixedLayout;
            if (layout != null)
            {
                this.c = new HudList();
                layout.AddControl(this.c, new Rectangle(0, 0, 300, 0x146));
                this.c.AddColumn(typeof(HudPictureBox), 0x10, "clx");
                this.c.AddColumn(typeof(HudStaticText), 0x270f, "cln");
                this.a();
                this.c.add_Click(new HudList.delClickedControl(this, (IntPtr) this.a));
                this.g.Clear();
                this.f = new HudCombo(layout.get_Group());
                layout.AddControl(this.f, new Rectangle(4, 330, 150, 0x10));
                foreach (int num in cl.GetTypeIDs<T>())
                {
                    this.g.Add(num);
                    this.f.AddItem(cl.Create<T>(num).g(), null);
                }
                HudButton button = new HudButton();
                layout.AddControl(button, new Rectangle(0x9e, 330, 100, 0x10));
                button.set_Text("Add...");
                button.add_Hit(new EventHandler(this.b));
            }
        }

        private void a(object A_0, EventArgs A_1)
        {
            if (this.b != null)
            {
                this.b.Dispose();
                this.b = null;
            }
        }

        private void a(object A_0, int A_1, int A_2)
        {
            if ((A_1 >= 0) && (A_1 < this.a.Count))
            {
                switch (A_2)
                {
                    case 0:
                        this.a.RemoveAt(A_1);
                        this.a();
                        PluginCore.cq.@as.d();
                        if (this.h != null)
                        {
                            this.h.c();
                        }
                        return;

                    case 1:
                    {
                        if (this.b != null)
                        {
                            this.b.Dispose();
                        }
                        T local = this.a[A_1];
                        this.b = new HudView("Edit " + MultipleBase<T>.a((b1) local), 300, 0x176, new ACImage(Color.Red));
                        this.b.set_UserMinimizable(false);
                        this.b.set_UserGhostable(false);
                        this.b.LoadUserSettings();
                        this.b.set_Visible(true);
                        this.d = new HudFixedLayout();
                        this.b.get_Controls().set_HeadControl(this.d);
                        HudButton button = new HudButton();
                        this.d.AddControl(button, new Rectangle(4, 0x162, 150, 0x10));
                        button.set_Text("Close");
                        button.add_Hit(new EventHandler(this.a));
                        this.e = new HudFixedLayout();
                        this.d.AddControl(this.e, new Rectangle(0, 0, 300, 350));
                        local.j(this.e);
                        return;
                    }
                }
            }
        }

        public void b(b1 A_0)
        {
            this.h = A_0;
        }

        private void b(object A_0, EventArgs A_1)
        {
            if ((this.f.get_Current() >= 0) && (this.f.get_Current() < this.g.Count))
            {
                int v = this.g[this.f.get_Current()];
                T item = cl.Create<T>(v);
                item.a(this);
                this.a.Add(item);
                this.a();
                PluginCore.cq.@as.d();
                if (this.h != null)
                {
                    this.h.c();
                }
            }
        }

        public k d()
        {
            a0 a = new a0(new string[] { "K", "V" });
            foreach (T local in this.a)
            {
                v v = new v(a);
                v[0] = k.a(cl.GetTypeIDForClass<T>(local));
                v[1] = local.i();
                a.c(v);
            }
            return new k(a);
        }

        public void e()
        {
            this.a();
            if (this.h != null)
            {
                this.h.c();
            }
        }

        public b1 f()
        {
            return this.h;
        }

        public abstract string g();
        public string h()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.g());
            builder.Append(": {");
            bool flag = true;
            foreach (T local in this.a)
            {
                if (flag)
                {
                    flag = false;
                }
                else
                {
                    builder.Append(", ");
                }
                builder.Append(local.k());
            }
            builder.Append("}");
            return builder.ToString();
        }

        public List<string> j()
        {
            List<string> list = new List<string>();
            foreach (T local in this.a)
            {
                List<string> collection = local.a();
                if (collection != null)
                {
                    list.AddRange(collection);
                }
            }
            return list;
        }
    }
}

