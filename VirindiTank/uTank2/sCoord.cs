namespace uTank2
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    [StructLayout(LayoutKind.Sequential)]
    public struct sCoord
    {
        public double x;
        public double y;
        public double z;
        public bool invalid;
        private static Regex a;
        public sCoord(double X, double Y, double Z)
        {
            this.x = X;
            this.y = Y;
            this.z = Z;
            this.invalid = false;
        }

        public static sCoord NoWhere
        {
            get
            {
                return new sCoord { x = 0.0, y = 0.0, z = 0.0, invalid = true };
            }
        }
        public static bool TryParse(string s, out sCoord result)
        {
            result = NoWhere;
            Match match = a.Match(s);
            if (!match.Success)
            {
                return false;
            }
            double x = double.Parse(match.Groups["ewnum"].Value);
            double y = double.Parse(match.Groups["nsnum"].Value);
            if (match.Groups["ewchr"].Value.ToLowerInvariant() == "w")
            {
                x *= -1.0;
            }
            if (match.Groups["nschr"].Value.ToLowerInvariant() == "s")
            {
                y *= -1.0;
            }
            result = new sCoord(x, y, 0.0);
            return true;
        }

        public override string ToString()
        {
            string str;
            string str2;
            if (this.y > 0.0)
            {
                str = "N";
            }
            else
            {
                str = "S";
            }
            if (this.x < 0.0)
            {
                str2 = "W";
            }
            else
            {
                str2 = "E";
            }
            return ("(" + Math.Abs(this.y).ToString("0.###") + str + ", " + Math.Abs(this.x).ToString("0.###") + str2 + ", " + Math.Abs(this.z).ToString("0.###") + ")");
        }

        public string ToStringXY()
        {
            string str;
            string str2;
            if (this.y > 0.0)
            {
                str = "N";
            }
            else
            {
                str = "S";
            }
            if (this.x < 0.0)
            {
                str2 = "W";
            }
            else
            {
                str2 = "E";
            }
            return ("(" + Math.Abs(this.y).ToString("0.###") + str + ", " + Math.Abs(this.x).ToString("0.###") + str2 + ")");
        }

        public static bool operator ==(sCoord o, sCoord o2)
        {
            if (o.invalid && o2.invalid)
            {
                return true;
            }
            if (o.invalid || o2.invalid)
            {
                return false;
            }
            return (((o.x == o2.x) && (o.y == o2.y)) && (o.z == o2.z));
        }

        public static bool operator !=(sCoord o, sCoord o2)
        {
            return !(o == o2);
        }

        static sCoord()
        {
            a = new Regex(@"(?'nsnum'[0-9]{1,2}(\.[0-9])?)(?'nschr'[nNsS])[\ ]*[\,]?[\ ]*(?'ewnum'[0-9]{1,2}(\.[0-9])?)(?'ewchr'[eEwW])");
        }
    }
}

