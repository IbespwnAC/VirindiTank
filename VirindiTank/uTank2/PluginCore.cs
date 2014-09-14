namespace uTank2
{
    using Decal.Adapter;
    using Decal.Adapter.Wrappers;
    using Decal.Filters;
    using Decal.Interop.Filters;
    using MetaViewWrappers;
    using MetaViewWrappers.VirindiViewServiceHudControls;
    using Microsoft.Win32;
    using MyClasses.MyWorldFilter;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using System.Xml;
    using uTank2.Logic;
    using uTank2.LootPlugins;
    using VirindiHotkeySystem;
    using VirindiViewService;
    using VirindiViewService.Controls;

    public class PluginCore : PluginBase
    {
        private const int a = 14;
        internal ICheckBox a0;
        internal IButton a1;
        internal IList a2;
        internal IButton a3;
        internal IButton a4;
        internal ITextBox a5;
        internal IStaticText a6;
        internal IStaticText a7;
        internal IStaticText a8;
        internal IStaticText a9;
        internal ICheckBox aa;
        internal ICheckBox ab;
        internal ICheckBox ac;
        internal ICheckBox ad;
        internal ICheckBox ae;
        internal ICheckBox af;
        internal ICheckBox ag;
        internal ICheckBox ah;
        internal ICheckBox ai;
        internal ICheckBox aj;
        internal ICheckBox ak;
        internal ITextBox al;
        internal ITextBox am;
        internal ITextBox an;
        internal ITextBox ao;
        internal ICombo ap;
        internal ICombo aq;
        internal ICombo ar;
        internal IButton @as;
        internal IButton at;
        internal ICheckBox au;
        internal IButton av;
        internal ICheckBox aw;
        internal IButton ax;
        internal IButton ay;
        internal ICombo az;
        private const int b = 0;
        internal ISlider b0;
        internal ISlider b1;
        internal ISlider b2;
        internal ISlider b3;
        internal ISlider b4;
        internal ISlider b5;
        internal ISlider b6;
        internal ISlider b7;
        internal ISlider b8;
        internal IList b9;
        internal IStaticText ba;
        internal IStaticText bb;
        internal IStaticText bc;
        internal IStaticText bd;
        internal IStaticText be;
        internal IStaticText bf;
        internal IStaticText bg;
        internal IStaticText bh;
        internal IStaticText bi;
        internal IStaticText bj;
        internal IStaticText bk;
        internal IList bl;
        internal ICombo bm;
        internal IButton bn;
        internal IButton bo;
        internal IButton bp;
        internal IButton bq;
        internal ICombo br;
        internal IButton bs;
        internal ITextBox bt;
        internal IButton bu;
        internal ITextBox bv;
        internal IImageButton bw;
        internal IImageButton bx;
        internal IImageButton by;
        internal ICombo bz;
        private const int c = 1;
        private MyDictionary<int, eBuffedItemAddOptions> c0 = new MyDictionary<int, eBuffedItemAddOptions>(0x3e7);
        internal MyList<int> c1 = new MyList<int>(40);
        private MyList<string> c2 = new MyList<string>(0x29);
        private MyList<int> c3 = new MyList<int>(0x2a);
        private List<d8> c4 = new List<d8>();
        internal MyList<cExternalInterfaceTrustedRelay> c5 = new MyList<cExternalInterfaceTrustedRelay>(0x25);
        private MyDictionary<string, eExternalsPermissionLevel> c6 = new MyDictionary<string, eExternalsPermissionLevel>(0x26);
        internal IButton ca;
        internal IList cb;
        internal IButton cc;
        internal IList cd;
        internal IButton ce;
        internal ICombo cf;
        internal static int cg = 0;
        internal static long ch = 0L;
        internal static string ci;
        internal static bool cj = true;
        internal static bool ck = false;
        internal bool cl;
        internal static bool cm = false;
        private bool cn;
        private string co = "";
        private ea cp;
        internal static ev cq;
        internal static bool cs = false;
        private bool ct;
        private bool cu;
        private bool cv;
        private bool cw;
        private MyList<int> cz = new MyList<int>(0x27);
        private const int d = 2;
        internal bool dj = true;
        private Dictionary<int, List<delFLootPluginClassifyCallback>> dk = new Dictionary<int, List<delFLootPluginClassifyCallback>>();
        private const int e = 3;
        private const int f = 4;
        private const int g = 5;
        internal IView h;
        internal e3 i;
        internal int j;
        internal int k;
        private bool l;
        internal IButton m;
        internal IList n;
        internal IButton o;
        internal IList p;
        public static PluginCore PC;
        internal IButton q;
        internal IButton r;
        internal IButton s;
        public const string SPECIALBONUSENTRY_ALLPEAS = "[All Peas]";
        internal IList t;
        internal ICheckBox u;
        internal ICheckBox v;
        internal IButton w;
        internal IButton x;
        internal ICheckBox y;
        internal ICheckBox z;

        public event AllSpellsExpiredDelegate AllSpellsExpired;

        public event EmptyDelegate AuthorizationComplete;

        public event EmptyDelegate LootProfileChanged;

        public event EmptyDelegate MacroStateChanged;

        internal event uTank2.PluginCore.b MyClientDispatch;

        internal event uTank2.PluginCore.a MyServerDispatch;

        public event NavRouteChangedDelegate NavRouteChanged;

        public event NavWaypointChangedDelegate NavWaypointChanged;

        public event EmptyDelegate ProfileChanged;

        public event SpreadLockDelegate RequestSpreadLock;

        public event RequestTargetSelectionDelegate RequestTargetSelection;

        public event TargetDelegate SetInvalidTarget;

        public event SpellCastAttemptingDelegate SpellCastAttempting;

        public event SpellCastCompleteDelegate SpellCastComplete;

        internal event EmptyDelegate StartupComplete;

        private void a()
        {
            this.c6.Clear();
            string path = Path.Combine(ci, "signkeys.txt");
            string str2 = Path.Combine(ci, "signkeys.txt.signature.txt");
            if (File.Exists(path) && File.Exists(str2))
            {
                string str3 = "";
                using (StreamReader reader = new StreamReader(str2))
                {
                    str3 = reader.ReadLine();
                }
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    if (this.a(stream, str3, "3fA6aYsS7Zw50gOcNTvZEKPeF3_HJELX7WiMSDGi9VCtDSmQrt0wvItdFqilD3uRIhtB9_0OIXok5jlXUkTV4Fzg_Uqqg3VEnQKV-h4o1_WozrIVPqVRTJYcIAYETXdSCs-76afnw-bd2rRm74gBH9D3Qx1dWfIzREb2RUILYWE.~AQAB"))
                    {
                        stream.Seek(0L, SeekOrigin.Begin);
                        using (StreamReader reader2 = new StreamReader(stream))
                        {
                            while (!reader2.EndOfStream)
                            {
                                try
                                {
                                    this.c6.Add(reader2.ReadLine(), (eExternalsPermissionLevel) Convert.ToInt32(reader2.ReadLine()));
                                    continue;
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void a(cv A_0)
        {
            try
            {
                if (base.get_Core().get_WorldFilter().get_Item(A_0.k) != null)
                {
                    if (this.c3.Contains(A_0.k))
                    {
                        this.c3.Remove(A_0.k);
                        this.h(A_0.k);
                    }
                    if (this.cz.Contains(A_0.k))
                    {
                        this.cz.Remove(A_0.k);
                        this.l(A_0.k);
                    }
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void a(ef A_0)
        {
            if (this.bz.Selected == 0)
            {
                cq.l.k.b.Add(A_0);
                this.f();
            }
            else
            {
                cq.l.k.b.Insert(cq.n.l, A_0);
                this.ao();
            }
            cq.l.g();
        }

        private void a(int A_0)
        {
            if ((A_0 == 1) && (this.a2.RowCount > 2))
            {
                this.a2[2][20][1] = 0;
            }
            if ((A_0 == (this.a2.RowCount - 1)) && (this.a2.RowCount > 2))
            {
                this.a2[this.a2.RowCount - 2][0x15][1] = 0;
            }
            this.a2.RemoveRow(A_0);
        }

        private void a(object A_0)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Decal\Plugins\{642F1F48-16BE-48BF-B1D4-286652C4533E}", true);
                string str = key.GetValue("Path", null) as string;
                if (str != null)
                {
                    str = str.TrimEnd(new char[] { '\\' }) + '\\';
                    key.SetValue("Path", str, RegistryValueKind.String);
                }
                str = key.GetValue("ProfilePath", null) as string;
                if (str != null)
                {
                    str = str.TrimEnd(new char[] { '\\' }) + '\\';
                    key.SetValue("ProfilePath", str, RegistryValueKind.String);
                }
                key.Close();
            }
            catch
            {
            }
        }

        private byte[] a(Assembly A_0)
        {
            try
            {
                cp inputStream = new cp();
                foreach (FileStream stream in A_0.GetFiles())
                {
                    inputStream.a(stream);
                }
                SHA1Managed managed = new SHA1Managed();
                return managed.ComputeHash(inputStream);
            }
            catch (Exception)
            {
                return new byte[0];
            }
        }

        private bool a(string A_0)
        {
            string key = b(A_0);
            if (key != null)
            {
                int num;
                if (bx.b == null)
                {
                    Dictionary<string, int> dictionary1 = new Dictionary<string, int>(0x13);
                    dictionary1.Add("Start/Stop", 0);
                    dictionary1.Add("Target lock", 1);
                    dictionary1.Add("Navigation", 2);
                    dictionary1.Add("Looting", 3);
                    dictionary1.Add("Combat", 4);
                    dictionary1.Add("Buffing", 5);
                    dictionary1.Add("Force buff", 6);
                    dictionary1.Add("Cancel force buff", 7);
                    dictionary1.Add("MeleeLow", 8);
                    dictionary1.Add("MeleeMid", 9);
                    dictionary1.Add("MeleeHigh", 10);
                    dictionary1.Add("NavAddPt", 11);
                    dictionary1.Add("TestItem", 12);
                    dictionary1.Add("PropertyDump", 13);
                    dictionary1.Add("Recharge", 14);
                    dictionary1.Add("NavPrio", 15);
                    dictionary1.Add("LootPrio", 0x10);
                    dictionary1.Add("NavLootPrio", 0x11);
                    dictionary1.Add("LootThisCont", 0x12);
                    bx.b = dictionary1;
                }
                if (bx.b.TryGetValue(key, out num))
                {
                    switch (num)
                    {
                        case 0:
                            if (!cq.n.b)
                            {
                                cq.c.StartMacro();
                            }
                            else
                            {
                                cq.c.StopMacro();
                            }
                            return true;

                        case 1:
                        {
                            bool flag = !er.j("TargetLock");
                            er.b("TargetLock", k.a(flag));
                            e("Target lock: " + flag.ToString());
                            return true;
                        }
                        case 2:
                        {
                            bool flag2 = !er.j("EnableNav");
                            er.b("EnableNav", k.a(flag2));
                            e("Navigation: " + flag2.ToString());
                            return true;
                        }
                        case 3:
                        {
                            bool flag3 = !er.j("EnableLooting");
                            er.b("EnableLooting", k.a(flag3));
                            e("Looting: " + flag3.ToString());
                            return true;
                        }
                        case 4:
                        {
                            bool flag4 = !er.j("EnableCombat");
                            er.b("EnableCombat", k.a(flag4));
                            e("Combat: " + flag4.ToString());
                            return true;
                        }
                        case 5:
                        {
                            bool flag5 = !er.j("EnableBuffing");
                            er.b("EnableBuffing", k.a(flag5));
                            e("Buffing: " + flag5.ToString());
                            return true;
                        }
                        case 6:
                            e("Force buff enabled.");
                            cq.j.d();
                            return true;

                        case 7:
                            e("Force buff canceled.");
                            cq.j.h();
                            return true;

                        case 8:
                            e("Melee attack height set: low");
                            er.b("DefaultMeleeAttackHeight", k.a(3));
                            return true;

                        case 9:
                            e("Melee attack height set: medium");
                            er.b("DefaultMeleeAttackHeight", k.a(2));
                            return true;

                        case 10:
                            e("Melee attack height set: high");
                            er.b("DefaultMeleeAttackHeight", k.a(1));
                            return true;

                        case 11:
                            this.f(null, (EventArgs) null);
                            return true;

                        case 12:
                            this.k("/vt testitem");
                            return true;

                        case 13:
                            this.k("/vt propertydump");
                            return true;

                        case 14:
                        {
                            ILogicRule rule = new az(1, "Recharge-Norm-HitP", "Recharge-Norm-Stam", "Recharge-Norm-Mana");
                            ILogicRule rule2 = new az(1, "Recharge-NoTarg-HitP", "Recharge-NoTarg-Stam", "Recharge-NoTarg-Mana");
                            if (!rule.ValidNow)
                            {
                                if (rule2.ValidNow)
                                {
                                    rule2.Running = true;
                                }
                                else
                                {
                                    e("No recharge needed.");
                                }
                            }
                            else
                            {
                                rule.Running = true;
                            }
                            return true;
                        }
                        case 15:
                        {
                            bool flag6 = !er.j("NavPriorityBoost");
                            er.b("NavPriorityBoost", k.a(flag6));
                            e("NavPriorityBoost: " + flag6.ToString());
                            return true;
                        }
                        case 0x10:
                        {
                            bool flag7 = !er.j("LootPriorityBoost");
                            er.b("LootPriorityBoost", k.a(flag7));
                            e("LootPriorityBoost: " + flag7.ToString());
                            return true;
                        }
                        case 0x11:
                        {
                            bool flag8 = !er.j("NavPriorityBoost");
                            er.b("NavPriorityBoost", k.a(flag8));
                            er.b("LootPriorityBoost", k.a(flag8));
                            e("NavPriorityBoost/LootPriorityBoost: " + flag8.ToString());
                            return true;
                        }
                        case 0x12:
                            if (!er.j("EnableLooting"))
                            {
                                e("Looting is disabled.");
                            }
                            else if (cq.q.j != 0)
                            {
                                cq.q.m = cq.q.j;
                                e("Looting...");
                            }
                            return true;
                    }
                }
            }
            return false;
        }

        private string a(eSecondaryEquipTypeOrObjectID A_0)
        {
            switch (A_0)
            {
                case eSecondaryEquipTypeOrObjectID.Auto:
                    return "<AUTO>";

                case eSecondaryEquipTypeOrObjectID.AutoShield:
                    return "<AUTO SHIELD>";

                case eSecondaryEquipTypeOrObjectID.AutoWeapon:
                    return "<AUTO WEAPON>";

                case eSecondaryEquipTypeOrObjectID.None:
                    return "<NONE>";
            }
            int num = (int) A_0;
            if ((dh.b(num) && (dh.c(num) == cg)) && (cq.p.d(num) != null))
            {
                return cq.p.d(num).e();
            }
            return ("<INVALID " + num.ToString() + ">");
        }

        private void a(string[] A_0)
        {
            er.b("EnableNav", k.a(this.ct));
            er.b("EnableLooting", k.a(this.cw));
            er.b("EnableBuffing", k.a(this.cv));
            er.b("EnableCombat", k.a(this.cu));
            e("Buffing, Combat, Nav and Loot have been restored to previous values.");
        }

        internal MyList<int> a(eLootAction A_0)
        {
            MyList<int> list = new MyList<int>(0x20);
            MyList<int> list2 = new MyList<int>(0x21);
            foreach (int num in cq.n.g.Keys)
            {
                if (cq.aw.get_WorldFilter().get_Item(num) == null)
                {
                    list2.Add(num);
                }
                else if (dh.c(num) != cg)
                {
                    list2.Add(num);
                }
                else if (((eLootAction) cq.n.g[num]) == A_0)
                {
                    list.Add(num);
                }
            }
            foreach (int num2 in list2)
            {
                cq.n.g.Remove(num2);
            }
            return list;
        }

        internal void a(sPlayerInfoUpdate A_0)
        {
            if (!cq.k.j.ContainsKey(A_0.PlayerID))
            {
                cq.k.j.Add(A_0.PlayerID, new eo.b());
            }
            cq.k.j[A_0.PlayerID].a = DateTimeOffset.Now;
            if (A_0.HasHealthInfo)
            {
                cq.k.j[A_0.PlayerID].b = A_0.maxHealth;
                cq.k.j[A_0.PlayerID].e = A_0.curHealth;
            }
            if (A_0.HasStamInfo)
            {
                cq.k.j[A_0.PlayerID].c = A_0.maxStam;
                cq.k.j[A_0.PlayerID].f = A_0.curStam;
            }
            if (A_0.HasManaInfo)
            {
                cq.k.j[A_0.PlayerID].d = A_0.maxMana;
                cq.k.j[A_0.PlayerID].g = A_0.curMana;
            }
        }

        internal void a(MyList<int> A_0)
        {
            if ((A_0.Count != 0) || !this.dj)
            {
                if (A_0.Count == 0)
                {
                    this.dj = true;
                }
                else
                {
                    this.dj = false;
                }
                if (this.dh != null)
                {
                    this.dh(A_0);
                }
            }
        }

        internal void a(HudView A_0)
        {
            HudTabView view = A_0.get_Controls().get_Item("MainTabs") as HudTabView;
            if (view != null)
            {
                Rectangle rectangle = view.get_Item(view.get_CurrentTab()).get_SavedClipRegion();
                HudFixedLayout layout = A_0.get_Controls().ParentOf("lstMetaRules") as HudFixedLayout;
                if (layout != null)
                {
                    Rectangle controlRect = layout.GetControlRect("cmdMetaCreate");
                    layout.SetControlRect("cmdMetaCreate", new Rectangle(controlRect.Left, rectangle.Height - (controlRect.Height + 4), controlRect.Width, controlRect.Height));
                    int height = controlRect.Height;
                    controlRect = layout.GetControlRect("lblmetacurrentstate");
                    layout.SetControlRect("lblmetacurrentstate", new Rectangle(controlRect.Left, rectangle.Height - (controlRect.Height + 4), controlRect.Width, controlRect.Height));
                    controlRect = layout.GetControlRect("cmbMetaCurrentState");
                    layout.SetControlRect("cmbMetaCurrentState", new Rectangle(controlRect.Left, rectangle.Height - (controlRect.Height + 4), controlRect.Width, controlRect.Height));
                    controlRect = layout.GetControlRect("lstMetaRules");
                    layout.SetControlRect("lstMetaRules", new Rectangle(controlRect.Left, controlRect.Top, controlRect.Width, rectangle.Height - ((controlRect.Top + 8) + height)));
                }
            }
        }

        private void a(cv A_0, dt A_1)
        {
            if (A_1 != dt.ao)
            {
                string name = "???";
                if (Enum.IsDefined(typeof(IntValueKey), (int) A_1))
                {
                    name = Enum.GetName(typeof(IntValueKey), (int) A_1);
                }
                string[] strArray = new string[] { "Character property change: Key ", ((int) A_1).ToString(), " (", name, "), Value ", A_0.a(A_1, 0).ToString() };
                cq.n.a(string.Concat(strArray), e8.l);
            }
        }

        private void a(ITextBox A_0, string A_1)
        {
            if (A_0.Text != A_1)
            {
                A_0.Text = A_1;
            }
        }

        private void a(bool A_0, TextReader A_1)
        {
            if (A_0)
            {
                try
                {
                    string str2;
                    int[] numArray = new int[] { Assembly.GetExecutingAssembly().GetName(false).Version.Major, Assembly.GetExecutingAssembly().GetName(false).Version.Minor, Assembly.GetExecutingAssembly().GetName(false).Version.Build, Assembly.GetExecutingAssembly().GetName(false).Version.Revision };
                    string str = A_1.ReadLine();
                    string[] strArray = str.Split(new char[] { '.' });
                    if (numArray.Length != strArray.Length)
                    {
                        throw new Exception();
                    }
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (numArray[i] > Convert.ToInt32(strArray[i]))
                        {
                            a5.a(eChatType.CommandLine, "Prerelease version of Virindi Tank detected.");
                            goto Label_00F1;
                        }
                        if (numArray[i] < Convert.ToInt32(strArray[i]))
                        {
                            a5.a(eChatType.CommandLine, "A new version of Virindi Tank is available. The current version is " + str + ".");
                            goto Label_00F1;
                        }
                    }
                    a5.a(eChatType.CommandLine, "Your version of Virindi Tank is current.");
                Label_00F1:
                    str2 = A_1.ReadToEnd();
                    if (!string.IsNullOrEmpty(str2))
                    {
                        foreach (string str3 in str2.Split(new char[] { '\n' }))
                        {
                            a5.a(eChatType.CommandLine, str3);
                        }
                    }
                }
                catch (Exception)
                {
                    a5.a(eChatType.Errors, "Unable to fetch info about the latest plugin version.");
                }
            }
            else
            {
                a5.a(eChatType.Errors, "Unable to fetch info about the latest plugin version.");
            }
        }

        private void a(int A_0, bool A_1)
        {
            if (this.dk.ContainsKey(A_0))
            {
                LootAction noLoot;
                if (A_1)
                {
                    noLoot = cq.ag.a(A_0);
                }
                else
                {
                    noLoot = LootAction.NoLoot;
                }
                foreach (delFLootPluginClassifyCallback callback in this.dk[A_0])
                {
                    try
                    {
                        callback(A_0, noLoot, A_1);
                    }
                    catch
                    {
                    }
                }
                this.dk.Remove(A_0);
            }
        }

        internal void a(int A_0, int A_1)
        {
            if (cq.e.c(A_0))
            {
                MySpell spell = cq.e.b(A_0);
                if (((spell != null) && (A_1 != 0)) && ((cq.i.b.ContainsKey(A_1) && cq.i.b[A_1].ContainsKey(spell.RealFamily)) && cq.i.b[A_1][spell.RealFamily].ContainsKey(spell.Id)))
                {
                    cq.i.b[A_1][spell.RealFamily].Remove(spell.Id);
                    if (cq.i.b[A_1][spell.RealFamily].Count == 0)
                    {
                        cq.i.b[A_1].Remove(spell.RealFamily);
                    }
                    if (cq.i.b[A_1].Count == 0)
                    {
                        cq.i.b.Remove(A_1);
                    }
                }
            }
        }

        internal void a(int A_0, string A_1)
        {
            cq.l.k.a(A_0, A_1);
            cq.l.g();
            this.ao();
        }

        private void a(int A_0, eBuffedItemAddOptions A_1)
        {
            this.c0[A_0] = A_1;
            if (cq.aw.get_WorldFilter().get_Item(A_0).get_HasIdData())
            {
                this.l(A_0);
            }
            else
            {
                this.cz.Add(A_0);
                cq.u.c(A_0);
            }
        }

        private void a(object A_0, ChatParserInterceptEventArgs A_1)
        {
            try
            {
                A_1.set_Eat(this.k(A_1.get_Text()));
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void a(object A_0, NetworkMessageEventArgs A_1)
        {
            try
            {
                if (this.cy != null)
                {
                    this.cy(A_0, A_1);
                }
                if (A_1.get_Message().get_Type() == 0xf7b0)
                {
                    if ((A_1.get_Message().Value<int>("event") == 0x13) && ((A_1.get_Message().Struct("properties").Value<int>("flags") & 1) > 0))
                    {
                        for (int i = 0; i < A_1.get_Message().Struct("properties").Value<short>("dwordCount"); i++)
                        {
                            int num2 = A_1.get_Message().Struct("properties").Struct("dwords").Struct(i).Value<int>("key");
                            int num3 = A_1.get_Message().Struct("properties").Struct("dwords").Struct(i).Value<int>("value");
                            switch (num2)
                            {
                                case 0xbc:
                                    cq.a1 = num3;
                                    break;

                                case 0xee:
                                    cq.a0 = num3;
                                    break;
                            }
                        }
                    }
                }
                else if (A_1.get_Message().get_Type() == 0x2cd)
                {
                    if (A_1.get_Message().Value<int>("key") == 0xee)
                    {
                        cq.a0 = A_1.get_Message().Value<int>("value");
                    }
                    else if (A_1.get_Message().Value<int>("key") == 0x2b)
                    {
                        this.a(null, (DeathEventArgs) null);
                    }
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void a(object A_0, WindowMessageEventArgs A_1)
        {
            try
            {
                if (((cg != 0) && !cm) && (!this.cn && (A_1.get_Msg() == 0x100)))
                {
                    if (r.a(u.h, A_1.get_LParam()))
                    {
                        if (cq.n.b)
                        {
                            cq.c.StopMacro();
                        }
                        else
                        {
                            cq.c.StartMacro();
                        }
                    }
                    else if (r.a(u.g, A_1.get_LParam()))
                    {
                        bool flag = !er.j("TargetLock");
                        er.b("TargetLock", k.a(flag));
                        e("Target lock: " + er.j("TargetLock").ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void a(object A_0, ChangePortalModeEventArgs A_1)
        {
            ch += 1L;
            if (A_1.get_Type() == null)
            {
                a2.b(true);
            }
            else if (A_1.get_Type() == 1)
            {
                a2.a(true);
            }
        }

        private void a(object A_0, DeathEventArgs A_1)
        {
            try
            {
                a2.c(true);
                if (cq.n.b && er.j("StopMacroOnDeath"))
                {
                    this.ct = er.j("EnableNav");
                    this.cw = er.j("EnableLooting");
                    this.cv = er.j("EnableBuffing");
                    this.cu = er.j("EnableCombat");
                    er.b("EnableNav", k.a(false));
                    er.b("EnableLooting", k.a(false));
                    er.b("EnableBuffing", k.a(false));
                    er.b("EnableCombat", k.a(false));
                    a.a("deathrestore", new a.c(this.a));
                    e("You died! Buffing, Combat, Nav and Loot have been disabled. " + a.a("Click here to restore them.", new string[] { "deathrestore" }));
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void a(object A_0, HotkeyEventArgs A_1)
        {
            try
            {
                if (this.a(A_1.get_Title()))
                {
                    A_1.set_Eat(true);
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void a(object A_0, LogoffEventArgs A_1)
        {
            try
            {
                if (A_1.get_Type() == null)
                {
                    cq.c.StopMacro();
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void a(object A_0, MVCheckBoxChangeEventArgs A_1)
        {
            try
            {
                er.b("EnableMeta", k.a(this.a0.Checked));
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void a(object A_0, MVControlEventArgs A_1)
        {
            try
            {
                if (!cq.ay.cl)
                {
                    a5.a(eChatType.Errors, "Please wait until you are fully logged in.");
                }
                else
                {
                    cq.at.g();
                    fl fl = new b4();
                    b3 b = new w();
                    d8 d = new d8(fl, b, "Default");
                    cq.@as.c(d);
                    cq.@as.k();
                    this.v();
                    cq.at.b(d);
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void a(object A_0, MVIndexChangeEventArgs A_1)
        {
            try
            {
                if (!this.l && (this.cf.Selected >= 0))
                {
                    cq.@as.a(this.cf.Text[this.cf.Selected]);
                    this.v();
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void a(object A_0, EventArgs A_1)
        {
            try
            {
                if (this.cl)
                {
                    int num = base.get_Host().get_Actions().get_CurrentSelection();
                    if (((num != 0) && dh.b(num)) && !this.c3.Contains(num))
                    {
                        if (cq.aw.get_WorldFilter().get_Item(num).get_HasIdData())
                        {
                            this.h(num);
                        }
                        else
                        {
                            this.c3.Add(num);
                            cq.u.c(num);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private string a(Assembly A_0, string A_1)
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.FromXmlString(this.c(A_1));
            return Convert.ToBase64String(provider.SignHash(this.a(A_0), CryptoConfig.MapNameToOID("SHA1")));
        }

        private bool a(string A_0, out double A_1)
        {
            A_1 = 1.0;
            if (string.IsNullOrEmpty(A_0))
            {
                return false;
            }
            string str = A_0.TrimEnd(new char[] { '.' });
            try
            {
                A_1 = Convert.ToDouble(str);
            }
            catch (Exception)
            {
            }
            A_1 *= 0.0041666666666666666;
            return true;
        }

        private void a(string A_0, aj.c A_1)
        {
            int rowCount = this.a2.RowCount;
            if (rowCount > 1)
            {
                this.a2[rowCount - 1][0x15][1] = 0x60028fd;
            }
            this.a(A_0, A_1, rowCount == 1, true);
        }

        internal void a(eSettingBool A_0, bool A_1)
        {
            switch (A_0)
            {
                case eSettingBool.UseDispelDrum:
                    er.b("UseDispelDrum", k.a(A_1));
                    return;

                case eSettingBool.SpreadFireLock:
                    cq.l.f = A_1;
                    if (A_1)
                    {
                        break;
                    }
                    if (cq.n.c != 0)
                    {
                        this.e(0);
                        cq.n.c = 0;
                        cq.n.e.Clear();
                    }
                    cq.n.n.a(ActionLockType.SpreadLockTargetRequested);
                    return;

                case eSettingBool.EnableBuffing:
                    er.b("EnableBuffing", k.a(A_1));
                    return;

                case eSettingBool.EnableCombat:
                    er.b("EnableCombat", k.a(A_1));
                    return;

                case eSettingBool.ForceBuff:
                    if (!A_1)
                    {
                        e("Force buff canceled.");
                        cq.j.h();
                        break;
                    }
                    e("Force buff enabled.");
                    cq.j.d();
                    return;

                default:
                    return;
            }
        }

        internal void a(sCoord A_0, int A_1)
        {
            cq.l.k.a(A_0, A_1);
            this.ao();
        }

        private void a(VHotkeyInfo A_0, ref bool A_1)
        {
            if (this.a(A_0.get_HotkeyName()))
            {
                A_1 = true;
            }
        }

        private void a(int A_0, int A_1, int A_2)
        {
        }

        private bool a(FileStream A_0, string A_1, string A_2)
        {
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
                provider.FromXmlString(this.c(A_2));
                byte[] rgbHash = new SHA1Managed().ComputeHash(A_0);
                return provider.VerifyHash(rgbHash, CryptoConfig.MapNameToOID("SHA1"), Convert.FromBase64String(A_1));
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void a(object A_0, int A_1, int A_2)
        {
            try
            {
                if ((A_1 >= 0) && (A_1 < this.c4.Count))
                {
                    d8 d = this.c4[A_1];
                    switch (A_2)
                    {
                        case 0:
                            cq.@as.b(d);
                            cq.@as.d();
                            return;

                        case 1:
                            cq.@as.a(d);
                            cq.@as.d();
                            return;

                        case 2:
                            cq.at.g();
                            cq.@as.d(d);
                            cq.@as.d();
                            return;

                        case 3:
                        case 4:
                        case 5:
                            cq.at.g();
                            cq.at.b(d);
                            return;
                    }
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private bool a(Assembly A_0, string A_1, string A_2)
        {
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
                provider.FromXmlString(this.c(A_2));
                return provider.VerifyHash(this.a(A_0), CryptoConfig.MapNameToOID("SHA1"), Convert.FromBase64String(A_1));
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal void a(int A_0, eWaypointType A_1, sCoord A_2, int A_3)
        {
            cq.l.k.a(A_0, A_1, A_2, A_3);
            cq.l.g();
            this.ao();
        }

        private void a(string A_0, aj.c A_1, bool A_2, bool A_3)
        {
            int rowCount = this.a2.RowCount;
            IListRow row = this.a2.AddRow();
            row[0][0] = A_1.l;
            row[1][0] = A_1.k;
            row[2][0] = A_1.j;
            row[3][0] = A_1.f;
            row[4][0] = A_1.h;
            row[5][0] = A_1.g;
            row[6][0] = !A_1.s;
            row[7][0] = A_1.i;
            row[8][0] = A_1.r;
            row[9][0] = A_1.m;
            row[10][0] = A_1.n;
            row[11][0] = A_1.o;
            row[12][0] = A_1.p;
            row[13][0] = A_1.q;
            row[14][0] = A_0;
            row[15][0] = A_1.a.ToString();
            row[0x10][0] = er.a(A_1.b);
            row[0x11][0] = er.a(A_1.c);
            row[0x12][0] = this.b(A_1.e);
            row[0x13][0] = this.a(A_1.d);
            if (!A_1.u)
            {
                if (!A_2)
                {
                    row[20][1] = 0x60028fc;
                }
                if (!A_3)
                {
                    row[0x15][1] = 0x60028fd;
                }
            }
        }

        internal void aa()
        {
            this.l = true;
            cq.ay.aq.Clear();
            cq.ay.aq.Add("[Default]");
            string o = cq.l.o;
            cq.ay.aq.Add("[By char]");
            string[] files = Directory.GetFiles(ci, "*.usd");
            Array.Sort<string>(files);
            foreach (string str2 in files)
            {
                string[] strArray2 = str2.Split(new char[] { '\\' });
                string text = strArray2[strArray2.Length - 1];
                if (text != o)
                {
                    if ((text.Length >= 2) && (text.Substring(0, 2) != "--"))
                    {
                        if (!this.au.Checked || (text == cq.l.m))
                        {
                            cq.ay.aq.Add(text);
                        }
                    }
                    else if ((text.Length >= this.co.Length) && (text.Substring(0, this.co.Length) == this.co))
                    {
                        string[] strArray3 = text.Substring(this.co.Length).Split(new char[] { '.' });
                        StringBuilder builder = new StringBuilder();
                        builder.Append("[Char] ");
                        for (int i = 0; i < (strArray3.Length - 1); i++)
                        {
                            if (i > 0)
                            {
                                builder.Append('.');
                            }
                            builder.Append(strArray3[i]);
                        }
                        cq.ay.aq.Add(builder.ToString());
                    }
                }
            }
            if (string.IsNullOrEmpty(cq.l.m))
            {
                cq.ay.aq.Selected = 0;
            }
            else if (cq.l.m == o)
            {
                cq.ay.aq.Selected = 1;
            }
            else
            {
                for (int j = 0; j < cq.ay.aq.Count; j++)
                {
                    if ((this.aq.Text[j].Length >= 7) && (this.aq.Text[j].Substring(0, 7) == "[Char] "))
                    {
                        if (!((this.co + this.aq.Text[j].Substring(7) + ".usd") == cq.l.m))
                        {
                            continue;
                        }
                        cq.ay.aq.Selected = j;
                        break;
                    }
                    if (cq.ay.aq.Text[j] == cq.l.m)
                    {
                        cq.ay.aq.Selected = j;
                        break;
                    }
                }
            }
            this.l = false;
        }

        private void aa(object A_0, EventArgs A_1)
        {
            try
            {
                double num;
                if (this.a(this.am.Text, out num) && (Math.Round(num, 8) != Math.Round(er.h("AttackDistance"), 8)))
                {
                    er.b("AttackDistance", k.a(num));
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void ab()
        {
            cq.l.k.a();
            cq.l.g();
            this.ao();
        }

        private void ab(object A_0, EventArgs A_1)
        {
            try
            {
                double num;
                if (this.a(this.al.Text, out num) && (Math.Round(num, 8) != Math.Round(er.h("RingDistance"), 8)))
                {
                    er.b("RingDistance", k.a(num));
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void ac()
        {
            this.b0.Position = er.i("Recharge-Norm-HitP");
            this.b1.Position = er.i("Recharge-Norm-Stam");
            this.b2.Position = er.i("Recharge-Norm-Mana");
            this.b3.Position = er.i("Recharge-NoTarg-HitP");
            this.b4.Position = er.i("Recharge-NoTarg-Stam");
            this.b5.Position = er.i("Recharge-NoTarg-Mana");
            this.b6.Position = er.i("Recharge-Helper-HitP");
            this.b7.Position = er.i("Recharge-Helper-Stam");
            this.b8.Position = er.i("Recharge-Helper-Mana");
        }

        private void ac(object A_0, EventArgs A_1)
        {
            try
            {
                double num;
                if (this.a(this.an.Text, out num))
                {
                    if (Math.Round(num, 8) != Math.Round(er.h("ApproachDistance"), 8))
                    {
                        er.b("ApproachDistance", k.a(num));
                    }
                    if (Math.Round(num, 8) != Math.Round(er.h("CorpseApproachRange-Max"), 8))
                    {
                        er.b("CorpseApproachRange-Max", k.a(num));
                    }
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void ad()
        {
            int scrollPosition = this.n.ScrollPosition;
            this.c2.Clear();
            this.n.Clear();
            foreach (string str in cq.l.g.Keys)
            {
                this.c2.Add(str);
                this.n.AddRow()[0][0] = str;
            }
            foreach (string str2 in cq.l.h.Keys)
            {
                this.c2.Add(str2);
                this.n.AddRow()[0][0] = str2;
            }
            this.p.Clear();
            do @do = new do(2);
            @do.a(er.f("BlacklistedSpellComps"));
            foreach (string[] strArray in @do)
            {
                int result = 0;
                if (int.TryParse(strArray[0], out result))
                {
                    result |= 0x6000000;
                }
                IListRow row3 = this.p.AddRow();
                row3[0][1] = result;
                row3[1][0] = strArray[1];
            }
            this.n.ScrollPosition = scrollPosition;
        }

        private void ad(object A_0, EventArgs A_1)
        {
            try
            {
                e("Force buff enabled.");
                cq.j.d();
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void ae()
        {
            if (this.c8 != null)
            {
                this.c8();
            }
        }

        private void ae(object A_0, EventArgs A_1)
        {
            try
            {
                e("Force buff canceled.");
                cq.j.h();
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void af(object A_0, EventArgs A_1)
        {
            try
            {
                if (!this.l)
                {
                    if (this.ar.Text[this.ar.Selected] == "[None]")
                    {
                        cq.l.n = "";
                    }
                    else if (this.ar.Text[this.ar.Selected] == "[By char]")
                    {
                        cq.l.n = cq.l.p;
                    }
                    else
                    {
                        cq.l.n = this.ar.Text[this.ar.Selected];
                    }
                    cq.l.r();
                    cq.l.k();
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void ag(object A_0, EventArgs A_1)
        {
            try
            {
                if (!this.l)
                {
                    if (this.ap.Text[this.ap.Selected] == "[None]")
                    {
                        cq.l.l = "";
                    }
                    else
                    {
                        cq.l.l = this.ap.Text[this.ap.Selected];
                    }
                    cq.l.r();
                    cq.l.l();
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void ah(object A_0, EventArgs A_1)
        {
            try
            {
                if (!dh.i() && this.cl)
                {
                    cq.m.a(u.i, true);
                    cq.m.a(u.i, false);
                    r.a(cq.m.b, "/vt nav save ");
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal string ai()
        {
            return cq.l.n;
        }

        private void ai(object A_0, EventArgs A_1)
        {
            try
            {
                if (!dh.i() && this.cl)
                {
                    cq.m.a(u.i, true);
                    cq.m.a(u.i, false);
                    if (this.au.Checked)
                    {
                        r.a(cq.m.b, "/vt settings savechar ");
                    }
                    else
                    {
                        r.a(cq.m.b, "/vt settings save ");
                    }
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void aj()
        {
            if (this.c7 != null)
            {
                this.c7();
            }
        }

        private void aj(object A_0, EventArgs A_1)
        {
            try
            {
                cq.l.k.b();
                cq.l.g();
                cq.n.c();
                cq.ay.ao();
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void ak()
        {
            this.l = true;
            cq.ay.ar.Clear();
            cq.ay.ar.Add("[None]");
            string p = cq.l.p;
            cq.ay.ar.Add("[By char]");
            string[] files = Directory.GetFiles(ci, "*.nav");
            Array.Sort<string>(files);
            foreach (string str2 in files)
            {
                string[] strArray2 = str2.Split(new char[] { '\\' });
                string text = strArray2[strArray2.Length - 1];
                if (((text != p) && (text.Substring(0, 2) != "--")) && (text.Substring(0, 2) != "~~"))
                {
                    cq.ay.ar.Add(text);
                }
            }
            if (string.IsNullOrEmpty(cq.l.n))
            {
                cq.ay.ar.Selected = 0;
            }
            else if (cq.l.n == p)
            {
                cq.ay.ar.Selected = 1;
            }
            else
            {
                for (int i = 0; i < cq.ay.ar.Count; i++)
                {
                    if (cq.ay.ar.Text[i] == cq.l.n)
                    {
                        cq.ay.ar.Selected = i;
                        break;
                    }
                }
            }
            this.l = false;
        }

        private void ak(object A_0, EventArgs A_1)
        {
            try
            {
                cq.l.o();
                cq.l.d();
                er.a();
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void al(object A_0, EventArgs A_1)
        {
            try
            {
                if (this.cl)
                {
                    if (this.aw.Checked)
                    {
                        if (!cq.ag.j())
                        {
                            this.aw.Checked = false;
                        }
                    }
                    else
                    {
                        cq.ag.k();
                    }
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void am()
        {
            this.a();
        }

        private void am(object A_0, EventArgs A_1)
        {
            try
            {
                if (!dh.i() && this.cl)
                {
                    cq.m.a(u.i, true);
                    cq.m.a(u.i, false);
                    e("The following loot plugin file extensions are active:");
                    cq.ag.e();
                    r.a(cq.m.b, "/vt loot new ");
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal string an()
        {
            return cq.l.l;
        }

        private void an(object A_0, EventArgs A_1)
        {
            if (this.cl)
            {
                this.o();
            }
        }

        internal void ao()
        {
            int scrollPosition = this.bl.ScrollPosition;
            this.bl.Clear();
            if (cq.l.k.c == eNavType.Target)
            {
                this.f();
            }
            else
            {
                foreach (ef ef in cq.l.k.b)
                {
                    this.j(ef.d());
                }
            }
            switch (cq.l.k.c)
            {
                case eNavType.Linear:
                    this.bm.Selected = 1;
                    break;

                case eNavType.Circular:
                    this.bm.Selected = 0;
                    break;

                case eNavType.Target:
                    this.bm.Selected = 2;
                    break;

                case eNavType.Once:
                    this.bm.Selected = 3;
                    break;
            }
            this.bl.ScrollPosition = scrollPosition;
        }

        private void ao(object A_0, EventArgs A_1)
        {
            this.g();
        }

        private void ap(object A_0, EventArgs A_1)
        {
            er.b("Recharge-Norm-HitP", k.a(this.b0.Position));
        }

        internal void aq()
        {
            l.a();
            if (this.da != null)
            {
                this.da();
            }
        }

        private void aq(object A_0, EventArgs A_1)
        {
            er.b("Recharge-Norm-Stam", k.a(this.b1.Position));
        }

        internal void ar()
        {
            l.b();
        }

        private void ar(object A_0, EventArgs A_1)
        {
            er.b("Recharge-Norm-Mana", k.a(this.b2.Position));
        }

        internal void @as()
        {
            l.c();
            if (this.dc != null)
            {
                this.dc();
            }
        }

        private void @as(object A_0, EventArgs A_1)
        {
            er.b("Recharge-Helper-HitP", k.a(this.b6.Position));
        }

        internal void at()
        {
            this.m.Click -= new EventHandler<MVControlEventArgs>(this.a);
            this.n.Click -= new dClickedList(this.e);
            this.o.Click -= new EventHandler<MVControlEventArgs>(this.e);
            this.p.Click -= new dClickedList(this.d);
            this.q.Click -= new EventHandler<MVControlEventArgs>(this.d);
            this.r.Click -= new EventHandler<MVControlEventArgs>(this.d);
            this.s.Click -= new EventHandler<MVControlEventArgs>(this.f);
            this.t.Click -= new dClickedList(this.g);
            this.az.Change -= new EventHandler<MVIndexChangeEventArgs>(this.b);
            this.a0.Change -= new EventHandler<MVCheckBoxChangeEventArgs>(this.a);
            this.a1.Click -= new EventHandler<MVControlEventArgs>(this.n);
            this.av.Click -= new EventHandler<MVControlEventArgs>(this.am);
            this.aw.Change_Old -= new EventHandler(this.al);
            this.ax.Click -= new EventHandler<MVControlEventArgs>(this.ak);
            this.ay.Click -= new EventHandler<MVControlEventArgs>(this.aj);
            this.@as.Click -= new EventHandler<MVControlEventArgs>(this.ai);
            this.at.Click -= new EventHandler<MVControlEventArgs>(this.ah);
            this.ap.Change_Old -= new EventHandler(this.ag);
            this.ar.Change_Old -= new EventHandler(this.af);
            this.x.Click -= new EventHandler<MVControlEventArgs>(this.ae);
            this.w.Click -= new EventHandler<MVControlEventArgs>(this.ad);
            this.an.Change_Old -= new EventHandler(this.ac);
            this.al.Change_Old -= new EventHandler(this.ab);
            this.am.Change_Old -= new EventHandler(this.aa);
            this.ao.Change_Old -= new EventHandler(this.z);
            this.z.Change_Old -= new EventHandler(this.y);
            this.y.Change_Old -= new EventHandler(this.x);
            this.aa.Change_Old -= new EventHandler(this.w);
            this.ab.Change_Old -= new EventHandler(this.v);
            this.ae.Change_Old -= new EventHandler(this.s);
            this.ac.Change_Old -= new EventHandler(this.u);
            this.ad.Change_Old -= new EventHandler(this.t);
            this.af.Change_Old -= new EventHandler(this.r);
            this.ag.Change_Old -= new EventHandler(this.q);
            this.ah.Change_Old -= new EventHandler(this.p);
            this.u.Change_Old -= new EventHandler(this.o);
            this.ai.Change_Old -= new EventHandler(this.n);
            this.aj.Change_Old -= new EventHandler(this.m);
            this.ak.Change_Old -= new EventHandler(this.l);
            this.v.Change_Old -= new EventHandler(this.k);
            this.au.Change_Old -= new EventHandler(this.j);
            this.aq.Change_Old -= new EventHandler(this.i);
            this.a4.Click -= new EventHandler<MVControlEventArgs>(this.c);
            this.a3.Click -= new EventHandler<MVControlEventArgs>(this.b);
            this.a2.Click -= new dClickedList(this.f);
            this.bq.Click -= new EventHandler<MVControlEventArgs>(this.g);
            this.bn.Click -= new EventHandler<MVControlEventArgs>(this.f);
            this.bp.Click -= new EventHandler<MVControlEventArgs>(this.k);
            this.bm.Change_Old -= new EventHandler(this.e);
            this.bl.Click -= new dClickedList(this.h);
            this.bs.Click -= new EventHandler<MVControlEventArgs>(this.j);
            this.bu.Click -= new EventHandler<MVControlEventArgs>(this.l);
            this.bo.Click -= new EventHandler<MVControlEventArgs>(this.m);
            this.bw.Click -= new EventHandler<MVControlEventArgs>(this.h);
            this.bx.Click -= new EventHandler<MVControlEventArgs>(this.i);
            this.by.Click -= new EventHandler<MVControlEventArgs>(this.g);
            this.b5.Change_Old -= new EventHandler(this.ax);
            this.b4.Change_Old -= new EventHandler(this.aw);
            this.b3.Change_Old -= new EventHandler(this.av);
            this.b8.Change_Old -= new EventHandler(this.au);
            this.b7.Change_Old -= new EventHandler(this.at);
            this.b6.Change_Old -= new EventHandler(this.@as);
            this.b2.Change_Old -= new EventHandler(this.ar);
            this.b1.Change_Old -= new EventHandler(this.aq);
            this.b0.Change_Old -= new EventHandler(this.ap);
            this.ca.Click -= new EventHandler<MVControlEventArgs>(this.c);
            this.b9.Click -= new dClickedList(this.c);
            this.cc.Click -= new EventHandler<MVControlEventArgs>(this.b);
            this.cb.Click -= new dClickedList(this.b);
            this.cd.Click -= new dClickedList(this.a);
            this.ce.Click -= new EventHandler<MVControlEventArgs>(this.a);
            this.cf.Change -= new EventHandler<MVIndexChangeEventArgs>(this.a);
            this.m = null;
            this.n = null;
            this.o = null;
            this.p = null;
            this.q = null;
            this.r = null;
            this.s = null;
            this.t = null;
            this.u = null;
            this.v = null;
            this.w = null;
            this.x = null;
            this.y = null;
            this.z = null;
            this.aa = null;
            this.ab = null;
            this.ae = null;
            this.ac = null;
            this.ad = null;
            this.af = null;
            this.ag = null;
            this.ah = null;
            this.ai = null;
            this.aj = null;
            this.ak = null;
            this.al = null;
            this.am = null;
            this.an = null;
            this.ao = null;
            this.ap = null;
            this.aq = null;
            this.ar = null;
            this.@as = null;
            this.at = null;
            this.au = null;
            this.av = null;
            this.aw = null;
            this.ax = null;
            this.ay = null;
            this.az = null;
            this.a0 = null;
            this.a1 = null;
            this.cf = null;
            this.a2 = null;
            this.a3 = null;
            this.a4 = null;
            this.a5 = null;
            this.a6 = null;
            this.a7 = null;
            this.a8 = null;
            this.a9 = null;
            this.ba = null;
            this.bb = null;
            this.bc = null;
            this.bd = null;
            this.be = null;
            this.bf = null;
            this.bg = null;
            this.bh = null;
            this.bi = null;
            this.bj = null;
            this.bk = null;
            this.bl = null;
            this.bm = null;
            this.bn = null;
            this.bo = null;
            this.bp = null;
            this.bq = null;
            this.br = null;
            this.bs = null;
            this.bt = null;
            this.bu = null;
            this.bv = null;
            this.bw = null;
            this.bx = null;
            this.by = null;
            this.bz = null;
            this.b0 = null;
            this.b1 = null;
            this.b2 = null;
            this.b3 = null;
            this.b4 = null;
            this.b5 = null;
            this.b6 = null;
            this.b7 = null;
            this.b8 = null;
            this.ca = null;
            this.b9 = null;
            this.cb = null;
            this.cc = null;
            this.cd = null;
            this.ce = null;
            this.i.e();
            this.i = null;
            this.h.Dispose();
            this.h = null;
        }

        private void at(object A_0, EventArgs A_1)
        {
            er.b("Recharge-Helper-Stam", k.a(this.b7.Position));
        }

        internal void au()
        {
            this.h = ff.f(base.get_Host(), "uTank2.ViewXML.mainView.xml");
            this.h.Title = "Virindi Tank v." + Assembly.GetExecutingAssembly().GetName(false).Version.ToString();
            if (cs)
            {
                this.h.Title = this.h.Title + " (SIMULATION MODE)";
            }
            this.h.SetIcon(0x65, GetModuleHandle("utank2-i"));
            this.i = new e3();
            this.i.a(new EventHandler(this.an));
            this.i.a(0xcc7);
            this.i.d();
            this.m = (IButton) this.h["cmdNewBuffItem"];
            this.n = (IList) this.h["lstExtraBuffItems"];
            this.o = (IButton) this.h["cmdAddAllPeas"];
            this.p = (IList) this.h["lstExcludedComponents"];
            this.q = (IButton) this.h["cmdNewExcludedComponent"];
            this.r = (IButton) this.h["cmdNewWeapon"];
            this.s = (IButton) this.h["cmdNewWeapon_NoBuffs"];
            this.t = (IList) this.h["lstBuffItems"];
            this.u = (ICheckBox) this.h["cShowAdvanced"];
            this.v = (ICheckBox) this.h["cOn"];
            this.w = (IButton) this.h["bForceBuff"];
            this.x = (IButton) this.h["bCancelForceBuff"];
            this.y = (ICheckBox) this.h["cGems"];
            this.z = (ICheckBox) this.h["cDispel"];
            this.aa = (ICheckBox) this.h["cNav"];
            this.ab = (ICheckBox) this.h["cLoot"];
            this.ac = (ICheckBox) this.h["cEnableBuffing"];
            this.ad = (ICheckBox) this.h["cEnableCombat"];
            this.ae = (ICheckBox) this.h["cAutoFellow"];
            this.af = (ICheckBox) this.h["cEnableAutoStack"];
            this.ag = (ICheckBox) this.h["cEnableAutoCram"];
            this.ah = (ICheckBox) this.h["cTopoffBuffs"];
            this.ai = (ICheckBox) this.h["cIdlePeace"];
            this.aj = (ICheckBox) this.h["cLootPriorityBoost"];
            this.ak = (ICheckBox) this.h["cMChargesWhenOff"];
            this.al = (ITextBox) this.h["txtRingRange"];
            this.am = (ITextBox) this.h["txtRange"];
            this.an = (ITextBox) this.h["txtApproachRange"];
            this.ao = (ITextBox) this.h["txtWPRange"];
            this.ap = (ICombo) this.h["cmbLootSet"];
            this.aq = (ICombo) this.h["cmbSettingsSet"];
            this.ar = (ICombo) this.h["cmbNavSet"];
            this.@as = (IButton) this.h["bSettingsSaveAs"];
            this.at = (IButton) this.h["bNavSaveAs"];
            this.au = (ICheckBox) this.h["cSettingsShowAll"];
            this.av = (IButton) this.h["bLootSaveAs"];
            this.aw = (ICheckBox) this.h["cShowLootEditor"];
            this.ax = (IButton) this.h["bSettingsReset"];
            this.ay = (IButton) this.h["bNavReset"];
            this.az = (ICombo) this.h["cmbMetaSet"];
            this.a0 = (ICheckBox) this.h["cMeta"];
            this.a1 = (IButton) this.h["bMetaSaveAs"];
            this.a2 = (IList) this.h["lstMonsters"];
            this.a3 = (IButton) this.h["cmdNewMonster"];
            this.a4 = (IButton) this.h["cmdNewMonsterFromCur"];
            this.a5 = (ITextBox) this.h["txtNewMonster"];
            this.a6 = (IStaticText) this.h["Label_Mon_F"];
            this.a7 = (IStaticText) this.h["Label_Mon_B"];
            this.a8 = (IStaticText) this.h["Label_Mon_G"];
            this.a9 = (IStaticText) this.h["Label_Mon_I"];
            this.ba = (IStaticText) this.h["Label_Mon_Y"];
            this.bb = (IStaticText) this.h["Label_Mon_V"];
            this.bc = (IStaticText) this.h["Label_Mon_A"];
            this.bd = (IStaticText) this.h["Label_Mon_R"];
            this.be = (IStaticText) this.h["Label_Mon_S"];
            this.bf = (IStaticText) this.h["Label_Mon_Void_1"];
            this.bg = (IStaticText) this.h["Label_Mon_Void_2"];
            this.bh = (IStaticText) this.h["Label_Mon_Void_3"];
            this.bi = (IStaticText) this.h["Label_Mon_Void_4"];
            this.bj = (IStaticText) this.h["Label_Mon_Void_5"];
            this.bk = (IStaticText) this.h["Label_Mon_P"];
            this.a6.TooltipText = "Fester";
            this.a7.TooltipText = "Broadside of a Barn";
            this.a8.TooltipText = "Gravity Well";
            this.a9.TooltipText = "Imperil";
            this.ba.TooltipText = "Yield";
            this.bb.TooltipText = "Vuln (Element)";
            this.bc.TooltipText = "Attack";
            this.bd.TooltipText = "Ring Spell";
            this.be.TooltipText = "Streak";
            this.bf.TooltipText = "Weakening Curse";
            this.bg.TooltipText = "Festering Curse";
            this.bh.TooltipText = "Corruption";
            this.bi.TooltipText = "Destructive Curse";
            this.bj.TooltipText = "Corrosion";
            this.bk.TooltipText = "Priority";
            this.bl = (IList) this.h["lstWaypoints"];
            this.bm = (ICombo) this.h["cmbNavType"];
            this.bn = (IButton) this.h["cmdNewWaypoint"];
            this.bo = (IButton) this.h["cmdNavOpenVendor"];
            this.bp = (IButton) this.h["cmdNewWaypointPortal"];
            this.bq = (IButton) this.h["cmdNewRecall"];
            this.br = (ICombo) this.h["cmbRecallType"];
            this.bs = (IButton) this.h["cmdNewWaypointPause"];
            this.bt = (ITextBox) this.h["txtPauseWaypointTime"];
            this.bu = (IButton) this.h["cmdNewWaypointChat"];
            this.bv = (ITextBox) this.h["txtChatWaypoint"];
            this.bw = (IImageButton) this.h["btnNavDown"];
            this.bx = (IImageButton) this.h["btnNavUp"];
            this.by = (IImageButton) this.h["btnNavResetPoint"];
            this.bw.TooltipText = "Advance Current Point";
            this.bx.TooltipText = "Regress Current Point";
            this.by.TooltipText = "Select Nearest Point";
            this.bz = (ICombo) this.h["cmbNavInsertMode"];
            this.b0 = (ISlider) this.h["slMyHP"];
            this.b1 = (ISlider) this.h["slMyStam"];
            this.b2 = (ISlider) this.h["slMyMana"];
            this.b3 = (ISlider) this.h["slTopOffHP"];
            this.b4 = (ISlider) this.h["slTopOffStam"];
            this.b5 = (ISlider) this.h["slTopOffMana"];
            this.b6 = (ISlider) this.h["slOtherHP"];
            this.b7 = (ISlider) this.h["slOtherStam"];
            this.b8 = (ISlider) this.h["slOtherMana"];
            this.b9 = (IList) this.h["lstBuffSpells"];
            this.ca = (IButton) this.h["cmdNewBuffSpell"];
            this.cb = (IList) this.h["lstAntiBuffSpells"];
            this.cc = (IButton) this.h["cmdNewAntiBuffSpell"];
            this.cd = (IList) this.h["lstMetaRules"];
            this.ce = (IButton) this.h["cmdMetaCreate"];
            this.cf = (ICombo) this.h["cmbMetaCurrentState"];
            this.m.Click += new EventHandler<MVControlEventArgs>(this.a);
            this.n.Click += new dClickedList(this.e);
            this.o.Click += new EventHandler<MVControlEventArgs>(this.e);
            this.p.Click += new dClickedList(this.d);
            this.q.Click += new EventHandler<MVControlEventArgs>(this.d);
            this.r.Click += new EventHandler<MVControlEventArgs>(this.d);
            this.s.Click += new EventHandler<MVControlEventArgs>(this.f);
            this.t.Click += new dClickedList(this.g);
            this.az.Change += new EventHandler<MVIndexChangeEventArgs>(this.b);
            this.a0.Change += new EventHandler<MVCheckBoxChangeEventArgs>(this.a);
            this.a1.Click += new EventHandler<MVControlEventArgs>(this.n);
            this.av.Click += new EventHandler<MVControlEventArgs>(this.am);
            this.aw.Change_Old += new EventHandler(this.al);
            this.ax.Click += new EventHandler<MVControlEventArgs>(this.ak);
            this.ay.Click += new EventHandler<MVControlEventArgs>(this.aj);
            this.@as.Click += new EventHandler<MVControlEventArgs>(this.ai);
            this.at.Click += new EventHandler<MVControlEventArgs>(this.ah);
            this.ap.Change_Old += new EventHandler(this.ag);
            this.ar.Change_Old += new EventHandler(this.af);
            this.x.Click += new EventHandler<MVControlEventArgs>(this.ae);
            this.w.Click += new EventHandler<MVControlEventArgs>(this.ad);
            this.an.Change_Old += new EventHandler(this.ac);
            this.al.Change_Old += new EventHandler(this.ab);
            this.am.Change_Old += new EventHandler(this.aa);
            this.ao.Change_Old += new EventHandler(this.z);
            this.z.Change_Old += new EventHandler(this.y);
            this.y.Change_Old += new EventHandler(this.x);
            this.aa.Change_Old += new EventHandler(this.w);
            this.ab.Change_Old += new EventHandler(this.v);
            this.ac.Change_Old += new EventHandler(this.u);
            this.ad.Change_Old += new EventHandler(this.t);
            this.ae.Change_Old += new EventHandler(this.s);
            this.af.Change_Old += new EventHandler(this.r);
            this.ag.Change_Old += new EventHandler(this.q);
            this.ah.Change_Old += new EventHandler(this.p);
            this.u.Change_Old += new EventHandler(this.o);
            this.ai.Change_Old += new EventHandler(this.n);
            this.aj.Change_Old += new EventHandler(this.m);
            this.ak.Change_Old += new EventHandler(this.l);
            this.v.Change_Old += new EventHandler(this.k);
            this.au.Change_Old += new EventHandler(this.j);
            this.aq.Change_Old += new EventHandler(this.i);
            this.a4.Click += new EventHandler<MVControlEventArgs>(this.c);
            this.a3.Click += new EventHandler<MVControlEventArgs>(this.b);
            this.a2.Click += new dClickedList(this.f);
            this.bq.Click += new EventHandler<MVControlEventArgs>(this.g);
            this.bn.Click += new EventHandler<MVControlEventArgs>(this.f);
            this.bp.Click += new EventHandler<MVControlEventArgs>(this.k);
            this.bm.Change_Old += new EventHandler(this.e);
            this.bl.Click += new dClickedList(this.h);
            this.bs.Click += new EventHandler<MVControlEventArgs>(this.j);
            this.bu.Click += new EventHandler<MVControlEventArgs>(this.l);
            this.bo.Click += new EventHandler<MVControlEventArgs>(this.m);
            this.bw.Click += new EventHandler<MVControlEventArgs>(this.h);
            this.bw.Background = 0x60028fd;
            this.bx.Click += new EventHandler<MVControlEventArgs>(this.i);
            this.bx.Background = 0x60028fc;
            this.by.Click += new EventHandler<MVControlEventArgs>(this.g);
            this.by.Background = 0x60011f7;
            this.b5.Change_Old += new EventHandler(this.ax);
            this.b4.Change_Old += new EventHandler(this.aw);
            this.b3.Change_Old += new EventHandler(this.av);
            this.b8.Change_Old += new EventHandler(this.au);
            this.b7.Change_Old += new EventHandler(this.at);
            this.b6.Change_Old += new EventHandler(this.@as);
            this.b2.Change_Old += new EventHandler(this.ar);
            this.b1.Change_Old += new EventHandler(this.aq);
            this.b0.Change_Old += new EventHandler(this.ap);
            this.ca.Click += new EventHandler<MVControlEventArgs>(this.c);
            this.b9.Click += new dClickedList(this.c);
            this.cc.Click += new EventHandler<MVControlEventArgs>(this.b);
            this.cb.Click += new dClickedList(this.b);
            this.cd.Click += new dClickedList(this.a);
            this.ce.Click += new EventHandler<MVControlEventArgs>(this.a);
            this.cf.Change += new EventHandler<MVIndexChangeEventArgs>(this.a);
            this.j = this.h.Size.Width;
            this.k = this.h.Size.Height;
            if (this.h is View)
            {
                this.h();
            }
        }

        private void au(object A_0, EventArgs A_1)
        {
            er.b("Recharge-Helper-Mana", k.a(this.b8.Position));
        }

        internal void av()
        {
            int scrollPosition = this.t.ScrollPosition;
            this.c1.Clear();
            this.t.Clear();
            foreach (KeyValuePair<int, int> pair in cq.j.g())
            {
                int key = pair.Key;
                if ((key != -1) && (key != cq.aw.get_CharacterFilter().get_Id()))
                {
                    this.c1.Add(key);
                    IListRow row = this.t.AddRow();
                    bool flag = false;
                    if (dh.b(key) && (cq.p.d(key) != null))
                    {
                        row[0][0] = cq.p.d(key).e();
                        if ((cq.p.d(key).a(dt.c1, 0) & 0x100000) > 0)
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        row[0][0] = "<INVALID " + key.ToString() + ">";
                        flag = true;
                    }
                    if (flag)
                    {
                        string str = ey.a((int) cq.n.e(key), typeof(eItemUseSpecifier));
                        if (str == "???")
                        {
                            str = "";
                        }
                        row[1][0] = str;
                    }
                    if (pair.Value == -1)
                    {
                        row[0].Color = Color.Red;
                        row[0][0] = ((string) row[0][0]) + " (NO BUFFS)";
                    }
                    cq.n.b(key);
                }
            }
            this.t.ScrollPosition = scrollPosition;
        }

        private void av(object A_0, EventArgs A_1)
        {
            er.b("Recharge-NoTarg-HitP", k.a(this.b3.Position));
        }

        private void aw(object A_0, EventArgs A_1)
        {
            er.b("Recharge-NoTarg-Stam", k.a(this.b4.Position));
        }

        private void ax(object A_0, EventArgs A_1)
        {
            er.b("Recharge-NoTarg-Mana", k.a(this.b5.Position));
        }

        private void b()
        {
            foreach (KeyValuePair<string, aa> pair in cq.l.t)
            {
                string str = "VTank: " + pair.Value.e;
                if (!base.get_Core().get_HotkeySystem().Exists(str))
                {
                    base.get_Core().get_HotkeySystem().AddHotkey("uTank2", str, pair.Value.c, pair.Value.f, pair.Value.a, pair.Value.b, pair.Value.d);
                }
            }
            base.get_Core().get_HotkeySystem().add_Hotkey(new EventHandler<HotkeyEventArgs>(this.a));
        }

        private List<string> b(cv A_0)
        {
            List<string> list = new List<string> {
                "--------------Object dump--------------",
                "[Meta] Create count: " + A_0.n.ToString(),
                "[Meta] Create time: " + A_0.o.ToLocalTime().DateTime.ToShortDateString() + " " + A_0.o.ToLocalTime().DateTime.ToShortTimeString(),
                "[Meta] Has identify data: " + A_0.j.ToString(),
                "[Meta] Last ID time: " + A_0.p.ToLocalTime().DateTime.ToShortDateString() + " " + A_0.p.ToLocalTime().DateTime.ToShortTimeString()
            };
            list.Add("[Meta] Worldfilter valid: " + ((base.get_Core().get_WorldFilter().get_Item(A_0.k) != null)).ToString());
            list.Add("[Meta] Client valid: " + base.get_Host().get_Actions().IsValidObject(A_0.k).ToString());
            list.Add("ID: " + A_0.k.ToString("X"));
            list.Add("ObjectClass: " + A_0.c().ToString());
            if ((A_0.f() == 0) && cq.p.i.ContainsKey(cg))
            {
                cv cv = cq.p.i[cg];
                dz dz = cv.b(base.get_Host().get_Actions());
                dz dz2 = A_0.b(base.get_Host().get_Actions());
                dz w = cv.w;
                dz dz4 = A_0.w;
                list.Add("[Protocol] Position: " + dz4.ToString());
                list.Add("[Protocol] Range: " + Math.Round((double) (w.a(dz4, true) * 240.0), 4).ToString() + "m, Angle: " + Math.Round(w.a(dz4), 4).ToString() + " radians from North");
                list.Add("[Memloc] Position: " + dz2.ToString());
                list.Add("[Memloc] Range: " + Math.Round((double) (dz.a(dz2, true) * 240.0), 4).ToString() + "m, Angle: " + Math.Round(dz.a(dz2), 4).ToString() + " radians from North");
            }
            if (A_0.c() == ObjectClass.Door)
            {
                A_0.a(cq.ax.get_Actions());
                list.Add("Door open? " + A_0.l.ToString());
            }
            foreach (KeyValuePair<int, string> pair in A_0.b)
            {
                string name = Enum.GetName(typeof(StringValueKey), pair.Key);
                if (string.IsNullOrEmpty(name))
                {
                    name = pair.Key.ToString();
                }
                list.Add("(S) " + name + ": " + pair.Value.ToString());
            }
            foreach (KeyValuePair<int, bool> pair2 in A_0.c)
            {
                string str2 = Enum.GetName(typeof(BoolValueKey), pair2.Key);
                if (string.IsNullOrEmpty(str2))
                {
                    str2 = pair2.Key.ToString();
                }
                list.Add("(B) " + str2 + ": " + pair2.Value.ToString());
            }
            foreach (KeyValuePair<int, int> pair3 in A_0.a)
            {
                string str3 = Enum.GetName(typeof(IntValueKey), pair3.Key);
                if (string.IsNullOrEmpty(str3))
                {
                    str3 = pair3.Key.ToString();
                }
                string str4 = pair3.Value.ToString();
                switch (pair3.Key)
                {
                    case dt.b3:
                        str4 = str4 + " (" + ((eCleaveType) pair3.Value).ToString() + ")";
                        break;

                    case dt.c1:
                        str4 = str4 + " (" + ((bk) pair3.Value).ToString() + ")";
                        break;

                    case dt.d:
                        str4 = str4 + " (" + ((bk) pair3.Value).ToString() + ")";
                        break;

                    case dt.a5:
                        str4 = str4 + " (" + ((eImbueType) pair3.Value).ToString() + ")";
                        break;
                }
                list.Add("(I) " + str3 + ": " + str4);
            }
            foreach (KeyValuePair<int, long> pair4 in A_0.e)
            {
                string str5 = Enum.GetName(typeof(QuadValueKey), pair4.Key);
                if (string.IsNullOrEmpty(str5))
                {
                    str5 = pair4.Key.ToString();
                }
                list.Add("(Q) " + str5 + ": " + pair4.Value.ToString());
            }
            foreach (KeyValuePair<int, double> pair5 in A_0.d)
            {
                string str6 = Enum.GetName(typeof(DoubleValueKey), pair5.Key);
                if (string.IsNullOrEmpty(str6))
                {
                    str6 = pair5.Key.ToString();
                }
                list.Add("(D) " + str6 + ": " + pair5.Value.ToString());
            }
            foreach (KeyValuePair<int, int> pair6 in A_0.f)
            {
                string str7 = Enum.GetName(typeof(LinkValueKey), pair6.Key);
                if (string.IsNullOrEmpty(str7))
                {
                    str7 = pair6.Key.ToString();
                }
                list.Add("(L) " + str7 + ": " + pair6.Value.ToString());
            }
            foreach (KeyValuePair<int, int> pair7 in A_0.g)
            {
                string str8 = Enum.GetName(typeof(fo), pair7.Key);
                if (string.IsNullOrEmpty(str8))
                {
                    str8 = pair7.Key.ToString();
                }
                list.Add("(R) " + str8 + ": " + pair7.Value.ToString());
            }
            int num = 0;
            foreach (bo bo in A_0.t)
            {
                string[] strArray = new string[10];
                strArray[0] = "Palette Entry ";
                int num6 = num++;
                strArray[1] = num6.ToString();
                strArray[2] = ": ID 0x";
                strArray[3] = bo.a.ToString("X6");
                strArray[4] = ", Ex Color: ";
                strArray[5] = (bo.a().ToArgb() & 0xffffff).ToString("X6");
                strArray[6] = ", ";
                strArray[7] = bo.b.ToString();
                strArray[8] = "/";
                strArray[9] = bo.c.ToString();
                list.Add(string.Concat(strArray));
            }
            return list;
        }

        internal void b(bool A_0)
        {
        }

        private string b(int A_0)
        {
            if (A_0 == 0)
            {
                return "<ANY WAND>";
            }
            if (A_0 == -1)
            {
                return "<AUTO>";
            }
            if ((dh.b(A_0) && (dh.c(A_0) == cg)) && (cq.p.d(A_0) != null))
            {
                return cq.p.d(A_0).e();
            }
            return ("<INVALID " + A_0.ToString() + ">");
        }

        internal static string b(string A_0)
        {
            if (A_0.StartsWith("VTank: "))
            {
                return A_0.Substring(7);
            }
            return A_0;
        }

        internal void b(HudView A_0)
        {
            HudTabView view = A_0.get_Controls().get_Item("MainTabs") as HudTabView;
            if (view != null)
            {
                Rectangle rectangle = view.get_Item(view.get_CurrentTab()).get_SavedClipRegion();
                HudFixedLayout layout = A_0.get_Controls().ParentOf("lstBuffSpells") as HudFixedLayout;
                if (layout != null)
                {
                    Rectangle controlRect = layout.GetControlRect("cmdNewBuffSpell");
                    layout.SetControlRect("cmdNewBuffSpell", new Rectangle(controlRect.Left, rectangle.Height - (controlRect.Height + 4), controlRect.Width, controlRect.Height));
                    int height = controlRect.Height;
                    controlRect = layout.GetControlRect("cmdNewAntiBuffSpell");
                    layout.SetControlRect("cmdNewAntiBuffSpell", new Rectangle(controlRect.Left, rectangle.Height - (controlRect.Height + 4), controlRect.Width, controlRect.Height));
                    controlRect = layout.GetControlRect("lstAntiBuffSpells");
                    layout.SetControlRect("lstAntiBuffSpells", new Rectangle(controlRect.Left, controlRect.Top, controlRect.Width, rectangle.Height - ((controlRect.Top + 8) + height)));
                    controlRect = layout.GetControlRect("lstBuffSpells");
                    layout.SetControlRect("lstBuffSpells", new Rectangle(controlRect.Left, controlRect.Top, controlRect.Width, rectangle.Height - ((controlRect.Top + 8) + height)));
                }
            }
        }

        private void b(int A_0, bool A_1)
        {
            if (A_1)
            {
                string str = "???";
                cv cv = cq.p.d(A_0);
                if (cv != null)
                {
                    str = cv.e();
                }
                LootAction action = cq.ag.a(A_0);
                string str2 = "";
                if (!string.IsNullOrEmpty(action.RuleName))
                {
                    str2 = " (matched rule \"" + action.RuleName + "\")";
                }
                if (action.IsNoLoot)
                {
                    e("TestItem: Item \"" + str + "\" will not be looted" + str2 + ".");
                }
                else if (action.IsKeep)
                {
                    e("TestItem: Item \"" + str + "\" will be looted and kept" + str2 + ".");
                }
                else if (action.IsSalvage)
                {
                    e("TestItem: Item \"" + str + "\" will be salvaged" + str2 + ".");
                }
                else
                {
                    e("TestItem: Item \"" + str + "\" matches custom rule" + str2 + ".");
                }
            }
            else
            {
                e("TestItem: Could not ID item.");
            }
        }

        internal void b(int A_0, int A_1)
        {
            if (this.df != null)
            {
                this.df(A_0, A_1);
            }
        }

        private void b(object A_0, NetworkMessageEventArgs A_1)
        {
            try
            {
                if (this.cx != null)
                {
                    this.cx(A_0, A_1);
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void b(object A_0, MVControlEventArgs A_1)
        {
            try
            {
                if (this.cl)
                {
                    cq.ae.a(true);
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void b(object A_0, MVIndexChangeEventArgs A_1)
        {
            try
            {
                if (!this.l)
                {
                    if (this.az.Text[this.az.Selected] == "[None]")
                    {
                        cq.@as.e("");
                    }
                    else if (this.az.Text[this.az.Selected] == "[By char]")
                    {
                        cq.@as.e(cq.l.q);
                    }
                    else
                    {
                        cq.@as.e(this.az.Text[this.az.Selected]);
                    }
                    cq.l.r();
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void b(object A_0, EventArgs A_1)
        {
            try
            {
                string text = this.a5.Text;
                if (string.IsNullOrEmpty(text) || cq.d.d(text))
                {
                    return;
                }
                aj.c c = cq.d.e();
                cq.d.a(text, c);
                this.a(text, c);
                this.a5.Text = "";
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
            cq.l.d();
        }

        internal void b(int A_0, int A_1, int A_2)
        {
            if (this.de != null)
            {
                this.de(A_0, A_1, A_2);
            }
        }

        private void b(object A_0, int A_1, int A_2)
        {
            try
            {
                if (this.cl)
                {
                    this.cb.RemoveRow(A_1);
                    cq.l.j.RemoveAt(A_1);
                    cq.l.d();
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void c()
        {
            foreach (KeyValuePair<string, aa> pair in cq.l.t)
            {
                VHotkeySystem.Instance.AddHotkey(pair.Value.a());
            }
            VHotkeySystem.Instance.add_HotkeyHit(new VHotkeySystem.delHotkeyHit(this, (IntPtr) this.a));
        }

        private eBuffedItemAddOptions c(int A_0)
        {
            if (this.c0.ContainsKey(A_0))
            {
                eBuffedItemAddOptions options = this.c0[A_0];
                this.c0.Remove(A_0);
                return options;
            }
            return eBuffedItemAddOptions.StandardBuffs;
        }

        private string c(string A_0)
        {
            string[] strArray = A_0.Split(new char[] { '~' });
            if (strArray.Length != 2)
            {
                throw new Exception("Invalid plainkey.");
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("<RSAKeyValue><Modulus>");
            foreach (char ch in strArray[0])
            {
                switch (ch)
                {
                    case '-':
                        builder.Append('/');
                        break;

                    case '.':
                        builder.Append('=');
                        break;

                    case '_':
                        builder.Append('+');
                        break;

                    default:
                        builder.Append(ch);
                        break;
                }
            }
            builder.Append("</Modulus><Exponent>");
            foreach (char ch2 in strArray[1])
            {
                switch (ch2)
                {
                    case '-':
                        builder.Append('/');
                        break;

                    case '.':
                        builder.Append('=');
                        break;

                    case '_':
                        builder.Append('+');
                        break;

                    default:
                        builder.Append(ch2);
                        break;
                }
            }
            builder.Append("</Exponent></RSAKeyValue>");
            return builder.ToString();
        }

        internal void c(HudView A_0)
        {
        }

        internal void c(int A_0, bool A_1)
        {
            if (cq.l.f && (A_0 != 0))
            {
                if (A_1)
                {
                    if (!cq.n.e.Contains(A_0))
                    {
                        cq.n.e.Add(A_0);
                    }
                }
                else if (cq.n.e.Contains(A_0))
                {
                    cq.n.e.Remove(A_0);
                }
            }
        }

        private void c(object A_0, MVControlEventArgs A_1)
        {
            try
            {
                if (this.cl)
                {
                    cq.ad.a(true);
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void c(object A_0, EventArgs A_1)
        {
            try
            {
                if (!dh.b(base.get_Host().get_Actions().get_CurrentSelection()) || (base.get_Core().get_WorldFilter().get_Item(base.get_Host().get_Actions().get_CurrentSelection()).get_ObjectClass() != 5))
                {
                    return;
                }
                string str = base.get_Core().get_WorldFilter().get_Item(base.get_Host().get_Actions().get_CurrentSelection()).get_Name();
                if (cq.d.d(str))
                {
                    return;
                }
                aj.c c = cq.d.e();
                cq.d.a(str, c);
                this.a(str, c);
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
            cq.l.d();
        }

        internal void c(int A_0, int A_1, int A_2)
        {
            cq.i.b(A_0, A_1, A_2);
        }

        private void c(object A_0, int A_1, int A_2)
        {
            try
            {
                if (this.cl)
                {
                    this.b9.RemoveRow(A_1);
                    cq.l.i.RemoveAt(A_1);
                    cq.l.d();
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void d()
        {
            if (cy.b())
            {
                this.c();
            }
        }

        internal void d(int A_0)
        {
            if (cq.n.f.ContainsKey(A_0))
            {
                cq.n.f[A_0].a = true;
            }
        }

        private string d(string A_0)
        {
            MemoryStream input = new MemoryStream();
            byte[] bytes = Encoding.Unicode.GetBytes(A_0);
            input.Write(bytes, 0, bytes.Length);
            input.Position = 0L;
            XmlTextReader reader = new XmlTextReader(input);
            string str = "";
            string str2 = "";
            string name = "";
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                    {
                        name = reader.Name;
                        continue;
                    }
                    case XmlNodeType.Attribute:
                    {
                        continue;
                    }
                    case XmlNodeType.Text:
                    {
                        switch (name)
                        {
                            case "Exponent":
                                goto Label_009A;
                        }
                        continue;
                    }
                    default:
                    {
                        continue;
                    }
                }
                str2 = reader.Value;
                continue;
            Label_009A:
                str = reader.Value;
            }
            StringBuilder builder = new StringBuilder();
            foreach (char ch in str2)
            {
                switch (ch)
                {
                    case '+':
                        builder.Append('_');
                        break;

                    case '/':
                        builder.Append('-');
                        break;

                    case '=':
                        builder.Append('.');
                        break;

                    default:
                        builder.Append(ch);
                        break;
                }
            }
            builder.Append('~');
            foreach (char ch2 in str)
            {
                switch (ch2)
                {
                    case '+':
                        builder.Append('_');
                        break;

                    case '/':
                        builder.Append('-');
                        break;

                    case '=':
                        builder.Append('.');
                        break;

                    default:
                        builder.Append(ch2);
                        break;
                }
            }
            return builder.ToString();
        }

        internal void d(HudView A_0)
        {
            HudTabView view = A_0.get_Controls().get_Item("MainTabs") as HudTabView;
            if (view != null)
            {
                Rectangle rectangle = view.get_Item(view.get_CurrentTab()).get_SavedClipRegion();
                HudFixedLayout layout = A_0.get_Controls().ParentOf("lstMonsters") as HudFixedLayout;
                if (layout != null)
                {
                    Rectangle controlRect = layout.GetControlRect("txtNewMonster");
                    layout.SetControlRect("txtNewMonster", new Rectangle(controlRect.Left, rectangle.Height - (controlRect.Height + 4), controlRect.Width, controlRect.Height));
                    int height = controlRect.Height;
                    controlRect = layout.GetControlRect("cmdNewMonster");
                    layout.SetControlRect("cmdNewMonster", new Rectangle(controlRect.Left, rectangle.Height - (controlRect.Height + 4), controlRect.Width, controlRect.Height));
                    controlRect = layout.GetControlRect("cmdNewMonsterFromCur");
                    layout.SetControlRect("cmdNewMonsterFromCur", new Rectangle(controlRect.Left, rectangle.Height - (controlRect.Height + 4), controlRect.Width, controlRect.Height));
                    controlRect = layout.GetControlRect("lstMonsters");
                    layout.SetControlRect("lstMonsters", new Rectangle(controlRect.Left, controlRect.Top, controlRect.Width, rectangle.Height - ((controlRect.Top + 8) + height)));
                }
            }
        }

        private void d(object A_0, MVControlEventArgs A_1)
        {
            try
            {
                if (this.cl)
                {
                    int num = base.get_Host().get_Actions().get_CurrentSelection();
                    if (num != 0)
                    {
                        cv cv = cq.p.d(num);
                        if (cv == null)
                        {
                            e("Select a spell component first.");
                        }
                        else if (cv.c() != ObjectClass.SpellComponent)
                        {
                            e("Select a spell component first.");
                        }
                        else
                        {
                            do @do = new do(2);
                            @do.a(er.f("BlacklistedSpellComps"));
                            string b = cv.e();
                            foreach (string[] strArray in @do)
                            {
                                if (string.Equals(strArray[1], b))
                                {
                                    e("Blacklist entry already exists.");
                                    return;
                                }
                            }
                            @do.Add(new string[] { cv.a(dt.co, 0).ToString(), b });
                            er.b("BlacklistedSpellComps", k.a(@do.ToString()));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void d(object A_0, EventArgs A_1)
        {
            try
            {
                int num = this.e();
                if (num != 0)
                {
                    this.a(num, eBuffedItemAddOptions.StandardBuffs);
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void d(int A_0, int A_1, int A_2)
        {
            if (this.dd != null)
            {
                this.dd(A_0, A_1, A_2);
            }
        }

        private void d(object A_0, int A_1, int A_2)
        {
            try
            {
                if (this.cl)
                {
                    do @do = new do(2);
                    @do.a(er.f("BlacklistedSpellComps"));
                    if (A_1 < @do.Count)
                    {
                        @do.RemoveAt(A_1);
                        er.b("BlacklistedSpellComps", k.a(@do.ToString()));
                    }
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private int e()
        {
            int num = cq.ax.get_Actions().get_CurrentSelection();
            if (dh.b(num))
            {
                int num2;
                if (this.c1.Contains(num))
                {
                    return 0;
                }
                if (this.cz.Contains(num))
                {
                    return 0;
                }
                if (fn.e(cq.aw.get_WorldFilter().get_Item(num)))
                {
                    return num;
                }
                if (!cq.aw.get_WorldFilter().get_Item(num).Exists(0xd00000e, ref num2))
                {
                    return 0;
                }
                switch (num2)
                {
                    case 0x100000:
                    case 0x200000:
                        return num;

                    case 0x400000:
                    case 0x1000000:
                    case 0x2000000:
                        return num;
                }
            }
            return 0;
        }

        internal void e(int A_0)
        {
            if (this.dg != null)
            {
                this.dg(A_0);
            }
        }

        internal static void e(string A_0)
        {
            try
            {
                if (!cj)
                {
                    a5.a(eChatType.CommandLine, A_0);
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void e(HudView A_0)
        {
            HudTabView view = A_0.get_Controls().get_Item("MainTabs") as HudTabView;
            if (view != null)
            {
                Rectangle rectangle = view.get_Item(view.get_CurrentTab()).get_SavedClipRegion();
                HudFixedLayout layout = A_0.get_Controls().ParentOf("lstWaypoints") as HudFixedLayout;
                if (layout != null)
                {
                    Rectangle controlRect = layout.GetControlRect("layoutRouteBottomControls");
                    layout.SetControlRect("layoutRouteBottomControls", new Rectangle(controlRect.Left, rectangle.Height - (controlRect.Height + 4), controlRect.Width, controlRect.Height));
                    int height = controlRect.Height;
                    controlRect = layout.GetControlRect("lstWaypoints");
                    layout.SetControlRect("lstWaypoints", new Rectangle(controlRect.Left, controlRect.Top, controlRect.Width, rectangle.Height - ((controlRect.Top + 8) + height)));
                }
            }
        }

        private void e(object A_0, MVControlEventArgs A_1)
        {
            try
            {
                if (this.cl)
                {
                    foreach (string str in this.c2)
                    {
                        if (str.Equals("[All Peas]"))
                        {
                            return;
                        }
                    }
                    this.t();
                    cq.l.d();
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void e(object A_0, EventArgs A_1)
        {
            try
            {
                switch (this.bm.Selected)
                {
                    case 0:
                        cq.l.k.a(eNavType.Circular);
                        break;

                    case 1:
                        cq.l.k.a(eNavType.Linear);
                        break;

                    case 2:
                        cq.l.k.a(eNavType.Target);
                        break;

                    case 3:
                        cq.l.k.a(eNavType.Once);
                        break;
                }
                cq.n.m = false;
                this.ao();
                cq.l.g();
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void e(int A_0, int A_1, int A_2)
        {
            if (cq.e.c(A_1))
            {
                MySpell spell = cq.e.b(A_1);
                if (((spell != null) && (A_2 > 0)) && (A_0 != 0))
                {
                    if (!cq.i.b.ContainsKey(A_0))
                    {
                        cq.i.b.Add(A_0, new MySortedList<int, MySortedList<int, dg.a>>(0x23));
                    }
                    if (!cq.i.b[A_0].ContainsKey(spell.RealFamily))
                    {
                        cq.i.b[A_0].Add(spell.RealFamily, new MySortedList<int, dg.a>(0x24));
                    }
                    if (!cq.i.b[A_0][spell.RealFamily].ContainsKey(spell.Id))
                    {
                        cq.i.b[A_0][spell.RealFamily].Add(spell.Id, new dg.a(DateTimeOffset.MinValue));
                    }
                    DateTimeOffset offset = DateTimeOffset.Now + TimeSpan.FromMilliseconds((double) A_2);
                    if (cq.i.b[A_0][spell.RealFamily][spell.Id].b < offset)
                    {
                        cq.n.a(string.Format("External cast {0} on {1} ending at {2}, OVERRIDDEN", spell.Name, A_0, offset.ToString()), e8.e);
                        cq.i.b[A_0][spell.RealFamily][spell.Id] = new dg.a(offset);
                    }
                    else
                    {
                        cq.n.a(string.Format("External cast {0} on {1} ending at {2}, newer already present", spell.Name, A_0, offset.ToString()), e8.e);
                    }
                }
            }
        }

        private void e(object A_0, int A_1, int A_2)
        {
            try
            {
                if (this.cl)
                {
                    string key = this.c2[A_1];
                    this.n.RemoveRow(A_1);
                    this.c2.RemoveAt(A_1);
                    if (cq.l.g.ContainsKey(key))
                    {
                        cq.l.g.Remove(key);
                    }
                    else
                    {
                        cq.l.h.Remove(key);
                    }
                    cq.l.d();
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void f()
        {
            if (cq.l.k.b.Count != 0)
            {
                this.j(cq.l.k.b[cq.l.k.b.Count - 1].d());
            }
        }

        internal void f(int A_0)
        {
            if (this.di != null)
            {
                this.di(A_0);
            }
        }

        private void f(string A_0)
        {
        }

        internal void f(HudView A_0)
        {
            HudTabView view = A_0.get_Controls().get_Item("MainTabs") as HudTabView;
            if (view != null)
            {
                Rectangle rectangle = view.get_Item(view.get_CurrentTab()).get_SavedClipRegion();
                HudFixedLayout layout = A_0.get_Controls().ParentOf("lstExtraBuffItems") as HudFixedLayout;
                if (layout != null)
                {
                    Rectangle controlRect = layout.GetControlRect("cmdNewBuffItem");
                    layout.SetControlRect("cmdNewBuffItem", new Rectangle(controlRect.Left, rectangle.Height - (controlRect.Height + 4), controlRect.Width, controlRect.Height));
                    int height = controlRect.Height;
                    controlRect = layout.GetControlRect("cmdAddAllPeas");
                    layout.SetControlRect("cmdAddAllPeas", new Rectangle(controlRect.Left, rectangle.Height - (controlRect.Height + 4), controlRect.Width, controlRect.Height));
                    controlRect = layout.GetControlRect("cmdNewExcludedComponent");
                    layout.SetControlRect("cmdNewExcludedComponent", new Rectangle(controlRect.Left, rectangle.Height - (controlRect.Height + 4), controlRect.Width, controlRect.Height));
                    controlRect = layout.GetControlRect("lstExcludedComponents");
                    layout.SetControlRect("lstExcludedComponents", new Rectangle(controlRect.Left, controlRect.Top, controlRect.Width, rectangle.Height - ((controlRect.Top + 8) + height)));
                    controlRect = layout.GetControlRect("lstExtraBuffItems");
                    layout.SetControlRect("lstExtraBuffItems", new Rectangle(controlRect.Left, controlRect.Top, controlRect.Width, rectangle.Height - ((controlRect.Top + 8) + height)));
                }
            }
        }

        private void f(object A_0, MVControlEventArgs A_1)
        {
            try
            {
                int num = this.e();
                if (num != 0)
                {
                    this.a(num, eBuffedItemAddOptions.NoBuffs);
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void f(object A_0, EventArgs A_1)
        {
            try
            {
                if (((cq.l.k.c == eNavType.Circular) || (cq.l.k.c == eNavType.Linear)) || (cq.l.k.c == eNavType.Once))
                {
                    sCoord coord = dh.a(cq.aw.get_CharacterFilter().get_Id(), cq.ax.get_Actions());
                    this.a((ef) new d5(coord));
                }
                else if (cq.l.k.c == eNavType.Target)
                {
                    int num = cq.ax.get_Actions().get_CurrentSelection();
                    if (((num != 0) && dh.b(num)) && ((num != cg) && (base.get_Core().get_WorldFilter().get_Item(num).get_ObjectClass() == 0x18)))
                    {
                        cq.l.k.b.Clear();
                        this.bl.Clear();
                        cq.l.k.b.Add(new cg(num, cq));
                        cq.l.k.d = num;
                        cq.l.k.e = base.get_Core().get_WorldFilter().get_Item(num).get_Name();
                        this.f();
                        cq.l.g();
                    }
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void f(object A_0, int A_1, int A_2)
        {
            try
            {
                aj.c c;
                int num3;
                eDamageElement element2;
                MyList<int> list;
                int index;
                MyList<int> list2;
                int d;
                bool flag = false;
                if (A_1 == 0)
                {
                    c = cq.d.d();
                }
                else
                {
                    string str = (string) this.a2[A_1][14][0];
                    c = cq.d.c(str);
                }
                switch (A_2)
                {
                    case 0:
                        c.l = (bool) this.a2[A_1][A_2][0];
                        goto Label_0691;

                    case 1:
                        c.k = (bool) this.a2[A_1][A_2][0];
                        goto Label_0691;

                    case 2:
                        c.j = (bool) this.a2[A_1][A_2][0];
                        goto Label_0691;

                    case 3:
                        c.f = (bool) this.a2[A_1][A_2][0];
                        goto Label_0691;

                    case 4:
                        c.h = (bool) this.a2[A_1][A_2][0];
                        goto Label_0691;

                    case 5:
                        c.g = (bool) this.a2[A_1][A_2][0];
                        goto Label_0691;

                    case 6:
                        c.s = !((bool) this.a2[A_1][A_2][0]);
                        goto Label_0691;

                    case 7:
                        c.i = (bool) this.a2[A_1][A_2][0];
                        goto Label_0691;

                    case 8:
                        c.r = (bool) this.a2[A_1][A_2][0];
                        goto Label_0691;

                    case 9:
                        c.m = (bool) this.a2[A_1][A_2][0];
                        goto Label_0691;

                    case 10:
                        c.n = (bool) this.a2[A_1][A_2][0];
                        goto Label_0691;

                    case 11:
                        c.o = (bool) this.a2[A_1][A_2][0];
                        goto Label_0691;

                    case 12:
                        c.p = (bool) this.a2[A_1][A_2][0];
                        goto Label_0691;

                    case 13:
                        c.q = (bool) this.a2[A_1][A_2][0];
                        goto Label_0691;

                    case 14:
                        if (A_1 != 0)
                        {
                            cq.d.b(c.t);
                            this.a(A_1);
                            flag = true;
                        }
                        goto Label_0691;

                    case 15:
                    {
                        int num = Convert.ToInt32((string) this.a2[A_1][A_2][0]) + 1;
                        if (num == 5)
                        {
                            num = -1;
                        }
                        this.a2[A_1][A_2][0] = num.ToString();
                        c.a = num;
                        goto Label_0691;
                    }
                    case 0x10:
                    {
                        int num2 = ((int) c.b) + 1;
                        if (num2 == 14)
                        {
                            num2 = 0;
                        }
                        eDamageElement element = (eDamageElement) num2;
                        this.a2[A_1][A_2][0] = er.a(element);
                        c.b = element;
                        goto Label_0691;
                    }
                    case 0x11:
                        num3 = (int) c.c;
                        if (num3 > 5)
                        {
                            break;
                        }
                        num3++;
                        goto Label_03C8;

                    case 0x12:
                        list = cq.j.e();
                        if (!list.Contains(c.e))
                        {
                            goto Label_0429;
                        }
                        index = list.IndexOf(c.e);
                        goto Label_043A;

                    case 0x13:
                        list2 = cq.j.e();
                        if (!list2.Contains((int) c.d))
                        {
                            goto Label_0510;
                        }
                        d = list2.IndexOf((int) c.d) + 4;
                        goto Label_052F;

                    case 20:
                        flag = true;
                        if (A_1 >= 2)
                        {
                            cq.d.a(c.t, (string) this.a2[A_1 - 1][14][0]);
                            this.n();
                        }
                        goto Label_0691;

                    case 0x15:
                        flag = true;
                        if (A_1 <= (this.a2.RowCount - 2))
                        {
                            cq.d.a(c.t, (string) this.a2[A_1 + 1][14][0]);
                            this.n();
                        }
                        goto Label_0691;

                    default:
                        goto Label_0691;
                }
                if (num3 == 6)
                {
                    num3 = 0x62;
                }
                else
                {
                    num3 = 0;
                }
            Label_03C8:
                element2 = (eDamageElement) num3;
                this.a2[A_1][A_2][0] = er.a(element2);
                c.c = element2;
                goto Label_0691;
            Label_0429:
                if (c.e == 0)
                {
                    index = -1;
                }
                else
                {
                    index = -2;
                }
            Label_043A:
                index++;
                if (index >= list.Count)
                {
                    index = -2;
                }
                else if (index != -1)
                {
                    a1 a = cq.n.c(list[index]);
                    if (((a != a1.c) && (a != a1.e)) && (((a != a1.f) && (a != a1.g)) && (a != a1.b)))
                    {
                        goto Label_043A;
                    }
                }
                if (index >= 0)
                {
                    c.e = list[index];
                }
                else if (index == -1)
                {
                    c.e = 0;
                }
                else
                {
                    c.e = -1;
                }
                this.a2[A_1][A_2][0] = this.b(c.e);
                goto Label_0691;
            Label_0510:
                if ((c.d >= eSecondaryEquipTypeOrObjectID.LISTEDTYPES_END) || (c.d < eSecondaryEquipTypeOrObjectID.Auto))
                {
                    d = -1;
                }
                else
                {
                    d = (int) c.d;
                }
            Label_052F:
                d++;
                if (d >= (list2.Count + 4))
                {
                    d = 0;
                }
                else if (d >= 4)
                {
                    int num6 = list2[d - 4];
                    if (num6 == c.e)
                    {
                        goto Label_052F;
                    }
                    a1 a2 = cq.n.c(num6);
                    if (((a2 != a1.c) && (a2 != a1.d)) || (dh.a(num6) && ((cq.p.d(num6).a(dt.c1, 0) & 0x2000000) > 0)))
                    {
                        goto Label_052F;
                    }
                }
                if (d >= 4)
                {
                    c.d = list2[d - 4];
                }
                else
                {
                    c.d = (eSecondaryEquipTypeOrObjectID) d;
                }
                this.a2[A_1][A_2][0] = this.a(c.d);
            Label_0691:
                if (!flag)
                {
                    if (A_1 == 0)
                    {
                        cq.d.a(c);
                    }
                    else
                    {
                        string str2 = (string) this.a2[A_1][14][0];
                        cq.d.a(str2, c);
                    }
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
            cq.l.d();
        }

        public ReadOnlyCollection<eDamageElement> FGameInfo_QueryAutoDamageElementList(string monstername)
        {
            return cq.x.c(monstername).AsReadOnly();
        }

        public void FLootPluginClassifyCallback(int obj, delFLootPluginClassifyCallback callback)
        {
            if (cq.p.d(obj) == null)
            {
                callback(obj, LootAction.NoLoot, false);
            }
            if (cq.p.d(obj).j || !cq.ag.b(obj))
            {
                try
                {
                    callback(obj, cq.ag.a(obj), true);
                }
                catch
                {
                }
            }
            else
            {
                if (!this.dk.ContainsKey(obj))
                {
                    this.dk.Add(obj, new List<delFLootPluginClassifyCallback>());
                }
                this.dk[obj].Add(callback);
                cq.u.b(obj, new b0.b(this.a));
            }
        }

        public LootAction FLootPluginClassifyImmediate(int obj)
        {
            if (cq.p.d(obj) == null)
            {
                return LootAction.NoLoot;
            }
            if (!cq.p.d(obj).j && this.FLootPluginQueryNeedsID(obj))
            {
                return LootAction.NoLoot;
            }
            return cq.ag.a(obj);
        }

        public bool FLootPluginQueryNeedsID(int obj)
        {
            if (cq.p.d(obj) == null)
            {
                return false;
            }
            return cq.ag.b(obj);
        }

        public eDamageElement FMonsterList_QueryFinalDamageType(GameItemInfo monster)
        {
            cv cv = cq.p.d(monster.Id);
            if (cv == null)
            {
                return eDamageElement.None;
            }
            if (cv.c() != ObjectClass.Monster)
            {
                return eDamageElement.None;
            }
            return cq.n.d(cv).b;
        }

        public int FWorldTracker_CountStackedInventoryObjectsWithName(string name)
        {
            return cq.p.d(name);
        }

        public ReadOnlyCollection<GameItemInfo> FWorldTracker_GetAllInInventoryWithName(string name)
        {
            List<GameItemInfo> list = new List<GameItemInfo>();
            foreach (cv cv in cq.p.a(name))
            {
                GameItemInfo item = new GameItemInfo(cv.k);
                if (item.IsValid)
                {
                    list.Add(item);
                }
            }
            return list.AsReadOnly();
        }

        public ReadOnlyCollection<GameItemInfo> FWorldTracker_GetInContainer(int container)
        {
            List<GameItemInfo> list = new List<GameItemInfo>();
            foreach (cv cv in cq.p.e(container))
            {
                GameItemInfo item = new GameItemInfo(cv.k);
                if (item.IsValid)
                {
                    list.Add(item);
                }
            }
            return list.AsReadOnly();
        }

        public ReadOnlyCollection<GameItemInfo> FWorldTracker_GetInventory()
        {
            List<GameItemInfo> list = new List<GameItemInfo>();
            foreach (cv cv in cq.p.d())
            {
                GameItemInfo item = new GameItemInfo(cv.k);
                if (item.IsValid)
                {
                    list.Add(item);
                }
            }
            return list.AsReadOnly();
        }

        public GameItemInfo FWorldTracker_GetWithID(int gameid)
        {
            GameItemInfo info = new GameItemInfo(gameid);
            if (info.IsValid)
            {
                return info;
            }
            return null;
        }

        public ReadOnlyCollection<GameItemInfo> FWorldTracker_GetWithName(string name)
        {
            List<GameItemInfo> list = new List<GameItemInfo>();
            foreach (cv cv in cq.p.c(name))
            {
                GameItemInfo item = new GameItemInfo(cv.k);
                if (item.IsValid)
                {
                    list.Add(item);
                }
            }
            return list.AsReadOnly();
        }

        public ReadOnlyCollection<GameItemInfo> FWorldTracker_GetWithObjectClass(ObjectClass objclass)
        {
            List<GameItemInfo> list = new List<GameItemInfo>();
            foreach (cv cv in cq.p.a((ObjectClass) objclass))
            {
                GameItemInfo item = new GameItemInfo(cv.k);
                if (item.IsValid)
                {
                    list.Add(item);
                }
            }
            return list.AsReadOnly();
        }

        public GameItemInfo FWorldTracker_GetWithVendorObjectTemplateID(int gameid)
        {
            if (cq.p.u != null)
            {
                GameItemInfo info = new GameItemInfo(cq.p.u.c(gameid));
                if (info.IsValid)
                {
                    return info;
                }
            }
            return null;
        }

        private void g()
        {
            View h = this.h as View;
            if (h != null)
            {
                HudView underlying = h.Underlying;
                if (underlying != null)
                {
                    this.h(underlying);
                    this.c(underlying);
                    this.d(underlying);
                    this.g(underlying);
                    this.f(underlying);
                    this.b(underlying);
                    this.e(underlying);
                    this.a(underlying);
                }
            }
        }

        internal void g(int A_0)
        {
            try
            {
                if (cq.l.f)
                {
                    cq.n.c = A_0;
                    cq.c.TryPokeMacro();
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void g(string A_0)
        {
            cq.l.m = A_0;
            cq.l.r();
            cq.l.j();
        }

        internal void g(HudView A_0)
        {
            HudTabView view = A_0.get_Controls().get_Item("MainTabs") as HudTabView;
            if (view != null)
            {
                Rectangle rectangle = view.get_Item(view.get_CurrentTab()).get_SavedClipRegion();
                HudFixedLayout layout = A_0.get_Controls().ParentOf("lstBuffItems") as HudFixedLayout;
                if (layout != null)
                {
                    Rectangle controlRect = layout.GetControlRect("cmdNewWeapon_NoBuffs");
                    layout.SetControlRect("cmdNewWeapon_NoBuffs", new Rectangle(controlRect.Left, rectangle.Height - (controlRect.Height + 4), controlRect.Width, controlRect.Height));
                    int height = controlRect.Height;
                    controlRect = layout.GetControlRect("cmdNewWeapon");
                    layout.SetControlRect("cmdNewWeapon", new Rectangle(controlRect.Left, rectangle.Height - (controlRect.Height + 4), controlRect.Width, controlRect.Height));
                    controlRect = layout.GetControlRect("lstBuffItems");
                    layout.SetControlRect("lstBuffItems", new Rectangle(controlRect.Left, controlRect.Top, controlRect.Width, rectangle.Height - ((controlRect.Top + 8) + height)));
                }
            }
        }

        private void g(object A_0, MVControlEventArgs A_1)
        {
            try
            {
                if ((cq.l.k.c != eNavType.Target) && (cq.l.k.c != eNavType.Once))
                {
                    cq.n.c();
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void g(object A_0, EventArgs A_1)
        {
            try
            {
                if (cq.l.k.c != eNavType.Target)
                {
                    string str = "";
                    switch (this.br.Selected)
                    {
                        case 0:
                            str = "Primary Portal Recall";
                            break;

                        case 1:
                            str = "Secondary Portal Recall";
                            break;

                        case 2:
                            str = "Lifestone Recall";
                            break;

                        case 3:
                            str = "Lifestone Sending";
                            break;

                        case 4:
                            str = "Portal Recall";
                            break;

                        case 5:
                            str = "Recall Aphus Lassel";
                            break;

                        case 6:
                            str = "Recall the Sanctuary";
                            break;

                        case 7:
                            str = "Recall to the Singularity Caul";
                            break;

                        case 8:
                            str = "Glenden Wood Recall";
                            break;

                        case 9:
                            str = "Aerlinthe Recall";
                            break;

                        case 10:
                            str = "Mount Lethe Recall";
                            break;

                        case 11:
                            str = "Ulgrim's Recall";
                            break;

                        case 12:
                            str = "Bur Recall";
                            break;

                        case 13:
                            str = "Paradox-touched Olthoi Infested Area Recall";
                            break;

                        case 14:
                            str = "Call of the Mhoire Forge";
                            break;

                        case 15:
                            str = "Colosseum Recall";
                            break;

                        case 0x10:
                            str = "Facility Hub Recall";
                            break;

                        case 0x11:
                            str = "Gear Knight Invasion Area Camp Recall";
                            break;

                        case 0x12:
                            str = "Lost City of Neftet Recall";
                            break;

                        case 0x13:
                            str = "Return to the Keep";
                            break;

                        case 20:
                            str = "Facility Hub Recall";
                            break;

                        case 0x15:
                            str = "Rynthid Recall";
                            break;
                    }
                    int id = cq.e.a(str).Id;
                    sCoord coord = dh.a(cq.aw.get_CharacterFilter().get_Id(), cq.ax.get_Actions());
                    this.a((ef) new fd(coord, id));
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void g(object A_0, int A_1, int A_2)
        {
            switch (A_2)
            {
                case 0:
                {
                    int num = this.c1[A_1];
                    this.c1.RemoveAt(A_1);
                    this.t.RemoveRow(A_1);
                    cq.j.c(num);
                    v v = cq.l.c["ItemUseSpecifiers"].a(0, k.a(num));
                    if (v != null)
                    {
                        cq.l.c["ItemUseSpecifiers"].b(v);
                    }
                    this.n();
                    break;
                }
                case 1:
                    if (!string.IsNullOrEmpty((string) this.t[A_1][1][0]))
                    {
                        int num2 = this.c1[A_1];
                        int num3 = ey.a((int) cq.n.e(num2), typeof(eItemUseSpecifier), "WEAP_");
                        v v2 = cq.l.c["ItemUseSpecifiers"].a(0, k.a(num2));
                        if (v2 == null)
                        {
                            v2 = new v(cq.l.c["ItemUseSpecifiers"]);
                            v2[0] = k.a(num2);
                            cq.l.c["ItemUseSpecifiers"].c(v2);
                        }
                        v2[1] = k.a(num3);
                        this.t[A_1][1][0] = ey.a(num3, typeof(eItemUseSpecifier));
                    }
                    break;
            }
            cq.l.d();
            this.av();
        }

        public cExternalInterfaceTrustedRelay GetExternalInterface()
        {
            return null;
        }

        public cExternalInterfaceTrustedRelay GetExternalInterface(string CallerAssemblySignature, string AssemblyKey)
        {
            if (!this.c6.ContainsKey(AssemblyKey))
            {
                e("GetExternalInterface: Key invalid.");
                return new cExternalInterfaceTrustedRelay(eExternalsPermissionLevel.None);
            }
            if (this.a(Assembly.GetCallingAssembly(), CallerAssemblySignature, AssemblyKey))
            {
                cExternalInterfaceTrustedRelay item = new cExternalInterfaceTrustedRelay(this.c6[AssemblyKey]);
                this.c5.Add(item);
                return item;
            }
            e("GetExternalInterface: Signature invalid. S: " + CallerAssemblySignature);
            e("GetExternalInterface: Signature invalid. K: " + AssemblyKey);
            return new cExternalInterfaceTrustedRelay(eExternalsPermissionLevel.None);
        }

        [DllImport("kernel32.dll")]
        private static extern int GetModuleHandle(string A_0);
        private void h()
        {
            View h = this.h as View;
            if (h != null)
            {
                HudView underlying = h.Underlying;
                if (underlying != null)
                {
                    underlying.set_UserResizeable(true);
                    underlying.set_MinimumClientArea(new Size(this.j, this.k));
                    underlying.set_MaximumClientArea(new Size(this.j, 0x270f));
                    underlying.LoadUserSettings();
                    underlying.add_Resize(new EventHandler(this.ao));
                    HudControl control = underlying.get_Controls().get_Item("lstMonsters");
                    if (control != null)
                    {
                        foreach (HudControl control2 in underlying.get_Controls().ChildrenOf(control))
                        {
                            HudVScrollBar bar = control2 as HudVScrollBar;
                            if (bar != null)
                            {
                                bar.add_Changed(new LinearPositionControl.delScrollChanged(this, (IntPtr) this.a));
                                break;
                            }
                        }
                    }
                    this.ao(null, null);
                }
            }
        }

        internal void h(int A_0)
        {
            WorldObject obj2 = base.get_Core().get_WorldFilter().get_Item(A_0);
            cq.x.b(A_0);
            int num = 0;
            if (obj2.get_SpellCount() != 0)
            {
                num = 1;
            }
            fz a = fz.a;
            bool flag = obj2.get_ObjectClass() == 0x1d;
            switch (obj2.Values(0x59, 0))
            {
                case 2:
                    num = 2;
                    a = fz.b;
                    break;

                case 4:
                    num = 2;
                    a = fz.d;
                    break;

                case 6:
                    num = 2;
                    a = fz.f;
                    break;
            }
            if (flag)
            {
                num = 2;
                string key = obj2.get_Name();
                if (key != null)
                {
                    int num3;
                    if (bx.a == null)
                    {
                        Dictionary<string, int> dictionary1 = new Dictionary<string, int>(8);
                        dictionary1.Add("Medicated Stamina Kit", 0);
                        dictionary1.Add("Medicated Mana Kit", 1);
                        dictionary1.Add("Eternal Stamina Kit", 2);
                        dictionary1.Add("Eternal Mana Kit", 3);
                        dictionary1.Add("Greater Stamina Kit", 4);
                        dictionary1.Add("Greater Mana Kit", 5);
                        dictionary1.Add("Lesser Stamina Kit", 6);
                        dictionary1.Add("Lesser Mana Kit", 7);
                        bx.a = dictionary1;
                    }
                    if (bx.a.TryGetValue(key, out num3))
                    {
                        switch (num3)
                        {
                            case 0:
                                a = fz.c;
                                goto Label_015E;

                            case 1:
                                a = fz.e;
                                goto Label_015E;

                            case 2:
                                a = fz.c;
                                goto Label_015E;

                            case 3:
                                a = fz.e;
                                goto Label_015E;

                            case 4:
                                a = fz.c;
                                goto Label_015E;

                            case 5:
                                a = fz.e;
                                goto Label_015E;

                            case 6:
                                a = fz.c;
                                goto Label_015E;

                            case 7:
                                a = fz.e;
                                goto Label_015E;
                        }
                    }
                }
                a = fz.a;
            }
        Label_015E:
            if (obj2.get_ObjectClass() == 0x10)
            {
                num = 3;
                a = fz.g;
            }
            if (obj2.get_ObjectClass() == 12)
            {
                num = 4;
            }
            if (obj2.get_ObjectClass() == 30)
            {
                num = 5;
            }
            if (cq.l.g.ContainsKey(obj2.get_Name()))
            {
                return;
            }
            if (cq.l.h.ContainsKey(obj2.get_Name()))
            {
                return;
            }
            if (((obj2.get_ObjectClass() == 6) || (obj2.get_ObjectClass() == 11)) || ((obj2.get_ObjectClass() == 0x1d) || (obj2.get_ObjectClass() == 0x10)))
            {
                switch (num)
                {
                    case 0:
                        return;

                    case 1:
                    {
                        MySpell spell = cq.e.b(obj2.Spell(0));
                        if (spell.School.SkillId == 0x20)
                        {
                            return;
                        }
                        if (spell.Duration < 300.0)
                        {
                            return;
                        }
                        cq.l.g.Add(obj2.get_Name(), spell);
                        this.n.AddRow()[0][0] = obj2.get_Name();
                        this.c2.Add(obj2.get_Name());
                        goto Label_04A1;
                    }
                    case 2:
                        cq.l.h.Add(obj2.get_Name(), a);
                        this.n.AddRow()[0][0] = obj2.get_Name();
                        this.c2.Add(obj2.get_Name());
                        goto Label_04A1;
                }
                if (num == 3)
                {
                    if (obj2.Values(0x89, 0.0) != 1.0)
                    {
                        cq.l.h.Add(obj2.get_Name(), fz.i);
                    }
                    else
                    {
                        if (obj2.Values(0x6c, -1) > 0)
                        {
                            return;
                        }
                        if (obj2.Values(0x6b, 0) <= 0)
                        {
                            return;
                        }
                        cq.l.h.Add(obj2.get_Name(), fz.g);
                    }
                    this.n.AddRow()[0][0] = obj2.get_Name();
                    this.c2.Add(obj2.get_Name());
                }
            }
            else if (fn.d(obj2))
            {
                cq.l.h.Add(obj2.get_Name(), fz.h);
                this.n.AddRow()[0][0] = obj2.get_Name();
                this.c2.Add(obj2.get_Name());
            }
            else if (num == 4)
            {
                if (obj2.get_Name().EndsWith(" Pea"))
                {
                    return;
                }
                cq.l.h.Add(obj2.get_Name(), fz.j);
                this.n.AddRow()[0][0] = obj2.get_Name();
                this.c2.Add(obj2.get_Name());
            }
            else if (num == 5)
            {
                cq.l.h.Add(obj2.get_Name(), fz.k);
                this.n.AddRow()[0][0] = obj2.get_Name();
                this.c2.Add(obj2.get_Name());
            }
            else
            {
                return;
            }
        Label_04A1:
            cq.l.d();
        }

        internal string h(string A_0)
        {
            string[] strArray = A_0.Split(new char[] { '\\' });
            string str = strArray[strArray.Length - 1];
            if ((str.Length >= 2) && (str.Substring(0, 2) != "--"))
            {
                if (!this.au.Checked || (str == cq.l.m))
                {
                    return str;
                }
            }
            else if ((str.Length >= this.co.Length) && (str.Substring(0, this.co.Length) == this.co))
            {
                string[] strArray2 = str.Substring(this.co.Length).Split(new char[] { '.' });
                StringBuilder builder = new StringBuilder();
                builder.Append("[Char] ");
                for (int i = 0; i < (strArray2.Length - 1); i++)
                {
                    if (i > 0)
                    {
                        builder.Append('.');
                    }
                    builder.Append(strArray2[i]);
                }
                return builder.ToString();
            }
            if (A_0 == cq.l.o)
            {
                return "[By char]";
            }
            if (A_0 == "")
            {
                return "[Default]";
            }
            return "???";
        }

        internal void h(HudView A_0)
        {
        }

        private void h(object A_0, MVControlEventArgs A_1)
        {
            try
            {
                if ((cq.l.k.c != eNavType.Target) && (cq.l.k.c != eNavType.Once))
                {
                    cq.n.l++;
                    if (cq.n.l >= cq.l.k.b.Count)
                    {
                        cq.n.l = cq.l.k.b.Count - 1;
                    }
                    this.ao();
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void h(object A_0, EventArgs A_1)
        {
            try
            {
                if (base.get_Core().get_HotkeySystem() == null)
                {
                    cm = false;
                }
                else
                {
                    cm = true;
                }
                this.cn = cy.b();
                if (cm && this.cn)
                {
                    cm = false;
                }
                this.au.Checked = true;
                this.aw.Checked = false;
                this.u.Checked = false;
                StringBuilder builder = new StringBuilder();
                Version version = Assembly.GetExecutingAssembly().GetName(false).Version;
                builder.Append("Virindi Tank v.");
                builder.Append(version.ToString());
                if (version.Revision == 0)
                {
                    builder.Append(" (Stable release)");
                }
                else
                {
                    builder.Append(" (Bundle release)");
                }
                builder.Append(" by Virindi Inquisitor of Thistledown.");
                a5.a(eChatType.CommandLine, builder.ToString());
                a5.a(eChatType.Warnings, @"For help on using this plugin, please see the <Tell:IIDString:0:VI2:openurl:http://www.virindi.net/wiki/index.php/Virindi_Plugins_FAQ>Virindi Plugins FAQ<\Tell>.");
                cq.l.o = "--" + cq.aw.get_CharacterFilter().get_Name() + "_" + cq.aw.get_CharacterFilter().get_Server() + ".usd";
                cq.l.p = "--" + cq.aw.get_CharacterFilter().get_Name() + "_" + cq.aw.get_CharacterFilter().get_Server() + ".nav";
                cq.l.q = "--" + cq.aw.get_CharacterFilter().get_Name() + "_" + cq.aw.get_CharacterFilter().get_Server() + ".met";
                this.co = "--" + cq.aw.get_CharacterFilter().get_Name() + "_" + cq.aw.get_CharacterFilter().get_Server() + "_";
                cq.ag.g();
                cq.i.e();
                this.cp.a("http://auth.virindi.net/plugins/latest.php", new ea.b(this.a));
                cg = base.get_Core().get_CharacterFilter().get_Id();
                cq.av = new ek(base.get_Core(), base.get_Host(), cg);
                cq.az.Add(cq.av);
                this.aj();
                cq.x.d();
                this.cl = true;
                cq.l.e();
                cq.l.h();
                if (cm)
                {
                    this.b();
                }
                if (this.cn)
                {
                    this.d();
                }
                e1.e();
                if (this.cr != null)
                {
                    this.cr();
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void h(object A_0, int A_1, int A_2)
        {
            try
            {
                if (cq.l.k.c == eNavType.Target)
                {
                    this.bl.RemoveRow(A_1);
                    cq.l.k.b.RemoveAt(A_1);
                    cq.l.k.e = "";
                    cq.l.k.d = 0;
                }
                else
                {
                    this.bl.RemoveRow(A_1);
                    cq.l.k.b.RemoveAt(A_1);
                    cq.n.c();
                }
                cq.l.g();
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void i()
        {
            this.l = true;
            this.az.Clear();
            this.az.Add("[None]");
            string q = cq.l.q;
            this.az.Add("[By char]");
            string[] files = Directory.GetFiles(ci, "*.met");
            Array.Sort<string>(files);
            foreach (string str2 in files)
            {
                string[] strArray2 = str2.Split(new char[] { '\\' });
                string text = strArray2[strArray2.Length - 1];
                if ((text != q) && (text.Substring(0, 2) != "--"))
                {
                    this.az.Add(text);
                }
            }
            if (string.IsNullOrEmpty(cq.@as.j()))
            {
                this.az.Selected = 0;
            }
            else if (cq.@as.j() == q)
            {
                this.az.Selected = 1;
            }
            else
            {
                for (int i = 0; i < this.az.Count; i++)
                {
                    if (this.az.Text[i] == cq.@as.j())
                    {
                        this.az.Selected = i;
                        break;
                    }
                }
            }
            this.l = false;
        }

        internal void i(int A_0)
        {
            cq.l.k.a(A_0);
            this.ao();
        }

        internal void i(string A_0)
        {
            cq.l.l = A_0;
            cq.l.r();
            cq.l.l();
        }

        private void i(object A_0, MVControlEventArgs A_1)
        {
            try
            {
                if ((cq.l.k.c != eNavType.Target) && (cq.l.k.c != eNavType.Once))
                {
                    cq.n.l--;
                    if (cq.n.l < 0)
                    {
                        cq.n.l = 0;
                    }
                    this.ao();
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void i(object A_0, EventArgs A_1)
        {
            try
            {
                if (!this.l)
                {
                    if (this.aq.Text[this.aq.Selected] == "[Default]")
                    {
                        cq.l.m = "";
                    }
                    else if (this.aq.Text[this.aq.Selected] == "[By char]")
                    {
                        cq.l.m = cq.l.o;
                    }
                    else if ((this.aq.Text[this.aq.Selected].Length >= 7) && (this.aq.Text[this.aq.Selected].Substring(0, 7) == "[Char] "))
                    {
                        cq.l.m = this.co + this.aq.Text[this.aq.Selected].Substring(7) + ".usd";
                    }
                    else
                    {
                        cq.l.m = this.aq.Text[this.aq.Selected];
                    }
                    cq.l.r();
                    cq.l.j();
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal int j()
        {
            return cq.l.k.d;
        }

        internal sWaypointDesc j(int A_0)
        {
            int num = A_0;
            if (num < 0)
            {
                num = 0;
            }
            if (num >= cq.l.k.b.Count)
            {
                num = cq.l.k.b.Count - 1;
            }
            return new sWaypointDesc { type = cq.l.k.b[num].a(), loc = cq.l.k.b[num].e(), bonus = cq.l.k.b[num].b() };
        }

        internal void j(string A_0)
        {
            if (!string.IsNullOrEmpty(A_0))
            {
                IListRow row = this.bl.AddRow();
                row[0][0] = "(" + this.bl.RowCount.ToString() + ") " + A_0;
                if ((this.bl.RowCount - 1) == cq.n.l)
                {
                    row[1][0] = "<<";
                }
            }
        }

        private void j(object A_0, MVControlEventArgs A_1)
        {
            try
            {
                if (cq.l.k.c != eNavType.Target)
                {
                    double result = 0.0;
                    double.TryParse(this.bt.Text, out result);
                    this.bt.Text = result.ToString();
                    int num2 = (int) (result * 1000.0);
                    this.a((ef) new i(sCoord.NoWhere, num2));
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void j(object A_0, EventArgs A_1)
        {
            try
            {
                this.aa();
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void k()
        {
        }

        internal void k(int A_0)
        {
            if (cq.k.j.ContainsKey(A_0))
            {
                cq.k.j.Remove(A_0);
            }
        }

        internal bool k(string A_0)
        {
            if (cg == 0)
            {
                return false;
            }
            bool flag = false;
            if (!A_0.StartsWith("/") && !A_0.StartsWith("@"))
            {
                return flag;
            }
            string str = A_0.TrimStart(new char[] { '@', '/' });
            if (!str.StartsWith("vt "))
            {
                return flag;
            }
            str = str.Substring(3);
            if (str.CompareTo("help") == 0)
            {
                e("/vt commands (profiles): settings nav loot meta opt testitem propertydump addnavpt refresh getdb");
                e("/vt commands (actions): start stop forcebuff cancelforcebuff setmetastate fakedeath deletemonster");
                e("/vt commands (game info): dumpspells dumpspecies dumpmats dumpskills");
                e("/vt commands (debug): log testmonster lockdump dumptracker clearlocks clearbusy");
                return true;
            }
            if (str.CompareTo("testmonster") == 0)
            {
                cv cv = cq.p.d(base.get_Host().get_Actions().get_CurrentSelection());
                if ((cv == null) || (cv.c() != ObjectClass.Monster))
                {
                    e("TestMonster: No monster selected.");
                    return flag;
                }
                e(string.Format("TestMonster: evaluating monster rules for monster {0}, type {1}", cv.g(), cv.a(dt.cn, 0)));
                cq.d.b(cv);
                c c = new c();
                e("Target initialization result: " + c.a(cv, er.h("AttackDistance"), er.h("AttackMinimumDistance"), er.j("TargetLock")).ToString() + ", allowedtarget: " + c.m.ToString());
                return flag;
            }
            if (str.StartsWith("testspell"))
            {
                string[] strArray = str.Split(new char[] { ' ' });
                if (strArray.Length == 2)
                {
                    int num;
                    if (!int.TryParse(strArray[1], out num))
                    {
                        e("Usage: /vt testspell [spellid]");
                        return flag;
                    }
                    if (!cq.e.c.ContainsKey(num))
                    {
                        e("Invalid spellid.");
                        return flag;
                    }
                    MySpell spell = cq.e.b(num);
                    e("Testing ability to cast spell " + spell.Name + ", translated family " + spell.RealFamily.ToString() + ", translated quality " + spell.Quality.ToString());
                    e("Buffing threshold mod " + cq.l.a(false).ToString());
                    e("Castable: " + cq.h.b(spell, false).ToString());
                    e("Check result: " + cq.h.a.ToString());
                    e("Hunting threshold mod " + cq.l.a(true).ToString());
                    e("Castable: " + cq.h.b(spell, true).ToString());
                    e("Check result: " + cq.h.a.ToString());
                    return flag;
                }
                e("Usage: /vt testspell [spellid]");
                return flag;
            }
            if (str.CompareTo("lockdump") == 0)
            {
                e("Unstoppably busy: " + cq.n.k.ToString());
                e("Action locks:");
                foreach (KeyValuePair<ActionLockType, DateTimeOffset> pair in cq.n.n.b())
                {
                    string[] strArray10 = new string[] { pair.Key.ToString(), ": ", pair.Value.ToLocalTime().DateTime.ToLongTimeString(), " ... ", (pair.Value > DateTimeOffset.Now).ToString() };
                    e(string.Concat(strArray10));
                }
                return flag;
            }
            if (str.CompareTo("clearlocks") == 0)
            {
                cq.n.n.b().Clear();
                return flag;
            }
            if (str.CompareTo("clearbusy") == 0)
            {
                cq.n.k = false;
                return flag;
            }
            if (str.CompareTo("testitem") == 0)
            {
                if (!dh.b(base.get_Host().get_Actions().get_CurrentSelection()))
                {
                    e("TestItem: No item selected.");
                }
                else if (base.get_Core().get_WorldFilter().get_Item(base.get_Host().get_Actions().get_CurrentSelection()).get_HasIdData() || !cq.ag.b(base.get_Host().get_Actions().get_CurrentSelection()))
                {
                    this.b(base.get_Host().get_Actions().get_CurrentSelection(), true);
                }
                else
                {
                    cq.u.b(base.get_Host().get_Actions().get_CurrentSelection(), new b0.b(this.b));
                }
                return true;
            }
            if (str.CompareTo("refresh") == 0)
            {
                er.a();
                this.ao();
                e("Refreshed settings pages.");
                return true;
            }
            if (str.CompareTo("activespells") == 0)
            {
                e("Active character spells list:");
                using (IEnumerator<KeyValuePair<int, ActiveSpellInfo>> enumerator2 = cq.a.d())
                {
                    while (enumerator2.MoveNext())
                    {
                        KeyValuePair<int, ActiveSpellInfo> current = enumerator2.Current;
                        e(current.Value.ToString());
                    }
                }
                return true;
            }
            if (str.CompareTo("test") == 0)
            {
                cq.p.d(base.get_Host().get_Actions().get_CurrentSelection());
                return true;
            }
            if (str.CompareTo("dumpspells") == 0)
            {
                StreamWriter writer = new StreamWriter(@"c:\spelldump.txt");
                try
                {
                    using (IEnumerator enumerator3 = cq.e.c())
                    {
                        while (enumerator3.MoveNext())
                        {
                            MySpell spell2 = (MySpell) enumerator3.Current;
                            writer.Write(spell2.Id);
                            writer.Write("\t");
                            writer.Write(spell2.Name);
                            writer.Write("\t");
                            writer.Write(spell2.Family);
                            writer.Write("\t");
                            writer.Write(spell2.RealFamily);
                            writer.Write("\t");
                            writer.Write(spell2.Saying);
                            writer.Write("\t");
                            writer.Write(spell2.Duration);
                            writer.Write("\t");
                            writer.Write(spell2.Difficulty);
                            writer.Write("\t");
                            writer.Write(spell2.isFellowship);
                            writer.Write("\t");
                            writer.Write(spell2.isOffensive);
                            writer.Write("\t");
                            writer.Write(spell2.isUntargetted);
                            writer.WriteLine();
                        }
                    }
                    e("Spelltable dump complete.");
                }
                finally
                {
                    writer.Close();
                }
                return true;
            }
            if (str.CompareTo("dumpspecies") == 0)
            {
                StreamWriter writer2 = new StreamWriter(@"c:\speciesdump.txt");
                try
                {
                    FileService service = base.get_Core().get_FileService();
                    for (int i = 0; i < service.get_SpeciesTable().get_Length(); i++)
                    {
                        writer2.Write(service.get_SpeciesTable().get_Item(i).get_Id());
                        writer2.Write("\t");
                        writer2.Write(service.get_SpeciesTable().get_Item(i).get_Name());
                        writer2.WriteLine();
                    }
                }
                finally
                {
                    writer2.Close();
                }
                return true;
            }
            if (str.CompareTo("dumpmats") == 0)
            {
                StreamWriter writer3 = new StreamWriter(@"c:\matdump.txt");
                try
                {
                    FileService service2 = base.get_Core().get_FileService();
                    for (int j = 0; j < service2.get_MaterialTable().get_Length(); j++)
                    {
                        writer3.Write(service2.get_MaterialTable().get_Item(j).get_Id());
                        writer3.Write("\t");
                        writer3.Write(service2.get_MaterialTable().get_Item(j).get_Name());
                        writer3.WriteLine();
                    }
                }
                finally
                {
                    writer3.Close();
                }
                return true;
            }
            if (str.CompareTo("dumpskills") == 0)
            {
                StreamWriter writer4 = new StreamWriter(@"c:\skilldump.txt");
                try
                {
                    FileService service3 = CoreManager.get_Current().get_FileService() as FileService;
                    SkillInfo o = null;
                    for (int m = 0; m < service3.get_SkillTable().get_Length(); m++)
                    {
                        try
                        {
                            writer4.Write(service3.get_SkillTable().get_Item(m).get_Id());
                            writer4.Write("\t");
                            writer4.Write(service3.get_SkillTable().get_Item(m).get_Name());
                            writer4.Write("\t");
                            writer4.Write(service3.get_SkillTable().get_Item(m).get_CreditsToTrain());
                            writer4.Write("\t");
                            writer4.Write(service3.get_SkillTable().get_Item(m).get_CreditsToSpecialize());
                            writer4.Write("\t");
                            writer4.Write(service3.get_SkillTable().get_Item(m).get_Description());
                            writer4.Write("\t");
                            writer4.Write(service3.get_SkillTable().get_Item(m).get_Attribute1Id());
                            writer4.Write("\t");
                            writer4.Write(service3.get_SkillTable().get_Item(m).get_Attribute2Id());
                            writer4.Write("\t");
                            writer4.Write(service3.get_SkillTable().get_Item(m).get_AttributeDivisor());
                            writer4.WriteLine();
                        }
                        finally
                        {
                            if (o != null)
                            {
                                Marshal.ReleaseComObject(o);
                            }
                        }
                    }
                }
                finally
                {
                    writer4.Close();
                }
                return true;
            }
            if (str.CompareTo("dumptracker") == 0)
            {
                using (StreamWriter writer5 = new StreamWriter(@"c:\trackerdump.txt"))
                {
                    writer5.WriteLine("Dump at {0}, object count {1}", DateTimeOffset.Now, cq.p.i.Count);
                    foreach (KeyValuePair<int, cv> pair3 in cq.p.i)
                    {
                        writer5.WriteLine(pair3.Value.ToString());
                    }
                    writer5.WriteLine();
                    writer5.WriteLine("***************************************************");
                    writer5.WriteLine("******************PROPERTY DUMPS*******************");
                    writer5.WriteLine("***************************************************");
                    writer5.WriteLine();
                    foreach (KeyValuePair<int, cv> pair4 in cq.p.i)
                    {
                        foreach (string str2 in this.b(pair4.Value))
                        {
                            writer5.WriteLine(str2);
                        }
                    }
                }
                return true;
            }
            if (str.CompareTo("deletemonster") == 0)
            {
                bool flag2 = false;
                if (cq.p.i.ContainsKey(base.get_Host().get_Actions().get_CurrentSelection()))
                {
                    cv cv3 = cq.p.i[base.get_Host().get_Actions().get_CurrentSelection()];
                    if (cv3.c() == ObjectClass.Monster)
                    {
                        e("Forcing the client to delete " + cv3.g() + " (" + cv3.k.ToString() + ")!!");
                        dh.d(cv3.k);
                        flag2 = true;
                    }
                }
                if (!flag2)
                {
                    e("Select a monster, then do /vt deletemonster");
                }
                return true;
            }
            if (str.CompareTo("dumpskills") == 0)
            {
                StreamWriter writer6 = new StreamWriter(@"c:\skilldump.txt");
                try
                {
                    FileService service4 = base.get_Core().get_FileService();
                    for (int n = 0; n < service4.get_SkillTable().get_Length(); n++)
                    {
                        writer6.Write(service4.get_SkillTable().get_Item(n).get_Id());
                        writer6.Write("\t");
                        writer6.Write(service4.get_SkillTable().get_Item(n).get_Name());
                        writer6.Write("\t");
                        writer6.Write(service4.get_SkillTable().get_Item(n).get_Description());
                        writer6.Write("\t");
                        writer6.Write(service4.get_SkillTable().get_Item(n).get_CreditsToTrain());
                        writer6.Write("\t");
                        writer6.Write(service4.get_SkillTable().get_Item(n).get_CreditsToSpecialize());
                        writer6.Write("\t");
                        writer6.Write(service4.get_SkillTable().get_Item(n).get_Attribute1Id());
                        writer6.Write("\t");
                        writer6.Write(service4.get_SkillTable().get_Item(n).get_Attribute2Id());
                        writer6.Write("\t");
                        writer6.Write(service4.get_SkillTable().get_Item(n).get_AttributeDivisor());
                        writer6.WriteLine();
                    }
                }
                finally
                {
                    writer6.Close();
                }
                return true;
            }
            if (!str.StartsWith("opt"))
            {
                if (str.CompareTo("getdb") == 0)
                {
                    cq.x.d();
                    return true;
                }
                if (str.CompareTo("obtest") == 0)
                {
                    e("Test value: " + cw.a.ToString());
                    return true;
                }
                if (str.StartsWith("nav"))
                {
                    flag = true;
                    string[] strArray3 = str.Split(new char[] { ' ' });
                    if (strArray3.Length >= 3)
                    {
                        int num7 = 0;
                        if (strArray3[1].Equals("save", StringComparison.OrdinalIgnoreCase))
                        {
                            num7 = 1;
                        }
                        if (strArray3[1].Equals("load", StringComparison.OrdinalIgnoreCase))
                        {
                            num7 = 2;
                        }
                        switch (num7)
                        {
                            case 0:
                                e("Usage: /vt nav [save/load] [filename]");
                                return flag;

                            case 1:
                                cq.l.n = string.Join(" ", strArray3, 2, strArray3.Length - 2) + ".nav";
                                cq.l.p();
                                cq.l.r();
                                return flag;

                            case 2:
                                cq.l.n = string.Join(" ", strArray3, 2, strArray3.Length - 2) + ".nav";
                                cq.l.k();
                                cq.l.r();
                                return flag;
                        }
                        return flag;
                    }
                    e("Usage: /vt nav [save/load] [filename]");
                    return flag;
                }
                if (str.StartsWith("settings"))
                {
                    flag = true;
                    string[] strArray4 = str.Split(new char[] { ' ' });
                    if (strArray4.Length >= 3)
                    {
                        int num8 = 0;
                        if (strArray4[1].Equals("save", StringComparison.OrdinalIgnoreCase))
                        {
                            num8 = 1;
                        }
                        if (strArray4[1].Equals("load", StringComparison.OrdinalIgnoreCase))
                        {
                            num8 = 2;
                        }
                        if (strArray4[1].Equals("savechar", StringComparison.OrdinalIgnoreCase))
                        {
                            num8 = 3;
                        }
                        if (strArray4[1].Equals("loadchar", StringComparison.OrdinalIgnoreCase))
                        {
                            num8 = 4;
                        }
                        switch (num8)
                        {
                            case 0:
                                e("Usage: /vt settings [save/load/savechar/loadchar] [filename]");
                                return flag;

                            case 1:
                                cq.l.m = string.Join(" ", strArray4, 2, strArray4.Length - 2) + ".usd";
                                cq.l.n();
                                cq.l.r();
                                return flag;

                            case 2:
                                cq.l.m = string.Join(" ", strArray4, 2, strArray4.Length - 2) + ".usd";
                                cq.l.j();
                                cq.l.r();
                                return flag;

                            case 3:
                                cq.l.m = this.co + string.Join(" ", strArray4, 2, strArray4.Length - 2) + ".usd";
                                cq.l.n();
                                cq.l.r();
                                return flag;

                            case 4:
                                cq.l.m = this.co + string.Join(" ", strArray4, 2, strArray4.Length - 2) + ".usd";
                                cq.l.j();
                                cq.l.r();
                                return flag;
                        }
                        return flag;
                    }
                    e("Usage: /vt settings [save/load/savechar/loadchar] [filename]");
                    return flag;
                }
                if (str.StartsWith("loot"))
                {
                    flag = true;
                    string[] strArray5 = str.Split(new char[] { ' ' });
                    if (strArray5.Length < 3)
                    {
                        e("Usage: /vt nav [save/load] [filename]");
                        return flag;
                    }
                    int num9 = 0;
                    if (strArray5[1].Equals("load", StringComparison.OrdinalIgnoreCase))
                    {
                        num9 = 2;
                    }
                    if (strArray5[1].Equals("new", StringComparison.OrdinalIgnoreCase))
                    {
                        num9 = 3;
                    }
                    switch (num9)
                    {
                        case 0:
                            e("Usage: /vt loot new [filename]");
                            return flag;

                        case 1:
                            return flag;

                        case 2:
                        case 3:
                        {
                            string str4 = string.Join(" ", strArray5, 2, strArray5.Length - 2);
                            if (!str4.Contains(@"\"))
                            {
                                string[] strArray6 = str4.Split(new char[] { '.' });
                                if ((strArray6.Length == 1) || !cq.ag.a(strArray6[strArray6.Length - 1]))
                                {
                                    e("Invalid file extension (." + strArray6[strArray6.Length - 1] + "). Active loot plugins are:");
                                    cq.ag.e();
                                    return flag;
                                }
                                cq.l.l = str4;
                                cq.l.l();
                                cq.l.r();
                                return flag;
                            }
                            e("Filename contains invalid characters.");
                            return true;
                        }
                    }
                    return flag;
                }
                if (str.StartsWith("meta"))
                {
                    flag = true;
                    string[] strArray7 = str.Split(new char[] { ' ' });
                    if (strArray7.Length >= 3)
                    {
                        int num10 = 0;
                        if (strArray7[1].Equals("save", StringComparison.OrdinalIgnoreCase))
                        {
                            num10 = 1;
                        }
                        if (strArray7[1].Equals("load", StringComparison.OrdinalIgnoreCase))
                        {
                            num10 = 2;
                        }
                        switch (num10)
                        {
                            case 0:
                                e("Usage: /vt meta [save/load] [filename]");
                                return flag;

                            case 1:
                                cq.@as.d(string.Join(" ", strArray7, 2, strArray7.Length - 2) + ".met");
                                cq.@as.k();
                                this.y();
                                cq.l.r();
                                return flag;

                            case 2:
                                cq.@as.e(string.Join(" ", strArray7, 2, strArray7.Length - 2) + ".met");
                                this.y();
                                cq.l.r();
                                return flag;
                        }
                        return flag;
                    }
                    e("Usage: /vt meta [save/load] [filename]");
                    return flag;
                }
                if (!str.StartsWith("log"))
                {
                    if (str.StartsWith("explain "))
                    {
                        ak.a(str.Substring(8));
                        return true;
                    }
                    if (str.StartsWith("debugon"))
                    {
                        e("Refcounting is disabled.");
                        return true;
                    }
                    if (str.StartsWith("debugdump"))
                    {
                        e("Refcounting is disabled.");
                        return true;
                    }
                    if (str.StartsWith("skillvalues"))
                    {
                        FileService service5 = CoreManager.get_Current().get_FileService() as FileService;
                        SkillInfo info2 = null;
                        for (int num11 = 0; num11 < service5.get_SkillTable().get_Length(); num11++)
                        {
                            try
                            {
                                info2 = cq.aw.get_CharacterFilter().get_Underlying().get_Skill((eSkillID) service5.get_SkillTable().get_Item(num11).get_Id());
                                e(info2.get_Name() + ", buffed " + info2.get_Buffed().ToString());
                            }
                            finally
                            {
                                if (info2 != null)
                                {
                                    Marshal.ReleaseComObject(info2);
                                    info2 = null;
                                }
                            }
                        }
                        return true;
                    }
                    if (str.StartsWith("propertydump"))
                    {
                        if (cq.p.i.ContainsKey(base.get_Host().get_Actions().get_CurrentSelection()))
                        {
                            cv cv4 = cq.p.i[base.get_Host().get_Actions().get_CurrentSelection()];
                            foreach (string str6 in this.b(cv4))
                            {
                                e(str6);
                            }
                        }
                        else
                        {
                            e("Propertydump: Either no object selected or current selection object is invalid.");
                        }
                        return true;
                    }
                    if (str.StartsWith("fakedeath"))
                    {
                        this.a(null, (DeathEventArgs) null);
                        return true;
                    }
                    if (str.StartsWith("fakeimp"))
                    {
                        int num12 = base.get_Host().get_Actions().get_CurrentSelection();
                        if (dh.a(num12))
                        {
                            MySpell spell3 = cq.e.a("Gossamer Flesh");
                            PC.d(spell3.Id, num12, 0x2dc6c0);
                            e("Fake cast complete.");
                        }
                        return true;
                    }
                    if (str.StartsWith("throwex"))
                    {
                        throw new Exception("Testing 123");
                    }
                    if (str.StartsWith("spheredist"))
                    {
                        cv cv5 = cq.p.d(base.get_Host().get_Actions().get_CurrentSelection());
                        if ((cv5 != null) && (cv5.f() == 0))
                        {
                            cv cv6 = cq.p.d(cg);
                            if (cv6 != null)
                            {
                                double num13 = cv6.b(base.get_Host().get_Actions()).a(cv5.b(base.get_Host().get_Actions()), true) * 240.0;
                                double num14 = dh.a(cv5.k, cv6.k) + 2.0;
                                e("Center to center range: " + num13.ToString());
                                e("Border to border range: " + num14.ToString());
                            }
                        }
                        return true;
                    }
                    if (str.StartsWith("start"))
                    {
                        cq.c.StartMacro();
                        return true;
                    }
                    if (str.StartsWith("stop"))
                    {
                        cq.c.StopMacro();
                        return true;
                    }
                    if (str.StartsWith("forcebuff"))
                    {
                        e("Force buff enabled.");
                        cq.j.d();
                        return true;
                    }
                    if (str.StartsWith("cancelforcebuff"))
                    {
                        e("Force buff canceled.");
                        cq.j.h();
                        return true;
                    }
                    if (str.StartsWith("setmetastate"))
                    {
                        if (str.Length <= 13)
                        {
                            e("Usage: /vt setmetastate [somestate]");
                            e("NOTE: States are case sensitive.");
                        }
                        else
                        {
                            string key = str.Substring(13);
                            if (cq.@as.g().ContainsKey(key))
                            {
                                cq.@as.a(key);
                            }
                            else
                            {
                                e("Warning: Attempted to set an unused state. Setting to default instead.");
                                cq.@as.a("Default");
                            }
                            this.v();
                        }
                        return true;
                    }
                    if (str.StartsWith("pscount"))
                    {
                        e("Portal space toggle count: " + ch.ToString());
                        return true;
                    }
                    if (!str.StartsWith("addnavpt"))
                    {
                        return flag;
                    }
                    if (cq.l.k.c != eNavType.Target)
                    {
                        string[] strArray9 = str.Split(new char[] { ' ' });
                        if (strArray9.Length >= 2)
                        {
                            sCoord coord;
                            StringBuilder builder2 = new StringBuilder();
                            bool flag3 = false;
                            for (int num15 = 1; num15 < strArray9.Length; num15++)
                            {
                                if (flag3)
                                {
                                    builder2.Append(" ");
                                    builder2.Append(strArray9[num15]);
                                }
                                else
                                {
                                    builder2.Append(strArray9[num15]);
                                    flag3 = true;
                                }
                            }
                            if (sCoord.TryParse(builder2.ToString(), out coord))
                            {
                                cq.l.k.b.Add(new d5(coord));
                                this.f();
                            }
                            else
                            {
                                e("Usage: /vt addnavpt [coords]");
                            }
                        }
                        else
                        {
                            e("Usage: /vt addnavpt [coords]");
                        }
                    }
                    return true;
                }
                string[] strArray8 = str.Split(new char[] { ' ' });
                switch (strArray8.Length)
                {
                    case 1:
                    {
                        string str5 = "Log state:  ";
                        if (cq.n.o != e8.a)
                        {
                            if ((cq.n.o & e8.b) > e8.a)
                            {
                                str5 = str5 + " ActiveRule";
                            }
                            if ((cq.n.o & e8.c) > e8.a)
                            {
                                str5 = str5 + " SalvageList";
                            }
                            if ((cq.n.o & e8.d) > e8.a)
                            {
                                str5 = str5 + " SpellCast";
                            }
                            if ((cq.n.o & e8.g) > e8.a)
                            {
                                str5 = str5 + " RuleInfo";
                            }
                            if ((cq.n.o & e8.h) > e8.a)
                            {
                                str5 = str5 + " Timers";
                            }
                            if ((cq.n.o & e8.i) > e8.a)
                            {
                                str5 = str5 + " CastInfo";
                            }
                            if ((cq.n.o & e8.j) > e8.a)
                            {
                                str5 = str5 + " DebuffChoice";
                            }
                            if ((cq.n.o & e8.k) > e8.a)
                            {
                                str5 = str5 + " Loot";
                            }
                            if ((cq.n.o & e8.l) > e8.a)
                            {
                                str5 = str5 + " CharProps";
                            }
                            if ((cq.n.o & e8.e) > e8.a)
                            {
                                str5 = str5 + " Misc";
                            }
                        }
                        else
                        {
                            str5 = " Not currently logging.";
                        }
                        e(str5);
                        e("Valid logtypes: ActiveRule SalvageList SpellCast RuleInfo Timers CastInfo DebuffChoice Loot CharProps Misc");
                        break;
                    }
                    case 3:
                    {
                        e8 a = e8.a;
                        if (strArray8[1].Equals("All", StringComparison.OrdinalIgnoreCase))
                        {
                            a = ~e8.a;
                        }
                        if (strArray8[1].Equals("ActiveRule", StringComparison.OrdinalIgnoreCase))
                        {
                            a = e8.b;
                        }
                        if (strArray8[1].Equals("SalvageList", StringComparison.OrdinalIgnoreCase))
                        {
                            a = e8.c;
                        }
                        if (strArray8[1].Equals("SpellCast", StringComparison.OrdinalIgnoreCase))
                        {
                            a = e8.d;
                        }
                        if (strArray8[1].Equals("RuleInfo", StringComparison.OrdinalIgnoreCase))
                        {
                            a = e8.g;
                        }
                        if (strArray8[1].Equals("Timers", StringComparison.OrdinalIgnoreCase))
                        {
                            a = e8.h;
                        }
                        if (strArray8[1].Equals("CastInfo", StringComparison.OrdinalIgnoreCase))
                        {
                            a = e8.i;
                        }
                        if (strArray8[1].Equals("DebuffChoice", StringComparison.OrdinalIgnoreCase))
                        {
                            a = e8.j;
                        }
                        if (strArray8[1].Equals("Loot", StringComparison.OrdinalIgnoreCase))
                        {
                            a = e8.k;
                        }
                        if (strArray8[1].Equals("CharProps", StringComparison.OrdinalIgnoreCase))
                        {
                            a = e8.l;
                        }
                        if (strArray8[1].Equals("Misc", StringComparison.OrdinalIgnoreCase))
                        {
                            a = e8.e;
                        }
                        if (strArray8[2].Equals("on", StringComparison.OrdinalIgnoreCase))
                        {
                            e("Set " + a.ToString());
                            cq.n.o |= a;
                        }
                        else if (strArray8[2].Equals("off", StringComparison.OrdinalIgnoreCase))
                        {
                            e("Reset " + a.ToString());
                            cq.n.o &= ~a;
                        }
                        break;
                    }
                }
                return true;
            }
            string[] strArray2 = str.Split(new char[] { ' ' });
            if (strArray2.Length == 1)
            {
                e("Usage: /vt opt [list/get/set/setinall]");
                goto Label_140A;
            }
            string str8 = strArray2[1];
            if (str8 == null)
            {
                goto Label_1400;
            }
            if (!(str8 == "setinall"))
            {
                if (str8 == "list")
                {
                    goto Label_10DD;
                }
                if (str8 == "get")
                {
                    if (strArray2.Length != 3)
                    {
                        e("Usage: /vt opt get [option name]");
                    }
                    else
                    {
                        k k2 = null;
                        try
                        {
                            k2 = er.d(strArray2[2]);
                        }
                        catch (Exception)
                        {
                        }
                        if (k2 == null)
                        {
                            e("Option get: Invalid option specified.");
                        }
                        else
                        {
                            e("Option " + strArray2[2] + " = " + k2.ToString());
                        }
                    }
                    goto Label_140A;
                }
                if (str8 == "set")
                {
                    if (strArray2.Length != 4)
                    {
                        e("Usage: /vt opt set [option name] [option value]");
                        goto Label_140A;
                    }
                    v v3 = null;
                    try
                    {
                        v3 = cq.l.b["Settings"].a(0, k.a(strArray2[2]));
                    }
                    catch (Exception)
                    {
                    }
                    if (v3 == null)
                    {
                        e("Option set: Invalid option specified.");
                        goto Label_140A;
                    }
                    try
                    {
                        if (v3[1].a() == typeof(double))
                        {
                            er.b(strArray2[2], k.a(Convert.ToDouble(strArray2[3])));
                        }
                        if (v3[1].a() == typeof(int))
                        {
                            er.b(strArray2[2], k.a(Convert.ToInt32(strArray2[3])));
                        }
                        if (v3[1].a() == typeof(float))
                        {
                            er.b(strArray2[2], k.a(Convert.ToSingle(strArray2[3])));
                        }
                        if (v3[1].a() == typeof(string))
                        {
                            er.b(strArray2[2], k.a(strArray2[3]));
                        }
                        if (v3[1].a() == typeof(bool))
                        {
                            er.b(strArray2[2], k.a(Convert.ToBoolean(strArray2[3])));
                        }
                        e("Set option " + strArray2[2] + " = " + er.d(strArray2[2]).ToString());
                        goto Label_140A;
                    }
                    catch (Exception)
                    {
                        e("Option set: Invalid value specified. Proper type of " + strArray2[2] + " is " + v3[1].a().ToString() + ".");
                        goto Label_140A;
                    }
                }
                goto Label_1400;
            }
            if (strArray2.Length != 4)
            {
                e("Usage: /vt opt setinall [option name] [option value]");
            }
            v v = null;
            try
            {
                v = cq.l.b["Settings"].a(0, k.a(strArray2[2]));
            }
            catch (Exception)
            {
            }
            if (v == null)
            {
                e("Option set: Invalid option specified.");
                goto Label_140A;
            }
            try
            {
                k k = null;
                if (v[1].a() == typeof(double))
                {
                    k = k.a(Convert.ToDouble(strArray2[3]));
                }
                if (v[1].a() == typeof(int))
                {
                    k = k.a(Convert.ToInt32(strArray2[3]));
                }
                if (v[1].a() == typeof(float))
                {
                    k = k.a(Convert.ToSingle(strArray2[3]));
                }
                if (v[1].a() == typeof(string))
                {
                    k = k.a(strArray2[3]);
                }
                if (v[1].a() == typeof(bool))
                {
                    k = k.a(Convert.ToBoolean(strArray2[3]));
                }
                if (k == null)
                {
                    e("Option set: Invalid value specified. Proper type of " + strArray2[2] + " is " + v[1].a().ToString() + ".");
                    return true;
                }
                b7.a(k.b(v[0]), k);
                goto Label_140A;
            }
            catch (Exception)
            {
                e("Option set: Invalid value specified. Proper type of " + strArray2[2] + " is " + v[1].a().ToString() + ".");
                goto Label_140A;
            }
        Label_10DD:
            if (strArray2.Length != 2)
            {
                e("Usage: /vt opt list");
            }
            else
            {
                e("Available options: (" + cq.l.b["Settings"].c().ToString() + ")");
                StringBuilder builder = new StringBuilder();
                int num6 = 0;
                foreach (v v2 in cq.l.b["Settings"].d())
                {
                    string str3 = k.b(v2[0]);
                    builder.Append("   ");
                    builder.Append(str3);
                    num6++;
                    if (num6 == 4)
                    {
                        e(builder.ToString());
                        builder = new StringBuilder();
                        num6 = 0;
                    }
                }
                if (num6 != 0)
                {
                    e(builder.ToString());
                }
            }
            goto Label_140A;
        Label_1400:
            e("Usage: /vt opt [list/get/set]");
        Label_140A:
            return true;
        }

        private void k(object A_0, MVControlEventArgs A_1)
        {
            try
            {
                if (cq.l.k.c != eNavType.Target)
                {
                    cv cv = cq.p.d(cq.ax.get_Actions().get_CurrentSelection());
                    bool flag = false;
                    if ((cv != null) && (cq.aw.get_WorldFilter().get_Item(cq.ax.get_Actions().get_CurrentSelection()) != null))
                    {
                        if ((cq.aw.get_WorldFilter().get_Item(cq.ax.get_Actions().get_CurrentSelection()).get_ObjectClass() == 14) || (cq.aw.get_WorldFilter().get_Item(cq.ax.get_Actions().get_CurrentSelection()).get_ObjectClass() == 0x25))
                        {
                            flag = true;
                        }
                        else if ((cq.aw.get_WorldFilter().get_Item(cq.ax.get_Actions().get_CurrentSelection()).get_ObjectClass() == 10) && (cq.aw.get_WorldFilter().get_Item(cq.ax.get_Actions().get_CurrentSelection()).get_Icon() == 0x20c0))
                        {
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        sCoord coord = dh.a(cq.aw.get_CharacterFilter().get_Id(), cq.ax.get_Actions());
                        this.a((ef) new c2(coord, cv.g(), cv.b(cq.ax.get_Actions()), cv.c()));
                    }
                    else
                    {
                        a5.a(eChatType.Errors, "Select a portal or NPC first.");
                    }
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void k(object A_0, EventArgs A_1)
        {
            try
            {
                if (this.v.Checked)
                {
                    cq.c.StartMacro();
                }
                else
                {
                    cq.c.StopMacro();
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void l()
        {
            l.d();
            if (this.c9 != null)
            {
                this.c9();
            }
        }

        internal void l(int A_0)
        {
            eBuffedItemAddOptions noBuffs = this.c(A_0);
            if (cq.p.d(A_0) != null)
            {
                int num;
                if (cq.aw.get_WorldFilter().get_Item(A_0).Exists(0x24, ref num))
                {
                    noBuffs = eBuffedItemAddOptions.NoBuffs;
                }
                if (fn.e(base.get_Core().get_WorldFilter().get_Item(A_0)))
                {
                    noBuffs = eBuffedItemAddOptions.NoBuffs;
                    cq.j.a(new dl.c(A_0, -1));
                    this.t.AddRow()[0][0] = cq.p.d(A_0).e();
                    this.c1.Add(A_0);
                    cq.n.b(A_0);
                }
                else if (cq.aw.get_WorldFilter().get_Item(A_0).Exists(0xd00000e, ref num))
                {
                    switch (num)
                    {
                        case 0x400000:
                            if (cq.n.c(A_0) == a1.h)
                            {
                                return;
                            }
                            if ((noBuffs & eBuffedItemAddOptions.StandardBuffs) > eBuffedItemAddOptions.NoBuffs)
                            {
                                cq.j.a(new dl.c(A_0, cq.e.a("Aura of Defender Self I").Id));
                                cq.j.a(new dl.c(A_0, cq.e.a("Aura of Blood Drinker Self I").Id));
                                cq.j.a(new dl.c(A_0, cq.e.a("Aura of Swift Killer Self I").Id));
                            }
                            else
                            {
                                cq.j.a(new dl.c(A_0, -1));
                            }
                            this.t.AddRow()[0][0] = cq.p.d(A_0).e();
                            this.c1.Add(A_0);
                            cq.n.b(A_0);
                            break;

                        case 0x1000000:
                            if ((noBuffs & eBuffedItemAddOptions.StandardBuffs) > eBuffedItemAddOptions.NoBuffs)
                            {
                                cq.j.a(new dl.c(A_0, cq.e.a("Aura of Defender Self I").Id));
                                cq.j.a(new dl.c(A_0, cq.e.a("Aura of Hermetic Link Self I").Id));
                                cq.j.a(new dl.c(A_0, cq.e.a("Aura of Spirit Drinker Self I").Id));
                            }
                            else
                            {
                                cq.j.a(new dl.c(A_0, -1));
                            }
                            this.t.AddRow()[0][0] = cq.p.d(A_0).e();
                            this.c1.Add(A_0);
                            cq.n.b(A_0);
                            break;

                        case 0x2000000:
                        case 0x100000:
                        {
                            if ((noBuffs & eBuffedItemAddOptions.StandardBuffs) > eBuffedItemAddOptions.NoBuffs)
                            {
                                cq.j.a(new dl.c(A_0, cq.e.a("Aura of Defender Self I").Id));
                                cq.j.a(new dl.c(A_0, cq.e.a("Aura of Blood Drinker Self I").Id));
                                cq.j.a(new dl.c(A_0, cq.e.a("Aura of Swift Killer Self I").Id));
                                cq.j.a(new dl.c(A_0, cq.e.a("Aura of Heart Seeker Self I").Id));
                            }
                            else
                            {
                                cq.j.a(new dl.c(A_0, -1));
                            }
                            IListRow row2 = this.t.AddRow();
                            row2[0][0] = cq.p.d(A_0).e();
                            if (num != 0x2000000)
                            {
                                row2[1][0] = ey.a(3, typeof(eItemUseSpecifier));
                            }
                            this.c1.Add(A_0);
                            cq.n.b(A_0);
                            break;
                        }
                        case 0x200000:
                            if ((noBuffs & eBuffedItemAddOptions.StandardBuffs) > eBuffedItemAddOptions.NoBuffs)
                            {
                                for (int i = 0; i < 7; i++)
                                {
                                    cq.j.a(new dl.c(A_0, cq.h.a((eDamageElement) i).Id));
                                }
                                cq.j.a(new dl.c(A_0, cq.h.a(eDamageElement.Physical).Id));
                            }
                            else
                            {
                                cq.j.a(new dl.c(A_0, -1));
                            }
                            this.t.AddRow()[0][0] = cq.p.d(A_0).e();
                            this.c1.Add(A_0);
                            cq.n.b(A_0);
                            break;
                    }
                }
                cq.l.d();
                this.av();
            }
        }

        internal void l(string A_0)
        {
            cq.l.n = A_0;
            cq.l.r();
            cq.l.k();
        }

        private void l(object A_0, MVControlEventArgs A_1)
        {
            try
            {
                if (cq.l.k.c != eNavType.Target)
                {
                    this.a((ef) new n(sCoord.NoWhere, this.bv.Text));
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void l(object A_0, EventArgs A_1)
        {
            try
            {
                er.b("ManaChargesWhenOff", k.a(this.ak.Checked));
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal MyList<sWaypointDesc> m()
        {
            MyList<sWaypointDesc> list = new MyList<sWaypointDesc>(0x22);
            foreach (ef ef in cq.l.k.b)
            {
                sWaypointDesc item = new sWaypointDesc {
                    type = ef.a(),
                    loc = ef.e(),
                    bonus = ef.b()
                };
                list.Add(item);
            }
            return list;
        }

        private void m(object A_0, MVControlEventArgs A_1)
        {
            try
            {
                if (cq.l.k.c != eNavType.Target)
                {
                    cv cv = cq.p.d(cq.ax.get_Actions().get_CurrentSelection());
                    if ((cv == null) || (cv.c() != ObjectClass.Vendor))
                    {
                        a5.a(eChatType.CommandLine, "Add OpenVendor waypoint: please select a vendor first.");
                    }
                    else
                    {
                        this.a((ef) new af(sCoord.NoWhere, cv.k, cv.e()));
                    }
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void m(object A_0, EventArgs A_1)
        {
            try
            {
                er.b("LootPriorityBoost", k.a(this.aj.Checked));
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void n()
        {
            int scrollPosition = this.a2.ScrollPosition;
            this.a2.Clear();
            this.a("<< DEFAULT >>", cq.d.d(), false, false);
            int num2 = cq.d.f();
            int num3 = 0;
            using (IEnumerator enumerator = cq.d.b())
            {
                while (enumerator.MoveNext())
                {
                    aj.c current = (aj.c) enumerator.Current;
                    if (!current.u)
                    {
                        num3++;
                        bool flag = num3 == 1;
                        bool flag2 = num3 == (num2 - 1);
                        this.a(current.t, current, flag, flag2);
                    }
                }
            }
            this.a2.ScrollPosition = scrollPosition;
        }

        private void n(object A_0, MVControlEventArgs A_1)
        {
            try
            {
                if (!dh.i() && this.cl)
                {
                    cq.m.a(u.i, true);
                    cq.m.a(u.i, false);
                    r.a(cq.m.b, "/vt meta save ");
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void n(object A_0, EventArgs A_1)
        {
            try
            {
                er.b("IdlePeaceMode", k.a(this.ai.Checked));
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void o()
        {
        }

        private void o(object A_0, EventArgs A_1)
        {
            try
            {
                if (!this.l)
                {
                    this.l = true;
                    if (!this.cl)
                    {
                        this.u.Checked = false;
                    }
                    this.l = false;
                    cq.ac.a(this.u.Checked);
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void p()
        {
            this.l = true;
            cq.ay.ap.Clear();
            cq.ay.ap.Add("[None]");
            foreach (string str in cq.ag.d())
            {
                string[] files = Directory.GetFiles(ci, "*." + str);
                Array.Sort<string>(files);
                foreach (string str2 in files)
                {
                    string[] strArray2 = str2.Split(new char[] { '\\' });
                    string text = strArray2[strArray2.Length - 1];
                    if (text.Substring(0, 2) != "--")
                    {
                        cq.ay.ap.Add(text);
                    }
                }
            }
            if (string.IsNullOrEmpty(cq.l.l))
            {
                cq.ay.ap.Selected = 0;
            }
            else
            {
                for (int i = 0; i < cq.ay.ap.Count; i++)
                {
                    if (cq.ay.ap.Text[i] == cq.l.l)
                    {
                        cq.ay.ap.Selected = i;
                        break;
                    }
                }
            }
            this.l = false;
        }

        private void p(object A_0, EventArgs A_1)
        {
            try
            {
                er.b("IdleBuffTopoff", k.a(this.ah.Checked));
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void q(object A_0, EventArgs A_1)
        {
            try
            {
                er.b("AutoCram", k.a(this.ag.Checked));
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        private void r(object A_0, EventArgs A_1)
        {
            try
            {
                er.b("AutoStack", k.a(this.af.Checked));
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        public void RequestKeyVerificationDownload(string AssemblyKey)
        {
        }

        private void s(object A_0, EventArgs A_1)
        {
            try
            {
                er.b("AutoFellowManagement", k.a(this.ae.Checked));
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        protected override void Shutdown()
        {
            try
            {
                c4.b();
                cj = true;
                dh.g();
                this.at();
                this.cp.b();
                cq.c.StopMacro();
                this.k();
                a.c();
                cq.p.k(new cj.c(this.a));
                base.remove_ClientDispatch(new EventHandler<NetworkMessageEventArgs>(this.b));
                base.remove_ServerDispatch(new EventHandler<NetworkMessageEventArgs>(this.a));
                base.get_Core().get_CharacterFilter().remove_Logoff(new EventHandler<LogoffEventArgs>(this.a));
                base.get_Core().get_CharacterFilter().remove_LoginComplete(new EventHandler(this.h));
                base.get_Core().get_CharacterFilter().remove_ChangePortalMode(new EventHandler<ChangePortalModeEventArgs>(this.a));
                base.get_Core().remove_WindowMessage(new EventHandler<WindowMessageEventArgs>(this.a));
                base.get_Core().remove_CommandLineText(new EventHandler<ChatParserInterceptEventArgs>(this.a));
                a5.a();
                cg = 0;
                cq.b();
                cq = null;
                PC = null;
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        protected override void Startup()
        {
            try
            {
                ck = false;
                if (base.get_Core() == null)
                {
                    throw new Exception("VTank Error: Core is null at Startup. Cannot continue.");
                }
                if (base.get_Core().get_WorldFilter() == null)
                {
                    throw new Exception("VTank Error: WorldFilter is null at Startup. Cannot continue.");
                }
                if (base.get_Core().get_CharacterFilter() == null)
                {
                    throw new Exception("VTank Error: CharacterFilter is null at Startup. Cannot continue.");
                }
                if (base.get_Core().get_FileService() == null)
                {
                    throw new Exception("VTank Error: FileService is null at Startup. Cannot continue.");
                }
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.a));
                try
                {
                    cs = string.Equals(Process.GetCurrentProcess().ProcessName, "Direct3D9_Container", StringComparison.OrdinalIgnoreCase);
                }
                catch
                {
                }
                c4.c();
                cg = 0;
                PC = this;
                cj = false;
                base.get_Host().get_Actions().SetIdleTime(1E+100);
                e3.a(base.get_Host(), new e3.a(ad.a));
                ap.a = "VTank";
                ap.b = base.get_Host();
                a5.b();
                l.j();
                a.a(new a.d(this.f), "vt3", new a.b(ad.a));
                ci = Registry.LocalMachine.OpenSubKey(@"Software\Decal\Plugins\{642F1F48-16BE-48BF-B1D4-286652C4533E}").GetValue("ProfilePath").ToString();
                this.cp = new ea();
                this.au();
                cq = new ev(base.get_Core(), base.get_Host(), this);
                cq.c.InitializeDefaultLogicRules();
                cq.p.l(new cj.c(this.a));
                base.get_Core().add_CommandLineText(new EventHandler<ChatParserInterceptEventArgs>(this.a));
                base.get_Core().add_WindowMessage(new EventHandler<WindowMessageEventArgs>(this.a));
                base.get_Core().get_CharacterFilter().add_LoginComplete(new EventHandler(this.h));
                base.get_Core().get_CharacterFilter().add_Logoff(new EventHandler<LogoffEventArgs>(this.a));
                base.get_Core().get_CharacterFilter().add_ChangePortalMode(new EventHandler<ChangePortalModeEventArgs>(this.a));
                base.add_ServerDispatch(new EventHandler<NetworkMessageEventArgs>(this.a));
                base.add_ClientDispatch(new EventHandler<NetworkMessageEventArgs>(this.b));
                this.am();
                cq.c.StopMacro();
                dh.h();
                cq.p.b(new cj.b(this.a));
                if (cs)
                {
                    cg = 0x3039;
                    this.h(null, (EventArgs) null);
                }
                ck = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                ad.a(exception);
            }
        }

        internal void t()
        {
            cq.l.h.Add("[All Peas]", fz.l);
            this.n.AddRow()[0][0] = "[All Peas]";
            this.c2.Add("[All Peas]");
        }

        private void t(object A_0, EventArgs A_1)
        {
            try
            {
                er.b("EnableCombat", k.a(this.ad.Checked));
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal string u()
        {
            return cq.l.m;
        }

        private void u(object A_0, EventArgs A_1)
        {
            try
            {
                er.b("EnableBuffing", k.a(this.ac.Checked));
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void v()
        {
            int scrollPosition = this.cd.ScrollPosition;
            this.cd.Clear();
            this.c4.Clear();
            foreach (KeyValuePair<string, List<d8>> pair in cq.@as.c)
            {
                bool flag = true;
                int num2 = 0;
                foreach (d8 d in pair.Value)
                {
                    this.c4.Add(d);
                    IListRow row = this.cd.AddRow();
                    row[3][0] = d.c;
                    row[4][0] = d.a.k();
                    row[5][0] = d.b.k();
                    if (cq.@as.d.ContainsKey(d))
                    {
                        row[3].Color = Color.Red;
                        row[4].Color = Color.Red;
                        row[5].Color = Color.Red;
                    }
                    bool flag2 = num2 == (pair.Value.Count - 1);
                    if (!flag)
                    {
                        row[0][1] = 0x60028fc;
                    }
                    if (!flag2)
                    {
                        row[1][1] = 0x60028fd;
                    }
                    row[2][1] = 0x60011f8;
                    flag = false;
                    num2++;
                }
            }
            this.l = true;
            this.cf.Clear();
            this.cf.Add("Default");
            this.cf.Selected = 0;
            foreach (KeyValuePair<string, int> pair2 in cq.@as.g())
            {
                if (!string.Equals(pair2.Key, "Default"))
                {
                    this.cf.Add(pair2.Key);
                    if (string.Equals(cq.@as.f(), pair2.Key))
                    {
                        this.cf.Selected = this.cf.Count - 1;
                    }
                }
            }
            this.l = false;
            this.cd.ScrollPosition = scrollPosition;
        }

        private void v(object A_0, EventArgs A_1)
        {
            try
            {
                er.b("EnableLooting", k.a(this.ab.Checked));
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void w()
        {
            l.e();
            if (this.db != null)
            {
                this.db();
            }
        }

        private void w(object A_0, EventArgs A_1)
        {
            try
            {
                er.b("EnableNav", k.a(this.aa.Checked));
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void x()
        {
            this.b9.Clear();
            foreach (int num in cq.l.i)
            {
                MySpell spell = cq.e.b(num);
                if (spell != null)
                {
                    this.b9.AddRow()[0][0] = spell.FriendlyName;
                }
            }
            this.cb.Clear();
            foreach (int num2 in cq.l.j)
            {
                MySpell spell2 = cq.e.b(num2);
                if (spell2 != null)
                {
                    this.cb.AddRow()[0][0] = spell2.FriendlyName;
                }
            }
        }

        private void x(object A_0, EventArgs A_1)
        {
            try
            {
                er.b("UseDispelItems", k.a(this.y.Checked));
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal void y()
        {
            this.aa();
            this.p();
            this.ak();
            this.i();
            this.a(this.am, Math.Round((double) (er.h("AttackDistance") * 240.0), 1).ToString());
            this.a(this.al, Math.Round((double) (er.h("RingDistance") * 240.0), 1).ToString());
            this.a(this.an, Math.Round((double) (er.h("ApproachDistance") * 240.0), 1).ToString());
            this.a(this.ao, Math.Round((double) (er.h("NavCloseStopRange") * 240.0), 1).ToString());
            this.z.Checked = er.j("CastDispelSelf");
            this.y.Checked = er.j("UseDispelItems");
            this.aa.Checked = er.j("EnableNav");
            this.ab.Checked = er.j("EnableLooting");
            this.a0.Checked = er.j("EnableMeta");
            this.ac.Checked = er.j("EnableBuffing");
            this.ad.Checked = er.j("EnableCombat");
            this.ae.Checked = er.j("AutoFellowManagement");
            this.af.Checked = er.j("AutoStack");
            this.ag.Checked = er.j("AutoCram");
            this.ah.Checked = er.j("IdleBuffTopoff");
            this.ai.Checked = er.j("IdlePeaceMode");
            this.aj.Checked = er.j("LootPriorityBoost");
            this.ak.Checked = er.j("ManaChargesWhenOff");
        }

        private void y(object A_0, EventArgs A_1)
        {
            try
            {
                er.b("CastDispelSelf", k.a(this.z.Checked));
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal string z()
        {
            return cq.l.k.e;
        }

        private void z(object A_0, EventArgs A_1)
        {
            try
            {
                double num;
                if (this.a(this.ao.Text, out num) && (Math.Round(num, 8) != Math.Round(er.h("NavCloseStopRange"), 8)))
                {
                    er.b("NavCloseStopRange", k.a(num));
                }
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        internal int CurrentRulePriority
        {
            get
            {
                return cq.n.q;
            }
        }

        internal double HelperBonusActionWaitSeconds
        {
            get
            {
                return cq.k.d;
            }
            set
            {
                cq.k.d = value;
            }
        }

        internal double HelperBonusTimeoutSeconds
        {
            get
            {
                return cq.k.c;
            }
            set
            {
                cq.k.c = value;
            }
        }

        internal bool InterfaceAllowed
        {
            get
            {
                return true;
            }
        }

        internal bool MacroEnabled
        {
            get
            {
                return cq.n.b;
            }
            set
            {
                if (value != cq.n.b)
                {
                    if (value)
                    {
                        cq.c.StartMacro();
                    }
                    else
                    {
                        cq.c.StopMacro();
                    }
                }
            }
        }

        internal int NavCurrent
        {
            get
            {
                return cq.n.l;
            }
        }

        internal int NavNumPoints
        {
            get
            {
                return cq.l.k.c();
            }
        }

        internal eNavType NavType
        {
            get
            {
                return cq.l.k.c;
            }
            set
            {
                cq.l.k.a(value);
                cq.l.g();
                cq.n.c();
                this.ao();
            }
        }

        internal delegate void a(object A_0, NetworkMessageEventArgs A_1);

        public delegate void AllSpellsExpiredDelegate(int spellID, int target);

        internal delegate void b(object A_0, NetworkMessageEventArgs A_1);

        public class cExternalInterfaceTrustedRelay
        {
            private eExternalsPermissionLevel a;

            internal cExternalInterfaceTrustedRelay(eExternalsPermissionLevel A_0)
            {
                if (Assembly.GetCallingAssembly() == Assembly.GetExecutingAssembly())
                {
                    this.a = A_0;
                }
                else
                {
                    this.a = eExternalsPermissionLevel.None;
                }
            }

            private void a(eExternalsPermissionLevel A_0)
            {
                if ((A_0 & this.a) == eExternalsPermissionLevel.None)
                {
                    throw new Exception("Permission denied: action not valid under current interface permission level.");
                }
            }

            public void AcceptSpreadLockTarget(int target)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.g(target);
            }

            public void CancelForceBuff()
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.e("Force buff canceled.");
                PluginCore.cq.j.h();
            }

            public bool Decision_IsLocked(ActionLockType t)
            {
                this.a(eExternalsPermissionLevel.LogicObject);
                return PluginCore.cq.n.n.b(t);
            }

            public void Decision_Lock(ActionLockType t, TimeSpan lt)
            {
                this.a(eExternalsPermissionLevel.LogicObject);
                PluginCore.cq.n.n.a(t, lt);
            }

            public void Decision_UnLock(ActionLockType t)
            {
                this.a(eExternalsPermissionLevel.LogicObject);
                PluginCore.cq.n.n.a(t);
            }

            public bool Equipment_TryEquipAnyWand()
            {
                this.a(eExternalsPermissionLevel.LogicObject);
                return PluginCore.cq.n.a(8, 0, true);
            }

            public bool Equipment_TryEquipWandWeapon(CombatState targetstate, int itemid)
            {
                this.a(eExternalsPermissionLevel.LogicObject);
                return PluginCore.cq.n.a(targetstate, itemid, false);
            }

            public bool Equipment_TryEquipWandWeaponWithArrows(CombatState targetstate, int itemid, eDamageElement arrowdamagetype)
            {
                this.a(eExternalsPermissionLevel.LogicObject);
                return PluginCore.cq.n.a(targetstate, itemid, false, arrowdamagetype, ePrismaticDamageBehavior.Any);
            }

            public bool Equipment_TryEquipWeaponsForMonster(string monstername)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                cv cv = new cv();
                cv.b[1] = monstername;
                MyQuad<int, eDamageElement, ePrismaticDamageBehavior, int> quad = PluginCore.cq.n.d(cv);
                CombatState state = 8;
                if (dh.b(quad.a) && (dh.c(quad.a) == PluginCore.cg))
                {
                    state = PluginCore.cq.n.a(PluginCore.cq.aw.get_WorldFilter().get_Item(quad.a).get_ObjectClass());
                }
                return PluginCore.cq.n.a(state, quad.a, false, quad.b, quad.c, quad.d);
            }

            public void ForceBuff()
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.e("Force buff enabled.");
                PluginCore.cq.j.d();
            }

            public MyList<int> GetByAction(eLootAction act)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                return PluginCore.PC.a(act);
            }

            public List<int> GetCustomLootActionItems(eLootAction act)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                List<int> list = new List<int>();
                foreach (KeyValuePair<int, eLootAction> pair in PluginCore.cq.n.g)
                {
                    if (PluginCore.cq.p.b(pair.Key, PluginCore.cq.ax) && (((eLootAction) pair.Value) == act))
                    {
                        list.Add(pair.Key);
                    }
                }
                return list;
            }

            public string GetLootProfile()
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                return PluginCore.PC.an();
            }

            public string GetNavProfile()
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                return PluginCore.PC.ai();
            }

            public object GetSetting(string Setting)
            {
                this.a(eExternalsPermissionLevel.ReadSettings);
                return er.d(Setting).c();
            }

            public string GetSettingsProfile()
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                return PluginCore.PC.u();
            }

            public Type GetSettingType(string Setting)
            {
                this.a(eExternalsPermissionLevel.ReadSettings);
                return er.d(Setting).a();
            }

            public void HelperPlayerSetInvalid(int u)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.k(u);
            }

            public void HelperPlayerUpdate(sPlayerInfoUpdate u)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.a(u);
            }

            public void LoadLootProfile(string p)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.i(p);
            }

            public void LoadNavProfile(string p)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.l(p);
            }

            public void LoadSettingsProfile(string p)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.g(p);
            }

            public void LogAllSpellsExpired(int spellID, int target)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.a(spellID, target);
            }

            public void LogCastAttempt(int spellID, int target, int skill)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.c(spellID, target, skill);
            }

            public void LogSpellCast(int target, int spellid, int durationmilliseconds)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.e(target, spellid, durationmilliseconds);
            }

            public void NavBeginChanges()
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.cq.l.k.a(true);
            }

            public void NavDeletePoint(int pos)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.i(pos);
            }

            public void NavEndChanges()
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.cq.l.k.a(false);
            }

            public int NavGetFollowTargetInt()
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                return PluginCore.PC.j();
            }

            public string NavGetFollowTargetString()
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                return PluginCore.PC.z();
            }

            public sWaypointDesc NavGetPoint(int pos)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                return PluginCore.PC.j(pos);
            }

            public MyList<sWaypointDesc> NavGetPoints()
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                return PluginCore.PC.m();
            }

            public void NavInsertPoint(sCoord pt, int pos)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.a(pt, pos);
            }

            public void NavRouteClear()
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.ab();
            }

            public void NavSetFollowTarget(int ft, string ftn)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.a(ft, ftn);
            }

            public void NavSetPoint(int point, eWaypointType wptype, sCoord pos, int bonusdata)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.a(point, wptype, pos, bonusdata);
            }

            public bool NeedToBuffInNext(int timeseconds)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                return PluginCore.cq.j.a(timeseconds);
            }

            public void ResetPanels()
            {
                this.a(eExternalsPermissionLevel.WriteSettings);
                er.a();
            }

            public void SetAnInvalidTarget(int target)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.d(target);
            }

            public void SetLockedByOther(int target, bool locked)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.c(target, locked);
            }

            public void SetMacroSetting(eSettingBool st, bool val)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.a(st, val);
            }

            public void SetSetting(string Setting, bool value)
            {
                this.a(eExternalsPermissionLevel.WriteSettings);
                er.b(Setting, k.a(value));
            }

            public void SetSetting(string Setting, double value)
            {
                this.a(eExternalsPermissionLevel.WriteSettings);
                er.b(Setting, k.a(value));
            }

            public void SetSetting(string Setting, int value)
            {
                this.a(eExternalsPermissionLevel.WriteSettings);
                er.b(Setting, k.a(value));
            }

            public void SetSetting(string Setting, object value)
            {
                this.a(eExternalsPermissionLevel.WriteSettings);
                k k = (k) value;
                er.b(Setting, k);
            }

            public void SetSetting(string Setting, float value)
            {
                this.a(eExternalsPermissionLevel.WriteSettings);
                er.b(Setting, k.a(value));
            }

            public void SetSetting(string Setting, string value)
            {
                this.a(eExternalsPermissionLevel.WriteSettings);
                er.b(Setting, k.a(value));
            }

            public void SetSpreadFire(bool on)
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.b(on);
            }

            public void ShowMainUI()
            {
                this.a(eExternalsPermissionLevel.FullUnderlying);
                PluginCore.PC.h.Visible = true;
            }

            public bool SpellSystem_CanUseWandSpell(int wand)
            {
                this.a(eExternalsPermissionLevel.LogicObject);
                return PluginCore.cq.z.a(wand);
            }

            public void SpellSystem_CastEquippedWandSpell(int wand, int target)
            {
                this.a(eExternalsPermissionLevel.LogicObject);
                PluginCore.cq.z.a(wand, target);
            }

            public void SpellSystem_CastNormalSpell(MySpell spell, int target)
            {
                this.a(eExternalsPermissionLevel.LogicObject);
                PluginCore.cq.g.a(spell, target);
            }

            public MySpell SpellSystem_GetSpellById(int spellid)
            {
                this.a(eExternalsPermissionLevel.LogicObject);
                return PluginCore.cq.e.b(spellid);
            }

            public MySpell SpellSystem_GetSpellByName(string spellname)
            {
                this.a(eExternalsPermissionLevel.LogicObject);
                return PluginCore.cq.e.a(spellname);
            }

            public MySpell SpellSystem_QueryBestSpellAvailableInSameFamilyAsSpellNamed(string spellname, bool UseSpellDiffExcessThreshold_Hunt)
            {
                this.a(eExternalsPermissionLevel.LogicObject);
                return PluginCore.cq.h.a(spellname, UseSpellDiffExcessThreshold_Hunt);
            }

            public MySpell SpellSystem_QueryCombatSpellForElement(eDamageElement Element, eCombatSpellType AttType)
            {
                this.a(eExternalsPermissionLevel.LogicObject);
                return PluginCore.cq.h.a(Element, AttType);
            }

            public int CurrentRulePriority
            {
                get
                {
                    this.a(eExternalsPermissionLevel.FullUnderlying);
                    return PluginCore.PC.q();
                }
            }

            public bool Decision_GlobalBusyFlag
            {
                get
                {
                    this.a(eExternalsPermissionLevel.LogicObject);
                    return PluginCore.cq.n.k;
                }
                set
                {
                    this.a(eExternalsPermissionLevel.LogicObject);
                    PluginCore.cq.n.k = value;
                }
            }

            public double HelperBonusActionWaitSeconds
            {
                get
                {
                    this.a(eExternalsPermissionLevel.FullUnderlying);
                    return PluginCore.PC.ag();
                }
                set
                {
                    this.a(eExternalsPermissionLevel.FullUnderlying);
                    PluginCore.PC.b(value);
                }
            }

            public double HelperBonusTimeoutSeconds
            {
                get
                {
                    this.a(eExternalsPermissionLevel.FullUnderlying);
                    return PluginCore.PC.s();
                }
                set
                {
                    this.a(eExternalsPermissionLevel.FullUnderlying);
                    PluginCore.PC.a(value);
                }
            }

            public cLogic LogicObject
            {
                get
                {
                    this.a(eExternalsPermissionLevel.LogicObject);
                    return PluginCore.cq.c;
                }
            }

            public bool MacroEnabled
            {
                get
                {
                    this.a(eExternalsPermissionLevel.FullUnderlying);
                    return PluginCore.PC.al();
                }
                set
                {
                    this.a(eExternalsPermissionLevel.FullUnderlying);
                    PluginCore.PC.a(value);
                }
            }

            public int NavCurrent
            {
                get
                {
                    this.a(eExternalsPermissionLevel.FullUnderlying);
                    return PluginCore.PC.af();
                }
            }

            public int NavNumPoints
            {
                get
                {
                    this.a(eExternalsPermissionLevel.FullUnderlying);
                    return PluginCore.PC.r();
                }
            }

            public eNavType NavType
            {
                get
                {
                    this.a(eExternalsPermissionLevel.FullUnderlying);
                    return PluginCore.PC.ah();
                }
                set
                {
                    this.a(eExternalsPermissionLevel.FullUnderlying);
                    PluginCore.PC.a(value);
                }
            }

            public eExternalsPermissionLevel PermissionLevel
            {
                get
                {
                    return this.a;
                }
            }

            public cVersion Version
            {
                get
                {
                    return cVersion.GetVersion(Assembly.GetExecutingAssembly());
                }
            }
        }

        public delegate void delFLootPluginClassifyCallback(int obj, LootAction result, bool getsuccess);

        [Flags]
        public enum eBuffedItemAddOptions
        {
            NoBuffs,
            StandardBuffs
        }

        public delegate void EmptyDelegate();

        public delegate void NavRouteChangedDelegate();

        public delegate void NavWaypointChangedDelegate();

        public delegate void RequestTargetSelectionDelegate(MyList<int> Targets);

        public delegate void SpellCastAttemptingDelegate(int spellID, int target, int skill);

        public delegate void SpellCastCompleteDelegate(int spellID, int target, int duration);

        public delegate void SpreadLockDelegate(int target);

        public delegate void TargetDelegate(int target);
    }
}

