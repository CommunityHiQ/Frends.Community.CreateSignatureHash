using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Frends.Community.CreateSignatureHash
{
    
    /// <summary>
    /// Execute process
    /// </summary>
    public class CreateSignatureHash
    {
        /// <summary>
        /// Calculates signature hash from hashed data and private key.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Object {string Hash}</returns>
        public static Output CreateSignatureHashTask(Input input)
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