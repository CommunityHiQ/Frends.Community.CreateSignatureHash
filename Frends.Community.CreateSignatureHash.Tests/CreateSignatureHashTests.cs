using System;
using NUnit.Framework;
using System.Security.Cryptography;

namespace Frends.Community.CreateSignatureHash.Tests
{
    [TestFixture]
    public class ExecuteTests
    {
        private const string Algorithm = "SHA512";
        private const string HashedDataSHA512 = "0a50261ebd1a390fed2bf326f2673c145582a6342d523204973d0219337f81616a8069b012587cf5635f6925f1b56c360230c19b273500ee013e030601bf2425";

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void TestExecuteScript()
        {
            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    var privateKey = rsa.ToXmlString(true);
                    var publicKey = rsa.ToXmlString(false);

                    var input = new CreateSignature.Input
                    {
                        HashedData = HashedDataSHA512,
                        PrivateKey = privateKey,
                        HashFunction = CreateSignature.Function.SHA512
                    };

                    var signatureHash = CreateSignature.CreateSignatureHash(input);

                    Assert.IsTrue(VerifyRsaPkcs1(HashedDataSHA512, signatureHash.Hash, publicKey, Algorithm));
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        private static bool VerifyRsaPkcs1(string signedData, string signatureHash, string publicKey, string algorithm = "SHA512")
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                try
                {
                    rsa.FromXmlString(publicKey);
                    var verifier = new RSAPKCS1SignatureDeformatter(rsa);
                    verifier.SetHashAlgorithm(algorithm);
                    return verifier.VerifySignature(StringToByteArray(signedData), StringToByteArray(signatureHash));
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        private static byte[] StringToByteArray(string hex)
        {
            var length = hex.Length;
            var bytes = new byte[length / 2];
            for (var i = 0; i < length; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}
