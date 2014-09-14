using Decal.Adapter.Wrappers;
using System;
using VirindiHotkeySystem;

internal class aa
{
    public bool a;
    public bool b;
    public string c;
    public bool d;
    public string e;
    public int f;

    public aa(HotkeyWrapper A_0)
    {
        this.a = A_0.get_AltState();
        this.b = A_0.get_ControlState();
        this.c = A_0.get_Description();
        this.d = A_0.get_ShiftState();
        this.e = A_0.get_Title();
        this.f = A_0.get_VirtualKey();
    }

    public aa(string A_0, string A_1)
    {
        this.e = A_0;
        this.c = A_1;
    }

    public aa(string A_0, string A_1, int A_2, bool A_3, bool A_4, bool A_5)
    {
        this.a = A_3;
        this.b = A_4;
        this.c = A_1;
        this.d = A_5;
        this.e = A_0;
        this.f = A_2;
    }

    public VHotkeyInfo a()
    {
        return new VHotkeyInfo("VTank", true, this.e, this.c, this.f, this.a, this.b, this.d);
    }

    public HotkeyWrapper b()
    {
        return new HotkeyWrapper("VTank: " + this.e, this.c, this.f, this.a, this.b, this.d);
    }
}

