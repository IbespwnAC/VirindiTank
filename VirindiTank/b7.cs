using System;
using System.IO;
using uTank2;

internal static class b7
{
    public static void a(string A_0, k A_1)
    {
        string[] files = Directory.GetFiles(PluginCore.ci, "*.usd");
        foreach (string str in files)
        {
            string[] strArray2 = str.Split(new char[] { '\\' });
            string str2 = strArray2[strArray2.Length - 1];
            if (str2 == PluginCore.cq.l.m)
            {
                er.b(A_0, A_1);
            }
            else
            {
                bf bf = new bf(str);
                v v = bf["Settings"].a(0, k.a(A_0));
                if (v == null)
                {
                    v v2 = new v(bf["Settings"]);
                    v2[0] = k.a(A_0);
                    v2[1] = A_1;
                    bf["Settings"].c(v2);
                }
                else
                {
                    v[1] = A_1;
                }
                bf.c(str);
            }
        }
        string[] strArray4 = new string[] { "Done saving setting ", A_0, " to all profiles. (Changed ", files.Length.ToString(), " profiles)" };
        PluginCore.e(string.Concat(strArray4));
    }
}

