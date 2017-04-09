using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Helper
{
    public static class PasswordHash
    {
        public const Int32 SaltByteSize = 24;
        public const Int32 HashByteSize = 20; // to match the size of the PBKDF2-HMAC-SHA-1 hash 
        public const Int32 Pbkdf2Iterations = 1000;
        public const Int32 IterationIndex = 0;
        public const Int32 SaltIndex = 1;
        public const Int32 Pbkdf2Index = 2;

        public static String HashPassword(String password)
        {
            var cryptoProvider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SaltByteSize];
            cryptoProvider.GetBytes(salt);

            var hash = GetPbkdf2Bytes(password, salt, Pbkdf2Iterations, HashByteSize);
            return Pbkdf2Iterations + ":" +
                   Convert.ToBase64String(salt) + ":" +
                   Convert.ToBase64String(hash);
        }

        public static Boolean ValidatePassword(String password, String correctHash)
        {
            char[] delimiter = { ':' };
            var split = correctHash.Split(delimiter);
            var iterations = Int32.Parse(split[IterationIndex]);
            var salt = Convert.FromBase64String(split[SaltIndex]);
            var hash = Convert.FromBase64String(split[Pbkdf2Index]);

            var testHash = GetPbkdf2Bytes(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        private static Boolean SlowEquals(Byte[] a, Byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (Int32 i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        private static Byte[] GetPbkdf2Bytes(String password, Byte[] salt, Int32 iterations, Int32 outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}
