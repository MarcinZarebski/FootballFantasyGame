namespace Logic
{
    using System;
    using System.Security.Cryptography;

    internal class Encryption
    {
        internal static byte[] ComputeHash(string password, string salt)
        {
            var saltAndPassword = String.Concat(password, salt);
            var data = System.Text.Encoding.ASCII.GetBytes(saltAndPassword);
            var shaM = new SHA256Managed();

            var result = shaM.ComputeHash(data);

            return result;
        }
    }
}
