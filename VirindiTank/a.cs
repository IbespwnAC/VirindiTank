using Decal.Adapter;
using MyClasses;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using VirindiViewService.Controls;

internal static class a
{
    private const char a = ':';
    private static a.d b;
    private static string c;
    private static a.b d;
    private static bool e = false;
    private static Dictionary<string, a.c> f = new Dictionary<string, a.c>();
    private static Dictionary<string, MyTriple<a.a, int, string>> g = new Dictionary<string, MyTriple<a.a, int, string>>();

    private static void a()
    {
        HudConsole.remove_LinkClicked(new HudConsole.delString(null, (IntPtr) a));
    }

    public static void a(string A_0)
    {
        if (!g.ContainsKey(A_0))
        {
            throw new ArgumentException();
        }
        g.Remove(A_0);
    }

    private static void a(object A_0, ChatClickInterceptEventArgs A_1)
    {
        A_1.set_Eat(c(A_1.get_Text()));
    }

    private static void a(object A_0, ChatParserInterceptEventArgs A_1)
    {
        try
        {
            if (!string.IsNullOrEmpty(A_1.get_Text()))
            {
                string[] sourceArray = A_1.get_Text().Split(new char[] { ' ' });
                if (g.ContainsKey(sourceArray[0]))
                {
                    string[] strArray2;
                    A_1.set_Eat(true);
                    MyTriple<a.a, int, string> triple = g[sourceArray[0]];
                    if (triple.b == 0)
                    {
                        strArray2 = new string[0];
                    }
                    else
                    {
                        if (triple.b > (sourceArray.Length - 1))
                        {
                            b("Usage: " + triple.c);
                            return;
                        }
                        strArray2 = new string[triple.b];
                        Array.Copy(sourceArray, 1, strArray2, 0, strArray2.Length - 1);
                        StringBuilder builder = new StringBuilder();
                        for (int i = strArray2.Length; i < sourceArray.Length; i++)
                        {
                            builder.Append(sourceArray[i]);
                            if (i < (sourceArray.Length - 1))
                            {
                                builder.Append(" ");
                            }
                        }
                        strArray2[strArray2.Length - 1] = builder.ToString();
                    }
                    if (!triple.a(sourceArray[0], strArray2))
                    {
                        b("Usage: " + triple.c);
                    }
                }
            }
        }
        catch (Exception exception)
        {
            if (d != null)
            {
                d(exception);
            }
        }
    }

    public static string a(string A_0, params string[] A_1)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<Tell:IIDString:0:");
        builder.Append(c);
        foreach (string str in A_1)
        {
            builder.Append(':');
            builder.Append(str);
        }
        builder.Append(">");
        builder.Append(A_0);
        builder.Append(@"<\Tell>");
        return builder.ToString();
    }

    public static void a(string A_0, a.c A_1)
    {
        if (!f.ContainsKey(A_0))
        {
            f.Add(A_0, A_1);
        }
    }

    private static void a(HudConsole A_0, string A_1)
    {
        c(A_1);
    }

    public static void a(a.d A_0, string A_1, a.b A_2)
    {
        c = A_1;
        b = A_0;
        d = A_2;
        f.Clear();
        g.Clear();
        CoreManager.get_Current().add_CommandLineText(new EventHandler<ChatParserInterceptEventArgs>(a.a));
        CoreManager.get_Current().add_ChatNameClicked(new EventHandler<ChatClickInterceptEventArgs>(a.a));
        if (ff.a(null, new Version("1.0.0.14")))
        {
            b();
            e = true;
        }
    }

    public static void a(string A_0, a.a A_1, int A_2, string A_3)
    {
        if (g.ContainsKey(A_0))
        {
            throw new ArgumentException();
        }
        g.Add(A_0, new MyTriple<a.a, int, string>(A_1, A_2, A_3));
    }

    private static void b()
    {
        HudConsole.add_LinkClicked(new HudConsole.delString(null, (IntPtr) a));
    }

    public static void b(string A_0)
    {
        if (f.ContainsKey(A_0))
        {
            f.Remove(A_0);
        }
    }

    public static void c()
    {
        if (e)
        {
            a();
        }
        CoreManager.get_Current().remove_ChatNameClicked(new EventHandler<ChatClickInterceptEventArgs>(a.a));
        CoreManager.get_Current().remove_CommandLineText(new EventHandler<ChatParserInterceptEventArgs>(a.a));
    }

    private static bool c(string A_0)
    {
        bool flag = false;
        if (A_0 == "")
        {
            return false;
        }
        string[] strArray = A_0.Split(new char[] { ':' });
        if (strArray.Length < 2)
        {
            return false;
        }
        if (strArray[0] == c)
        {
            flag = true;
            if (!f.ContainsKey(strArray[1]))
            {
                return flag;
            }
            string[] strArray2 = new string[strArray.Length - 1];
            for (int i = 1; i < strArray.Length; i++)
            {
                strArray2[i - 1] = strArray[i];
            }
            f[strArray[1]](strArray2);
        }
        return flag;
    }

    public delegate bool a(string A_0, string[] A_1);

    public delegate void b(Exception A_0);

    public delegate void c(string[] A_0);

    public delegate void d(string A_0);
}

