using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System;
using uTank2;

internal class a7 : dr
{
    private bool a;
    private int b;
    private int c;
    private string d;

    public a7(CoreManager A_0)
    {
        PluginCore.PC.a(new uTank2.PluginCore.a(this.a));
    }

    public override void a()
    {
        base.a();
        if (!this.a)
        {
            this.a = true;
            PluginCore.PC.b(new uTank2.PluginCore.a(this.a));
        }
    }

    private void a(object A_0, NetworkMessageEventArgs A_1)
    {
        try
        {
            MessageStruct struct2;
            switch (this.c())
            {
                case dr.b.b:
                    if (A_1.get_Message().get_Type() == 0xf74c)
                    {
                        try
                        {
                            if ((((A_1.get_Message().Value<int>("object") != PluginCore.cq.aw.get_CharacterFilter().get_Id()) || (A_1.get_Message().Value<short>("activity") != 0)) || ((A_1.get_Message().Value<byte>("animation_type") != 0) || (A_1.get_Message().Value<byte>("type_flags") != 0))) || (((A_1.get_Message().Value<short>("stance") != 0x3d) || ((A_1.get_Message().Value<int>("flags") & 0xf80) == 0)) || (A_1.get_Message().Struct("animations").Struct(0).Value<short>("animation") != 0x7e)))
                            {
                                return;
                            }
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        this.a(dr.b.c);
                    }
                    return;

                case dr.b.c:
                    if (A_1.get_Message().get_Type() == 0xf745)
                    {
                        struct2 = A_1.get_Message().Struct("game");
                        if (struct2.Value<string>("name") == this.d)
                        {
                            break;
                        }
                    }
                    return;

                default:
                    return;
            }
            if (((struct2.Value<int>("flags1") & 0x4000) != 0) && (struct2.Value<int>("container") == PluginCore.cg))
            {
                this.a(dr.b.a);
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    public MyPair<int, int> a(string A_0, int A_1)
    {
        if (dh.a(A_0) < A_1)
        {
            try
            {
                MyList<v> list = PluginCore.cq.x.c["CraftInteractions"].b(2, k.a(A_0));
                if (list.Count != 0)
                {
                    foreach (v v in list)
                    {
                        if (k.e(v[6]) != 0)
                        {
                            CharFilterSkillType type = (CharFilterSkillType) k.e(v[6]);
                            if (PluginCore.cq.aw.get_CharacterFilter().get_Skills().get_Item(type).get_Training() == null)
                            {
                                return null;
                            }
                        }
                        string str = k.b(v[0]);
                        string str2 = k.b(v[1]);
                        MyPair<int, int> pair = this.a(str, 1);
                        if (pair != null)
                        {
                            return pair;
                        }
                        pair = this.a(str2, 1);
                        if (pair != null)
                        {
                            return pair;
                        }
                        int num = dh.b(str);
                        int num2 = dh.b(str2);
                        if ((num != 0) && (num2 != 0))
                        {
                            return new MyPair<int, int> { a = num, b = num2 };
                        }
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        return null;
    }

    public void a(int A_0, int A_1, string A_2)
    {
        if (((this.c() == dr.b.a) && dh.b(A_0)) && dh.b(A_1))
        {
            this.b = A_0;
            this.c = A_1;
            this.d = A_2;
            this.a(dr.b.b);
        }
    }

    protected override void b()
    {
        int num = PluginCore.cq.ax.get_Actions().get_CurrentSelection();
        PluginCore.cq.ax.get_Actions().SelectItem(this.c);
        PluginCore.cq.ax.get_Actions().UseItem(this.b, 1);
        PluginCore.cq.ax.get_Actions().SelectItem(num);
    }
}

