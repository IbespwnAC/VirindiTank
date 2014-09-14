using Decal.Adapter;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using uTank2;

internal class ar : IDisposable
{
    public Dictionary<int, ar.a> a = new Dictionary<int, ar.a>();
    private int b;
    private bool c;
    private bool d;
    private EventHandler e;
    private EventHandler f;
    private EventHandler g;
    private EventHandler h;
    private bool i;

    public ar()
    {
        PluginCore.PC.a(new uTank2.PluginCore.a(this.a));
    }

    public void a()
    {
        if (!this.i)
        {
            this.i = true;
            GC.SuppressFinalize(this);
            PluginCore.PC.b(new uTank2.PluginCore.a(this.a));
        }
    }

    private bool a(MessageStruct A_0)
    {
        bool flag = false;
        int key = A_0.Value<int>("fellow");
        if (!this.a.ContainsKey(key))
        {
            this.a[key] = new ar.a();
            flag = true;
        }
        ar.a a = this.a[key];
        a.a = key;
        a.b = A_0.Value<string>("name");
        a.c = A_0.Value<short>("level");
        a.d = A_0.Value<int>("maxHealth");
        a.e = A_0.Value<int>("maxStam");
        a.f = A_0.Value<int>("maxMana");
        a.g = A_0.Value<int>("curHealth");
        a.h = A_0.Value<int>("curStam");
        a.i = A_0.Value<int>("curMana");
        a.j = A_0.Value<int>("shareLoot") != 0;
        return flag;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void a(EventHandler A_0)
    {
        this.g = (EventHandler) Delegate.Combine(this.g, A_0);
    }

    private void a(object A_0, NetworkMessageEventArgs A_1)
    {
        if (A_1.get_Message().get_Type() == 0xf7b0)
        {
            switch (A_1.get_Message().Value<int>("event"))
            {
                case 0xa3:
                case 0xa4:
                {
                    int key = A_1.get_Message().Value<int>("fellow");
                    if (!this.a.ContainsKey(key))
                    {
                        if (key != PluginCore.cg)
                        {
                            return;
                        }
                        goto Label_01F5;
                    }
                    this.a.Remove(key);
                    if (this.f != null)
                    {
                        this.f(this, null);
                    }
                    return;
                }
                case 0x2be:
                {
                    this.a.Clear();
                    bool flag = false;
                    int num = A_1.get_Message().Value<short>("fellowCount");
                    for (int i = 0; i < num; i++)
                    {
                        if (A_1.get_Message().Struct("fellows").Struct(i).Struct("fellow").Value<int>("fellow") != PluginCore.cg)
                        {
                            flag |= this.a(A_1.get_Message().Struct("fellows").Struct(i).Struct("fellow"));
                        }
                    }
                    int b = this.b;
                    this.b = A_1.get_Message().Value<int>("leader");
                    bool c = this.c;
                    this.c = A_1.get_Message().Value<int>("open") != 0;
                    bool d = this.d;
                    this.d = true;
                    if (!d && (this.g != null))
                    {
                        this.g(this, null);
                    }
                    if (flag && (this.f != null))
                    {
                        this.f(this, null);
                    }
                    if ((c != this.c) && (this.h != null))
                    {
                        this.h(this, null);
                    }
                    if ((b != this.b) && (this.e != null))
                    {
                        this.e(this, null);
                    }
                    return;
                }
                case 0x2bf:
                    goto Label_01F5;

                case 0x2c0:
                    if (((A_1.get_Message().Struct("fellow").Value<int>("fellow") != PluginCore.cg) && this.a(A_1.get_Message().Struct("fellow"))) && (this.f != null))
                    {
                        this.f(this, null);
                    }
                    return;
            }
        }
        return;
    Label_01F5:
        this.a.Clear();
        this.b = 0;
        this.d = false;
        if (this.g != null)
        {
            this.g(this, null);
        }
    }

    public int b()
    {
        return this.b;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void b(EventHandler A_0)
    {
        this.f = (EventHandler) Delegate.Combine(this.f, A_0);
    }

    public bool c()
    {
        return this.d;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void c(EventHandler A_0)
    {
        this.f = (EventHandler) Delegate.Remove(this.f, A_0);
    }

    public bool d()
    {
        return this.c;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void d(EventHandler A_0)
    {
        this.e = (EventHandler) Delegate.Combine(this.e, A_0);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void e(EventHandler A_0)
    {
        this.g = (EventHandler) Delegate.Remove(this.g, A_0);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void f(EventHandler A_0)
    {
        this.h = (EventHandler) Delegate.Combine(this.h, A_0);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void g(EventHandler A_0)
    {
        this.e = (EventHandler) Delegate.Remove(this.e, A_0);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void h(EventHandler A_0)
    {
        this.h = (EventHandler) Delegate.Remove(this.h, A_0);
    }

    public class a
    {
        public int a;
        public string b;
        public short c;
        public int d;
        public int e;
        public int f;
        public int g;
        public int h;
        public int i;
        public bool j;
    }
}

