using System;
using System.Collections.Generic;
using System.Text;

internal class @do : List<string[]>
{
    private int a;

    public @do(int A_0)
    {
        this.a = A_0;
    }

    public void a(string A_0)
    {
        base.Clear();
        foreach (string str in A_0.Split(new char[] { ';' }))
        {
            string[] item = str.Split(new char[] { ',' });
            if (item.Length == this.a)
            {
                base.Add(item);
            }
        }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < base.Count; i++)
        {
            string[] strArray = base[i];
            for (int j = 0; j < strArray.Length; j++)
            {
                builder.Append(strArray[j]);
                if (j != (strArray.Length - 1))
                {
                    builder.Append(",");
                }
            }
            if (i != (base.Count - 1))
            {
                builder.Append(";");
            }
        }
        return builder.ToString();
    }
}

