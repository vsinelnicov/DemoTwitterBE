using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace DemoTwitter.WebApi.Infrastructure
{
    public class AccountAppService
    {
        /// <summary>
        /// Create SHA256 value in base64
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetSha256Hash(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            var shaObj = SHA256.Create();
            var hashedBytes = shaObj.ComputeHash(inputBytes);

            return Convert.ToBase64String(hashedBytes);
        }
    }
}