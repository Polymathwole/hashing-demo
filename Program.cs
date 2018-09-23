using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Security.Cryptography;
using System.IO;

namespace Cryptography
{
    class Program
    {
        RSACryptoServiceProvider rsa;
        static void PlayWithJson()
        {
            JavaScriptSerializer jsonWriter = new JavaScriptSerializer();
            string json = jsonWriter.Serialize(new { age = 23, fname = "Wole", lname = "Dele" });
            Console.WriteLine(json);
        }

        static void GetHash(string x)
        {
            byte[] bite = Encoding.UTF8.GetBytes(x);
            string xxx = Encoding.UTF8.GetString(bite);
            string b64 = Convert.ToBase64String(bite);
            string ss = String.Empty;
            List<byte> lb = new List<byte>();
            foreach (var b in bite)
            {
                ss += b;
                lb.Add(b);
            }
            byte[] hash = SHA512.Create().ComputeHash(bite);
            string hashS = Convert.ToBase64String(hash);
            string hashS1 = Convert.ToBase64String(SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes("Adetoro")));

            string str1 = String.Empty;
            string str2 = String.Empty;
            string str3 = String.Empty;

            for (int i = 0; i < hash.Length; i++)
            {
                str1 += hash[i].ToString();
                str2 += hash[i].ToString("x2");//hexadecimal to 2 places
                str3 += hash[i].ToString("x");
            }

            Console.WriteLine(str1);
            Console.WriteLine(str2);
            Console.WriteLine(str3);
            Console.WriteLine(hashS);
            Console.WriteLine(hashS.Equals(hashS1));
        }

        static void Main(string[] args)
        {
            GetHash("Adetoro");
        }
    }
}
