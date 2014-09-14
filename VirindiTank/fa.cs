using System;
using System.Globalization;
using System.IO;

internal class fa : e6
{
    public string a = "";

    public string a()
    {
        return "ba";
    }

    public bool a(TextReader A_0)
    {
        int count = Convert.ToInt32(A_0.ReadLine(), CultureInfo.InvariantCulture);
        char[] buffer = new char[count];
        if (A_0.Read(buffer, 0, count) != count)
        {
            return false;
        }
        this.a = new string(buffer);
        return true;
    }

    public void a(TextWriter A_0)
    {
        A_0.WriteLine(Convert.ToString(this.a.Length, CultureInfo.InvariantCulture));
        A_0.Write(this.a);
    }
}

