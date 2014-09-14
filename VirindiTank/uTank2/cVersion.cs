namespace uTank2
{
    using System;
    using System.Reflection;

    public class cVersion
    {
        private int[] a;

        public cVersion(string ver)
        {
            this.a = new int[4];
            string[] strArray = ver.Split(new char[] { '.' });
            if (strArray.Length != 4)
            {
                throw new Exception();
            }
            this.a[0] = Convert.ToInt32(strArray[0]);
            this.a[1] = Convert.ToInt32(strArray[1]);
            this.a[2] = Convert.ToInt32(strArray[2]);
            this.a[3] = Convert.ToInt32(strArray[3]);
        }

        public cVersion(int maj, int min, int bld, int rv)
        {
            this.a = new int[4];
            this.a[0] = maj;
            this.a[1] = min;
            this.a[2] = bld;
            this.a[3] = rv;
        }

        public static cVersion GetVersion(Assembly a)
        {
            return new cVersion(a.GetName(false).Version.Major, a.GetName(false).Version.Minor, a.GetName(false).Version.Build, a.GetName(false).Version.Revision);
        }

        public static bool operator ==(cVersion a, cVersion b)
        {
            for (int i = 0; i < 4; i++)
            {
                if (a.a[i] != b.a[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator >(cVersion a, cVersion b)
        {
            for (int i = 0; i < 4; i++)
            {
                if (a.a[i] > b.a[i])
                {
                    return true;
                }
                if (a.a[i] < b.a[i])
                {
                    return false;
                }
            }
            return false;
        }

        public static bool operator !=(cVersion a, cVersion b)
        {
            for (int i = 0; i < 4; i++)
            {
                if (a.a[i] != b.a[i])
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator <(cVersion a, cVersion b)
        {
            for (int i = 0; i < 4; i++)
            {
                if (a.a[i] < b.a[i])
                {
                    return true;
                }
                if (a.a[i] > b.a[i])
                {
                    return false;
                }
            }
            return false;
        }

        public int Build
        {
            get
            {
                return this.a[2];
            }
        }

        public int Major
        {
            get
            {
                return this.a[0];
            }
        }

        public int Minor
        {
            get
            {
                return this.a[1];
            }
        }

        public int Revision
        {
            get
            {
                return this.a[3];
            }
        }
    }
}

