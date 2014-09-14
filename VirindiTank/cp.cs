using System;
using System.Collections;
using System.IO;

internal class cp : Stream
{
    private ArrayList a = new ArrayList();
    private long b;

    public void a(Stream A_0)
    {
        this.a.Add(A_0);
    }

    public override long a(long A_0, SeekOrigin A_1)
    {
        long length = this.Length;
        switch (A_1)
        {
            case SeekOrigin.Begin:
                this.b = A_0;
                break;

            case SeekOrigin.Current:
                this.b += A_0;
                break;

            case SeekOrigin.End:
                this.b = length - A_0;
                break;
        }
        if (this.b > length)
        {
            this.b = length;
        }
        else if (this.b < 0L)
        {
            this.b = 0L;
        }
        return this.b;
    }

    public override int a(byte[] A_0, int A_1, int A_2)
    {
        long num = 0L;
        int num2 = 0;
        int offset = A_1;
        foreach (Stream stream in this.a)
        {
            if (this.b < (num + stream.Length))
            {
                stream.Position = this.b - num;
                int num4 = stream.Read(A_0, offset, A_2);
                num2 += num4;
                offset += num4;
                this.b += num4;
                if (num4 >= A_2)
                {
                    return num2;
                }
                A_2 -= num4;
            }
            num += stream.Length;
        }
        return num2;
    }

    public override void b(long A_0)
    {
    }

    public override void b(byte[] A_0, int A_1, int A_2)
    {
    }

    public override void f()
    {
    }

    [__DynamicallyInvokable]
    public override bool System.IO.Stream.CanRead
    {
        get
        {
            return true;
        }
    }

    [__DynamicallyInvokable]
    public override bool System.IO.Stream.CanSeek
    {
        get
        {
            return true;
        }
    }

    [__DynamicallyInvokable]
    public override bool System.IO.Stream.CanWrite
    {
        get
        {
            return false;
        }
    }

    [__DynamicallyInvokable]
    public override long System.IO.Stream.Length
    {
        get
        {
            long num = 0L;
            foreach (Stream stream in this.a)
            {
                num += stream.Length;
            }
            return num;
        }
    }

    [__DynamicallyInvokable]
    public override long System.IO.Stream.Position
    {
        get
        {
            return this.b;
        }
        set
        {
            this.Seek(value, SeekOrigin.Begin);
        }
    }
}

