﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.IO;

namespace WebDocumentSystem.BusinessLogic
{
    public class Encryptor
    {
        public static byte[] GetSalt()
        {
            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
            var salt = new byte[256];
            rngCsp.GetBytes(salt);
            return salt;
        }

        public static byte[] Encrypt(string password, byte[] data, byte[] salt)
        {
            var encryptedResult = new MemoryStream();

            using(var algorithm = new RijndaelManaged())
            using (var key = new Rfc2898DeriveBytes(password, salt))
            {

                algorithm.Key = key.GetBytes(algorithm.KeySize/8);
                algorithm.IV = key.GetBytes(algorithm.BlockSize/8);

                
                using (var encryptedStream = new CryptoStream(encryptedResult, algorithm.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    encryptedStream.Write(data, 0, data.Length);
                }
            }

            return encryptedResult.ToArray();
        }

        public static byte[] Decrypt(string password, byte[] data, byte[] salt)
        {
            var decryptedResult = new MemoryStream();

            using(var algorithm = new RijndaelManaged())
            using (var key = new Rfc2898DeriveBytes(password, salt))
            {

                algorithm.Key = key.GetBytes(algorithm.KeySize/8);
                algorithm.IV = key.GetBytes(algorithm.BlockSize/8);



                using (var decryptedStream = new CryptoStream(decryptedResult, algorithm.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    decryptedStream.Write(data, 0, data.Length);
                }
            }
            return decryptedResult.ToArray();
        }

        
    }
}