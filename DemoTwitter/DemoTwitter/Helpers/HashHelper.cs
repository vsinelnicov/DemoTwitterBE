using System.Text;

namespace DemoTwitter.WEB.Helpers
{
    public class HashHelper
    {
        public string CalculateMd5(string input)
        {
            using (System.Security.Cryptography.MD5 md5Sum = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5Sum.ComputeHash(inputBytes);

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(i.ToString("X2"));
                }
                return stringBuilder.ToString();
            }
        }
    }
}