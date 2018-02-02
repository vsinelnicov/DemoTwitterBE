using System;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;

namespace DemoTwitter.WEB.Helpers
{
    public class HashHelper
    {
        public string CalculateMd5(string input)
        {
            using (MD5 md5Sum = MD5.Create())
            {
                //calculate md5 hash
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hash = md5Sum.ComputeHash(inputBytes);
                // convert into array
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    stringBuilder.Append(hash[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }

        public string CalculateSha256(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            SHA256 shaObj = SHA256.Create();
            var hashedBytes = shaObj.ComputeHash(inputBytes);

            return Convert.ToBase64String(hashedBytes);
        }
    }
}