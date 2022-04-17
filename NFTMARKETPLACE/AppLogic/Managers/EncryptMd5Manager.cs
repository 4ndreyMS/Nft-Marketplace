using DTO_POJOS;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AppLogic.Managers
{
    public class EncryptMd5Manager
    {
        
        public static string Encrypt(string msj)
        {
            string hash = "gJ3Cn4$Z2s~QBTbE";
            byte[] data = UTF8Encoding.UTF8.GetBytes(msj);

            MD5 md5 = MD5.Create();
            TripleDES tripleDes = TripleDES.Create();

            tripleDes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripleDes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripleDes.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(result);
        }

        public static string Decrypt(string msjEncrypt)
        {
            string hash = "gJ3Cn4$Z2s~QBTbE";
            byte[] data = Convert.FromBase64String(msjEncrypt);

            MD5 md5 = MD5.Create();
            TripleDES tripleDes = TripleDES.Create();

            tripleDes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripleDes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripleDes.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return UTF8Encoding.UTF8.GetString(result);
        }


    }
}
