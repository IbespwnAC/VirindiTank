using System;
using uTank2;

internal class c9
{
    private static bool a;

    private static void a()
    {
        bool a = c9.a;
    }

    private static string a(eDamageElement A_0)
    {
        switch (A_0)
        {
            case eDamageElement.Pierce:
                return "Armor Piercing";

            case eDamageElement.Bludgeon:
                return "Blunt";

            case eDamageElement.Slash:
                return "Frog Crotch";

            case eDamageElement.Acid:
                return "Acid";

            case eDamageElement.Lightning:
                return "Lightning";

            case eDamageElement.Cold:
                return "Frost";

            case eDamageElement.Fire:
                return "Fire";
        }
        return "";
    }

    public static MyList<at> a(bool A_0, eDamageElement A_1)
    {
        MyList<at> list = new MyList<at>(0x4a);
        string str = a(A_1);
        if (!A_0)
        {
            list.Add(new at(str + " Arrowheads", 2, a(false, A_1, 1)));
            list.Add(new at("Greater " + str + " Arrowheads", 4, a(false, A_1, 2)));
            list.Add(new at("Deadly " + str + " Arrowheads", 6, a(false, A_1, 3)));
            if (A_1 == eDamageElement.Pierce)
            {
                list.Add(new at("Barbed Arrowheads", 1, 20));
                list.Add(new at("Greater Barbed Arrowheads", 3, 160));
                list.Add(new at("Deadly Barbed Arrowheads", 5, 0xaf));
            }
            return list;
        }
        list.Add(new at("Wrapped Bundle of " + str + " Arrowheads", 2, a(true, A_1, 1)));
        list.Add(new at("Wrapped Bundle of Greater " + str + " Arrowheads", 4, a(true, A_1, 2)));
        list.Add(new at("Wrapped Bundle of Deadly " + str + " Arrowheads", 6, a(true, A_1, 3)));
        if (A_1 == eDamageElement.Pierce)
        {
            list.Add(new at("Wrapped Bundle of Barbed Arrowheads", 1, 50));
            list.Add(new at("Wrapped Bundle of Greater Barbed Arrowheads", 3, 190));
            list.Add(new at("Wrapped Bundle of Deadly Barbed Arrowheads", 5, 200));
        }
        return list;
    }

    public static string a(int A_0, bool A_1)
    {
        if (A_1)
        {
            switch (A_0)
            {
                case 1:
                    return "Wrapped Bundle of Arrowshafts";

                case 2:
                    return "Wrapped Bundle of Quarrelshafts";

                case 4:
                    return "Wrapped Bundle of Atlatl Dartshafts";
            }
        }
        else
        {
            switch (A_0)
            {
                case 1:
                    return "Bundle of Arrowshafts";

                case 2:
                    return "Bundle of Quarrelshafts";

                case 4:
                    return "Bundle of Atlatl Dart Shafts";
            }
        }
        return "";
    }

    public static MyList<at> a(int A_0, eDamageElement A_1)
    {
        MyList<at> list = new MyList<at>(0x49);
        string str = a(A_1);
        string str2 = "";
        switch (A_0)
        {
            case 1:
                str2 = "Arrow";
                break;

            case 2:
                str2 = "Quarrel";
                break;

            case 4:
                str2 = "Atlatl Dart";
                break;
        }
        list.Add(new at(str + " " + str2, 2, 0));
        list.Add(new at("Greater " + str + " " + str2, 4, 0));
        list.Add(new at("Deadly " + str + " " + str2, 6, 0));
        if (A_1 == eDamageElement.Pierce)
        {
            str = "Barbed";
            list.Add(new at(str + " " + str2, 1, 0));
            list.Add(new at("Greater " + str + " " + str2, 3, 0));
            list.Add(new at("Deadly " + str + " " + str2, 5, 0));
        }
        return list;
    }

    private static int a(bool A_0, eDamageElement A_1, int A_2)
    {
        if (A_0)
        {
            switch (A_2)
            {
                case 1:
                    switch (A_1)
                    {
                        case eDamageElement.Pierce:
                            return 50;

                        case eDamageElement.Bludgeon:
                            return 40;

                        case eDamageElement.Slash:
                            return 50;
                    }
                    return 90;

                case 2:
                    switch (A_1)
                    {
                        case eDamageElement.Pierce:
                            return 190;

                        case eDamageElement.Bludgeon:
                            return 170;

                        case eDamageElement.Slash:
                            return 190;
                    }
                    return 230;

                case 3:
                    switch (A_1)
                    {
                        case eDamageElement.Pierce:
                            return 200;

                        case eDamageElement.Bludgeon:
                            return 180;

                        case eDamageElement.Slash:
                            return 200;
                    }
                    return 250;
            }
        }
        else
        {
            switch (A_2)
            {
                case 1:
                    switch (A_1)
                    {
                        case eDamageElement.Pierce:
                            return 20;

                        case eDamageElement.Bludgeon:
                            return 10;

                        case eDamageElement.Slash:
                            return 20;
                    }
                    return 60;

                case 2:
                    switch (A_1)
                    {
                        case eDamageElement.Pierce:
                            return 160;

                        case eDamageElement.Bludgeon:
                            return 140;

                        case eDamageElement.Slash:
                            return 160;
                    }
                    return 200;

                case 3:
                    switch (A_1)
                    {
                        case eDamageElement.Pierce:
                            return 0xaf;

                        case eDamageElement.Bludgeon:
                            return 150;

                        case eDamageElement.Slash:
                            return 0xaf;
                    }
                    return 0xe1;
            }
        }
        return 0;
    }
}

