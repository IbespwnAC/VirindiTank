using Decal.Adapter;
using Decal.Adapter.Wrappers;
using Decal.Filters;
using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using uTank2;

internal class bv : IDisposable
{
    private PluginCore.EmptyDelegate a;
    private bool b;
    public bf c = new bf();
    private bool d;
    private ea e = new ea();

    public bv(CoreManager A_0)
    {
        string path = Path.Combine(PluginCore.ci, "gameinfodb.ugd");
        if (File.Exists(path))
        {
            try
            {
                this.c.b(path);
                bf bf = new bf();
                bf.d("uTank2.Resources.defaultinfodb.ugd");
                if (this.a(this.c) != this.a(bf))
                {
                    this.c = bf;
                }
            }
            catch (Exception)
            {
                this.c.d("uTank2.Resources.defaultinfodb.ugd");
            }
        }
        else
        {
            this.c.d("uTank2.Resources.defaultinfodb.ugd");
        }
        A_0.get_WorldFilter().add_CreateObject(new EventHandler<CreateObjectEventArgs>(this.a));
    }

    public static int a()
    {
        return a(DateTimeOffset.UtcNow);
    }

    private int a(bf A_0)
    {
        try
        {
            return k.e(A_0["DBVersion"].d()[0][0]);
        }
        catch (Exception)
        {
            return 1;
        }
    }

    public void a(WorldObject A_0)
    {
        if ((A_0.get_ObjectClass() == 5) && !this.b(A_0.get_Name()))
        {
            PluginCore.cq.u.b(A_0.get_Id(), new b0.b(this.a));
        }
        if ((A_0.get_ObjectClass() == 0x1d) && (this.a(A_0.get_Name()) == null))
        {
            PluginCore.cq.u.b(A_0.get_Id(), new b0.b(this.a));
        }
    }

    public void a(dp A_0)
    {
        if (this.c["HealKits"].a(0, k.a(A_0.a)) == null)
        {
            v v = new v(this.c["HealKits"]);
            v.a("KitName", k.a(A_0.a));
            v.a("RestoreBonus", k.a(A_0.b));
            v.a("SkillBonus", k.a(A_0.c));
            v.a("WhichVital", k.a((int) A_0.d));
            this.c["HealKits"].c(v);
            try
            {
                this.c.c(Path.Combine(PluginCore.ci, "gameinfodb.ugd"));
            }
            catch
            {
            }
        }
    }

    public static int a(DateTimeOffset A_0)
    {
        TimeSpan span = (TimeSpan) (A_0 - new DateTimeOffset(new DateTime(0x7b2, 1, 1), TimeSpan.Zero));
        return (int) span.TotalSeconds;
    }

    public static DateTimeOffset a(int A_0)
    {
        TimeSpan span = new TimeSpan(0, 0, A_0);
        return (new DateTimeOffset(new DateTime(0x7b2, 1, 1), TimeSpan.Zero) + span);
    }

    public dp a(string A_0)
    {
        v v = this.c["HealKits"].a(0, k.a(A_0));
        if (v == null)
        {
            return null;
        }
        return new dp { a = k.b(v.a("KitName")), b = k.f(v.a("RestoreBonus")), c = k.e(v.a("SkillBonus")), d = (eRechargeVital_Single) k.e(v.a("WhichVital")) };
    }

    private string a(TimeSpan A_0)
    {
        StringBuilder builder = new StringBuilder();
        if (A_0.Days > 1)
        {
            builder.Append(A_0.Days);
            builder.Append(" Days, ");
        }
        else if (A_0.Days == 1)
        {
            builder.Append("1 Day, ");
        }
        if (A_0.Hours > 1)
        {
            builder.Append(A_0.Hours);
            builder.Append(" Hours, ");
        }
        else if (A_0.Hours == 1)
        {
            builder.Append("1 Hour, ");
        }
        if (A_0.Minutes > 1)
        {
            builder.Append(A_0.Minutes);
            builder.Append(" Minutes, ");
        }
        else if (A_0.Minutes == 1)
        {
            builder.Append("1 Minute, ");
        }
        if (A_0.Seconds == 1)
        {
            builder.Append("1 Second");
        }
        else
        {
            builder.Append(A_0.Seconds);
            builder.Append(" Seconds");
        }
        return builder.ToString();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void a(PluginCore.EmptyDelegate A_0)
    {
        this.a = (PluginCore.EmptyDelegate) Delegate.Combine(this.a, A_0);
    }

    private void a(bool A_0, TextReader A_1)
    {
        if (A_0)
        {
            try
            {
                bf bf = new bf();
                bf.a(A_1);
                int num = bf.b() - 1;
                if (num > 0)
                {
                    foreach (KeyValuePair<string, a0> pair in this.c)
                    {
                        int num2 = 0;
                        for (int i = 0; i < pair.Value.a(); i++)
                        {
                            if (pair.Value.b(i))
                            {
                                num2 = i;
                                break;
                            }
                        }
                        if (bf.ContainsKey(pair.Key))
                        {
                            pair.Value.a(bf[pair.Key], num2);
                        }
                    }
                    string str = Path.Combine(PluginCore.ci, "gameinfodb.ugd");
                    try
                    {
                        this.c.c(str);
                    }
                    catch
                    {
                    }
                    PluginCore.cq.d.c();
                    PluginCore.e("GameInfoDB updated (" + num.ToString() + " changed records).");
                }
                else
                {
                    PluginCore.e("GameInfoDB is current.");
                }
            }
            catch (Exception exception)
            {
                PluginCore.e("GameInfoDB update failed due to an unknown error.");
                PluginCore.cq.n.a(exception.Message, e8.f);
                PluginCore.cq.n.a(exception.StackTrace, e8.f);
            }
        }
        else
        {
            PluginCore.e("GameInfoDB update failed (" + A_1.ReadToEnd() + ").");
        }
        this.b = true;
        this.f();
        if (this.a != null)
        {
            this.a();
        }
    }

    private void a(int A_0, bool A_1)
    {
        WorldObject obj2 = PluginCore.cq.aw.get_WorldFilter().get_Item(A_0);
        cv cv = PluginCore.cq.p.d(A_0);
        if ((A_1 && dh.b(A_0)) && (obj2.get_HasIdData() && (cv != null)))
        {
            ObjectClass class2 = cv.c();
            if (class2 != ObjectClass.Monster)
            {
                if (class2 != ObjectClass.HealingKit)
                {
                    return;
                }
            }
            else
            {
                if (!this.b(obj2.get_Name()))
                {
                    int num = obj2.Values(2, -1);
                    int num2 = cv.a(dt.dz, -1);
                    v v = new v(this.c["SpeciesMembers"]);
                    v[0] = k.a(obj2.get_Name());
                    v[1] = k.a(num);
                    v[2] = k.a(num2);
                    this.c["SpeciesMembers"].c(v);
                    try
                    {
                        this.c.c(Path.Combine(PluginCore.ci, "gameinfodb.ugd"));
                    }
                    catch
                    {
                    }
                    if (this.c["SpeciesDamages"].a(0, k.a(num)) == null)
                    {
                        a5.a(eChatType.Warnings, "Warning: added monster \"" + obj2.get_Name() + "\" to DB but species \"" + ((FileService) PluginCore.cq.aw.get_FileService()).get_SpeciesTable().GetById(num).get_Name() + "\" has no auto damage definition.");
                    }
                    PluginCore.cq.d.c();
                    if (this.a == null)
                    {
                        return;
                    }
                    this.a();
                }
                return;
            }
            if (this.a(obj2.get_Name()) == null)
            {
                dp dp = new dp {
                    a = obj2.get_Name(),
                    b = obj2.Values(100, 1.0),
                    c = obj2.Values(90, 0)
                };
                switch (obj2.Values(0x59, 0))
                {
                    case 2:
                        dp.d = eRechargeVital_Single.Health;
                        break;

                    case 4:
                        dp.d = eRechargeVital_Single.Stamina;
                        break;

                    case 6:
                        dp.d = eRechargeVital_Single.Mana;
                        break;

                    default:
                        dp.d = eRechargeVital_Single.Health;
                        break;
                }
                this.a(dp);
                if (this.a != null)
                {
                    this.a();
                }
            }
        }
    }

    private void a(object A_0, CreateObjectEventArgs A_1)
    {
        try
        {
            if (this.b && (PluginCore.cq.aw.get_WorldFilter().get_Item(A_1.get_New().get_Id()) != null))
            {
                this.a(A_1.get_New());
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    public void b()
    {
        if (!this.d)
        {
            this.d = true;
            GC.SuppressFinalize(this);
            PluginCore.cq.aw.get_WorldFilter().remove_CreateObject(new EventHandler<CreateObjectEventArgs>(this.a));
            if (this.e != null)
            {
                this.e.b();
            }
        }
    }

    public void b(int A_0)
    {
        WorldObject obj2 = CoreManager.get_Current().get_WorldFilter().get_Item(A_0);
        if (obj2 != null)
        {
            this.a(obj2);
        }
    }

    public bool b(string A_0)
    {
        if (!this.b)
        {
            return false;
        }
        return (this.c["SpeciesMembers"].a(0, k.a(A_0)) != null);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void b(PluginCore.EmptyDelegate A_0)
    {
        this.a = (PluginCore.EmptyDelegate) Delegate.Remove(this.a, A_0);
    }

    public DateTimeOffset c()
    {
        return a(k.e(this.c["DBLastUpdateTime"].d()[0][1]));
    }

    public cu c(int A_0)
    {
        v v = this.c["SpellQualityOverrides"].a(0, k.a(A_0));
        if (v == null)
        {
            return null;
        }
        return new cu { a = k.e(v.a("SpellID")), b = k.a(v.a("Valid")), c = k.e(v.a("NewQuality")), d = k.e(v.a("NewFamily")) };
    }

    public an c(string A_0)
    {
        an an = new an();
        if (this.b)
        {
            v v = this.c["MonsterDamageOverrides"].a(0, k.a(A_0));
            if (v != null)
            {
                return an.a(k.b(v[1]));
            }
            v = this.c["SpeciesMembers"].a(0, k.a(A_0));
            if (v != null)
            {
                v v2 = this.c["SpeciesDamages"].a(0, v[1]);
                if (v2 != null)
                {
                    return an.a(k.b(v2[1]));
                }
            }
        }
        return an;
    }

    public void d()
    {
        this.b = false;
        int num = k.e(this.c["DBLastUpdateTime"].d()[0][1]);
        PluginCore.e("Checking for GameInfoDB update (DB age " + this.a((TimeSpan) (DateTimeOffset.UtcNow - a(num))) + ").");
        this.e.a("http://auth.virindi.net/plugins/gamedb/get2.php?date=" + num.ToString() + "&dbver=" + this.a(this.c).ToString(), new ea.b(this.a));
    }

    public bz d(string A_0)
    {
        v v = this.c["GrenadeOptions"].a(0, k.a(A_0));
        if (v == null)
        {
            return null;
        }
        bz bz = new bz {
            a = k.b(v.a("GrenName")),
            b = k.e(v.a("WieldReqType")),
            c = k.e(v.a("WieldReqAttribute")),
            d = k.e(v.a("WieldReqValue")),
            e = PluginCore.cq.e.b(k.e(v.a("Spell"))),
            f = k.e(v.a("Spellcraft"))
        };
        if (bz.e == null)
        {
            return null;
        }
        return bz;
    }

    public bool e()
    {
        return this.b;
    }

    public int e(string A_0)
    {
        if (!this.b)
        {
            return -1;
        }
        v v = this.c["SpeciesMembers"].a(0, k.a(A_0));
        if (v == null)
        {
            return -1;
        }
        return k.e(v[2]);
    }

    public void f()
    {
        List<string> list = new List<string>();
        foreach (WorldObject obj2 in PluginCore.cq.aw.get_WorldFilter().GetInventory())
        {
            if (!list.Contains(obj2.get_Name()))
            {
                list.Add(obj2.get_Name());
                this.a(obj2);
            }
        }
    }

    public int f(string A_0)
    {
        if (!this.b)
        {
            return -1;
        }
        v v = this.c["SpeciesMembers"].a(0, k.a(A_0));
        if (v == null)
        {
            return -1;
        }
        return k.e(v[1]);
    }
}

