using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Frends.Community.CreateSignatureHash
{
    /// <summary>
    /// Execute process
    /// </summary>
    public class CreateSignature
    {
        /// <summary>
        /// 
        /// </summary>
        public class Input
        {
            /// <summary>
            /// Hashed data to sign
            /// </summary>
            public string HashedData { get; set; }
            /// <summary>
            /// RSA/CPS as xml string
            /// </summary>
            [PasswordPropertyText(true)]
            public string PrivateKey { get; set; }
            /// <summary>
            /// Used hash
            /// </summary>
            [DefaultValue(Function.MD5)]
            public Function HashFunction { get; set; }
        }

        /// <summary>
        /// Enum for choosing HashAlgorithm type
        /// </summary>
#pragma warning disable
        public enum Function { MD5, RIPEMD160, SHA1, SHA256, SHA384, SHA512 }
#pragma warning restore

        /// <summary>
        /// Return object
        /// </summary>
        public class Output
        {
            /// <summary>
            /// RSA signature
            /// </summary>
            public string Hash { get; set; }
        }

        /// <summary>
        /// Calculates signature hash from hashed data and private key.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Object {string Hash}</returns>
        public static Output CreateSignatureHash(Input input)
        {
            byte[] signatureHash;
            using (var rsa = new RSACryptoServiceProvider())
            {
                try
                {
                    rsa.FromXmlString(input.PrivateKey);
                    signatureHash = rsa.SignHash(StringToByteArray(input.HashedData), CryptoConfig.MapNameToOID(input.HashFunction.ToString()));
                }
                catch (CryptographicException e)
                {
                    throw new Exception("Creating signature failed. Exception:" + e.Message);
                }
                finally
                {
                    rsa.PersistKeyInCsp = false; // Clear keycontainer when rsa is disposed.
                }
            }

            var sBuilder = new StringBuilder();
            signatureHash.ToList().ForEach(b => sBuilder.Append(b.ToString("x2")));
            
            return new Output { Hash = sBuilder.ToString() };
        }

        private static byte[] StringToByteArray(string hex)
        {
            var lenght = hex.Length;
            var bytes = new byte[lenght / 2];
            for (var i = 0; i < lenght; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}