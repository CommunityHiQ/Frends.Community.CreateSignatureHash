using System;
using System.Linq;
using NUnit.Framework;
using System.Security.Cryptography;
using System.Text;

namespace Frends.Community.CreateSignatureHash.Tests
{
    [TestFixture]
    public class ExecuteTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void TestMd5Hash()
        {
            var hashFunction = Function.MD5;
            var tempHash = GenerateHash(hashFunction);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    var privateKey = rsa.ToXmlString(true);
                    var publicKey = rsa.ToXmlString(false);

                    var input = new Input
                    {
                        HashedData = tempHash,
                        PrivateKey = privateKey,
                        HashFunction = Function.MD5
                    };

                    var signatureHash = CreateSignatureHash.CreateSignatureHashTask(input);

                    Assert.IsTrue(VerifyRsaPkcs1(tempHash, signatureHash.Hash, publicKey, hashFunction.ToString()));
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        [Test]
        public void TestSha1Hash()
        {
            var hashFunction = Function.SHA1;
            var tempHash = GenerateHash(hashFunction);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    var privateKey = rsa.ToXmlString(true);
                    var publicKey = rsa.ToXmlString(false);

                    var input = new Input
                    {
                        HashedData = tempHash,
                        PrivateKey = privateKey,
                        HashFunction = hashFunction
                    };

                    var signatureHash = CreateSignatureHash.CreateSignatureHashTask(input);

                    Assert.IsTrue(VerifyRsaPkcs1(tempHash, signatureHash.Hash, publicKey, hashFunction.ToString()));
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        [Test]
        public void TestSha256Hash()
        {
            var hashFunction = Function.SHA256;
            var tempHash = GenerateHash(hashFunction);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    var privateKey = rsa.ToXmlString(true);
                    var publicKey = rsa.ToXmlString(false);

                    var input = new Input
                    {
                        HashedData = tempHash,
                        PrivateKey = privateKey,
                        HashFunction = hashFunction
                    };

                    var signatureHash = CreateSignatureHash.CreateSignatureHashTask(input);

                    Assert.IsTrue(VerifyRsaPkcs1(tempHash, signatureHash.Hash, publicKey, hashFunction.ToString()));
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        [Test]
        public void TestSha384Hash()
        {
            var hashFunction = Function.SHA384;
            var tempHash = GenerateHash(hashFunction);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    var privateKey = rsa.ToXmlString(true);
                    var publicKey = rsa.ToXmlString(false);

                    var input = new Input
                    {
                        HashedData = tempHash,
                        PrivateKey = privateKey,
                        HashFunction = hashFunction
                    };

                    var signatureHash = CreateSignatureHash.CreateSignatureHashTask(input);

                    Assert.IsTrue(VerifyRsaPkcs1(tempHash, signatureHash.Hash, publicKey, hashFunction.ToString()));
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        [Test]
        public void TestSha512Hash()
        {
            var hashFunction = Function.SHA512;
            var tempHash = GenerateHash(hashFunction);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    var privateKey = rsa.ToXmlString(true);
                    var publicKey = rsa.ToXmlString(false);

                    var input = new Input
                    {
                        HashedData = tempHash,
                        PrivateKey = privateKey,
                        HashFunction = hashFunction
                    };

                    var signatureHash = CreateSignatureHash.CreateSignatureHashTask(input);

                    Assert.IsTrue(VerifyRsaPkcs1(tempHash, signatureHash.Hash, publicKey, hashFunction.ToString()));
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        private static string GenerateHash(Function alg)
        {
            var hash = HashAlgorithm.Create("System.Security.Cryptography." + alg);
            var bytes = hash.ComputeHash(Encoding.UTF8.GetBytes("FooBar"));

            var sBuilder = new StringBuilder();
            bytes.ToList().ForEach(b => sBuilder.Append(b.ToString("x2")));
            return sBuilder.ToString();
        }

        private static bool VerifyRsaPkcs1(string signedData, string signatureHash, string publicKey, string algorithm)
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
