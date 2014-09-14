using System;
using System.Runtime.InteropServices;
using System.Text;

internal static class r
{
    public static int a()
    {
        int currentProcessId = GetCurrentProcessId();
        ba ba = new ba();
        foreach (int num2 in ba)
        {
            int num3 = 0;
            GetWindowThreadProcessId(num2, ref num3);
            if (num3 == currentProcessId)
            {
                StringBuilder builder = new StringBuilder(0xff);
                GetWindowText(num2, builder, builder.Capacity);
                if (builder.ToString() == "Asheron's Call")
                {
                    return num2;
                }
            }
        }
        return 0;
    }

    public static u a(char A_0)
    {
        switch (A_0)
        {
            case 'a':
                return u.o;

            case 'b':
                return u.p;

            case 'c':
                return u.q;

            case 'd':
                return u.r;

            case 'e':
                return u.s;

            case 'f':
                return u.t;

            case 'g':
                return u.u;

            case 'h':
                return u.v;

            case 'i':
                return u.w;

            case 'j':
                return u.x;

            case 'k':
                return u.y;

            case 'l':
                return u.z;

            case 'm':
                return u.aa;

            case 'n':
                return u.ab;

            case 'o':
                return u.ac;

            case 'p':
                return u.ad;

            case 'q':
                return u.ae;

            case 'r':
                return u.af;

            case 's':
                return u.ag;

            case 't':
                return u.ah;

            case 'u':
                return u.ai;

            case 'v':
                return u.aj;

            case 'w':
                return u.ak;

            case 'x':
                return u.al;

            case 'y':
                return u.am;

            case 'z':
                return u.an;

            case '/':
                return u.ao;

            case ' ':
                return u.b;
        }
        return u.b;
    }

    public static ushort a(u A_0)
    {
        switch (A_0)
        {
            case u.a:
                return 0x2a;

            case u.j:
                return 0x1d;

            case u.h:
                return 0x45;

            case u.b:
                return 0x39;

            case u.n:
                return 0x151;

            case u.l:
                return 0x14f;

            case u.c:
                return 0x14b;

            case u.e:
                return 0x148;

            case u.d:
                return 0x14d;

            case u.f:
                return 0x150;

            case u.m:
                return 0x153;

            case u.o:
                return 30;

            case u.p:
                return 0x30;

            case u.q:
                return 0x2e;

            case u.r:
                return 0x20;

            case u.s:
                return 0x12;

            case u.t:
                return 0x21;

            case u.u:
                return 0x22;

            case u.v:
                return 0x23;

            case u.w:
                return 0x17;

            case u.x:
                return 0x24;

            case u.y:
                return 0x25;

            case u.z:
                return 0x26;

            case u.aa:
                return 50;

            case u.ab:
                return 0x31;

            case u.ac:
                return 0x18;

            case u.ad:
                return 0x19;

            case u.ae:
                return 0x10;

            case u.af:
                return 0x13;

            case u.ag:
                return 0x1f;

            case u.ah:
                return 20;

            case u.ai:
                return 0x16;

            case u.aj:
                return 0x2f;

            case u.ak:
                return 0x11;

            case u.al:
                return 0x2d;

            case u.am:
                return 0x15;

            case u.an:
                return 0x2c;

            case u.g:
                return 70;

            case u.ao:
                return 0x35;
        }
        return 0;
    }

    public static void a(int A_0, string A_1)
    {
        foreach (char ch in A_1)
        {
            u u = a(ch);
            uint num2 = (uint) ((a(u) << 0x10) | 1);
            PostMessage(A_0, 0x100, (short) u, num2);
            PostMessage(A_0, 0x101, (short) u, 0xc0000000 | num2);
        }
    }

    public static bool a(ushort A_0, int A_1)
    {
        return ((A_0 << 0x10) == (A_1 & 0x1ff0000));
    }

    public static bool a(u A_0, int A_1)
    {
        return a(a(A_0), A_1);
    }

    public static void a(int A_0, u A_1, bool A_2)
    {
        r.a b;
        uint num = 0;
        if (A_2)
        {
            num = 1;
            b = r.a.a;
        }
        else
        {
            num = 0xc0000001;
            b = r.a.b;
        }
        u u = A_1;
        if (u <= u.m)
        {
            switch (u)
            {
                case u.i:
                    num += 0x1c0000;
                    break;

                case u.a:
                    num += 0x2a0000;
                    break;

                case u.j:
                    num += 0x1d0000;
                    break;

                case u.k:
                    num += 0xe0000;
                    break;

                case u.b:
                    num += 0x390000;
                    break;

                case u.n:
                    num += 0x1510000;
                    break;

                case u.l:
                    num += 0x14f0000;
                    break;

                case u.c:
                    num += 0x14b0000;
                    break;

                case u.e:
                    num += 0x1480000;
                    break;

                case u.d:
                    num += 0x14d0000;
                    break;

                case u.f:
                    num += 0x1500000;
                    break;

                case u.m:
                    num += 0x1530000;
                    break;
            }
        }
        else
        {
            switch (u)
            {
                case u.q:
                    num += 0x2e0000;
                    goto Label_013E;

                case u.aj:
                    num += 0x2f0000;
                    goto Label_013E;
            }
            if (u == u.an)
            {
                num += 0x2c0000;
            }
        }
    Label_013E:
        PostMessage(A_0, (uint) b, (short) A_1, num);
    }

    [DllImport("user32.dll")]
    public static extern int GetClassName(int A_0, [MarshalAs(UnmanagedType.LPStr)] StringBuilder A_1, int A_2);
    [DllImport("kernel32.dll")]
    public static extern int GetCurrentProcessId();
    [DllImport("user32.dll")]
    public static extern ushort GetKeyState(uint A_0);
    [DllImport("kernel32.dll")]
    public static extern int GetModuleHandle(string A_0);
    [DllImport("user32.dll")]
    public static extern int GetWindowText(int A_0, StringBuilder A_1, int A_2);
    [DllImport("user32.dll")]
    public static extern int GetWindowThreadProcessId(int A_0, ref int A_1);
    [DllImport("user32.dll")]
    public static extern bool IsWindowVisible(int A_0);
    [DllImport("kernel32.dll")]
    public static extern int LoadLibrary(string A_0);
    [DllImport("user32.dll")]
    public static extern bool PostMessage(int A_0, uint A_1, short A_2, uint A_3);

    public enum a
    {
        a = 0x100,
        b = 0x101
    }
}

