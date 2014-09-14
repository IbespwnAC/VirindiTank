using System;

[AttributeUsage(AttributeTargets.Assembly)]
public sealed class DotfuscatorAttribute : Attribute
{
    private string a;

    public DotfuscatorAttribute(string a)
    {
        this.a = a;
    }

    public string A
    {
        get
        {
            return this.a;
        }
    }
}

