#pragma warning disable 1591

using System.ComponentModel;

namespace Frends.Community.CreateSignatureHash
{
    /// <summary>
    /// Input
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
    public enum Function { MD5, SHA1, SHA256, SHA384, SHA512 }
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
}
