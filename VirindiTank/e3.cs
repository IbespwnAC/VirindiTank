using Decal.Adapter;
using Decal.Adapter.Wrappers;
using Decal.Interop.Core;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

internal class e3 : dq
{
    private static PluginHost a;
    private static bool b = true;
    private static ulong c = 0L;
    private static ulong d = 0L;
    private static List<e3> e = new List<e3>();
    private static e3.a f;
    private ulong g;
    private ulong h;
    private bool i;
    private Timer j = new Timer();
    private EventHandler k;

    public e3()
    {
        if (b)
        {
            throw new Exception("MyTimer class must be statically initialized before any timers can be created.");
        }
        this.j.Tick += new EventHandler(this.a);
        this.h = a();
        e.Add(this);
    }

    public static ulong a()
    {
        return d;
    }

    public void a(bool A_0)
    {
        this.j.Enabled = A_0;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void a(EventHandler A_0)
    {
        this.k = (EventHandler) Delegate.Combine(this.k, A_0);
    }

    public void a(int A_0)
    {
        this.j.Interval = A_0;
    }

    public static void a(PluginHost A_0, e3.a A_1)
    {
        if (b)
        {
            b = false;
            a = A_0;
            f = A_1;
            c = 0L;
            d += (ulong) 1L;
            a.get_Underlying().get_Hooks().add_RenderPreUI(new IACHooksEvents_RenderPreUIEventHandler(null, (UIntPtr) c));
            CoreManager.get_Current().add_PluginTermComplete(new EventHandler<EventArgs>(e3.b));
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
        if (b || (this.h != a()))
        {
            if (this.j != null)
            {
                this.j.Stop();
                this.j.Dispose();
                this.j = null;
            }
        }
        else if (this.g != c)
        {
            this.g = c;
            if (this.k != null)
            {
                try
                {
                    this.k(this, null);
                }
                catch (Exception exception)
                {
                    if (f != null)
                    {
                        f(exception);
                    }
                }
                finally
                {
                    GC.WaitForPendingFinalizers();
                }
            }
        }
    }

    public static ulong b()
    {
        return c;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void b(EventHandler A_0)
    {
        this.k = (EventHandler) Delegate.Remove(this.k, A_0);
    }

    private static void b(object A_0, EventArgs A_1)
    {
        b = true;
        List<e3> list = new List<e3>();
        foreach (e3 e in e3.e)
        {
            list.Add(e);
        }
        foreach (e3 e2 in list)
        {
            e2.e();
        }
        e3.e.Clear();
        CoreManager.get_Current().remove_PluginTermComplete(new EventHandler<EventArgs>(e3.b));
        a = null;
        f = null;
    }

    private static void c()
    {
        c += (ulong) 1L;
    }

    public void d()
    {
        this.j.Start();
    }

    public void e()
    {
        if (!this.i)
        {
            this.i = true;
            if (this.j != null)
            {
                this.j.Stop();
                this.j.Dispose();
                this.j = null;
            }
            if (e.Contains(this))
            {
                e.Remove(this);
            }
        }
    }

    public void f()
    {
        this.j.Stop();
    }

    public bool g()
    {
        return this.j.Enabled;
    }

    public int h()
    {
        return this.j.Interval;
    }

    public delegate void a(Exception A_0);
}

