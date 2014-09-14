using System;
using System.Runtime.CompilerServices;

internal interface dq : IDisposable
{
    void a();
    void a(bool A_0);
    [MethodImpl(MethodImplOptions.Synchronized)]
    void a(EventHandler A_0);
    void a(int A_0);
    void b();
    [MethodImpl(MethodImplOptions.Synchronized)]
    void b(EventHandler A_0);
    bool c();
    int d();
}

