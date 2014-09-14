using System;
using uTank2;

internal class @as
{
    private MyDictionary<ActionLockType, DateTimeOffset> a = new MyDictionary<ActionLockType, DateTimeOffset>(0x3e);

    public void a()
    {
        this.a.Clear();
    }

    public void a(ActionLockType A_0)
    {
        this.a.Remove(A_0);
    }

    public void a(ActionLockType A_0, TimeSpan A_1)
    {
        DateTimeOffset offset = DateTimeOffset.Now + A_1;
        if (this.a.ContainsKey(A_0))
        {
            if (offset > this.a[A_0])
            {
                this.a[A_0] = offset;
            }
        }
        else
        {
            this.a.Add(A_0, offset);
        }
    }

    public MyDictionary<ActionLockType, DateTimeOffset> b()
    {
        return this.a;
    }

    public bool b(ActionLockType A_0)
    {
        if (this.a.ContainsKey(A_0))
        {
            if (this.a[A_0] >= DateTimeOffset.Now)
            {
                return true;
            }
            this.a.Remove(A_0);
        }
        return false;
    }
}

