using Decal.Adapter;
using Decal.Adapter.Wrappers;
using Decal.Filters;
using System;
using uTank2;

internal class ev
{
    public b2 a;
    public int a0;
    public int a1;
    public d0 aa;
    public da ab;
    public bj ac;
    public fs ad;
    public b9 ae;
    public en af;
    public cc ag;
    public e0 ah;
    public ar ai;
    public y aj;
    public cRechargeManager ak;
    public q al;
    public fr am;
    public ei an;
    public ca ao;
    public cr ap;
    public bp aq;
    public ay ar;
    public h @as;
    public du at;
    public ac au;
    public ek av;
    public CoreManager aw;
    public PluginHost ax;
    public PluginCore ay;
    public MyList<IDisposable> az = new MyList<IDisposable>(0x3b);
    public j b;
    public cLogic c;
    public aj d;
    public cd e;
    public d6 f;
    public dv g;
    public cs h;
    public dg i;
    public dl j;
    public eo k;
    public bh l;
    public fq m;
    public fn n;
    public bw o;
    public cj p;
    public b5 q;
    public cz r;
    public ag s;
    public fc t;
    public b0 u;
    public el v;
    public bd w;
    public bv x;
    public a7 y;
    public s z;

    public ev(CoreManager A_0, PluginHost A_1, PluginCore A_2)
    {
        this.aw = A_0;
        this.ax = A_1;
        this.ay = A_2;
        this.a = new b2(this.ay);
        this.az.Add(this.a);
        this.b = new j();
        this.az.Add(this.b);
        this.d = new aj();
        this.az.Add(this.d);
        this.e = new cd((FileService) this.aw.get_FileService(), this);
        this.az.Add(this.e);
        this.f = new d6();
        this.az.Add(this.f);
        this.g = new dv(this);
        this.az.Add(this.g);
        this.z = new s(this.aw);
        this.az.Add(this.z);
        this.h = new cs(this);
        this.az.Add(this.h);
        this.i = new dg(this);
        this.az.Add(this.i);
        this.j = new dl(this);
        this.az.Add(this.j);
        this.k = new eo(this);
        this.az.Add(this.k);
        this.l = new bh();
        this.az.Add(this.l);
        this.m = new fq();
        this.az.Add(this.m);
        this.o = new bw();
        this.az.Add(this.o);
        this.c = new cLogic(this.g, this.ay, this.z);
        this.az.Add(this.c);
        this.p = new cj(new cj.a(ad.a), A_1.get_Actions());
        this.az.Add(this.p);
        this.q = new b5(this.aw, this.ay);
        this.az.Add(this.q);
        this.r = new cz(this.ay, this.aw, this.ax, this.p);
        this.az.Add(this.r);
        this.s = new ag();
        this.az.Add(this.s);
        this.t = new fc(this.aw, this.ay);
        this.az.Add(this.t);
        this.u = new b0(this.aw, this.ay, this.p);
        this.az.Add(this.u);
        this.v = new el(this.aw);
        this.az.Add(this.v);
        this.w = new bd();
        this.az.Add(this.w);
        this.x = new bv(this.aw);
        this.az.Add(this.x);
        this.y = new a7(this.aw);
        this.az.Add(this.y);
        this.n = new fn(this.aw, this.p);
        this.az.Add(this.n);
        this.aa = new d0(this.aw);
        this.az.Add(this.aa);
        this.ab = new da(this.p, this.ay);
        this.az.Add(this.ab);
        this.ac = new bj();
        this.az.Add(this.ac);
        this.ad = new fs();
        this.az.Add(this.ad);
        this.ae = new b9();
        this.az.Add(this.ae);
        this.af = new en();
        this.az.Add(this.af);
        this.ah = new e0();
        this.az.Add(this.ah);
        this.ai = new ar();
        this.az.Add(this.ai);
        this.aj = new y(this.ai);
        this.az.Add(this.aj);
        this.ak = new cRechargeManager();
        this.az.Add(this.ak);
        this.al = new q();
        this.az.Add(this.al);
        this.am = new fr();
        this.az.Add(this.am);
        this.an = new ei(this.g, this.p);
        this.az.Add(this.an);
        this.ao = new ca(this.x, this.an);
        this.az.Add(this.ao);
        this.ap = new cr(this.ay);
        this.az.Add(this.ap);
        this.aq = new bp();
        this.az.Add(this.aq);
        this.ar = new ay(this.p);
        this.az.Add(this.ar);
        this.@as = new h();
        this.az.Add(this.@as);
        this.at = new du();
        this.az.Add(this.at);
        this.au = new ac();
        this.az.Add(this.au);
        this.ag = new cc();
        this.az.Add(this.ag);
    }

    public void a()
    {
        foreach (IDisposable disposable in this.az)
        {
            disposable.Dispose();
        }
    }

    public void b()
    {
        GC.SuppressFinalize(this);
        this.a();
        this.az.Clear();
        this.n = null;
        this.ag = null;
        this.au = null;
        this.at = null;
        this.@as = null;
        this.ar = null;
        this.aq = null;
        this.ap = null;
        this.ao = null;
        this.an = null;
        this.am = null;
        this.al = null;
        this.ak = null;
        this.aj = null;
        this.ai = null;
        this.ah = null;
        this.af = null;
        this.ae = null;
        this.ad = null;
        this.ac = null;
        this.ab = null;
        this.aa = null;
        this.z = null;
        this.y = null;
        this.x = null;
        this.w = null;
        this.v = null;
        this.u = null;
        this.t = null;
        this.s = null;
        this.r = null;
        this.q = null;
        this.p = null;
        this.c = null;
        this.av = null;
        this.o = null;
        this.m = null;
        this.l = null;
        this.k = null;
        this.j = null;
        this.i = null;
        this.h = null;
        this.g = null;
        this.f = null;
        this.e = null;
        this.d = null;
        this.b = null;
        this.a = null;
        this.aw = null;
        this.ax = null;
        this.ay = null;
    }

    protected override void c()
    {
        try
        {
            this.b();
        }
        finally
        {
            base.Finalize();
        }
    }
}

