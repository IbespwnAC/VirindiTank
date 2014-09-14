using System;

internal abstract class dx : IDisposable
{
    private bool a;

    public void a()
    {
        if (!this.a)
        {
            this.a = true;
            GC.SuppressFinalize(this);
            this.b();
        }
    }

    protected abstract void b();
    protected override void c()
    {
        try
        {
            this.a();
        }
        finally
        {
            base.Finalize();
        }
    }

    public bool d()
    {
        return this.a;
    }
}

