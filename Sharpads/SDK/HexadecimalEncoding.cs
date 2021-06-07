using System;
using System.Text;

namespace Sharpads.SDK
{
    public class HexadecimalEncoding
    {
        public static string ToHexString(string str)
        {
            var sb = new StringBuilder();
            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
                sb.Append(t.ToString("X2") + " ");
            string op = sb.ToString();
            return op.Remove(op.Length - 1, op.Length);
        }

        public static string FromHexString(string vhexString)
        {
            string hexString = vhexString.Replace(" ", "");
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return Encoding.Unicode.GetString(bytes);
        }
    }
}
