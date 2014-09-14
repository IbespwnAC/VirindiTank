using Decal.Adapter;
using Decal.Adapter.Wrappers;
using Decal.Interop.Core;
using Decal.Interop.Filters;
using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using uTank2;

internal static class dh
{
    private static CombatState a = 1;
    private static DateTimeOffset b = DateTimeOffset.MinValue;
    private static bool c = false;
    internal static int d = 0x4c65e4;
    internal static int e = 0x193874;

    public static int a()
    {
        return (int) (((float) PluginCore.cq.aw.get_CharacterFilter().get_Age()) / 0.895f);
    }

    public static void a(CombatState A_0)
    {
        a = PluginCore.cq.ax.get_Actions().get_CombatMode();
        b = DateTimeOffset.Now;
        c = true;
        PluginCore.cq.ax.get_Actions().SetCombatMode(A_0);
    }

    public static sCoord a(WorldObject A_0)
    {
        CoordsObject obj2 = A_0.Coordinates();
        if (obj2 == null)
        {
            return sCoord.NoWhere;
        }
        Vector3Object obj3 = A_0.RawCoordinates();
        if (obj3 == null)
        {
            return sCoord.NoWhere;
        }
        return new sCoord { x = obj2.get_EastWest(), y = obj2.get_NorthSouth(), z = obj3.get_Z() / 240.0 };
    }

    internal static bool a(bool A_0)
    {
        int num;
        if (A_0)
        {
            num = 1;
        }
        else
        {
            num = 0;
        }
        int num2 = f("2a688d2c3d66891b73d734a99e3154d2");
        if (num2 == 0)
        {
            return false;
        }
        IntPtr ptr = new IntPtr(num2);
        dh.f delegateForFunctionPointer = (dh.f) Marshal.GetDelegateForFunctionPointer(ptr, typeof(dh.f));
        delegateForFunctionPointer(num);
        return true;
    }

    public static double a(double A_0)
    {
        double num = A_0;
        while ((num < 0.0) || (num >= 360.0))
        {
            if (num >= 360.0)
            {
                num -= 360.0;
            }
            else
            {
                num += 360.0;
            }
        }
        return num;
    }

    public static bool a(int A_0)
    {
        if (!PluginCore.cq.ax.get_Actions().IsValidObject(A_0))
        {
            return false;
        }
        if (!PluginCore.cq.p.i.ContainsKey(A_0))
        {
            return false;
        }
        return true;
    }

    public static unsafe bool a(float A_0)
    {
        int* numPtr = (int*) f("0dce56812beda3840a566ebca2c1c568");
        if (numPtr == IntPtr.Zero.ToPointer())
        {
            return false;
        }
        int num = numPtr[0];
        num[0x4c] = (int) A_0;
        return true;
    }

    public static int a(string A_0)
    {
        MyList<int> list = d(A_0);
        int num = 0;
        foreach (int num2 in list)
        {
            WorldObject obj2 = PluginCore.cq.aw.get_WorldFilter().get_Item(num2);
            if (obj2.Exists(0xd000006))
            {
                int num3 = obj2.Values(0xd000006, 1);
                num += num3;
            }
            else
            {
                num++;
            }
        }
        return num;
    }

    public static eTrainingType a(eGameSkillID A_0)
    {
        SkillInfo o = null;
        eTrainingType type;
        try
        {
            o = PluginCore.cq.aw.get_CharacterFilter().get_Underlying().get_Skill((eSkillID) A_0);
            type = o.get_Training();
        }
        finally
        {
            if (o != null)
            {
                Marshal.ReleaseComObject(o);
                o = null;
            }
        }
        return type;
    }

    public static int a(eRechargeVital_Single A_0)
    {
        float num4;
        int num = 0;
        int num2 = 1;
        switch (A_0)
        {
            case eRechargeVital_Single.Stamina:
                num = PluginCore.cq.ax.get_Actions().get_Vital().get_Item(4);
                num2 = PluginCore.cq.ax.get_Actions().get_Vital().get_Item(3);
                break;

            case eRechargeVital_Single.Mana:
                num = PluginCore.cq.ax.get_Actions().get_Vital().get_Item(6);
                num2 = PluginCore.cq.ax.get_Actions().get_Vital().get_Item(5);
                break;

            default:
                num = PluginCore.cq.ax.get_Actions().get_Vital().get_Item(2);
                num2 = PluginCore.cq.ax.get_Actions().get_Vital().get_Item(1);
                break;
        }
        float num3 = num2 - num;
        if (PluginCore.cq.ax.get_Actions().get_CombatMode() == 1)
        {
            num4 = 2f;
        }
        else
        {
            num4 = 2.6f;
        }
        return (int) Math.Ceiling((double) (num4 * num3));
    }

    private static double a(double A_0, double A_1)
    {
        double num3;
        double num = A_0;
        double num2 = A_1;
        if (num == 0.0)
        {
            if (num2 == 0.0)
            {
                num3 = 270.0;
            }
            else
            {
                num3 = 90.0;
            }
        }
        else if (num > 0.0)
        {
            if (num2 >= 0.0)
            {
                num3 = Math.Abs((double) ((Math.Atan(num2 / num) * 180.0) / 3.1415926535897931));
            }
            else
            {
                num3 = 360.0 - Math.Abs((double) ((Math.Atan(num2 / num) * 180.0) / 3.1415926535897931));
            }
        }
        else if (num2 >= 0.0)
        {
            num3 = 180.0 - Math.Abs((double) ((Math.Atan(num2 / num) * 180.0) / 3.1415926535897931));
        }
        else
        {
            num3 = 180.0 + Math.Abs((double) ((Math.Atan(num2 / num) * 180.0) / 3.1415926535897931));
        }
        return a(num3);
    }

    public static sCoord a(int A_0, HooksWrapper A_1)
    {
        if (!PluginCore.cq.ax.get_Actions().IsValidObject(A_0))
        {
            return sCoord.NoWhere;
        }
        int num = A_1.PhysicsObject(A_0).ToInt32();
        if (num == 0)
        {
            return sCoord.NoWhere;
        }
        float num2 = num[0x84];
        float num3 = num[0x88];
        float num4 = num[140];
        int num5 = num[0x4c];
        return a((double) num2, (double) num3, (double) (num4 / 240f), num5);
    }

    public static unsafe int a(int A_0, bool A_1)
    {
        int num = PluginCore.cq.ax.get_Actions().WeenieObject(PluginCore.cg).ToInt32();
        if (num == 0)
        {
            return 0;
        }
        int num2 = 0;
        if (!A_1)
        {
            num2 = 1;
        }
        int num3 = f("53206ac42f1fde4291705f53a44be5df");
        if (num3 == 0)
        {
            return 0;
        }
        int num4 = *((int*) (((IntPtr) num) + (((IntPtr) (num3 / 4)) * 4)));
        dh.d delegateForFunctionPointer = (dh.d) Marshal.GetDelegateForFunctionPointer((IntPtr) f("db5ff26ac4680fc26c2d021bfe6a432d"), typeof(dh.d));
        int num6 = 0;
        delegateForFunctionPointer(num4, A_0, out num6, num2);
        return num6;
    }

    public static double a(int A_0, int A_1)
    {
        if (!PluginCore.cq.ax.get_Actions().IsValidObject(A_0))
        {
            return double.MaxValue;
        }
        if (!PluginCore.cq.ax.get_Actions().IsValidObject(A_1))
        {
            return double.MaxValue;
        }
        sCoord coord = a(A_0, PluginCore.cq.ax.get_Actions());
        sCoord coord2 = a(A_1, PluginCore.cq.ax.get_Actions());
        return a(coord.x * 240.0, coord.y * 240.0, coord.z * 240.0, (double) l(A_0), (double) k(A_0), coord2.x * 240.0, coord2.y * 240.0, coord2.z * 240.0, (double) l(A_1), (double) k(A_1));
    }

    public static bool a(int A_0, float A_1)
    {
        int num = f("fe0a10f2f1fae4c7d48f1d508eb673ae");
        int num2 = f("0dce56812beda3840a566ebca2c1c568");
        if ((num == 0) || (num2 == 0))
        {
            return false;
        }
        IntPtr ptr = new IntPtr(num);
        dh.j delegateForFunctionPointer = (dh.j) Marshal.GetDelegateForFunctionPointer(ptr, typeof(dh.j));
        int num3 = num2[0];
        delegateForFunctionPointer(num3, A_0, A_1);
        return true;
    }

    public static double a(int A_0, eRechargeVital_Single A_1)
    {
        return c(PluginCore.cq.ax.get_Actions().get_Skill().get_Item(0x15) + A_0, a(A_1));
    }

    private static unsafe IntPtr a(IntPtr A_0, int A_1)
    {
        try
        {
            if (A_0 == IntPtr.Zero)
            {
                return IntPtr.Zero;
            }
            int* numPtr = (int*) A_0;
            numPtr = (int*) numPtr[0];
            if (numPtr == null)
            {
                return IntPtr.Zero;
            }
            numPtr = (int*) ((((int) numPtr) + (A_1 * 4)) + 12);
            if (numPtr == null)
            {
                return IntPtr.Zero;
            }
            numPtr = (int*) numPtr[0];
            if (numPtr == null)
            {
                return IntPtr.Zero;
            }
            return (IntPtr) numPtr;
        }
        catch
        {
            return IntPtr.Zero;
        }
    }

    private static void a(object A_0, NetworkMessageEventArgs A_1)
    {
        if ((((c && (A_1.get_Message().get_Type() == 0xf74c)) && (A_1.get_Message().Value<int>("object") == PluginCore.cg)) && (A_1.get_Message().Value<byte>("animation_type") == 0)) && (A_1.get_Message().Value<uint>("flags") == 0))
        {
            b = DateTimeOffset.Now;
            c = false;
        }
    }

    public static int a(eGameSkillID A_0, bool A_1)
    {
        if (!Enum.IsDefined(typeof(eGameSkillID), (int) A_0))
        {
            return 0;
        }
        int num = a((int) A_0, A_1);
        switch (A_0)
        {
            case eGameSkillID.CreatureEnchantment:
            case eGameSkillID.ItemEnchantment:
            case eGameSkillID.LifeMagic:
            case eGameSkillID.WarMagic:
            case eGameSkillID.VoidMagic:
            {
                cv cv = PluginCore.cq.p.d(PluginCore.cg);
                if ((cv != null) && (cv.a(dt.cb, 0) > 0))
                {
                    num += 10;
                }
                return num;
            }
            case eGameSkillID.Leadership:
            case eGameSkillID.Loyalty:
            case eGameSkillID.Fletching:
            case eGameSkillID.Alchemy:
            case eGameSkillID.Cooking:
            case eGameSkillID.Salvaging:
            case ((eGameSkillID) 0x2a):
                return num;

            case eGameSkillID.TwoHandedCombat:
            case eGameSkillID.HeavyWeapons:
            case eGameSkillID.LightWeapons:
            case eGameSkillID.FinesseWeapons:
            {
                cv cv2 = PluginCore.cq.p.d(PluginCore.cg);
                if ((cv2 != null) && (cv2.a(dt.ca, 0) > 0))
                {
                    num += 10;
                }
                return num;
            }
        }
        return num;
    }

    public static double a(sCoord A_0, sCoord A_1)
    {
        if (A_0.invalid || A_1.invalid)
        {
            return 9999999.0;
        }
        double num = A_0.x - A_1.x;
        double num2 = A_0.y - A_1.y;
        double num3 = A_0.z - A_1.z;
        return Math.Sqrt(((num * num) + (num2 * num2)) + (num3 * num3));
    }

    internal static void a(int A_0, bool A_1, int A_2)
    {
        if ((A_2 < 0) || (A_2 > 2))
        {
            A_1 = false;
        }
        if (!A_1)
        {
            A_2 = 2;
        }
        int num = 0;
        if (!A_1)
        {
            num = 1;
        }
        int num2 = 0;
        if (A_1)
        {
            num2 = 1;
        }
        int num3 = f("91e54efac7288ed8cee2640123ab64db");
        int num4 = 0;
        try
        {
            num4 = f("9f36187ce96fbc3eae90d48eb4fe8f67");
        }
        catch
        {
        }
        if (num4 == 0)
        {
            num4 = d ^ e;
        }
        dh.k delegateForFunctionPointer = (dh.k) Marshal.GetDelegateForFunctionPointer(new IntPtr(num4), typeof(dh.k));
        delegateForFunctionPointer(num3[0], A_0, A_2, num, num2, 0, 0);
    }

    public static double a(int A_0, int A_1, bool A_2)
    {
        return a(a(A_0, PluginCore.cq.ax.get_Actions()), a(A_1, PluginCore.cq.ax.get_Actions()), A_2);
    }

    internal static unsafe bool a(string A_0, bool A_1, PluginHost A_2)
    {
        int num3;
        int num = f("89eadf284c1d426b39561f6d318c583b");
        int num2 = f("aa442292878b3cd80c4e2c2779faaa71");
        if (num == 0)
        {
            return false;
        }
        if (num2 == 0)
        {
            return false;
        }
        if (A_1)
        {
            num3 = 1;
        }
        else
        {
            num3 = 0;
        }
        if (string.IsNullOrEmpty(A_0))
        {
            return false;
        }
        string str = g(A_0);
        if (string.IsNullOrEmpty(str))
        {
            return false;
        }
        IntPtr ptr = new IntPtr(num);
        IntPtr ptr2 = new IntPtr(num2);
        dh.i delegateForFunctionPointer = (dh.i) Marshal.GetDelegateForFunctionPointer(ptr, typeof(dh.i));
        dh.c c = (dh.c) Marshal.GetDelegateForFunctionPointer(ptr2, typeof(dh.c));
        void* voidPtr = null;
        delegateForFunctionPointer((int) ((IntPtr) &voidPtr), str);
        c((int) ((IntPtr) &voidPtr), num3);
        int* numPtr = (int*) (((int) voidPtr) + 4);
        Interlocked.Decrement(ref (int) ref numPtr);
        void* voidPtr2 = *((void**) voidPtr);
        voidPtr2 = *((void**) voidPtr2);
        dh.a a = (dh.a) Marshal.GetDelegateForFunctionPointer(new IntPtr(voidPtr2), typeof(dh.a));
        a((int) voidPtr, 1);
        return true;
    }

    public static double a(sCoord A_0, sCoord A_1, bool A_2)
    {
        if ((A_0 == sCoord.NoWhere) || (A_1 == sCoord.NoWhere))
        {
            return 9999999.0;
        }
        if (A_2)
        {
            double num = A_0.x - A_1.x;
            double num2 = A_0.y - A_1.y;
            double num3 = A_0.z - A_1.z;
            return Math.Sqrt(((num * num) + (num2 * num2)) + (num3 * num3));
        }
        double num4 = A_0.x - A_1.x;
        double num5 = A_0.y - A_1.y;
        return Math.Sqrt((num4 * num4) + (num5 * num5));
    }

    public static double a(sCoord A_0, sCoord A_1, sCoord A_2)
    {
        sCoord coord = b(A_0, A_1, A_2);
        double num = a(coord, A_1);
        double num2 = a(coord, A_2);
        double num3 = a(A_1, A_2);
        if (Math.Abs((double) ((num + num2) - num3)) < 1E-05)
        {
            return a(A_0, coord);
        }
        double num4 = a(A_0, A_1);
        double num5 = a(A_0, A_2);
        if (num4 < num5)
        {
            return num4;
        }
        return num5;
    }

    public static sCoord a(double A_0, double A_1, double A_2, int A_3)
    {
        sCoord coord = new sCoord();
        int num = ((int) Math.Floor((double) (((double) A_3) / 16777216.0))) & 0xff;
        int num2 = ((int) Math.Floor((double) (((double) A_3) / 65536.0))) & 0xff;
        double num3 = ((((num2 - 0x7f) * 192.0) + A_1) - 84.0) / 240.0;
        double num4 = ((((num - 0x7f) * 192.0) + A_0) - 84.0) / 240.0;
        coord.x = num4;
        coord.y = num3;
        coord.z = A_2;
        return coord;
    }

    public static void a(double A_0, double A_1, double A_2, out double A_3, out double A_4, out double A_5)
    {
        double num = Math.Sqrt(((A_0 * A_0) + (A_1 * A_1)) + (A_2 * A_2));
        if (num == 0.0)
        {
            A_3 = 1.0;
            A_4 = 0.0;
            A_5 = 0.0;
        }
        else
        {
            A_3 = A_0 / num;
            A_4 = A_1 / num;
            A_5 = A_2 / num;
        }
    }

    public static double a(double A_0, double A_1, double A_2, double A_3, double A_4, double A_5, double A_6, double A_7, double A_8, double A_9)
    {
        double num = A_0 - A_5;
        double num2 = A_1 - A_6;
        double num3 = A_2 - A_7;
        double num4 = Math.Sqrt(((num * num) + (num2 * num2)) + (num3 * num3));
        double num5 = A_0 - A_5;
        double num6 = A_1 - A_6;
        double num7 = A_2 - A_7;
        a(num5, num6, num7, out num5, out num6, out num7);
        num = num5 * A_3;
        num2 = num6 * A_3;
        num3 = num7 * A_4;
        num4 -= Math.Sqrt(((num * num) + (num2 * num2)) + (num3 * num3));
        num = num5 * A_8;
        num2 = num6 * A_8;
        num3 = num7 * A_9;
        return (num4 - Math.Sqrt(((num * num) + (num2 * num2)) + (num3 * num3)));
    }

    private static ACHooks b()
    {
        return PluginCore.cq.ax.get_Underlying().get_Hooks();
    }

    internal static bool b(bool A_0)
    {
        int num;
        if (A_0)
        {
            num = 1;
        }
        else
        {
            num = 0;
        }
        int num2 = f("754666c0c0746a266899ed2318a533ab");
        if (num2 == 0)
        {
            return false;
        }
        IntPtr ptr = new IntPtr(num2);
        dh.f delegateForFunctionPointer = (dh.f) Marshal.GetDelegateForFunctionPointer(ptr, typeof(dh.f));
        delegateForFunctionPointer(num);
        return true;
    }

    public static bool b(int A_0)
    {
        if (!PluginCore.cq.ax.get_Actions().IsValidObject(A_0))
        {
            return false;
        }
        if (PluginCore.cq.aw.get_WorldFilter().get_Item(A_0) == null)
        {
            return false;
        }
        return true;
    }

    public static int b(string A_0)
    {
        MyList<int> list = d(A_0);
        int num = 0;
        int num2 = 0;
        int num3 = 0x7fffffff;
        foreach (int num4 in list)
        {
            WorldObject obj2 = PluginCore.cq.aw.get_WorldFilter().get_Item(num4);
            if (obj2.Exists(0xd000006))
            {
                int num5 = obj2.Values(0xd000006, 1);
                num += num5;
                if (num5 < num3)
                {
                    num3 = num5;
                    num2 = num4;
                }
            }
            else
            {
                num++;
                if (1 < num3)
                {
                    num3 = 1;
                    num2 = num4;
                }
            }
        }
        if (num == 0)
        {
            return 0;
        }
        return num2;
    }

    public static bool b(eGameSkillID A_0)
    {
        eTrainingType type = a(A_0);
        if (type != 2)
        {
            return (type == 3);
        }
        return true;
    }

    public static double b(double A_0, double A_1)
    {
        double num;
        double num2;
        if (A_0 >= A_1)
        {
            num = A_0;
            num2 = A_1;
        }
        else
        {
            num = A_1;
            num2 = A_0;
        }
        double num3 = num - num2;
        double num4 = (num2 - num) + 360.0;
        if (num3 < num4)
        {
            return num3;
        }
        return num4;
    }

    public static unsafe void b(int A_0, int A_1)
    {
        IntPtr iUnknownForObject = Marshal.GetIUnknownForObject(PluginCore.cq.ax.get_Underlying().get_Hooks());
        IntPtr zero = IntPtr.Zero;
        Guid iid = new Guid("67AFC283-4A3C-4d5d-86C0-3EA230687FFE");
        Marshal.QueryInterface(iUnknownForObject, ref iid, out zero);
        int* numPtr = (int*) zero;
        numPtr = (int*) numPtr[0];
        numPtr = (int*) (((int) numPtr) + 0x10);
        numPtr = (int*) numPtr[0];
        if (numPtr != null)
        {
            m delegateForFunctionPointer = (m) Marshal.GetDelegateForFunctionPointer((IntPtr) numPtr, typeof(m));
            delegateForFunctionPointer(zero, A_1, A_0);
        }
        Marshal.Release(zero);
        Marshal.Release(iUnknownForObject);
    }

    public static double b(sCoord A_0, sCoord A_1)
    {
        double num = A_1.y - A_0.y;
        double num2 = A_1.x - A_0.x;
        return a(num, num2);
    }

    public static sCoord b(sCoord A_0, sCoord A_1, sCoord A_2)
    {
        bool flag = A_1.x == A_2.x;
        bool flag2 = A_1.y == A_2.y;
        bool flag3 = A_1.z == A_2.z;
        sCoord coord = new sCoord(A_0.x, A_0.y, A_0.z);
        sCoord coord2 = new sCoord(A_1.x, A_1.y, A_1.z);
        sCoord coord3 = new sCoord(A_2.x, A_2.y, A_2.z);
        int num = 0;
        if ((flag && flag2) && flag3)
        {
            return new sCoord(A_1.x, A_1.y, A_1.z);
        }
        if (flag2 && flag3)
        {
            return new sCoord(A_0.x, A_1.y, A_1.z);
        }
        if (flag && flag3)
        {
            return new sCoord(A_1.x, A_0.y, A_1.z);
        }
        if (flag && flag2)
        {
            return new sCoord(A_1.x, A_1.y, A_0.z);
        }
        if (flag2)
        {
            double num2 = coord.y;
            coord.y = coord.x;
            coord.x = num2;
            num2 = coord2.y;
            coord2.y = coord2.x;
            coord2.x = num2;
            num2 = coord3.y;
            coord3.y = coord3.x;
            coord3.x = num2;
            num = 1;
        }
        else if (flag3)
        {
            double num3 = coord.z;
            coord.z = coord.x;
            coord.x = num3;
            num3 = coord2.z;
            coord2.z = coord2.x;
            coord2.x = num3;
            num3 = coord3.z;
            coord3.z = coord3.x;
            coord3.x = num3;
            num = 2;
        }
        double num4 = coord2.x - coord3.x;
        double num5 = coord2.y - coord3.y;
        double num6 = coord2.z - coord3.z;
        double num7 = ((coord.x * num4) + (coord.y * num5)) + (coord.z * num6);
        double num8 = -num4 / num5;
        double num9 = coord2.x + (coord2.y * num8);
        double num10 = -num6 / num5;
        double num11 = coord2.z + (coord2.y * num10);
        double z = (((num4 * ((num8 * num11) - (num9 * num10))) - (num5 * num11)) + (num7 * num10)) / (((num4 * num8) - num5) + (num6 * num10));
        double y = (num11 - z) / num10;
        double x = num9 - (num8 * y);
        switch (num)
        {
            case 0:
                return new sCoord(x, y, z);

            case 1:
                return new sCoord(y, x, z);
        }
        return new sCoord(z, y, x);
    }

    public static bool c()
    {
        int num = f("0e287bb4b483917ff6a8183b989002fe");
        int num2 = f("0dce56812beda3840a566ebca2c1c568");
        if ((num == 0) || (num2 == 0))
        {
            return false;
        }
        IntPtr ptr = new IntPtr(num);
        dh.e delegateForFunctionPointer = (dh.e) Marshal.GetDelegateForFunctionPointer(ptr, typeof(dh.e));
        int num3 = num2[0];
        delegateForFunctionPointer(num3);
        return true;
    }

    public static int c(int A_0)
    {
        try
        {
            if (!b(A_0))
            {
                return 0;
            }
            WorldObject obj2 = PluginCore.cq.aw.get_WorldFilter().get_Item(A_0);
            if (obj2.get_Container() == 0)
            {
                if (PluginCore.cq.av.g.Contains(A_0))
                {
                    return PluginCore.cg;
                }
                return 0;
            }
            int num = obj2.get_Container();
            int num2 = A_0;
            int num3 = 0;
            while (num != 0)
            {
                if (num == PluginCore.cg)
                {
                    return PluginCore.cg;
                }
                num3++;
                if ((num3 > 20) || (num2 == num))
                {
                    return num2;
                }
                num2 = num;
                num = PluginCore.cq.aw.get_WorldFilter().get_Item(num).get_Container();
            }
            return num2;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public static int c(string A_0)
    {
        MyList<int> list = d(A_0);
        bool flag = true;
        int num = 0;
        int num2 = -2147483648;
        foreach (int num3 in list)
        {
            WorldObject obj2 = PluginCore.cq.aw.get_WorldFilter().get_Item(num3);
            if (obj2.Exists(0xd000006))
            {
                int num4 = obj2.Values(0xd000006, 1);
                flag = false;
                if (num4 > num2)
                {
                    num2 = num4;
                    num = num3;
                }
            }
            else
            {
                flag = false;
                if (1 > num2)
                {
                    num2 = 1;
                    num = num3;
                }
            }
        }
        if (flag)
        {
            return 0;
        }
        return num;
    }

    public static bool c(double A_0, double A_1)
    {
        return (b(a((double) (A_0 - b(A_0, A_1))), A_1) < 1.0);
    }

    public static double c(int A_0, int A_1)
    {
        return (1.0 - (1.0 / (1.0 + Math.Exp(0.03 * (A_0 - A_1)))));
    }

    public static CombatState d()
    {
        if (e())
        {
            return a;
        }
        return PluginCore.cq.ax.get_Actions().get_CombatMode();
    }

    internal static void d(int A_0)
    {
        try
        {
            if (PluginCore.cq.ax.get_Actions().IsValidObject(A_0))
            {
                int num = f("56188e71599e0d3a73146e53cd01b972");
                int num2 = *(f("395046a14d79ae85df4653af740b0189"));
                dh.b delegateForFunctionPointer = (dh.b) Marshal.GetDelegateForFunctionPointer((IntPtr) num, typeof(dh.b));
                delegateForFunctionPointer(num2, A_0);
            }
        }
        catch
        {
        }
    }

    public static MyList<int> d(string A_0)
    {
        try
        {
            ReadOnlyCollection<cv> onlys = PluginCore.cq.p.a(A_0);
            MyList<int> list = new MyList<int>(1);
            foreach (cv cv in onlys)
            {
                if (b(cv.k))
                {
                    list.Add(cv.k);
                }
            }
            return list;
        }
        catch (Exception)
        {
            return new MyList<int>(2);
        }
    }

    [DllImport("Decal.dll")]
    private static extern int DispatchOnChatCommand(ref IntPtr A_0, [MarshalAs(UnmanagedType.U4)] int A_1);
    public static bool e()
    {
        if (f())
        {
            return false;
        }
        return true;
    }

    internal static bool e(int A_0)
    {
        int num = f("180e009a82e5ff5f1f0a88ae91534465");
        if (num == 0)
        {
            return false;
        }
        IntPtr ptr = new IntPtr(num);
        dh.f delegateForFunctionPointer = (dh.f) Marshal.GetDelegateForFunctionPointer(ptr, typeof(dh.f));
        delegateForFunctionPointer(A_0);
        return true;
    }

    public static int e(string A_0)
    {
        try
        {
            foreach (cv cv in PluginCore.cq.p.a(A_0))
            {
                if (b(cv.k))
                {
                    return cv.k;
                }
            }
            return 0;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    private static bool f()
    {
        if (c)
        {
            if ((b + TimeSpan.FromMilliseconds(600.0)) > DateTimeOffset.Now)
            {
                return false;
            }
            return true;
        }
        if ((b + TimeSpan.FromMilliseconds(600.0)) > DateTimeOffset.Now)
        {
            return false;
        }
        return true;
    }

    internal static bool f(int A_0)
    {
        int num = f("bf83247053610d8db10e0ab54e80f1c1");
        if (num == 0)
        {
            return false;
        }
        IntPtr ptr = new IntPtr(num);
        dh.f delegateForFunctionPointer = (dh.f) Marshal.GetDelegateForFunctionPointer(ptr, typeof(dh.f));
        delegateForFunctionPointer(A_0);
        return true;
    }

    internal static int f(string A_0)
    {
        int num2;
        IntPtr iUnknownForObject = Marshal.GetIUnknownForObject(b());
        if (iUnknownForObject == IntPtr.Zero)
        {
            return 0;
        }
        try
        {
            IntPtr zero = IntPtr.Zero;
            Guid iid = new Guid("67AFC283-4A3C-4d5d-86C0-3EA230687FFE");
            Marshal.QueryInterface(iUnknownForObject, ref iid, out zero);
            if (zero == IntPtr.Zero)
            {
                num2 = 0;
            }
            else
            {
                try
                {
                    IntPtr ptr = a(zero, 0);
                    if (ptr == IntPtr.Zero)
                    {
                        return 0;
                    }
                    dh.g delegateForFunctionPointer = (dh.g) Marshal.GetDelegateForFunctionPointer(ptr, typeof(dh.g));
                    int num = 0;
                    delegateForFunctionPointer(zero, A_0, ref num);
                    num2 = num;
                }
                finally
                {
                    Marshal.Release(zero);
                }
            }
        }
        finally
        {
            Marshal.Release(iUnknownForObject);
        }
        return num2;
    }

    public static void g()
    {
        PluginCore.PC.b(new uTank2.PluginCore.a(dh.a));
    }

    internal static bool g(int A_0)
    {
        int num = f("c47dbb6ed9de5e3735be513dec1b268d");
        if (num == 0)
        {
            return false;
        }
        IntPtr ptr = new IntPtr(num);
        dh.f delegateForFunctionPointer = (dh.f) Marshal.GetDelegateForFunctionPointer(ptr, typeof(dh.f));
        delegateForFunctionPointer(A_0);
        return true;
    }

    private static string g(string A_0)
    {
        string str = A_0.Trim();
        StringBuilder builder = new StringBuilder();
        for (int i = 0; (i < str.Length) && (i < 0x20); i++)
        {
            char c = str[i];
            if (!char.IsControl(c))
            {
                builder.Append(c);
            }
        }
        return builder.ToString();
    }

    public static void h()
    {
        PluginCore.PC.a(new uTank2.PluginCore.a(dh.a));
    }

    internal static bool h(int A_0)
    {
        int num = f("8f91028e0faec04d7d29af9792fd305e");
        if (num == 0)
        {
            return false;
        }
        IntPtr ptr = new IntPtr(num);
        dh.f delegateForFunctionPointer = (dh.f) Marshal.GetDelegateForFunctionPointer(ptr, typeof(dh.f));
        delegateForFunctionPointer(A_0);
        return true;
    }

    public static void h(string A_0)
    {
        if (!i(A_0))
        {
            PluginCore.cq.ax.get_Actions().InvokeChatParser(A_0);
        }
    }

    public static bool i()
    {
        return ff.a(PluginCore.cq.ax);
    }

    public static bool i(int A_0)
    {
        int num = f("2e07193fd6eb536115a4be44860eb829");
        int num2 = f("0dce56812beda3840a566ebca2c1c568");
        if ((num == 0) || (num2 == 0))
        {
            return false;
        }
        IntPtr ptr = new IntPtr(num);
        dh.l delegateForFunctionPointer = (dh.l) Marshal.GetDelegateForFunctionPointer(ptr, typeof(dh.l));
        int num3 = num2[0];
        delegateForFunctionPointer(num3, A_0);
        return true;
    }

    public static bool i(string A_0)
    {
        bool flag2;
        IntPtr ptr = Marshal.StringToBSTR(A_0);
        try
        {
            flag2 = (DispatchOnChatCommand(ref ptr, 1) & 1) > 0;
        }
        finally
        {
            Marshal.FreeBSTR(ptr);
        }
        return flag2;
    }

    internal static unsafe void j(int A_0)
    {
        IntPtr iUnknownForObject = Marshal.GetIUnknownForObject(PluginCore.cq.ax.get_Underlying().get_Hooks());
        IntPtr zero = IntPtr.Zero;
        Guid iid = new Guid("67AFC283-4A3C-4d5d-86C0-3EA230687FFE");
        Marshal.QueryInterface(iUnknownForObject, ref iid, out zero);
        int* numPtr = (int*) zero;
        numPtr = (int*) numPtr[0];
        numPtr = (int*) (((int) numPtr) + 20);
        numPtr = (int*) numPtr[0];
        if (numPtr != null)
        {
            n delegateForFunctionPointer = (n) Marshal.GetDelegateForFunctionPointer((IntPtr) numPtr, typeof(n));
            delegateForFunctionPointer(zero, A_0);
        }
        Marshal.Release(zero);
        Marshal.Release(iUnknownForObject);
    }

    public static float k(int A_0)
    {
        if (!PluginCore.cq.ax.get_Actions().IsValidObject(A_0))
        {
            return 0f;
        }
        if (PluginCore.cq.ax.get_Actions().PhysicsObject(A_0) == IntPtr.Zero)
        {
            return 0f;
        }
        return PluginCore.cq.ax.get_Underlying().get_Hooks().ObjectHeight(A_0);
    }

    public static float l(int A_0)
    {
        if (!PluginCore.cq.ax.get_Actions().IsValidObject(A_0))
        {
            return 0f;
        }
        IntPtr ptr = PluginCore.cq.ax.get_Actions().PhysicsObject(A_0);
        if (ptr == IntPtr.Zero)
        {
            return 0f;
        }
        int num = f("9c5e52a21260eb9f53be0ecf39c6e17e");
        if (num == 0)
        {
            return 0f;
        }
        dh.h delegateForFunctionPointer = (dh.h) Marshal.GetDelegateForFunctionPointer((IntPtr) num, typeof(dh.h));
        return delegateForFunctionPointer(ptr);
    }

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate void a(int A_0, int A_1);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate void b(int A_0, int A_1);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate void c(int A_0, int A_1);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate void d(int A_0, int A_1, out int A_2, int A_3);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate void e(int A_0);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate void f(int A_0);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate int g(IntPtr A_0, [MarshalAs(UnmanagedType.BStr)] string A_1, ref int A_2);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate float h(IntPtr A_0);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate void i(int A_0, [MarshalAs(UnmanagedType.LPStr)] string A_1);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate void j(int A_0, int A_1, float A_2);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate void k(int A_0, int A_1, int A_2, int A_3, int A_4, int A_5, int A_6);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate void l(int A_0, int A_1);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate int m(IntPtr A_0, int A_1, int A_2);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate int n(IntPtr A_0, int A_1);
}

