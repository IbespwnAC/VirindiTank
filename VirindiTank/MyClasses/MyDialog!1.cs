namespace MyClasses
{
    using Decal.Adapter.Wrappers;
    using MetaViewWrappers;
    using MetaViewWrappers.VirindiViewServiceHudControls;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using VirindiViewService;

    internal abstract class MyDialog<T> : IDisposable
    {
        protected IView a;
        private string b;
        protected IView c;
        private bool d;
        private delDialogReturned<T> e;

        protected MyDialog(string A_0, IView A_1)
        {
            this.b = A_0;
            this.c = A_1;
        }

        protected abstract string a();
        protected bool a(PluginHost A_0)
        {
            if (cn.a(this.b))
            {
                this.d = true;
                GC.SuppressFinalize(this);
                return false;
            }
            cn.b();
            cn.a(this.b, this, new cn.a(this.c));
            this.a = ff.c(A_0, this.a());
            this.a.Visible = true;
            Rectangle rectangle = A_0.get_Actions().get_RegionWindow();
            int x = (rectangle.Width - this.a.Size.Width) / 2;
            int y = (rectangle.Height - this.a.Size.Height) / 2;
            this.a.Location = new Point(x, y);
            if (this.a is View)
            {
                this.b();
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void a(delDialogReturned<T> A_0)
        {
            this.e = (delDialogReturned<T>) Delegate.Remove(this.e, A_0);
        }

        protected void a(string A_0, T A_1)
        {
            if (this.e != null)
            {
                this.e(A_0, A_1);
            }
            this.c();
            if (this.c != null)
            {
                this.c.Visible = true;
            }
        }

        private void b()
        {
            HudView underlying = ((View) this.a).Underlying;
            underlying.set_UserMinimizable(false);
            underlying.set_UserGhostable(false);
            underlying.set_UserAlphaChangeable(false);
            underlying.set_ShowInBar(false);
            underlying.set_ForcedZOrder(10);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void b(delDialogReturned<T> A_0)
        {
            this.e = (delDialogReturned<T>) Delegate.Combine(this.e, A_0);
        }

        public virtual void c()
        {
            if (!this.d)
            {
                this.d = true;
                GC.SuppressFinalize(this);
                cn.a(this.b, this);
                this.e();
                if (this.a != null)
                {
                    this.a.Dispose();
                    this.a = null;
                }
            }
        }

        protected override void d()
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

        protected virtual void e()
        {
        }

        public delegate void delDialogReturned(string A_0, T A_1);
    }
}

