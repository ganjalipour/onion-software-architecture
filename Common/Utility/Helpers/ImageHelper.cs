using System.IO;

namespace Framework.Core.ImageUtilities
{
    public static class ImageHelper
    {
        public static byte[] GetImage(string address)
        {
            try
            {
                FileStream fs = File.OpenRead(address);
                return ConvertStreamToByteArray(fs);
            }
            catch
            {
                //TODO:Log Exception For Get Image
                return null;
            }
        }
        private static byte[] ConvertStreamToByteArray(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                read = ReadStream(input, buffer, ms);
                return ms.ToArray();
            }
        }
        private static int ReadStream(Stream input, byte[] buffer, MemoryStream ms)
        {
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return read;
        }
    }
}