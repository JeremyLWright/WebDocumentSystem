using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebDocumentSystem.BusinessLogic;

namespace WebDocTests
{
    [TestClass]
    public class EncryptorUnit
    {
        [TestInitialize]
        public void SetUp()
        {
            sampleData = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit.
Nam nec urna at orci sagittis gravida eget id odio.
Aenean commodo nulla vitae quam dapibus viverra.
Aenean pretium convallis nulla, a posuere nibh mollis vitae.
Ut id tellus eu est aliquet scelerisque at eu urna.
Nunc fermentum laoreet dui, non rutrum ipsum congue scelerisque.
Quisque ut leo in dui ultricies facilisis.";

        }
        [TestMethod]
        public void TestUniqueSalt()
        {
            Assert.AreNotEqual(Encryptor.GetSalt(), Encryptor.GetSalt());
        }

        [TestMethod]
        public void TestEncrypt()
        {
            var salt = Encryptor.GetSalt();
            var encoding = new ASCIIEncoding();
            var sampleBytes = encoding.GetBytes(sampleData);

            var ciphered = Encryptor.Encrypt(password, sampleBytes, salt);
            Assert.AreNotEqual(ciphered, sampleBytes);

            var plain = Encryptor.Decrypt(password, ciphered, salt);
            
            string decryptedString = encoding.GetString(plain);
            Assert.AreEqual(sampleData, decryptedString);

        }

        private string password = "H5asdqaz";
        private string sampleData; 
    }
}
