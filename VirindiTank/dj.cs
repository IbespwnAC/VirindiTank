using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

internal static class dj
{
    private static Thread a = null;
    private static List<Exception> b = new List<Exception>();
    private static Semaphore c = new Semaphore(0, 1);

    private static void a()
    {
        int count;
        Exception exception;
        List<Exception> list;
        List<Exception> list2;
    Label_0000:
        Monitor.Enter(list = b);
        try
        {
            count = b.Count;
            goto Label_01F6;
        }
        finally
        {
            Monitor.Exit(list);
        }
    Label_0025:
        Monitor.Enter(list2 = b);
        try
        {
            exception = b[0];
            b.RemoveAt(0);
        }
        finally
        {
            Monitor.Exit(list2);
        }
        try
        {
            string name = Assembly.GetExecutingAssembly().GetName().Name;
            string str2 = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string str3 = exception.ToString();
            string s = name + "~~" + str2 + "~~" + str3 + "L:SKDJjhaklfhAJKS@!(((";
            StringBuilder builder = new StringBuilder();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] buffer = MD5.Create().ComputeHash(encoding.GetBytes(s));
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.AppendFormat("{0:X2}", buffer[i]);
            }
            string str5 = builder.ToString();
            StringBuilder builder2 = new StringBuilder();
            builder2.Append("http://www.virindi.net/plugins/exceptions/post.php?");
            builder2.Append("pn=");
            builder2.Append(name);
            builder2.Append("&pv=");
            builder2.Append(str2);
            builder2.Append("&ex=");
            builder2.Append(str3);
            builder2.Append("&h=");
            builder2.Append(str5);
            WebRequest request = WebRequest.Create(builder2.ToString());
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = 0L;
            using (request.GetResponse().GetResponseStream())
            {
            }
        }
        catch
        {
        }
        lock (b)
        {
            count = b.Count;
        }
    Label_01F6:
        if (count > 0)
        {
            goto Label_0025;
        }
        lock (b)
        {
            if (b.Count == 0)
            {
                a = null;
            }
            else
            {
                goto Label_0000;
            }
        }
    }

    public static void a(Exception A_0, bool A_1)
    {
        if (b() || !A_1)
        {
            lock (b)
            {
                b.Add(A_0);
                if (a == null)
                {
                    a = new Thread(new ThreadStart(dj.a));
                    a.Start();
                }
            }
        }
    }

    private static bool b()
    {
        dj.a a = dj.a.a;
        return (a.ToString() != "test");
    }

    private enum a
    {
        a
    }
}

