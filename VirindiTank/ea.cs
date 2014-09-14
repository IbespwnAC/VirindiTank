using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using uTank2;

internal class ea : IDisposable
{
    private ea.a a;
    private TextReader b;
    private bool c;
    private ea.b d;
    private string e;
    private string f;
    private e3 g = new e3();
    private ThreadStart h;
    private Thread i;
    private bool j;

    public ea()
    {
        this.g.f();
        this.g.a(new EventHandler(this.a));
        this.g.a(500);
    }

    private void a()
    {
        try
        {
            switch (this.a)
            {
                case ea.a.a:
                {
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] bytes = encoding.GetBytes(this.f);
                    HttpWebRequest request = (HttpWebRequest) WebRequest.Create(this.e);
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = bytes.Length;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                    StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream(), encoding);
                    this.b = reader;
                    this.c = true;
                    return;
                }
                case ea.a.b:
                {
                    ASCIIEncoding encoding2 = new ASCIIEncoding();
                    HttpWebRequest request2 = (HttpWebRequest) WebRequest.Create(this.e);
                    request2.Method = "GET";
                    request2.ContentType = "application/x-www-form-urlencoded";
                    request2.ContentLength = 0L;
                    StreamReader reader2 = new StreamReader(request2.GetResponse().GetResponseStream(), encoding2);
                    this.b = reader2;
                    this.c = true;
                    return;
                }
            }
        }
        catch (Exception exception)
        {
            this.b = new StringReader(exception.Message);
            this.c = false;
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
        if (this.i.ThreadState == ThreadState.Stopped)
        {
            this.g.f();
            if (this.d != null)
            {
                this.d(this.c, this.b);
            }
        }
    }

    public void a(string A_0, ea.b A_1)
    {
        if (!this.d())
        {
            this.a = ea.a.b;
            this.d = A_1;
            this.e = A_0;
            this.c = false;
            PluginCore.cq.n.a("HTTP GET: " + A_0, e8.f);
            this.g.d();
            this.h = new ThreadStart(this.a);
            this.i = new Thread(this.h);
            this.i.Start();
        }
    }

    public void a(string A_0, string A_1, ea.b A_2)
    {
        if (!this.d())
        {
            this.a = ea.a.a;
            this.d = A_2;
            this.e = A_0;
            this.f = A_1;
            this.c = false;
            PluginCore.cq.n.a("HTTP POST: " + A_0, e8.f);
            PluginCore.cq.n.a("POSTDATA: " + A_1, e8.f);
            this.g.d();
            this.h = new ThreadStart(this.a);
            this.i = new Thread(this.h);
            this.i.Start();
        }
    }

    public void b()
    {
        if (!this.j)
        {
            this.j = true;
            GC.SuppressFinalize(this);
            this.c();
            this.g.b(new EventHandler(this.a));
            if (this.g != null)
            {
                this.g.e();
            }
            if (this.b != null)
            {
                this.b.Dispose();
            }
        }
    }

    public void c()
    {
        if (this.i != null)
        {
            this.i.Abort();
            this.i = null;
        }
        if (this.g.g())
        {
            this.g.a(false);
        }
    }

    public bool d()
    {
        return this.g.g();
    }

    private enum a
    {
        a,
        b
    }

    public delegate void b(bool A_0, TextReader A_1);
}

