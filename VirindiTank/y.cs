using Decal.Adapter;
using MyClasses;
using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using uTank2;

internal class y : IDisposable
{
    private const int a = 8;
    private const double b = 0.041666666666666664;
    private const double c = 2.0;
    private const double d = 4.0;
    private const int e = 30;
    private ar f;
    private e3 g = new e3();
    private ActionLockDictionary<string> h = new ActionLockDictionary<string>(TimeSpan.FromMinutes(3.0), 8);
    private bool i;
    private List<string> j = new List<string>();
    private List<string> k = new List<string>();
    private bool l;
    private bool m;
    private bool n = true;
    private int o;
    private List<string> p = new List<string>();
    private Dictionary<string, DateTimeOffset> q = new Dictionary<string, DateTimeOffset>();
    private Dictionary<y.b, List<MyPair<string, bool>>> r = new Dictionary<y.b, List<MyPair<string, bool>>>();
    private string s = "";
    private int t;
    private Dictionary<string, DateTimeOffset> u = new Dictionary<string, DateTimeOffset>();
    private string v;
    private int w;
    private Regex x = new Regex("^<Tell\\:IIDString\\:[0-9]*\\:(?'name'[^\\>]*)>[^\\<]*<\\\\Tell> tells you, \\\"(?'msg'.*)\\\"$");

    public y(ar A_0)
    {
        this.f = A_0;
        CoreManager.get_Current().add_ChatBoxMessage(new EventHandler<ChatTextInterceptEventArgs>(this.a));
        this.f.d(new EventHandler(this.b));
        this.f.a(new EventHandler(this.a));
        this.f.b(new EventHandler(this.c));
        this.g.a(new EventHandler(this.d));
        a.a("fvote", new a.c(this.a));
        PluginCore.PC.ProfileChanged += new PluginCore.EmptyDelegate(this.d);
        this.g.a(0x30d7);
        this.g.d();
    }

    private bool a()
    {
        return (this.f.a.Count >= 8);
    }

    private bool a(string A_0)
    {
        this.h.a(A_0);
        if (this.h.b(A_0))
        {
            PluginCore.e("Tell from " + A_0 + " ignored due to spam.");
            return true;
        }
        return false;
    }

    private void a(string[] A_0)
    {
        y.b key;
        List<MyPair<string, bool>> list;
        bool flag;
        string str;
        bool flag2;
        if (A_0.Length == 3)
        {
            int num;
            if (A_0[0] != "fvote")
            {
                return;
            }
            if (!int.TryParse(A_0[1], out num))
            {
                return;
            }
            key = null;
            list = null;
            foreach (KeyValuePair<y.b, List<MyPair<string, bool>>> pair in this.r)
            {
                if (pair.Key.e == num)
                {
                    key = pair.Key;
                    list = pair.Value;
                    break;
                }
            }
            if (key != null)
            {
                flag = false;
                str = CoreManager.get_Current().get_CharacterFilter().get_Name();
                if (string.Compare(A_0[2], "yes", true) == 0)
                {
                    flag = true;
                    goto Label_00FD;
                }
                if (string.Compare(A_0[2], "no", true) == 0)
                {
                    flag = false;
                    goto Label_00FD;
                }
                if (string.Compare(A_0[2], "abort", true) == 0)
                {
                    this.r.Remove(key);
                    PluginCore.cq.ah.b("/f [VT Fellow Manager] Vote " + key.ToString() + " canceled by fellow leader.  -v-");
                }
            }
        }
        return;
    Label_00FD:
        flag2 = false;
        foreach (MyPair<string, bool> pair2 in list)
        {
            if (pair2.a == str)
            {
                flag2 = true;
                pair2.b = flag;
                break;
            }
        }
        if (!flag2)
        {
            MyPair<string, bool> item = new MyPair<string, bool> {
                a = str,
                b = flag
            };
            list.Add(item);
        }
        int num2 = 0;
        int num3 = 0;
        foreach (MyPair<string, bool> pair4 in list)
        {
            if (pair4.b)
            {
                num2++;
            }
            else
            {
                num3++;
            }
        }
        PluginCore.cq.ah.b("/f [VT Fellow Manager] Vote total for " + key.ToString() + ": " + num2.ToString() + "/" + num3.ToString() + "  -v-");
    }

    private void a(bool A_0)
    {
        if ((this.f.c() && this.l) && (A_0 != this.f.d()))
        {
            dh.a(A_0);
        }
    }

    private void a(object A_0, ChatTextInterceptEventArgs A_1)
    {
        try
        {
            string str;
            string str2;
            string str10;
            string str11;
            y.b b;
            int e;
            if ((PluginCore.cq.n.b && er.j("AutoFellowManagement")) && ((A_1.get_Color() == 3) && this.f.c()))
            {
                Match match = this.x.Match(A_1.get_Text());
                if (match.Success)
                {
                    str = match.Groups["name"].Value;
                    str2 = match.Groups["msg"].Value;
                    if (string.Compare(str2, "xp", true) == 0)
                    {
                        if (!this.a(str))
                        {
                            foreach (KeyValuePair<int, ar.a> pair in this.f.a)
                            {
                                if (pair.Value.b == str)
                                {
                                    PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] You are already in the fellowship.  -v-");
                                    return;
                                }
                            }
                            if (this.j.Contains(str.ToLowerInvariant()))
                            {
                                PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] Sorry, but you have been banned from this fellowship.  -v-");
                            }
                            else if (!this.l && !this.f.d())
                            {
                                string str3 = "????";
                                if (this.f.a.ContainsKey(this.f.b()))
                                {
                                    str3 = this.f.a[this.f.b()].b;
                                }
                                PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] I'm sorry, but the fellowship is closed and I am not the leader. The leader is currently: " + str3 + "  -v-");
                            }
                            else if (this.l)
                            {
                                if (this.k.Contains(str))
                                {
                                    if (this.m)
                                    {
                                        if (this.u.ContainsKey(str))
                                        {
                                            if (!this.p.Contains(str))
                                            {
                                                this.p.Add(str);
                                            }
                                            PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] Please wait nearby. I will try to recruit you in a moment.  -v-");
                                        }
                                        else
                                        {
                                            int num = this.k.IndexOf(str) + 1;
                                            PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] You are already number " + num.ToString() + " of " + this.k.Count.ToString() + " on the waiting list.  -v-");
                                        }
                                    }
                                    else
                                    {
                                        PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] Please wait nearby. I will try to recruit you in a moment.  -v-");
                                    }
                                }
                                else if (this.m)
                                {
                                    this.k.Add(str);
                                    PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] The fellow is full, and I am the leader. I am adding you to the waiting list at position " + this.k.Count.ToString() + "  -v-");
                                }
                                else
                                {
                                    this.k.Add(str);
                                    PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] I will recruit you in a moment. Please stand close to me.  -v-");
                                }
                            }
                            else if ((!this.l && this.f.d()) && !this.a())
                            {
                                if (!this.k.Contains(str))
                                {
                                    this.k.Add(str);
                                }
                                PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] Please wait nearby. I will try to recruit you in a moment.  -v-");
                            }
                            else if ((!this.l && this.f.d()) && this.a())
                            {
                                string str4 = "????";
                                if (this.f.a.ContainsKey(this.f.b()))
                                {
                                    str4 = this.f.a[this.f.b()].b;
                                }
                                PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] I'm sorry, but the fellowship is full. The leader is currently: " + str4 + "  -v-");
                            }
                        }
                    }
                    else if (((string.Compare(str2, "line", true) == 0) || (string.Compare(str2, "list", true) == 0)) || (string.Compare(str2, "status", true) == 0))
                    {
                        if (!this.a(str))
                        {
                            if (this.l)
                            {
                                if (!this.m)
                                {
                                    string[] strArray7 = new string[] { "/t ", str, ", [VT Fellow Manager] There is no waiting list. The fellowship has ", (this.f.a.Count + 1).ToString(), " members.  -v-" };
                                    PluginCore.cq.ah.b(string.Concat(strArray7));
                                }
                                else if (this.k.Contains(str))
                                {
                                    int num2 = this.k.IndexOf(str) + 1;
                                    PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] You are number " + num2.ToString() + " of " + this.k.Count.ToString() + " on the waiting list.  -v-");
                                }
                                else
                                {
                                    PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] The waiting list contains " + this.k.Count.ToString() + " players. You are not on it.  -v-");
                                }
                            }
                            else
                            {
                                string str5;
                                if (this.f.d())
                                {
                                    str5 = "open";
                                }
                                else
                                {
                                    str5 = "closed";
                                }
                                string str6 = "????";
                                if (this.f.a.ContainsKey(this.f.b()))
                                {
                                    str6 = this.f.a[this.f.b()].b;
                                }
                                PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] The leader is currently: " + str6 + ". The fellowship is " + str5 + ".  -v-");
                            }
                        }
                    }
                    else if (string.Compare(str2, "remove", true) == 0)
                    {
                        if (!this.a(str))
                        {
                            string item = str;
                            if (this.k.Contains(item))
                            {
                                this.k.Remove(item);
                            }
                            if (this.p.Contains(item))
                            {
                                this.p.Remove(item);
                            }
                            if (this.u.ContainsKey(item))
                            {
                                this.u.Remove(item);
                            }
                            this.b();
                            PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] You have been removed from the list.  -v-");
                        }
                    }
                    else if (string.Compare(str2, "leader", true) == 0)
                    {
                        if (!this.a(str))
                        {
                            string str8;
                            if (this.f.d())
                            {
                                str8 = "open";
                            }
                            else
                            {
                                str8 = "closed";
                            }
                            if (this.l)
                            {
                                PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] I am the fellowship leader. The fellowship is " + str8 + ".  -v-");
                            }
                            else
                            {
                                string str9 = "????";
                                if (this.f.a.ContainsKey(this.f.b()))
                                {
                                    str9 = this.f.a[this.f.b()].b;
                                }
                                PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] The leader is currently: " + str9 + ". The fellowship is " + str8 + ".  -v-");
                            }
                        }
                    }
                    else if (string.Compare(str2, "help", true) == 0)
                    {
                        if (!this.a(str))
                        {
                            PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] Available commands: xp, line, remove, leader, startvote, vote, location, help  -v-");
                        }
                    }
                    else if (string.Compare(str2, "help startvote", true) == 0)
                    {
                        if (!this.a(str))
                        {
                            PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] Usage: startvote [votetype] [parameter]. Possible vote types: kick, ban, giveleader, setopen.  -v-");
                        }
                    }
                    else if (string.Compare(str2, "help vote", true) == 0)
                    {
                        if (!this.a(str))
                        {
                            PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] Usage: vote [vote id] [yes/no]  -v-");
                        }
                    }
                    else
                    {
                        if (!str2.StartsWith("startvote "))
                        {
                            goto Label_1027;
                        }
                        if ((!this.a(str) && this.b(str)) && !this.j.Contains(str.ToLowerInvariant()))
                        {
                            if (this.q.ContainsKey(str) && (this.q[str] > DateTimeOffset.Now))
                            {
                                string[] strArray13 = new string[] { "/t ", str, ", [VT Fellow Manager] You have initiated a vote too recently (wait another ", (this.q[str] - DateTimeOffset.Now).ToString(), ").  -v-" };
                                PluginCore.cq.ah.b(string.Concat(strArray13));
                            }
                            else
                            {
                                string[] strArray = str2.Split(new char[] { ' ' });
                                if (strArray.Length < 3)
                                {
                                    PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] Not enough parameters to startvote command. Tell me 'help startvote' for more information.  -v-");
                                }
                                else
                                {
                                    str10 = strArray[1];
                                    StringBuilder builder = new StringBuilder();
                                    for (int i = 2; i < strArray.Length; i++)
                                    {
                                        if (i > 2)
                                        {
                                            builder.Append(" ");
                                        }
                                        builder.Append(strArray[i]);
                                    }
                                    str11 = builder.ToString();
                                    b = new y.b {
                                        b = str11.ToLowerInvariant()
                                    };
                                    if (string.Compare(str10, "kick", true) == 0)
                                    {
                                        if (!this.b(str11))
                                        {
                                            PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] Cannot vote to kick " + str11 + ", that player is not in the fellow.  -v-");
                                            return;
                                        }
                                        b.a = y.a.a;
                                        goto Label_0CE0;
                                    }
                                    if (string.Compare(str10, "ban", true) == 0)
                                    {
                                        if (!this.b(str11))
                                        {
                                            PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] Cannot vote to ban " + str11 + ", that player is not in the fellow.  -v-");
                                            return;
                                        }
                                        b.a = y.a.b;
                                        goto Label_0CE0;
                                    }
                                    if (string.Compare(str10, "giveleader", true) == 0)
                                    {
                                        if (!this.b(str11))
                                        {
                                            PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] Cannot vote to give leader to " + str11 + ", that player is not in the fellow.  -v-");
                                            return;
                                        }
                                        b.a = y.a.c;
                                        goto Label_0CE0;
                                    }
                                    if (string.Compare(str10, "setopen", true) == 0)
                                    {
                                        if ((str11 != "true") && (str11 != "false"))
                                        {
                                            PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] A setopen vote call must be followed by 'true' or 'false'.  -v-");
                                            return;
                                        }
                                        b.a = y.a.d;
                                        goto Label_0CE0;
                                    }
                                    PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] Unknown vote type. Tell me 'help startvote' for more information.  -v-");
                                }
                            }
                        }
                    }
                }
            }
            return;
        Label_0CE0:
            e = 0;
            foreach (KeyValuePair<y.b, List<MyPair<string, bool>>> pair2 in this.r)
            {
                if (pair2.Key.a(b) == 0)
                {
                    e = pair2.Key.e;
                    break;
                }
            }
            if (e != 0)
            {
                PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] An identical vote is already in progress! (Vote ID " + e.ToString() + ")  -v-");
            }
            else
            {
                b.c = DateTimeOffset.Now + TimeSpan.FromMinutes(2.0);
                string[] strArray3 = new string[] { "/f [VT Fellow Manager] ", str, " has called a new vote: ", str10.ToLowerInvariant(), " ", str11, "! To vote, either tell me 'vote ", b.e.ToString(), " yes' or 'vote ", b.e.ToString(), " no'. You have ", 2.0.ToString(), " minutes.  -v-" };
                PluginCore.cq.ah.b(string.Concat(strArray3));
                this.r.Add(b, new List<MyPair<string, bool>>());
                MyPair<string, bool> pair3 = new MyPair<string, bool> {
                    a = str,
                    b = true
                };
                this.r[b].Add(pair3);
                this.q[str] = DateTimeOffset.Now + TimeSpan.FromMinutes(4.0);
                PluginCore.cq.ah.b("/f [VT Fellow Manager] Vote total for '" + str10.ToLowerInvariant() + " " + str11 + "' (ID " + b.e.ToString() + "): 1/0  -v-");
                PluginCore.e("Vote called by " + str + ": " + b.ToString() + ". [" + a.a("Vote Yes", new string[] { "fvote", b.e.ToString(), "yes" }) + "] [" + a.a("Vote No", new string[] { "fvote", b.e.ToString(), "no" }) + "] [" + a.a("Abort Vote", new string[] { "fvote", b.e.ToString(), "abort" }) + "]");
            }
            return;
        Label_1027:
            if (str2.StartsWith("vote "))
            {
                if ((!this.a(str) && this.b(str)) && !this.j.Contains(str.ToLowerInvariant()))
                {
                    int num5;
                    string[] strArray2 = str2.Split(new char[] { ' ' });
                    if ((strArray2.Length != 3) || !int.TryParse(strArray2[1], out num5))
                    {
                        PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] Invalid vote command. Votes should look like: vote idnumber yes, or: vote idnumber no  -v-");
                        return;
                    }
                    bool flag = false;
                    if (string.Compare(strArray2[2], "yes", true) == 0)
                    {
                        flag = true;
                    }
                    else if (string.Compare(strArray2[2], "no", true) == 0)
                    {
                        flag = false;
                    }
                    else
                    {
                        PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] Invalid vote command. Votes should look like: vote idnumber yes, or: vote idnumber no  -v-");
                        return;
                    }
                    y.b key = null;
                    List<MyPair<string, bool>> list = null;
                    foreach (KeyValuePair<y.b, List<MyPair<string, bool>>> pair4 in this.r)
                    {
                        if (pair4.Key.e == num5)
                        {
                            key = pair4.Key;
                            list = pair4.Value;
                            break;
                        }
                    }
                    if (key == null)
                    {
                        PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] Invalid vote ID number. Votes should look like: vote idnumber yes, or: vote idnumber no  -v-");
                        return;
                    }
                    bool flag2 = false;
                    foreach (MyPair<string, bool> pair5 in list)
                    {
                        if (pair5.a == str)
                        {
                            flag2 = true;
                            pair5.b = flag;
                            break;
                        }
                    }
                    if (!flag2)
                    {
                        MyPair<string, bool> pair6 = new MyPair<string, bool> {
                            a = str,
                            b = flag
                        };
                        list.Add(pair6);
                    }
                    int num6 = 0;
                    int num7 = 0;
                    foreach (MyPair<string, bool> pair7 in list)
                    {
                        if (pair7.b)
                        {
                            num6++;
                        }
                        else
                        {
                            num7++;
                        }
                    }
                    PluginCore.cq.ah.b("/f [VT Fellow Manager] Vote total for " + key.ToString() + ": " + num6.ToString() + "/" + num7.ToString() + "  -v-");
                }
            }
            else
            {
                if ((string.Compare(str2, "location", true) != 0) || this.a(str))
                {
                    return;
                }
                bool flag3 = false;
                foreach (KeyValuePair<int, ar.a> pair8 in this.f.a)
                {
                    if (pair8.Value.b == str)
                    {
                        flag3 = true;
                        break;
                    }
                }
                if (flag3)
                {
                    PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] I am currently located in landcell: " + PluginCore.cq.p.d(PluginCore.cg).w.d().ToString("X8") + "  -v-");
                }
                else
                {
                    PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] Sorry, I can only send my location to members of the fellowship.  -v-");
                }
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
        if ((er.j("AutoFellowManagement") && PluginCore.cq.n.b) && !this.f.c())
        {
            if (this.m)
            {
                foreach (string str in this.k)
                {
                    PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] You have been dropped from the waiting list because I am no longer in the fellowship.");
                }
                this.m = false;
            }
            this.k.Clear();
            this.p.Clear();
            this.u.Clear();
            this.j.Clear();
            this.q.Clear();
            this.r.Clear();
        }
    }

    private void b()
    {
        if ((this.f.c() && (this.m && this.l)) && PluginCore.cq.n.b)
        {
            int num = 8 - this.f.a.Count;
            while ((num > this.u.Count) && (this.u.Count < this.k.Count))
            {
                int count = this.u.Count;
                this.u.Add(this.k[count], DateTimeOffset.Now + TimeSpan.FromMinutes(5.0));
                PluginCore.cq.ah.b("/t " + this.k[count] + ", [VT Fellow Manager] Your spot in the fellowship is now open. You have 5 minutes to come to where I am and tell me 'xp'.  -v-");
            }
            if (((this.k.Count == 0) && (this.u.Count == 0)) && (this.p.Count == 0))
            {
                this.a(this.n);
                this.m = false;
            }
            else
            {
                this.a(false);
            }
        }
    }

    private bool b(string A_0)
    {
        foreach (KeyValuePair<int, ar.a> pair in this.f.a)
        {
            if (string.Compare(pair.Value.b, A_0, true) == 0)
            {
                return true;
            }
        }
        return false;
    }

    private void b(object A_0, EventArgs A_1)
    {
        if ((er.j("AutoFellowManagement") && this.f.c()) && PluginCore.cq.n.b)
        {
            bool flag = this.f.b() == PluginCore.cg;
            if (flag != this.l)
            {
                this.l = flag;
                if (this.l)
                {
                    if (this.a())
                    {
                        int num = 0;
                        foreach (string str in this.k)
                        {
                            num++;
                            PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] I am now the fellowship leader, but the fellow is full. You have been put on the waiting list at position " + num.ToString() + "  -v-");
                        }
                        if (num > 0)
                        {
                            this.m = true;
                            this.a(false);
                            PluginCore.cq.ah.b("/f [VT Fellow Manager] Since the fellowship is full, a waiting list has been started. There are currently " + num.ToString() + " people on it.  -v-");
                        }
                        else
                        {
                            this.m = false;
                            this.p.Clear();
                            this.u.Clear();
                            this.a(this.n);
                        }
                    }
                    else
                    {
                        this.m = false;
                        this.p.Clear();
                        this.a(this.n);
                    }
                }
                else
                {
                    if (this.m)
                    {
                        string b = "????";
                        if (this.f.a.ContainsKey(this.f.b()))
                        {
                            b = this.f.a[this.f.b()].b;
                        }
                        foreach (string str3 in this.k)
                        {
                            PluginCore.cq.ah.b("/t " + str3 + ", [VT Fellow Manager] You have been dropped from the waiting list because I am no longer the fellowship leader. The new leader is: " + b + "  -v-");
                        }
                        this.m = false;
                    }
                    this.k.Clear();
                    this.p.Clear();
                    this.u.Clear();
                    this.j.Clear();
                    if (this.r.Count > 0)
                    {
                        PluginCore.cq.ah.b("/f [VT Fellow Manager] I am no longer the fellowship leader. All votes have been canceled.  -v-");
                    }
                    this.q.Clear();
                    this.r.Clear();
                }
            }
        }
    }

    private string c()
    {
        if (er.j("AutoFellowManagement"))
        {
            if (PluginCore.cq.n.n.b(ActionLockType.FellowRecruit))
            {
                return "";
            }
            foreach (KeyValuePair<int, ar.a> pair in this.f.a)
            {
                string b = pair.Value.b;
                if (this.k.Contains(b))
                {
                    this.k.Remove(b);
                }
                if (this.p.Contains(b))
                {
                    this.p.Remove(b);
                }
                if (this.u.ContainsKey(b))
                {
                    this.u.Remove(b);
                }
            }
            this.b();
            string str2 = "";
            if (!this.f.d() && !this.l)
            {
                this.t = 0;
                this.s = "";
                return "";
            }
            if (this.a())
            {
                if (this.m)
                {
                    foreach (string str3 in this.p)
                    {
                        if (!this.k.Contains(str3))
                        {
                            this.k.Add(str3);
                        }
                        int index = this.k.IndexOf(str3);
                        string[] strArray = new string[] { "/t ", str3, ", [VT Fellow Manager] Oops! Your spot has been taken! You are now back on the waiting list at position ", (index + 1).ToString(), " of ", this.k.Count.ToString(), "  -v-" };
                        PluginCore.cq.ah.b(string.Concat(strArray));
                    }
                    this.p.Clear();
                    foreach (KeyValuePair<string, DateTimeOffset> pair2 in this.u)
                    {
                        if (!this.k.Contains(pair2.Key))
                        {
                            this.k.Add(pair2.Key);
                        }
                        int num2 = this.k.IndexOf(pair2.Key);
                        string[] strArray2 = new string[] { "/t ", pair2.Key, ", [VT Fellow Manager] Oops! Your spot has been taken! You are now back on the waiting list at position ", (num2 + 1).ToString(), " of ", this.k.Count.ToString(), "  -v-" };
                        PluginCore.cq.ah.b(string.Concat(strArray2));
                    }
                    this.u.Clear();
                }
                else if (this.l)
                {
                    this.m = true;
                    for (int i = 0; i < this.k.Count; i++)
                    {
                        string[] strArray3 = new string[] { "/t ", this.k[i], ", [VT Fellow Manager] Oops! Your spot has been taken! You have been placed on the waiting list at position ", (i + 1).ToString(), "  -v-" };
                        PluginCore.cq.ah.b(string.Concat(strArray3));
                    }
                    if ((this.k.Count != 0) || (this.p.Count != 0))
                    {
                        this.a(false);
                    }
                }
                this.t = 0;
                this.s = "";
                return "";
            }
            if (!this.m && (this.k.Count > 0))
            {
                str2 = this.k[0];
            }
            else if (this.p.Count > 0)
            {
                str2 = this.p[0];
            }
            if (str2 == "")
            {
                this.t = 0;
                this.s = "";
                return "";
            }
            ReadOnlyCollection<cv> onlys = PluginCore.cq.p.c(str2);
            if (onlys.Count > 0)
            {
                foreach (cv cv in onlys)
                {
                    if ((cv.c() == ObjectClass.Player) && (dh.a(cv.k, PluginCore.cg, true) <= 0.041666666666666664))
                    {
                        this.w = cv.k;
                        return str2;
                    }
                }
            }
            if (this.s == str2)
            {
                this.t++;
                if (this.t > 15)
                {
                    if (this.t == 0x10)
                    {
                        PluginCore.cq.n.n.a(ActionLockType.FellowRecruit, TimeSpan.FromSeconds(20.0));
                        PluginCore.cq.ah.b("/t " + str2 + ", [VT Fellow Manager] You are too far away. I will wait 20 seconds and give you one more chance.  -v-");
                    }
                    else if ((this.t <= 0x10) || (this.t > 30))
                    {
                        PluginCore.cq.ah.b("/t " + str2 + ", [VT Fellow Manager] I'm sorry, but I couldn't recruit you. Please try again.  -v-");
                        this.s = "";
                        this.t = 0;
                        if (this.k.Contains(str2))
                        {
                            this.k.Remove(str2);
                        }
                        if (this.p.Contains(str2))
                        {
                            this.p.Remove(str2);
                        }
                        if (this.u.ContainsKey(str2))
                        {
                            this.u.Remove(str2);
                        }
                        this.b();
                    }
                }
            }
            else
            {
                this.s = str2;
                this.t = 0;
            }
        }
        return "";
    }

    public void c(string A_0)
    {
        if (this.l)
        {
            foreach (KeyValuePair<int, ar.a> pair in this.f.a)
            {
                if (string.Compare(pair.Value.b, A_0, true) == 0)
                {
                    dh.g(pair.Key);
                }
            }
        }
    }

    private void c(object A_0, EventArgs A_1)
    {
        if ((er.j("AutoFellowManagement") && PluginCore.cq.n.b) && (this.o != this.f.a.Count))
        {
            this.o = this.f.a.Count;
            List<string> list = new List<string>();
            foreach (KeyValuePair<int, ar.a> pair in this.f.a)
            {
                string b = pair.Value.b;
                list.Add(b);
                if (this.k.Contains(b))
                {
                    this.k.Remove(b);
                }
                if (this.p.Contains(b))
                {
                    this.p.Remove(b);
                }
                if (this.u.ContainsKey(b))
                {
                    this.u.Remove(b);
                }
            }
            foreach (KeyValuePair<y.b, List<MyPair<string, bool>>> pair2 in this.r)
            {
                for (int i = pair2.Value.Count - 1; i >= 0; i--)
                {
                    if (!list.Contains(pair2.Value[i].a))
                    {
                        pair2.Value.RemoveAt(i);
                    }
                }
            }
            this.b();
        }
    }

    private void d()
    {
        this.g();
    }

    public void d(string A_0)
    {
        if (this.l)
        {
            foreach (KeyValuePair<int, ar.a> pair in this.f.a)
            {
                if (string.Compare(pair.Value.b, A_0, true) == 0)
                {
                    dh.h(pair.Key);
                }
            }
        }
    }

    private void d(object A_0, EventArgs A_1)
    {
        if (((this.f.c() && PluginCore.cq.n.b) && er.j("AutoFellowManagement")) && this.l)
        {
            if (this.m)
            {
                List<string> list = new List<string>();
                foreach (KeyValuePair<string, DateTimeOffset> pair in this.u)
                {
                    if (pair.Value <= DateTimeOffset.Now)
                    {
                        list.Add(pair.Key);
                    }
                }
                foreach (string str in list)
                {
                    PluginCore.cq.ah.b("/t " + str + ", [VT Fellow Manager] Your spot in the fellowship has expired. You have been removed from the list.  -v-");
                    if (this.k.Contains(str))
                    {
                        this.k.Remove(str);
                    }
                    if (this.p.Contains(str))
                    {
                        this.p.Remove(str);
                    }
                    if (this.u.ContainsKey(str))
                    {
                        this.u.Remove(str);
                    }
                }
                this.b();
            }
            List<y.b> list2 = new List<y.b>();
            foreach (KeyValuePair<y.b, List<MyPair<string, bool>>> pair2 in this.r)
            {
                int num;
                int num2;
                if (pair2.Key.c <= DateTimeOffset.Now)
                {
                    list2.Add(pair2.Key);
                    num = 0;
                    num2 = 0;
                    foreach (MyPair<string, bool> pair3 in pair2.Value)
                    {
                        if (pair3.b)
                        {
                            num++;
                        }
                        else
                        {
                            num2++;
                        }
                    }
                    if (num <= ((num + num2) / 2))
                    {
                        goto Label_02E8;
                    }
                    PluginCore.cq.ah.b("/f [VT Fellow Manager] Vote " + pair2.Key.ToString() + " passed (" + num.ToString() + "/" + num2.ToString() + ").  -v-");
                    switch (pair2.Key.a)
                    {
                        case y.a.a:
                            this.d(pair2.Key.b);
                            break;

                        case y.a.b:
                            this.e(pair2.Key.b);
                            break;

                        case y.a.c:
                            this.c(pair2.Key.b);
                            break;

                        case y.a.d:
                            if (string.Compare(pair2.Key.b, "true") != 0)
                            {
                                goto Label_02DF;
                            }
                            this.n = true;
                            break;
                    }
                }
                continue;
            Label_02DF:
                this.n = false;
                continue;
            Label_02E8:;
                PluginCore.cq.ah.b("/f [VT Fellow Manager] Vote " + pair2.Key.ToString() + " failed (" + num.ToString() + "/" + num2.ToString() + ").  -v-");
            }
            foreach (y.b b in list2)
            {
                this.r.Remove(b);
            }
        }
    }

    public void e()
    {
        if (!this.i)
        {
            this.i = true;
            GC.SuppressFinalize(this);
            CoreManager.get_Current().remove_ChatBoxMessage(new EventHandler<ChatTextInterceptEventArgs>(this.a));
            this.f.g(new EventHandler(this.b));
            this.f.e(new EventHandler(this.a));
            this.f.c(new EventHandler(this.c));
            this.g.b(new EventHandler(this.d));
            PluginCore.PC.ProfileChanged -= new PluginCore.EmptyDelegate(this.d);
            a.b("fvote");
            this.g.e();
        }
    }

    public void e(string A_0)
    {
        if (this.l)
        {
            string item = A_0.ToLowerInvariant();
            if (!this.j.Contains(item))
            {
                this.j.Add(item);
            }
            this.d(A_0);
        }
    }

    public void f()
    {
        if (this.s != this.v)
        {
            this.s = this.v;
            this.t = 0;
        }
        this.t++;
        if (this.t > 30)
        {
            string v = this.v;
            PluginCore.cq.ah.b("/t " + v + ", [VT Fellow Manager] I'm sorry, but I couldn't recruit you. Please try again.  -v-");
            this.s = "";
            if (this.k.Contains(v))
            {
                this.k.Remove(v);
            }
            if (this.p.Contains(v))
            {
                this.p.Remove(v);
            }
            if (this.u.ContainsKey(v))
            {
                this.u.Remove(v);
            }
            this.b();
        }
        else
        {
            dh.f(this.w);
        }
    }

    public void g()
    {
        if ((PluginCore.cq.n.b && er.j("AutoFellowManagement")) && this.f.c())
        {
            this.a(null, (EventArgs) null);
            this.b(null, null);
            this.c(null, null);
            if (((this.k.Count == 0) && (this.u.Count == 0)) && (this.p.Count == 0))
            {
                this.a(this.n);
                this.m = false;
            }
            else
            {
                this.a(false);
            }
        }
    }

    public bool h()
    {
        this.v = this.c();
        return (this.v != "");
    }

    private enum a
    {
        a,
        b,
        c,
        d
    }

    private class b : IComparable<y.b>
    {
        public y.a a;
        public string b;
        public DateTimeOffset c;
        private static int d = 1;
        public int e = d;

        public b()
        {
            d++;
        }

        public override string a()
        {
            string str = "";
            switch (this.a)
            {
                case y.a.a:
                    str = "Kick";
                    break;

                case y.a.b:
                    str = "Ban";
                    break;

                case y.a.c:
                    str = "GiveLeader";
                    break;

                case y.a.d:
                    str = "SetOpen";
                    break;
            }
            return ("'" + str + " " + this.b + "' (ID " + this.e.ToString() + ")");
        }

        public int a(y.b A_0)
        {
            int num = this.a.CompareTo(A_0.a);
            if (num != 0)
            {
                return num;
            }
            return this.b.CompareTo(A_0.b);
        }
    }
}

