namespace uTank2
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct sWaypointDesc
    {
        public eWaypointType type;
        public int bonus;
        public sCoord loc;
        public static sWaypointDesc Invalid
        {
            get
            {
                return new sWaypointDesc { type = eWaypointType.Other, bonus = 0, loc = sCoord.NoWhere };
            }
        }
    }
}

