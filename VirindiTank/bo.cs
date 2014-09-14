using System;
using System.Drawing;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal struct bo
{
    public int a;
    public byte b;
    public byte c;
    public Color a()
    {
        int index = ((this.c * 0x10) + (this.b * 0x20)) + 8;
        try
        {
            byte[] buffer = e.a(this.a);
            return Color.FromArgb(buffer[index + 3], buffer[index + 2], buffer[index + 1], buffer[index]);
        }
        catch
        {
            return Color.Black;
        }
    }
}

