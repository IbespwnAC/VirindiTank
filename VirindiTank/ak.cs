using System;
using System.Collections.Generic;
using System.Text;
using uTank2;

internal static class ak
{
    private static void a()
    {
        b0.c c = new b0.c(PluginCore.cq.u);
        PluginCore.e("IDQueue overall category counts:");
        foreach (KeyValuePair<b0.a, int> pair in c.d)
        {
            PluginCore.e(string.Format("{0}: {1}", (int) pair.Key, pair.Value));
        }
        PluginCore.e("IDQueue entries:");
        foreach (int num in c.a)
        {
            string str = "???";
            if (PluginCore.cq.p.d(num) != null)
            {
                str = PluginCore.cq.p.d(num).g();
            }
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0} ({1})", str, num);
            builder.Append(": ");
            if (c.c.ContainsKey(num))
            {
                builder.AppendFormat("Category {0}, ", (int) c.c[num]);
            }
            if (c.b.ContainsKey(num) && (c.b[num].Count > 0))
            {
                builder.Append("[Callback], ");
            }
            builder.AppendFormat("IsGoodObj {0}, ", dh.b(num));
            if (dh.b(num))
            {
                builder.AppendFormat("ContainerZero {0}, ", PluginCore.cq.aw.get_WorldFilter().get_Item(num).get_Container() == 0);
                builder.AppendFormat("InRange {0}, ", dh.a(num, PluginCore.cg, true) <= PluginCore.cq.n.p);
            }
            a5.a(eChatType.CommandLine, builder.ToString());
        }
    }

    public static void a(string A_0)
    {
        string str;
        if (((str = A_0) != null) && (str == "idqueue"))
        {
            a();
        }
        else
        {
            PluginCore.e("Usage: \"/vt explain [command]\". Available commands: idqueue");
        }
    }
}

