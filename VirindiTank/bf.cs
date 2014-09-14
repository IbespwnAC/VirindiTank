using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using uTank2;

internal class bf : MySortedDictionary<string, a0>
{
    private static Dictionary<string, e6> a = new Dictionary<string, e6>();
    private static bool b = false;
    private static readonly object c = new object();

    public bf() : base(0x52)
    {
        this.a();
    }

    public bf(string A_0) : base(0x53)
    {
        this.a();
        this.b(A_0);
    }

    private void a()
    {
        if (!b)
        {
            lock (c)
            {
                if (!b)
                {
                    a(new a0(new string[0]));
                    a(new fa());
                    b = true;
                }
            }
        }
    }

    public static bool a(e6 A_0)
    {
        string key = A_0.a();
        if (a.ContainsKey(key))
        {
            return false;
        }
        a.Add(key, A_0);
        return true;
    }

    public void a(StreamWriter A_0)
    {
        A_0.WriteLine(base.Count.ToString(CultureInfo.InvariantCulture));
        foreach (KeyValuePair<string, a0> pair in this)
        {
            A_0.WriteLine(pair.Key);
            pair.Value.a(A_0);
        }
    }

    public void a(TextReader A_0)
    {
        base.Clear();
        int num = Convert.ToInt32(A_0.ReadLine(), CultureInfo.InvariantCulture);
        for (int i = 0; i < num; i++)
        {
            string str = A_0.ReadLine();
            base[str] = new a0(new string[0]);
            base[str].a(A_0);
        }
    }

    public static e6 a(string A_0)
    {
        if (!a.ContainsKey(A_0))
        {
            return null;
        }
        try
        {
            return (e6) a[A_0].GetType().GetConstructor(new Type[0]).Invoke(new object[0]);
        }
        catch
        {
            return null;
        }
    }

    public int b()
    {
        int num = 0;
        foreach (KeyValuePair<string, a0> pair in this)
        {
            num += pair.Value.c();
        }
        return num;
    }

    public void b(string A_0)
    {
        using (FileStream stream = new FileStream(A_0, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                this.a(reader);
            }
        }
    }

    public void c(string A_0)
    {
        StreamWriter writer = new StreamWriter(A_0);
        try
        {
            this.a(writer);
        }
        finally
        {
            writer.Close();
        }
    }

    public void d(string A_0)
    {
        Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(A_0);
        StreamReader reader = new StreamReader(manifestResourceStream);
        this.a(reader);
        reader.Close();
        manifestResourceStream.Close();
    }
}

