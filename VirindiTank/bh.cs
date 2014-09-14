using Decal.Adapter;
using Decal.Adapter.Wrappers;
using Decal.Filters;
using Decal.Interop.Filters;
using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using uTank2;

internal class bh : IDisposable
{
    public const string a = "uTank2 CDF 1.0";
    public bf b = new bf();
    public bf c = new bf();
    public string d = "uTank2.Resources.defaultsettings.usd";
    public string e = "uTank2.Resources.defaultsettingstemplate.usd";
    public bool f;
    public MyDictionary<string, MySpell> g = new MyDictionary<string, MySpell>(11);
    public MyDictionary<string, fz> h = new MyDictionary<string, fz>(12);
    public MyList<int> i = new MyList<int>(0x270f);
    public MyList<int> j = new MyList<int>(0x270f);
    public a4 k = new a4();
    public string l = "";
    public string m = "";
    public string n = "";
    public string o;
    public string p;
    public string q;
    private bool r;
    private bool s;
    public MyDictionary<string, aa> t = new MyDictionary<string, aa>(14);

    public bh()
    {
        this.b.d(this.d);
    }

    private void a()
    {
        PluginCore.cq.j.b(this.c["BuffedItems"]);
        this.h.Clear();
        foreach (v v in this.c["AssistItems"].d())
        {
            this.h.Add(k.b(v[0]), (fz) k.e(v[1]));
        }
        this.g.Clear();
        foreach (v v2 in this.c["GemFoodItems"].d())
        {
            this.g.Add(k.b(v2[0]), PluginCore.cq.e.b(k.e(v2[1])));
        }
        this.i.Clear();
        foreach (v v3 in this.c["ExtraBuffSpells"].d())
        {
            this.i.Add(k.e(v3[0]));
        }
        this.j.Clear();
        foreach (v v4 in this.c["AntiExtraBuffSpells"].d())
        {
            this.j.Add(k.e(v4[0]));
        }
        PluginCore.cq.ak.a(er.d("RechargeHandlerSet"));
    }

    private void a(aa A_0)
    {
        this.t.Add(A_0.e, A_0);
    }

    public int a(bool A_0)
    {
        if (A_0)
        {
            return er.i("SpellDiffExcessThreshold-Hunt");
        }
        return er.i("SpellDiffExcessThreshold-Buff");
    }

    public bool a(int A_0)
    {
        FileService service = PluginCore.cq.aw.get_FileService();
        string key = service.get_MaterialTable().GetById(A_0).get_Name();
        if (key != null)
        {
            int num;
            if (bx.j == null)
            {
                Dictionary<string, int> dictionary1 = new Dictionary<string, int>(0x19);
                dictionary1.Add("Agate", 0);
                dictionary1.Add("Azurite", 1);
                dictionary1.Add("Black Opal", 2);
                dictionary1.Add("Bloodstone", 3);
                dictionary1.Add("Carnelian", 4);
                dictionary1.Add("Citrine", 5);
                dictionary1.Add("Fire Opal", 6);
                dictionary1.Add("Hematite", 7);
                dictionary1.Add("Lavender Jade", 8);
                dictionary1.Add("Malachite", 9);
                dictionary1.Add("Red Jade", 10);
                dictionary1.Add("Rose Quartz", 11);
                dictionary1.Add("Sunstone", 12);
                dictionary1.Add("White Sapphire", 13);
                dictionary1.Add("Red Garnet", 14);
                dictionary1.Add("Jet", 15);
                dictionary1.Add("Imperial Topaz", 0x10);
                dictionary1.Add("Emerald", 0x11);
                dictionary1.Add("Black Garnet", 0x12);
                dictionary1.Add("Aquamarine", 0x13);
                dictionary1.Add("Zircon", 20);
                dictionary1.Add("Yellow Topaz", 0x15);
                dictionary1.Add("Peridot", 0x16);
                dictionary1.Add("Leather", 0x17);
                dictionary1.Add("Ivory", 0x18);
                bx.j = dictionary1;
            }
            if (bx.j.TryGetValue(key, out num))
            {
                switch (num)
                {
                    case 0:
                        return true;

                    case 1:
                        return true;

                    case 2:
                        return true;

                    case 3:
                        return true;

                    case 4:
                        return true;

                    case 5:
                        return true;

                    case 6:
                        return true;

                    case 7:
                        return true;

                    case 8:
                        return true;

                    case 9:
                        return true;

                    case 10:
                        return true;

                    case 11:
                        return true;

                    case 12:
                        return true;

                    case 13:
                        return true;

                    case 14:
                        return true;

                    case 15:
                        return true;

                    case 0x10:
                        return true;

                    case 0x11:
                        return true;

                    case 0x12:
                        return true;

                    case 0x13:
                        return true;

                    case 20:
                        return true;

                    case 0x15:
                        return true;

                    case 0x16:
                        return true;

                    case 0x17:
                        return true;

                    case 0x18:
                        return true;
                }
            }
        }
        return false;
    }

    public void a(int A_0, bool A_1)
    {
        if (!A_1 || !dh.b(A_0))
        {
            goto Label_045E;
        }
        WorldObject obj2 = PluginCore.cq.aw.get_WorldFilter().get_Item(A_0);
        if (((obj2.get_ObjectClass() == 6) || (obj2.get_ObjectClass() == 11)) || ((obj2.get_ObjectClass() == 0x1d) || (obj2.get_ObjectClass() == 0x10)))
        {
            string str;
            if (!obj2.Exists(0x11) || (((str = obj2.get_Name()) != null) && (((str == "Eternal Health Kit") || (str == "Eternal Stamina Kit")) || (str == "Eternal Mana Kit"))))
            {
                if (obj2.get_SpellCount() > 0)
                {
                    MySpell spell = PluginCore.cq.e.b(obj2.Spell(0));
                    if ((spell == null) || (spell.Duration < 1200.0))
                    {
                        goto Label_045E;
                    }
                }
                string key = obj2.get_Name();
                if (key != null)
                {
                    int num2;
                    if (bx.k == null)
                    {
                        Dictionary<string, int> dictionary1 = new Dictionary<string, int>(0x27);
                        dictionary1.Add("Burning Coal", 0);
                        dictionary1.Add("Enhanced Mucor", 1);
                        dictionary1.Add("Gem of Impulse", 2);
                        dictionary1.Add("Refreshing Water", 3);
                        dictionary1.Add("Enhanced Health Elixir", 4);
                        dictionary1.Add("Enhanced Mana Elixir", 5);
                        dictionary1.Add("Black Market Health Elixir", 6);
                        dictionary1.Add("Black Market Mana Elixir", 7);
                        dictionary1.Add("Draught of Revitalization", 8);
                        dictionary1.Add("Gonjoku's Mana Infusion", 9);
                        dictionary1.Add("Harbinger Blood Infusion", 10);
                        dictionary1.Add("Platinum Spirits", 11);
                        dictionary1.Add("Potion of Black Fire", 12);
                        dictionary1.Add("Potion of Destiny's Wind", 13);
                        dictionary1.Add("Potion of Endless Vigor", 14);
                        dictionary1.Add("Coral Fragment", 15);
                        dictionary1.Add("Blue Gem", 0x10);
                        dictionary1.Add("Black Page of Salt and Ash", 0x11);
                        dictionary1.Add("Dull Gem", 0x12);
                        dictionary1.Add("Gem of Black Fire", 0x13);
                        dictionary1.Add("Gem of Harbinger's Acid Barrier", 20);
                        dictionary1.Add("Gem of Harbinger's Flame Barrier", 0x15);
                        dictionary1.Add("Gem of Harbinger's Frost Barrier", 0x16);
                        dictionary1.Add("Gem of Harbinger's Lightning Barrier", 0x17);
                        dictionary1.Add("Miyako's Moonstone", 0x18);
                        dictionary1.Add("Priceless Ore", 0x19);
                        dictionary1.Add("Rage of Grael Gem", 0x1a);
                        dictionary1.Add("Red Gem", 0x1b);
                        dictionary1.Add("Swamp Gem", 0x1c);
                        dictionary1.Add("Essence of Cave Penguin", 0x1d);
                        dictionary1.Add("Stout Lugian Ale", 30);
                        dictionary1.Add("Hearty Lugian Loaf", 0x1f);
                        dictionary1.Add("Pepper Jack Cheese", 0x20);
                        dictionary1.Add("Tasty Pudding", 0x21);
                        dictionary1.Add("Thick Lugian Stew", 0x22);
                        dictionary1.Add("Light Infused Healing Kit", 0x23);
                        dictionary1.Add("Sake", 0x24);
                        dictionary1.Add("Slice of Royal Wedding Cake", 0x25);
                        dictionary1.Add("Massive Mana Charge", 0x26);
                        bx.k = dictionary1;
                    }
                    if (bx.k.TryGetValue(key, out num2))
                    {
                        switch (num2)
                        {
                            case 0:
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 0x10:
                            case 0x11:
                            case 0x12:
                            case 0x13:
                            case 20:
                            case 0x15:
                            case 0x16:
                            case 0x17:
                            case 0x18:
                            case 0x19:
                            case 0x1a:
                            case 0x1b:
                            case 0x1c:
                            case 0x1d:
                            case 30:
                            case 0x1f:
                            case 0x20:
                            case 0x21:
                            case 0x22:
                            case 0x23:
                            case 0x24:
                            case 0x25:
                            case 0x26:
                                goto Label_045E;
                        }
                    }
                }
                PluginCore.PC.h(A_0);
            }
            goto Label_045E;
        }
        if (!fn.a(obj2))
        {
            goto Label_045E;
        }
        if ((obj2.get_ObjectClass() == 1) || (obj2.get_ObjectClass() == 9))
        {
            SkillInfo o = null;
            try
            {
                int num = obj2.Values(0xd000020, 0);
                if (num != 0)
                {
                    o = PluginCore.cq.aw.get_CharacterFilter().get_Underlying().get_Skill((eSkillID) num);
                    if ((o.get_Training() != 1) && (o.get_Training() != null))
                    {
                        goto Label_041F;
                    }
                }
                goto Label_045E;
            }
            finally
            {
                if (o != null)
                {
                    Marshal.ReleaseComObject(o);
                }
            }
        }
    Label_041F:
        if (obj2.Exists(0x69) && !obj2.Exists(0xab))
        {
            if (CoreManager.get_Current().get_CharacterFilter().get_Level() >= 120)
            {
                goto Label_045E;
            }
            ai.a("Note: since you are under level 120, untinkered items are being auto-added to your items list.");
        }
        PluginCore.PC.l(A_0);
    Label_045E:
        if (this.r && (PluginCore.cq.u.b(b0.a.a) == 0))
        {
            PluginCore.e("Set default profile: Done scanning inventory.");
        }
    }

    private void b()
    {
        PluginCore.cq.j.a(this.c["BuffedItems"]);
        this.c["AssistItems"].f();
        foreach (string str in this.h.Keys)
        {
            v v = new v(this.c["AssistItems"]);
            v[0] = k.a(str);
            v[1] = k.a((int) this.h[str]);
            this.c["AssistItems"].c(v);
        }
        this.c["GemFoodItems"].f();
        foreach (string str2 in this.g.Keys)
        {
            v v2 = new v(this.c["GemFoodItems"]);
            v2[0] = k.a(str2);
            v2[1] = k.a(this.g[str2].Id);
            this.c["GemFoodItems"].c(v2);
        }
        this.c["ExtraBuffSpells"].f();
        foreach (int num in this.i)
        {
            v v3 = new v(this.c["ExtraBuffSpells"]);
            v3[0] = k.a(num);
            this.c["ExtraBuffSpells"].c(v3);
        }
        this.c["AntiExtraBuffSpells"].f();
        foreach (int num2 in this.j)
        {
            v v4 = new v(this.c["AntiExtraBuffSpells"]);
            v4[0] = k.a(num2);
            this.c["AntiExtraBuffSpells"].c(v4);
        }
        er.a("RechargeHandlerSet", PluginCore.cq.ak.b());
    }

    public void c()
    {
        if (!this.s)
        {
            this.s = true;
            GC.SuppressFinalize(this);
        }
    }

    public void d()
    {
        if (!string.IsNullOrEmpty(this.m))
        {
            this.n();
        }
        PluginCore.cq.ay.w();
    }

    public void e()
    {
        this.q();
        this.m();
        this.j();
        this.l();
        this.k();
    }

    public void f()
    {
        MyList<string> list = new MyList<string>(15);
        foreach (cv cv in PluginCore.cq.p.d())
        {
            if (list.Contains(cv.g()))
            {
                continue;
            }
            bool flag = false;
            switch (cv.c())
            {
                case ObjectClass.MeleeWeapon:
                    flag = true;
                    break;

                case ObjectClass.Armor:
                    flag = true;
                    break;

                case ObjectClass.Food:
                    flag = true;
                    list.Add(cv.g());
                    break;

                case ObjectClass.MissileWeapon:
                    flag = true;
                    break;

                case ObjectClass.Gem:
                    flag = true;
                    list.Add(cv.g());
                    break;

                case ObjectClass.ManaStone:
                    flag = true;
                    list.Add(cv.g());
                    break;

                case ObjectClass.HealingKit:
                    flag = true;
                    list.Add(cv.g());
                    break;

                case ObjectClass.WandStaffOrb:
                    flag = true;
                    break;
            }
            if (flag)
            {
                if (cv.j)
                {
                    this.a(cv.k, true);
                }
                else
                {
                    PluginCore.cq.u.a(cv.k, new b0.b(this.a), b0.a.a);
                }
            }
        }
        if (PluginCore.cq.u.b(b0.a.a) > 0)
        {
            PluginCore.e("Set default profile: Beginning inventory scan (" + PluginCore.cq.u.b(b0.a.a).ToString() + " items).");
            this.r = true;
        }
        else
        {
            PluginCore.e("Set default profile: Inventory scan not needed.");
        }
    }

    public void g()
    {
        if (!string.IsNullOrEmpty(this.n))
        {
            this.p();
        }
        PluginCore.cq.ay.l();
    }

    public void h()
    {
        this.t.Clear();
        this.a(new aa("Start/Stop", "Starts or stops the macro.", 0x13, false, false, false));
        this.a(new aa("Target lock", "Forces the macro to attack selected target.", 0x91, false, false, false));
        this.a(new aa("Navigation", "Enable / Disable bot navigation."));
        this.a(new aa("Looting", "Enable / Disable bot looting."));
        this.a(new aa("Combat", "Enable / Disable bot combat."));
        this.a(new aa("Buffing", "Enable /Disable bot buffing."));
        this.a(new aa("Force buff", "Initiates a forced rebuff."));
        this.a(new aa("Cancel force buff", "Cancels a forced rebuff."));
        this.a(new aa("MeleeLow", "Sets melee attack height to low.", 0x2e, false, true, false));
        this.a(new aa("MeleeMid", "Sets melee attack height to medium.", 0x23, false, true, false));
        this.a(new aa("MeleeHigh", "Sets melee attack height to high.", 0x22, false, true, false));
        this.a(new aa("NavAddPt", "Adds a new navigation waypoint."));
        this.a(new aa("TestItem", "Invokes /vt testitem."));
        this.a(new aa("PropertyDump", "Invokes /vt propertydump."));
        this.a(new aa("Recharge", "Attempts a single recharge with the current settings."));
        this.a(new aa("NavPrio", "Toggles navigation priority."));
        this.a(new aa("LootPrio", "Toggles loot priority."));
        this.a(new aa("NavLootPrio", "Toggles both nav and loot priority."));
        this.a(new aa("LootThisCont", "Flags the currently open container to be looted."));
    }

    public void i()
    {
    }

    public void j()
    {
        if ((PluginCore.cq.u.b(b0.a.a) > 0) && this.r)
        {
            PluginCore.e("Set default profile: Inventory scan canceled.");
        }
        this.r = false;
        PluginCore.cq.u.a(b0.a.a);
        if (string.IsNullOrEmpty(this.m))
        {
            this.o();
        }
        else
        {
            string path = Path.Combine(PluginCore.ci, this.m);
            if (File.Exists(path))
            {
                bool flag = true;
                try
                {
                    this.c.b(path);
                    if (this.c["MyMonsters"].a() <= 10)
                    {
                        this.c["MyMonsters"].b("Broadside", k.a(false));
                    }
                    if (this.c["MyMonsters"].a() <= 11)
                    {
                        this.c["MyMonsters"].b("Fester", k.a(false));
                    }
                    if (this.c["MyMonsters"].a() <= 12)
                    {
                        this.c["MyMonsters"].b("WeakeningCurse", k.a(false));
                    }
                    if (this.c["MyMonsters"].a() <= 13)
                    {
                        this.c["MyMonsters"].b("FesteringCurse", k.a(false));
                    }
                    if (this.c["MyMonsters"].a() <= 14)
                    {
                        this.c["MyMonsters"].b("Corruption", k.a(false));
                    }
                    if (this.c["MyMonsters"].a() <= 15)
                    {
                        this.c["MyMonsters"].b("DestructiveCurse", k.a(false));
                    }
                    if (this.c["MyMonsters"].a() <= 0x10)
                    {
                        this.c["MyMonsters"].b("Corrosion", k.a(false));
                    }
                    if (this.c["MyMonsters"].a() <= 0x11)
                    {
                        this.c["MyMonsters"].b("Streak", k.a(false));
                    }
                    if (this.c["MyMonsters"].a() <= 0x12)
                    {
                        this.c["MyMonsters"].b("SecondaryVuln", k.a(0x62));
                    }
                    if (this.c["MyMonsters"].a() <= 0x13)
                    {
                        this.c["MyMonsters"].b("SecondaryEquip", k.a(0));
                    }
                    if (!this.c.ContainsKey("ExtraBuffSpells"))
                    {
                        this.c.Add("ExtraBuffSpells", new a0(new string[] { "ExemplarId" }));
                    }
                    if (!this.c.ContainsKey("AntiExtraBuffSpells"))
                    {
                        this.c.Add("AntiExtraBuffSpells", new a0(new string[] { "ExemplarId" }));
                    }
                    if (!this.c.ContainsKey("ItemUseSpecifiers"))
                    {
                        this.c.Add("ItemUseSpecifiers", new a0(new string[] { "Object", "Uses" }));
                        this.c["ItemUseSpecifiers"].c(0);
                    }
                    this.a();
                }
                catch (Exception)
                {
                    flag = false;
                }
                if (flag)
                {
                    PluginCore.e("Loaded macro settings.");
                }
                else
                {
                    this.o();
                    this.b();
                    this.c.c(path);
                }
            }
            else
            {
                this.o();
                this.b();
                this.c.c(path);
            }
        }
        PluginCore.cq.d.c();
        PluginCore.cq.ay.w();
        er.a();
        PluginCore.cq.x.f();
    }

    public void k()
    {
        PluginCore.cq.ay.w();
        if (string.IsNullOrEmpty(this.n))
        {
            this.k.b();
        }
        else
        {
            if (!File.Exists(Path.Combine(PluginCore.ci, this.n)))
            {
                this.k.b();
                this.k.a(this.n);
            }
            if (this.k.b(this.n))
            {
                PluginCore.e("Loaded nav ruleset.");
            }
            else
            {
                this.k.b();
                this.k.a(this.n);
                PluginCore.e("Failed to load nav ruleset.");
            }
        }
        PluginCore.cq.ay.ak();
        PluginCore.cq.n.c();
        PluginCore.cq.ay.l();
    }

    public void l()
    {
        PluginCore.cq.ay.w();
        PluginCore.cq.ag.k();
        if (!string.IsNullOrEmpty(this.l))
        {
            string path = Path.Combine(PluginCore.ci, this.l);
            if (File.Exists(path))
            {
                PluginCore.cq.ag.a(path, false);
            }
            else
            {
                PluginCore.cq.ag.a(path, true);
            }
        }
        else
        {
            PluginCore.cq.ag.h();
        }
        PluginCore.cq.ay.p();
        PluginCore.PC.@as();
    }

    public void m()
    {
        string q = this.q;
        try
        {
            using (StreamReader reader = new StreamReader(Path.Combine(PluginCore.ci, PluginCore.cq.aw.get_CharacterFilter().get_Server() + "_" + PluginCore.cq.aw.get_CharacterFilter().get_Name() + ".cdf")))
            {
                if (reader.ReadLine() != "uTank2 CDF 1.0")
                {
                    this.l = "";
                    this.m = this.o;
                    this.n = this.p;
                    reader.Close();
                    this.r();
                    return;
                }
                this.m = reader.ReadLine();
                this.l = reader.ReadLine();
                this.n = reader.ReadLine();
                if (!reader.EndOfStream)
                {
                    q = reader.ReadLine();
                }
            }
            string[] strArray = this.m.Split(new char[] { '.' });
            if (strArray[strArray.Length - 1] == "uts")
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < (strArray.Length - 1); i++)
                {
                    builder.Append(strArray[i]);
                    builder.Append(".");
                }
                builder.Append("usd");
                this.m = builder.ToString();
            }
        }
        catch (Exception)
        {
            this.l = "";
            this.m = this.o;
            this.n = this.p;
            this.r();
        }
        finally
        {
            PluginCore.cq.@as.b(q);
        }
    }

    public void n()
    {
        if (PluginCore.cq.ay.cl)
        {
            this.b();
            this.c.c(Path.Combine(PluginCore.ci, this.m));
        }
        PluginCore.cq.ay.aa();
    }

    public void o()
    {
        if ((PluginCore.cq.u.b(b0.a.a) > 0) && this.r)
        {
            PluginCore.e("Set default profile: Inventory scan canceled.");
        }
        this.r = false;
        PluginCore.cq.u.a(b0.a.a);
        this.c.d(this.e);
        this.a();
        PluginCore.e("Loaded default settings.");
        if (PluginCore.cq.p.a("Splitting Tool").Count > 0)
        {
            PluginCore.e("Set default profile: Splitting Tool in inventory. Assuming you want to split old component peas.");
            PluginCore.PC.t();
        }
        this.f();
    }

    public void p()
    {
        this.k.a(this.n);
        PluginCore.cq.ay.ak();
    }

    public void q()
    {
        string str = "uTank2 SCF 1.06";
        int num = 0;
        foreach (string str2 in Directory.GetFiles(PluginCore.ci, "*.uts"))
        {
            try
            {
                string[] strArray2 = str2.Split(new char[] { '\\' });
                string str3 = strArray2[strArray2.Length - 1];
                string str4 = str3.Split(new char[] { '.' })[0];
                this.c.d(this.e);
                this.a();
                StreamReader reader = new StreamReader(str2);
                if (reader.ReadLine() == str)
                {
                    er.a("EnableLooting", k.a(Convert.ToBoolean(reader.ReadLine())));
                    er.a("EnableNav", k.a(Convert.ToBoolean(reader.ReadLine())));
                    er.a("NavCloseStopRange", k.a(Convert.ToDouble(reader.ReadLine())));
                    er.a("NavFarStopRange", k.a(Convert.ToDouble(reader.ReadLine())));
                    er.a("SpellDiffExcessThreshold-Hunt", k.a(Convert.ToInt32(reader.ReadLine())));
                    er.a("SpellDiffExcessThreshold-Buff", k.a(Convert.ToInt32(reader.ReadLine())));
                    er.a("ArrowheadFletchDiffExcessThreshold", k.a(Convert.ToInt32(reader.ReadLine())));
                    er.a("Recharge-Norm-HitP", k.a((int) Convert.ToSingle(reader.ReadLine())));
                    er.a("Recharge-Norm-Stam", k.a((int) Convert.ToSingle(reader.ReadLine())));
                    er.a("Recharge-Norm-Mana", k.a((int) Convert.ToSingle(reader.ReadLine())));
                    er.a("Recharge-NoTarg-HitP", k.a((int) Convert.ToSingle(reader.ReadLine())));
                    er.a("Recharge-NoTarg-Stam", k.a((int) Convert.ToSingle(reader.ReadLine())));
                    er.a("Recharge-NoTarg-Mana", k.a((int) Convert.ToSingle(reader.ReadLine())));
                    er.a("Recharge-Helper-HitP", k.a((int) Convert.ToSingle(reader.ReadLine())));
                    er.a("Recharge-Helper-Stam", k.a((int) Convert.ToSingle(reader.ReadLine())));
                    er.a("Recharge-Helper-Mana", k.a((int) Convert.ToSingle(reader.ReadLine())));
                    er.a("DoHelp", k.a(Convert.ToBoolean(reader.ReadLine())));
                    er.a("AttackDistance", k.a(Convert.ToDouble(reader.ReadLine())));
                    er.a("ApproachDistance", k.a(Convert.ToDouble(reader.ReadLine())));
                    er.a("RingDistance", k.a(Convert.ToDouble(reader.ReadLine())));
                    er.a("HelperDistanceHitP", k.a(Convert.ToDouble(reader.ReadLine())));
                    er.a("HelperDistanceStam", k.a(er.h("HelperDistanceHitP")));
                    er.a("HelperDistanceMana", k.a(er.h("HelperDistanceHitP")));
                    er.a("MinimumRingTargets", k.a(Convert.ToInt32(reader.ReadLine())));
                    er.a("CastDispelSelf", k.a(Convert.ToBoolean(reader.ReadLine())));
                    er.a("UseDispelItems", k.a(Convert.ToBoolean(reader.ReadLine())));
                    this.g.Clear();
                    int num2 = Convert.ToInt32(reader.ReadLine());
                    for (int i = 0; i < num2; i++)
                    {
                        string key = reader.ReadLine();
                        int num4 = Convert.ToInt32(reader.ReadLine());
                        this.g.Add(key, PluginCore.cq.e.b(num4));
                    }
                    this.h.Clear();
                    int num5 = Convert.ToInt32(reader.ReadLine());
                    for (int j = 0; j < num5; j++)
                    {
                        string str7 = reader.ReadLine();
                        int num7 = Convert.ToInt32(reader.ReadLine());
                        this.h.Add(str7, (fz) num7);
                    }
                    PluginCore.cq.d.h();
                    int num8 = Convert.ToInt32(reader.ReadLine());
                    aj.c c = new aj.c();
                    c.a(reader);
                    PluginCore.cq.d.a(c);
                    for (int k = 0; k < num8; k++)
                    {
                        string str8 = reader.ReadLine();
                        aj.c c2 = new aj.c();
                        c2.a(reader);
                        PluginCore.cq.d.a(str8, c2);
                    }
                    reader.Close();
                    this.b();
                    this.c.c(Path.Combine(PluginCore.ci, str4 + ".usd"));
                    new FileInfo(str2).MoveTo(str2 + ".bak");
                    num++;
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }
        if (num > 0)
        {
            PluginCore.e("Converted " + num.ToString() + " old 0.2.0.x profiles.");
        }
    }

    public void r()
    {
        using (StreamWriter writer = new StreamWriter(Path.Combine(PluginCore.ci, PluginCore.cq.aw.get_CharacterFilter().get_Server() + "_" + PluginCore.cq.aw.get_CharacterFilter().get_Name() + ".cdf"), false))
        {
            writer.WriteLine("uTank2 CDF 1.0");
            writer.WriteLine(this.m);
            writer.WriteLine(this.l);
            writer.WriteLine(this.n);
            writer.WriteLine(PluginCore.cq.@as.j());
        }
    }
}

