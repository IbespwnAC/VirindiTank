using Decal.Adapter;
using Decal.Filters;
using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using uTank2;

internal static class dk
{
    private static Dictionary<string, dk.c> a = new Dictionary<string, dk.c>();
    private static aj.a b;
    private static cv c;
    private static bool d;
    private static Dictionary<char, dk.b> e = new Dictionary<char, dk.b>();

    static dk()
    {
        a();
        a("true", new dk.c(dk.h));
        a("false", new dk.c(dk.g));
        a("name", new dk.c(dk.e));
        a("typeid", new dk.c(dk.f));
        a("species", new dk.c(dk.d));
        a("maxhp", new dk.c(dk.c));
        a("range", new dk.c(dk.b));
        a("hasshield", new dk.c(dk.a));
    }

    private static void a()
    {
        e['+'] = dk.b.d;
        e['-'] = dk.b.d;
        e['*'] = dk.b.d;
        e['/'] = dk.b.d;
        e['%'] = dk.b.d;
        e['#'] = dk.b.d;
        e['<'] = dk.b.d;
        e['>'] = dk.b.d;
        e['='] = dk.b.d;
        e['!'] = dk.b.d;
        e['&'] = dk.b.d;
        e['|'] = dk.b.d;
        e['('] = dk.b.e;
        e[')'] = dk.b.f;
        e['0'] = dk.b.b;
        e['1'] = dk.b.b;
        e['2'] = dk.b.b;
        e['3'] = dk.b.b;
        e['4'] = dk.b.b;
        e['5'] = dk.b.b;
        e['6'] = dk.b.b;
        e['7'] = dk.b.b;
        e['8'] = dk.b.b;
        e['9'] = dk.b.b;
        e['.'] = dk.b.b;
    }

    private static object a(cv A_0)
    {
        b("hasshield");
        foreach (cv cv in PluginCore.cq.p.e(A_0.k))
        {
            if (cv.c() == ObjectClass.Armor)
            {
                return 1.0;
            }
        }
        return 0.0;
    }

    private static dk.a a(string A_0)
    {
        if (A_0.Length == 0)
        {
            return new dk.a(dk.b.b, 0.0);
        }
        Queue<dk.a> queue = new Queue<dk.a>();
        dk.b b = dk.b.a;
        bool flag = false;
        int startIndex = -1;
        for (int i = 0; i < A_0.Length; i++)
        {
            dk.b c = dk.b.c;
            if (flag)
            {
                flag = false;
            }
            else
            {
                if (A_0[i] == '\\')
                {
                    flag = true;
                    continue;
                }
                if (e.ContainsKey(A_0[i]))
                {
                    c = e[A_0[i]];
                }
                if (char.IsWhiteSpace(A_0[i]))
                {
                    continue;
                }
            }
            if (((c != b) || (b == dk.b.e)) || (b == dk.b.f))
            {
                if (b != dk.b.a)
                {
                    queue.Enqueue(new dk.a(b, A_0.Substring(startIndex, i - startIndex).Trim()));
                }
                b = c;
                startIndex = i;
            }
        }
        queue.Enqueue(new dk.a(b, A_0.Substring(startIndex, A_0.Length - startIndex).Trim()));
        Queue<dk.a> queue2 = new Queue<dk.a>();
        while (queue.Count > 0)
        {
            dk.a item = queue.Dequeue();
            switch (item.a)
            {
                case dk.b.b:
                    item.c = double.Parse(item.b.Trim(), CultureInfo.InvariantCulture);
                    break;

                case dk.b.c:
                    dk.a a2;
                    if (a(item.b, out a2))
                    {
                        item = a2;
                    }
                    break;
            }
            queue2.Enqueue(item);
        }
        Queue<dk.a> queue3 = new Queue<dk.a>();
        Stack<dk.a> stack = new Stack<dk.a>();
        while (queue2.Count > 0)
        {
            int num3;
            dk.a a3 = queue2.Dequeue();
            switch (a3.a)
            {
                case dk.b.b:
                {
                    queue3.Enqueue(a3);
                    continue;
                }
                case dk.b.c:
                {
                    queue3.Enqueue(a3);
                    continue;
                }
                case dk.b.d:
                    num3 = a3.a();
                    goto Label_0210;

                case dk.b.e:
                {
                    stack.Push(a3);
                    continue;
                }
                case dk.b.f:
                    break;

                default:
                {
                    continue;
                }
            }
            while (true)
            {
                if (stack.Count == 0)
                {
                    throw new dk.d("No matching '(' found");
                }
                dk.a a4 = stack.Pop();
                if (a4.a != dk.b.e)
                {
                    queue3.Enqueue(a4);
                }
            }
        Label_0202:
            queue3.Enqueue(stack.Pop());
        Label_0210:
            if (((stack.Count > 0) && (stack.Peek().a == dk.b.d)) && (num3 <= stack.Peek().a()))
            {
                goto Label_0202;
            }
            stack.Push(a3);
        }
        while (stack.Count > 0)
        {
            dk.a a5 = stack.Pop();
            if (a5.a == dk.b.f)
            {
                throw new dk.d("No matching '(' found");
            }
            if (a5.a == dk.b.e)
            {
                throw new dk.d("No matching ')' found");
            }
            queue3.Enqueue(a5);
        }
        while (queue3.Count > 0)
        {
            dk.a a6 = queue3.Dequeue();
            switch (a6.a)
            {
                case dk.b.b:
                case dk.b.c:
                    stack.Push(a6);
                    break;

                case dk.b.d:
                {
                    dk.a a7 = stack.Pop();
                    dk.a a8 = stack.Pop();
                    stack.Push(a(a8, a7, a6));
                    break;
                }
            }
        }
        if (stack.Count == 0)
        {
            throw new dk.d("No operands");
        }
        if (stack.Count > 1)
        {
            throw new dk.d("Operand without intervening operator");
        }
        return stack.Pop();
    }

    private static bool a(string A_0, out dk.a A_1)
    {
        string key = A_0.ToLowerInvariant().Trim();
        if (A_0.StartsWith("setting_"))
        {
            PluginCore.cq.d.a(A_0);
            k k = er.d(A_0.Substring(8));
            Type type = k.c().GetType();
            if (type == typeof(int))
            {
                A_1 = new dk.a(dk.b.b, (double) ((int) k.c()));
                return true;
            }
            if (type == typeof(double))
            {
                A_1 = new dk.a(dk.b.b, (double) k.c());
                return true;
            }
            if (type == typeof(bool))
            {
                double num;
                if ((bool) k.c())
                {
                    num = 1.0;
                }
                else
                {
                    num = 0.0;
                }
                A_1 = new dk.a(dk.b.b, num);
                return true;
            }
            if (type == typeof(string))
            {
                A_1 = new dk.a(dk.b.c, (string) k.c());
                return true;
            }
            A_1 = new dk.a(dk.b.b, 0.0);
            return true;
        }
        if (a.ContainsKey(key))
        {
            object obj2 = a[key](c);
            if (obj2 == null)
            {
                A_1 = new dk.a(dk.b.b, 0.0);
                return true;
            }
            if (obj2.GetType() == typeof(double))
            {
                A_1 = new dk.a(dk.b.b, (double) obj2);
                return true;
            }
            if (obj2.GetType() == typeof(int))
            {
                A_1 = new dk.a(dk.b.b, (double) ((int) obj2));
                return true;
            }
            if (obj2.GetType() == typeof(string))
            {
                A_1 = new dk.a(dk.b.c, (string) obj2);
                return true;
            }
            A_1 = new dk.a(dk.b.b, 0.0);
            return true;
        }
        A_1 = new dk.a(dk.b.b, 0.0);
        return false;
    }

    public static void a(string A_0, dk.c A_1)
    {
        a[A_0.ToLowerInvariant().Trim()] = A_1;
    }

    private static dk.a a(dk.a A_0, dk.a A_1, dk.a A_2)
    {
        if ((A_0.a != dk.b.b) || (A_1.a != dk.b.b))
        {
            if ((A_0.a != dk.b.c) || (A_1.a != dk.b.c))
            {
                throw new dk.d("Attempted to compare two disperate types");
            }
            string key = A_2.b;
            if (key != null)
            {
                int num5;
                if (bx.h == null)
                {
                    Dictionary<string, int> dictionary2 = new Dictionary<string, int>(9);
                    dictionary2.Add("==", 0);
                    dictionary2.Add("<", 1);
                    dictionary2.Add(">", 2);
                    dictionary2.Add(">=", 3);
                    dictionary2.Add("<=", 4);
                    dictionary2.Add("!=", 5);
                    dictionary2.Add("+", 6);
                    dictionary2.Add("-", 7);
                    dictionary2.Add("#", 8);
                    bx.h = dictionary2;
                }
                if (bx.h.TryGetValue(key, out num5))
                {
                    switch (num5)
                    {
                        case 0:
                            if (string.Compare(A_0.b, A_1.b, StringComparison.OrdinalIgnoreCase) != 0)
                            {
                                return new dk.a(dk.b.b, 0.0);
                            }
                            return new dk.a(dk.b.b, 1.0);

                        case 1:
                            if (string.Compare(A_0.b, A_1.b, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                return new dk.a(dk.b.b, 0.0);
                            }
                            return new dk.a(dk.b.b, 1.0);

                        case 2:
                            if (string.Compare(A_0.b, A_1.b, StringComparison.OrdinalIgnoreCase) <= 0)
                            {
                                return new dk.a(dk.b.b, 0.0);
                            }
                            return new dk.a(dk.b.b, 1.0);

                        case 3:
                            if (string.Compare(A_0.b, A_1.b, StringComparison.OrdinalIgnoreCase) < 0)
                            {
                                return new dk.a(dk.b.b, 0.0);
                            }
                            return new dk.a(dk.b.b, 1.0);

                        case 4:
                            if (string.Compare(A_0.b, A_1.b, StringComparison.OrdinalIgnoreCase) > 0)
                            {
                                return new dk.a(dk.b.b, 0.0);
                            }
                            return new dk.a(dk.b.b, 1.0);

                        case 5:
                            if (string.Compare(A_0.b, A_1.b, StringComparison.OrdinalIgnoreCase) == 0)
                            {
                                return new dk.a(dk.b.b, 0.0);
                            }
                            return new dk.a(dk.b.b, 1.0);

                        case 6:
                            return new dk.a(dk.b.c, A_0.b + A_1.b);

                        case 7:
                            return new dk.a(dk.b.c, A_0.b + "-" + A_1.b);

                        case 8:
                        {
                            Regex regex = new Regex(A_1.b, RegexOptions.IgnoreCase);
                            if (!regex.IsMatch(A_0.b))
                            {
                                return new dk.a(dk.b.b, 0.0);
                            }
                            return new dk.a(dk.b.b, 1.0);
                        }
                    }
                }
            }
            throw new dk.d("Invalid operator '" + A_2.b + "' for 'String'");
        }
        double c = A_0.c;
        double num2 = A_1.c;
        string b = A_2.b;
        if (b != null)
        {
            int num4;
            if (bx.g == null)
            {
                Dictionary<string, int> dictionary1 = new Dictionary<string, int>(13);
                dictionary1.Add("&&", 0);
                dictionary1.Add("||", 1);
                dictionary1.Add("==", 2);
                dictionary1.Add("<", 3);
                dictionary1.Add(">", 4);
                dictionary1.Add(">=", 5);
                dictionary1.Add("<=", 6);
                dictionary1.Add("!=", 7);
                dictionary1.Add("+", 8);
                dictionary1.Add("-", 9);
                dictionary1.Add("*", 10);
                dictionary1.Add("/", 11);
                dictionary1.Add("%", 12);
                bx.g = dictionary1;
            }
            if (bx.g.TryGetValue(b, out num4))
            {
                switch (num4)
                {
                    case 0:
                        if ((c == 0.0) || (num2 == 0.0))
                        {
                            return new dk.a(dk.b.b, 0.0);
                        }
                        return new dk.a(dk.b.b, 1.0);

                    case 1:
                        if ((c == 0.0) && (num2 == 0.0))
                        {
                            return new dk.a(dk.b.b, 0.0);
                        }
                        return new dk.a(dk.b.b, 1.0);

                    case 2:
                        if (c != num2)
                        {
                            return new dk.a(dk.b.b, 0.0);
                        }
                        return new dk.a(dk.b.b, 1.0);

                    case 3:
                        if (c >= num2)
                        {
                            return new dk.a(dk.b.b, 0.0);
                        }
                        return new dk.a(dk.b.b, 1.0);

                    case 4:
                        if (c <= num2)
                        {
                            return new dk.a(dk.b.b, 0.0);
                        }
                        return new dk.a(dk.b.b, 1.0);

                    case 5:
                        if (c < num2)
                        {
                            return new dk.a(dk.b.b, 0.0);
                        }
                        return new dk.a(dk.b.b, 1.0);

                    case 6:
                        if (c > num2)
                        {
                            return new dk.a(dk.b.b, 0.0);
                        }
                        return new dk.a(dk.b.b, 1.0);

                    case 7:
                        if (c == num2)
                        {
                            return new dk.a(dk.b.b, 0.0);
                        }
                        return new dk.a(dk.b.b, 1.0);

                    case 8:
                        return new dk.a(dk.b.b, c + num2);

                    case 9:
                        return new dk.a(dk.b.b, c - num2);

                    case 10:
                        return new dk.a(dk.b.b, c * num2);

                    case 11:
                        return new dk.a(dk.b.b, c / num2);

                    case 12:
                        return new dk.a(dk.b.b, (double) (((int) c) % ((int) num2)));
                }
            }
        }
        throw new dk.d("Invalid operator '" + A_2.b + "' for 'Number'");
    }

    public static bool a(aj.a A_0, string A_1, cv A_2, out bool A_3)
    {
        try
        {
            dk.d = true;
            b = A_0;
            c = A_2;
            dk.a a = dk.a(A_1);
            if (a.a == dk.b.b)
            {
                A_3 = dk.d;
                return !(a.c == 0.0);
            }
            A_3 = dk.d;
            return A_0.a.Trim().Equals(a.b.Trim(), StringComparison.OrdinalIgnoreCase);
        }
        catch (dk.d d)
        {
            ai.a("Parse error in monster spec: \"" + A_1 + "\", ignoring entry (" + d.Message + ").");
            A_3 = true;
            return false;
        }
        catch
        {
            ai.a("Unspecified error in monster spec: \"" + A_1 + "\", ignoring entry.");
            A_3 = true;
            return false;
        }
    }

    private static object b(cv A_0)
    {
        b("range");
        return (dh.a(A_0.k, PluginCore.cg, true) * 240.0);
    }

    private static void b(string A_0)
    {
        PluginCore.cq.d.a(A_0);
        d = false;
    }

    private static object c(cv A_0)
    {
        return PluginCore.cq.x.e(A_0.g());
    }

    private static object d(cv A_0)
    {
        int num = PluginCore.cq.x.f(A_0.g());
        FileService service = CoreManager.get_Current().get_FileService() as FileService;
        try
        {
            return service.get_SpeciesTable().GetById(num).get_Name();
        }
        catch
        {
            return "";
        }
    }

    private static object e(cv A_0)
    {
        return A_0.g();
    }

    private static object f(cv A_0)
    {
        return A_0.a(dt.cn, 0);
    }

    private static object g(cv A_0)
    {
        return 0.0;
    }

    private static object h(cv A_0)
    {
        return 1.0;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct a
    {
        public dk.b a;
        public string b;
        public double c;
        public a(dk.b A_0, string A_1)
        {
            this.a = A_0;
            this.b = A_1;
            this.c = 0.0;
        }

        public a(dk.b A_0, double A_1)
        {
            this.a = A_0;
            this.c = A_1;
            this.b = "";
        }

        public int a()
        {
            string b = this.b;
            if (b != null)
            {
                int num;
                if (bx.i == null)
                {
                    Dictionary<string, int> dictionary1 = new Dictionary<string, int>(14);
                    dictionary1.Add("&&", 0);
                    dictionary1.Add("||", 1);
                    dictionary1.Add("==", 2);
                    dictionary1.Add("<", 3);
                    dictionary1.Add(">", 4);
                    dictionary1.Add(">=", 5);
                    dictionary1.Add("<=", 6);
                    dictionary1.Add("!=", 7);
                    dictionary1.Add("#", 8);
                    dictionary1.Add("+", 9);
                    dictionary1.Add("-", 10);
                    dictionary1.Add("*", 11);
                    dictionary1.Add("/", 12);
                    dictionary1.Add("%", 13);
                    bx.i = dictionary1;
                }
                if (bx.i.TryGetValue(b, out num))
                {
                    switch (num)
                    {
                        case 0:
                            return -1;

                        case 1:
                            return -1;

                        case 2:
                            return 0;

                        case 3:
                            return 0;

                        case 4:
                            return 0;

                        case 5:
                            return 0;

                        case 6:
                            return 0;

                        case 7:
                            return 0;

                        case 8:
                            return 1;

                        case 9:
                            return 2;

                        case 10:
                            return 2;

                        case 11:
                            return 3;

                        case 12:
                            return 3;

                        case 13:
                            return 3;
                    }
                }
            }
            throw new dk.d("Invalid operator '" + this.b + "'");
        }
    }

    private enum b
    {
        a,
        b,
        c,
        d,
        e,
        f
    }

    public delegate object c(cv A_0);

    private class d : Exception
    {
        public d(string A_0) : base(A_0)
        {
        }
    }
}

