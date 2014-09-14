using System;
using System.Text;
using uTank2;

internal class an : MyList<eDamageElement>
{
    public an() : base(0x5f)
    {
    }

    public static string a(an A_0)
    {
        StringBuilder builder = new StringBuilder();
        int num = 0;
        foreach (eDamageElement element in A_0)
        {
            num++;
            builder.Append((int) element);
            if (num < A_0.Count)
            {
                builder.Append(';');
            }
        }
        return builder.ToString();
    }

    public static an a(string A_0)
    {
        string[] strArray = A_0.Split(new char[] { ';' });
        an an = new an();
        foreach (string str in strArray)
        {
            an.Add((eDamageElement) Convert.ToInt32(str));
        }
        return an;
    }

    public eDamageElement b(an A_0)
    {
        foreach (eDamageElement element in this)
        {
            if (A_0.Contains(element))
            {
                return element;
            }
        }
        return eDamageElement.None;
    }
}

