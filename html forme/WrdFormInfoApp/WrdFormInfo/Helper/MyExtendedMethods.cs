using System;
using System.IO;

namespace WrdFormInfo.Helper
{
    public static class MyExtendedMethods
    {
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        public static string ToBase64String(this Stream s)
        {
            byte[] bytedata = ReadFully(s);

            string strBase64 = Convert.ToBase64String(bytedata);
            return strBase64;
        }
    }
}
