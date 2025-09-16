using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UsingSha256
{
    public class DatabaseCon
    {
        public static string connString = "Data Source=LAB4-PC30\\SQLEXPRESS;Initial Catalog=PasswordHash;Integrated Security=True;TrustServerCertificate=True";




    }
    public class Hash1
    {
        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256 object
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // "x2" formats as hexadecimal with two digits
                }
                return builder.ToString();
            }
        }
    } 
}

