using Decal.Adapter;
using Decal.Filters;
using System;
using System.Collections.Generic;

internal static class e
{
    private static Dictionary<int, byte[]> a = new Dictionary<int, byte[]>();

    public static void a()
    {
        a.Clear();
    }

    public static byte[] a(int A_0)
    {
        int key = A_0 | 0x4000000;
        if (a.ContainsKey(key))
        {
            return a[key];
        }
        FileService service = CoreManager.get_Current().get_FileService() as FileService;
        byte[] portalFile = null;
        try
        {
            portalFile = service.GetPortalFile(key);
        }
        catch
        {
        }
        a[key] = portalFile;
        return portalFile;
    }
}

