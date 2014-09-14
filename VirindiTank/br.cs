using System;
using uTank2.Meta;

internal class br : MultipleBase<fl>, fl
{
    public c3 a()
    {
        return c3.c;
    }

    public bool b()
    {
        foreach (fl fl in base.a)
        {
            if (!fl.h())
            {
                return false;
            }
        }
        return true;
    }

    public override string c()
    {
        return "All";
    }
}

