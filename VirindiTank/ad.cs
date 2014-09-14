using Decal.Adapter;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using uTank2;

internal class ad
{
    private static string a = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), @"Decal Plugins\Virindi Tank\vtank-error.txt");
    internal static bool b = false;

    internal static void a(Exception A_0)
    {
        try
        {
            if (PluginCore.PC != null)
            {
                if (!b)
                {
                    if (!PluginCore.cj)
                    {
                        string str = "[VTank] Exception \"" + A_0.Message + "\", full data written to " + a;
                        if (str.Length > 0xff)
                        {
                            str = str.Substring(0, 0xf8) + " [...]";
                        }
                        try
                        {
                            a5.a(eChatType.Errors, str);
                        }
                        catch (Exception)
                        {
                        }
                        b = true;
                        PluginCore.cq.c.StopMacro();
                        b = false;
                    }
                    try
                    {
                        dj.a(A_0, true);
                    }
                    catch
                    {
                    }
                }
                else if (!PluginCore.cj)
                {
                    string str2 = "Exception occurred while trying to stop macro.";
                    try
                    {
                        a5.a(eChatType.Errors, str2);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            string directoryName = Path.GetDirectoryName(a);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            using (StreamWriter writer = new StreamWriter(a, true))
            {
                writer.WriteLine("============================================================================");
                writer.WriteLine(DateTimeOffset.Now.ToString());
                writer.Write("PC == null? ");
                writer.WriteLine(PluginCore.PC == null);
                writer.Write("C == null? ");
                writer.WriteLine(PluginCore.cq == null);
                writer.Write("VTank version: ");
                writer.WriteLine(Assembly.GetExecutingAssembly().GetName(false).Version.ToString());
                writer.WriteLine("Error: " + A_0.Message);
                writer.WriteLine("Source: " + A_0.Source);
                writer.WriteLine("Stack: " + A_0.StackTrace);
                if (A_0.InnerException != null)
                {
                    writer.WriteLine("Inner: " + A_0.InnerException.Message);
                    writer.WriteLine("Inner Stack: " + A_0.InnerException.StackTrace);
                }
                writer.WriteLine("============================================================================");
                writer.WriteLine("");
            }
        }
        catch (Exception)
        {
        }
    }

    internal static void a(Exception A_0, NetworkMessageEventArgs A_1)
    {
        if (A_1 == null)
        {
            a(A_0);
        }
        else
        {
            StringBuilder builder = new StringBuilder();
            foreach (byte num in A_1.get_Message().get_RawData())
            {
                builder.AppendFormat("{0:X2}:", num);
            }
            builder.Append(";;;;");
            a(new Exception(A_0.ToString() + "\n\nPKT: " + builder.ToString()));
        }
    }
}

