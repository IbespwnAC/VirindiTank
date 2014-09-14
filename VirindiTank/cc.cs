using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using uTank2;
using uTank2.LootPlugins;

internal class cc : IDisposable
{
    private dy a;
    private bool b;
    internal List<dy> c = new List<dy>();
    private bool d;

    protected override void a()
    {
        try
        {
            this.f();
        }
        finally
        {
            base.Finalize();
        }
    }

    public LootAction a(int A_0)
    {
        if (this.a == null)
        {
            return LootAction.NoLoot;
        }
        GameItemInfo item = new GameItemInfo(A_0);
        if (!item.IsValid)
        {
            return LootAction.NoLoot;
        }
        try
        {
            return this.a.a.GetLootDecision(item);
        }
        catch
        {
            return LootAction.NoLoot;
        }
    }

    public bool a(string A_0)
    {
        foreach (dy dy in this.c)
        {
            if (dy.b.a == A_0.ToLowerInvariant())
            {
                return true;
            }
        }
        return false;
    }

    public bool a(Type A_0)
    {
        if (this.a == null)
        {
            return false;
        }
        return A_0.IsAssignableFrom(this.a.a.GetType());
    }

    public void a(string A_0, bool A_1)
    {
        this.h();
        string[] strArray = A_0.Split(new char[] { '.' });
        string str = strArray[strArray.Length - 1].ToLowerInvariant();
        dy dy = null;
        foreach (dy dy2 in this.c)
        {
            if (dy2.b.a == str)
            {
                dy = dy2;
                break;
            }
        }
        if (dy != null)
        {
            this.a = dy;
            try
            {
                this.a.a.LoadProfile(A_0, A_1);
            }
            catch
            {
            }
        }
    }

    public void b()
    {
        this.h();
        foreach (dy dy in this.c)
        {
            try
            {
                dy.a.Shutdown();
            }
            catch
            {
            }
            dy.a.a.DestroyAllViews();
            dy.a.b.a = null;
            dy.a.a.a = null;
        }
        this.c.Clear();
    }

    public bool b(int A_0)
    {
        if (this.a == null)
        {
            return false;
        }
        GameItemInfo item = new GameItemInfo(A_0);
        if (!item.IsValid)
        {
            return false;
        }
        try
        {
            return this.a.a.DoesPotentialItemNeedID(item);
        }
        catch
        {
            return false;
        }
    }

    public bool c()
    {
        return (this.a != null);
    }

    public List<string> d()
    {
        List<string> list = new List<string>();
        foreach (dy dy in this.c)
        {
            string a = dy.b.a;
            if (!list.Contains(a))
            {
                list.Add(a);
            }
        }
        return list;
    }

    public void e()
    {
        foreach (dy dy in this.c)
        {
            PluginCore.e("(*." + dy.b.a + ") " + dy.d);
        }
    }

    public void f()
    {
        if (!this.d)
        {
            this.d = true;
            GC.SuppressFinalize(this);
            this.b();
        }
    }

    public void g()
    {
        RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Decal\LootPlugins");
        if (key != null)
        {
            foreach (string str in key.GetSubKeyNames())
            {
                LootPluginBase base2;
                string str2 = "";
                string path = "";
                string str4 = "";
                Assembly assembly = null;
                try
                {
                    RegistryKey key2 = key.OpenSubKey(str);
                    if (((key2.GetValueKind("") != RegistryValueKind.String) || (key2.GetValueKind("Assembly") != RegistryValueKind.String)) || ((key2.GetValueKind("Object") != RegistryValueKind.String) || (key2.GetValueKind("Path") != RegistryValueKind.String)))
                    {
                        continue;
                    }
                    path = Path.Combine((string) key2.GetValue("Path"), (string) key2.GetValue("Assembly"));
                    str4 = (string) key2.GetValue("");
                    str2 = (string) key2.GetValue("Object");
                    if (!File.Exists(path))
                    {
                        continue;
                    }
                    AssemblyName assemblyRef = new AssemblyName {
                        CodeBase = path
                    };
                    assembly = Assembly.Load(assemblyRef);
                    if (assembly == null)
                    {
                        continue;
                    }
                    Type type = assembly.GetType(str2);
                    if ((type == null) || !type.IsSubclassOf(typeof(LootPluginBase)))
                    {
                        continue;
                    }
                    base2 = (LootPluginBase) Activator.CreateInstance(type);
                    if (base2 == null)
                    {
                        continue;
                    }
                }
                catch
                {
                    continue;
                }
                dy item = new dy();
                this.c.Add(item);
                item.d = str4;
                item.e = path;
                item.c = assembly;
                item.a = base2;
                base2.b = new VTHost();
                base2.b.a = item;
                base2.a = new FlexibleViewSystem();
                base2.a.a = item;
                try
                {
                    item.b = base2.Startup();
                    if (item.b == null)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    try
                    {
                        base2.Shutdown();
                    }
                    catch
                    {
                    }
                    this.c.Remove(item);
                    item.a.b.a = null;
                    item.a.a.a = null;
                }
            }
        }
    }

    public void h()
    {
        if (this.a != null)
        {
            this.k();
            try
            {
                this.a.a.UnloadProfile();
            }
            catch
            {
            }
            this.a = null;
        }
    }

    public LootPluginBase i()
    {
        if (this.a == null)
        {
            return null;
        }
        return this.a.a;
    }

    public bool j()
    {
        if (this.a == null)
        {
            return false;
        }
        if (!this.b)
        {
            try
            {
                this.a.a.OpenEditorForProfile();
            }
            catch
            {
            }
            this.b = true;
        }
        return true;
    }

    public void k()
    {
        if ((this.a != null) && this.b)
        {
            try
            {
                this.a.a.CloseEditorForProfile();
            }
            catch
            {
            }
            this.b = false;
            if (!PluginCore.cj)
            {
                PluginCore.PC.aw.Checked = false;
            }
        }
    }
}

