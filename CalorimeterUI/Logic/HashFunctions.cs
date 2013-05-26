using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Logic
{
    public static class HashFunctions
    {
        public static string CalculateMD5Hash(string password)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string CalculateFromMD5Hash(string password)
        {
            byte[] bytes = GetBytes(password);
            StringBuilder result = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString("X2"));

            return result.ToString();
        }

        private static byte[] GetBytes(string pasword)
        {
            byte[] bytes = new byte[pasword.Length * sizeof(char)];
            System.Buffer.BlockCopy(pasword.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
