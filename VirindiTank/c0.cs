using System;
using System.Collections.Generic;

internal static class c0
{
    private static Dictionary<int, string> a = new Dictionary<int, string>();

    static c0()
    {
        a("Agate", 10);
        a("Alabaster", 0x42);
        a("Amber", 11);
        a("Amethyst", 12);
        a("Aquamarine", 13);
        a("Armoredillo Hide", 0x35);
        a("Azurite", 14);
        a("Black Garnet", 15);
        a("Black Opal", 0x10);
        a("Bloodstone", 0x11);
        a("Brass", 0x39);
        a("Bronze", 0x3a);
        a("Carnelian", 0x12);
        a("Ceramic", 1);
        a("Citrine", 0x13);
        a("Copper", 0x3b);
        a("Diamond", 20);
        a("Ebony", 0x49);
        a("Emerald", 0x15);
        a("Fire Opal", 0x16);
        a("Gold", 60);
        a("Granite", 0x43);
        a("Green Garnet", 0x17);
        a("Green Jade", 0x18);
        a("Gromnie Hide", 0x36);
        a("Hematite", 0x19);
        a("Imperial Topaz", 0x1a);
        a("Iron", 0x3d);
        a("Ivory", 0x33);
        a("Jet", 0x1b);
        a("Lapis Lazuli", 0x1c);
        a("Lavender Jade", 0x1d);
        a("Leather", 0x34);
        a("Linen", 4);
        a("Mahogany", 0x4a);
        a("Malachite", 30);
        a("Marble", 0x44);
        a("Moonstone", 0x1f);
        a("Oak", 0x4b);
        a("Obsidian", 0x45);
        a("Onyx", 0x20);
        a("Opal", 0x21);
        a("Peridot", 0x22);
        a("Pine", 0x4c);
        a("Porcelain", 2);
        a("Pyreal", 0x3e);
        a("Red Garnet", 0x23);
        a("Red Jade", 0x24);
        a("Reed Shark Hide", 0x37);
        a("Rose Quartz", 0x25);
        a("Ruby", 0x26);
        a("Sandstone", 70);
        a("Sapphire", 0x27);
        a("Satin", 5);
        a("Serpentine", 0x47);
        a("Silk", 6);
        a("Silver", 0x3f);
        a("Smokey Quartz", 40);
        a("Steel", 0x40);
        a("Sunstone", 0x29);
        a("Teak", 0x4d);
        a("Tiger Eye", 0x2a);
        a("Tourmaline", 0x2b);
        a("Turquoise", 0x2c);
        a("Velvet", 7);
        a("White Jade", 0x2d);
        a("White Quartz", 0x2e);
        a("White Sapphire", 0x2f);
        a("Wool", 8);
        a("Yellow Garnet", 0x30);
        a("Yellow Topaz", 0x31);
        a("Zircon", 50);
    }

    public static string a(int A_0)
    {
        if (a.ContainsKey(A_0))
        {
            return a[A_0];
        }
        return null;
    }

    private static void a(string A_0, int A_1)
    {
        a[A_1] = A_0;
    }
}

