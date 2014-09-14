using System;
using System.Globalization;
using System.Runtime.InteropServices;

internal class m
{
    public static bool a(char A_0)
    {
        int num2 = Convert.ToInt32('A');
        int num3 = Convert.ToInt32('0');
        A_0 = char.ToUpper(A_0, CultureInfo.InvariantCulture);
        int num = Convert.ToInt32(A_0);
        return (((num >= num2) && (num < (num2 + 6))) || ((num >= num3) && (num < (num3 + 10))));
    }

    private static byte a(string A_0)
    {
        if ((A_0.Length > 2) || (A_0.Length <= 0))
        {
            throw new ArgumentException("hex must be 1 or 2 characters in length");
        }
        return byte.Parse(A_0, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
    }

    public static string a(byte[] A_0)
    {
        string str = "";
        for (int i = 0; i < A_0.Length; i++)
        {
            str = str + A_0[i].ToString("X2");
        }
        return str;
    }

    public static byte[] a(string A_0, out int A_1)
    {
        A_1 = 0;
        string str = "";
        for (int i = 0; i < A_0.Length; i++)
        {
            char ch = A_0[i];
            if (a(ch))
            {
                str = str + ch;
            }
            else
            {
                A_1++;
            }
        }
        if ((str.Length % 2) != 0)
        {
            A_1++;
            str = str.Substring(0, str.Length - 1);
        }
        int num2 = str.Length / 2;
        byte[] buffer = new byte[num2];
        int num3 = 0;
        for (int j = 0; j < buffer.Length; j++)
        {
            string str2 = new string(new char[] { str[num3], str[num3 + 1] });
            buffer[j] = a(str2);
            num3 += 2;
        }
        return buffer;
    }

    public static bool b(string A_0)
    {
        foreach (char ch in A_0)
        {
            if (!a(ch))
            {
                return false;
            }
        }
        return true;
    }

    public static int c(string A_0)
    {
        int num = 0;
        for (int i = 0; i < A_0.Length; i++)
        {
            char ch = A_0[i];
            if (a(ch))
            {
                num++;
            }
        }
        if ((num % 2) != 0)
        {
            num--;
        }
        return (num / 2);
    }
}

