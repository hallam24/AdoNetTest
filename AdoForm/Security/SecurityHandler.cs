using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace AdoForm.Security
{
    public class SecurityHandler
    {
        // There is probably a better way to do this
        public string HashPassword(string passToHash)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            // Iterations could be higher
            var pbkdf2 = new Rfc2898DeriveBytes(passToHash, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string hashedPassword = Convert.ToBase64String(hashBytes);
            return hashedPassword;
        }

        public bool ArePasswordsSame(string storedPassword, string newPassword)
        {
            // Extract the bytes
            byte[] hashBytesStored = Convert.FromBase64String(storedPassword);

            //byte[] hashBytesNew = Convert.FromBase64String(newPassword);

            // Get salt
            byte[] salt = new byte[16];
            Array.Copy(hashBytesStored, 0, salt, 0, 16);
            // Hash the new password could call other function instead of repeating
            var pbkdf2 = new Rfc2898DeriveBytes(newPassword, salt, 10000);
            byte[] hashBytesNew = pbkdf2.GetBytes(20);
            // Compare the results
            for (int i = 0; i < 20; i++)
            {
                if (hashBytesStored[i + 16] != hashBytesNew[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}