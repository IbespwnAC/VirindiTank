using System;

internal class e2
{
    private u a;
    private int b;
    private int c;
    private bool d;

    public e2(u A_0, int A_1)
    {
        this.a = A_0;
        this.b = A_1;
    }

    public bool a()
    {
        return this.d;
    }

    public void a(bool A_0)
    {
        if (A_0 && !this.d)
        {
            r.a(this.b, this.a, true);
            this.d = true;
        }
        else if (!A_0 && this.d)
        {
            r.a(this.b, this.a, false);
            this.d = false;
            this.c = 0;
        }
        else if (A_0 && this.d)
        {
            this.c++;
            if (this.c == 12)
            {
                r.a(this.b, this.a, false);
                r.a(this.b, this.a, true);
                this.c = 0;
            }
        }
    }
}

