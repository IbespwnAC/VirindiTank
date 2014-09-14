using MyClasses;
using System;
using uTank2;

internal class e0 : SpeedLimitQueue<string>
{
    public e0() : base(6, 0x7918)
    {
    }

    protected override void a(string A_0)
    {
        PluginCore.cq.ax.get_Actions().InvokeChatParser(A_0);
    }
}

