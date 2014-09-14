using System;

internal class cf
{
    public bool a;
    public string b;
    private DateTimeOffset c = DateTimeOffset.MinValue;

    public cf(string A_0)
    {
        this.b = A_0;
    }

    public bool a()
    {
        if (!this.a)
        {
            return (this.c > DateTimeOffset.Now);
        }
        return true;
    }

    public void a(TimeSpan A_0)
    {
        DateTimeOffset offset = DateTimeOffset.Now + A_0;
        if (offset > this.c)
        {
            this.c = offset;
        }
    }
}

