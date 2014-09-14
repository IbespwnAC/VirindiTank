using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class ba : ArrayList
{
    public ba()
    {
        GCHandle handle = GCHandle.Alloc(this);
        ba.a a = new ba.a(ba.a);
        EnumWindows(a, (IntPtr) handle);
        handle.Free();
    }

    private static bool a(int A_0, IntPtr A_1)
    {
        GCHandle handle = (GCHandle) A_1;
        ((ba) handle.Target).Add(A_0);
        return true;
    }

    [DllImport("user32")]
    private static extern int EnumWindows(ba.a A_0, IntPtr A_1);

    private delegate bool a(int A_0, IntPtr A_1);
}

