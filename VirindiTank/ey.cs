using System;

internal static class ey
{
    public static string a(int A_0, Type A_1)
    {
        string name = Enum.GetName(A_1, A_0);
        if (name == null)
        {
            return "???";
        }
        string[] strArray = name.Split(new char[] { '_' }, 2);
        if (strArray.Length != 2)
        {
            return name;
        }
        return strArray[1];
    }

    public static int a(int A_0, Type A_1, string A_2)
    {
        string[] names = Enum.GetNames(A_1);
        string name = Enum.GetName(A_1, A_0);
        if (name == null)
        {
            for (int k = 0; k < names.Length; k++)
            {
                if (names[k].StartsWith(A_2))
                {
                    return (int) Enum.Parse(A_1, names[k]);
                }
            }
            return (int) Enum.Parse(A_1, names[0]);
        }
        int index = -1;
        for (int i = 0; i < names.Length; i++)
        {
            if (names[i] == name)
            {
                index = i;
                break;
            }
        }
    Label_0073:
        index++;
        if ((index < names.Length) && !names[index].Equals("LISTEDTYPES_END", StringComparison.OrdinalIgnoreCase))
        {
            if (names[index].StartsWith(A_2))
            {
                return (int) Enum.Parse(A_1, names[index]);
            }
            goto Label_0073;
        }
        for (int j = 0; j < names.Length; j++)
        {
            if (names[j].StartsWith(A_2))
            {
                return (int) Enum.Parse(A_1, names[j]);
            }
        }
        return (int) Enum.Parse(A_1, names[0]);
    }

    public static int b(int A_0, Type A_1)
    {
        string[] names = Enum.GetNames(A_1);
        string name = Enum.GetName(A_1, A_0);
        if (name == null)
        {
            return (int) Enum.Parse(A_1, names[0]);
        }
        int index = -1;
        for (int i = 0; i < names.Length; i++)
        {
            if (names[i] == name)
            {
                index = i;
                break;
            }
        }
        index++;
        if (index >= names.Length)
        {
            return (int) Enum.Parse(A_1, names[0]);
        }
        if (names[index].Equals("LISTEDTYPES_END", StringComparison.OrdinalIgnoreCase))
        {
            return (int) Enum.Parse(A_1, names[0]);
        }
        return (int) Enum.Parse(A_1, names[index]);
    }
}

