using Decal.Adapter;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

internal static class c4
{
    private static Dictionary<int, int> a = new Dictionary<int, int>();
    private static bool b = false;

    private static string a()
    {
        string str = (string) Registry.LocalMachine.OpenSubKey(@"Software\Decal\Agent").GetValue("AgentPath");
        XmlDocument document = new XmlDocument();
        string str2 = "?";
        using (StreamReader reader = new StreamReader(Path.Combine(str, "messages.xml")))
        {
            string xml = reader.ReadToEnd();
            document.LoadXml(xml);
            str2 = document.DocumentElement.GetElementsByTagName("revision")[0].Attributes[0].Value;
            SHA1 sha = SHA1.Create();
            reader.BaseStream.Position = 0L;
            byte[] buffer = new byte[reader.BaseStream.Length];
            reader.BaseStream.Read(buffer, 0, buffer.Length);
            string str4 = Convert.ToBase64String(sha.ComputeHash(buffer));
            return string.Format("{0} (SHA1 {1})", str2, str4);
        }
    }

    private static void a(object A_0, MessageProcessedEventArgs A_1)
    {
        try
        {
            byte[] buffer = A_1.get_Message().get_RawData();
            MessageDirection direction = 0;
            int num = BitConverter.ToInt32(buffer, 0);
            object obj2 = typeof(Message).GetMethod("GetParser", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof(int), typeof(MessageDirection) }, null).Invoke(null, new object[] { num, direction });
            Type type = Assembly.GetAssembly(typeof(Message)).GetType("Decal.Adapter.NetParser.MemberParser");
            Message message = (Message) typeof(Message).GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(byte[]), type }, null).Invoke(new object[] { buffer, obj2 });
            bool flag = false;
            Exception exception = null;
            try
            {
                message.get_Count();
                flag = true;
            }
            catch (Exception exception2)
            {
                exception = exception2;
            }
            if (!flag)
            {
                a(buffer, direction, exception);
            }
        }
        catch
        {
        }
    }

    private static void a(byte[] A_0, MessageDirection A_1, Exception A_2)
    {
        int key = BitConverter.ToInt32(A_0, 0);
        string str = "???";
        if (!a.ContainsKey(key))
        {
            a[key] = 1;
        }
        else
        {
            Dictionary<int, int> dictionary;
            int num3;
            (dictionary = a)[num3 = key] = dictionary[num3] + 1;
        }
        try
        {
            str = a();
        }
        catch
        {
        }
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("[VTank] Decal parse failure logged for {0} message with type {1}, messages ver {2}, data: ", A_1, key, str);
        builder.AppendFormat("[{0:0000}:{1:00}:{2:00}:{3:00}:{4:00}:{5:00}]   ", new object[] { DateTimeOffset.Now.Year, DateTimeOffset.Now.Month, DateTimeOffset.Now.Day, DateTimeOffset.Now.Hour, DateTimeOffset.Now.Minute, DateTimeOffset.Now.Second });
        builder.Append("[");
        builder.Append(key.ToString("X"));
        builder.Append(",");
        builder.Append(A_1.ToString());
        builder.Append("]  ");
        foreach (byte num2 in A_0)
        {
            builder.AppendFormat("{0:X2}:", num2);
        }
        builder.Append("    ");
        builder.Append(A_2.ToString());
        string message = builder.ToString();
        Debug.Print(message);
        if (a[key] <= 3)
        {
            dj.a(new Exception(message), false);
        }
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), @"Decal Plugins\Virindi Tank\parseerrors.txt");
        string directoryName = Path.GetDirectoryName(path);
        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.Write(message);
            writer.WriteLine();
        }
    }

    public static void b()
    {
        if (b)
        {
            b = false;
            CoreManager.get_Current().remove_MessageProcessed(new EventHandler<MessageProcessedEventArgs>(c4.a));
        }
    }

    public static void c()
    {
        if (!b)
        {
            b = true;
            CoreManager.get_Current().add_MessageProcessed(new EventHandler<MessageProcessedEventArgs>(c4.a));
        }
    }
}

