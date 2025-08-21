using System;
using System.Security.Cryptography;
using System.Text;

namespace SCI
{
    public static class Utilidades
    {
        public static int CalcularEdad(DateTime fechaNacimiento)
        {
            var hoy = DateTime.Today;
            int edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento > hoy.AddYears(-edad)) edad--;
            return edad;
        }
        /*/
        public static string HashContrasena(string contrasena)
        {
            // Generar salt aleatoria
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Derivar hash
            var pbkdf2 = new Rfc2898DeriveBytes(contrasena, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(32); // 256 bits

            // Unir salt + hash
            byte[] hashBytes = new byte[1 + salt.Length + hash.Length];
            hashBytes[0] = 0; // versión
            Buffer.BlockCopy(salt, 0, hashBytes, 1, salt.Length);
            Buffer.BlockCopy(hash, 0, hashBytes, 1 + salt.Length, hash.Length);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerificarContrasena(string contrasena, string hashGuardado)
        {
            byte[] hashBytes = Convert.FromBase64String(hashGuardado);

            if (hashBytes[0] != 0)
                throw new NotSupportedException("Versión de hash no compatible");

            byte[] salt = new byte[16];
            Buffer.BlockCopy(hashBytes, 1, salt, 0, 16);

            byte[] storedHash = new byte[32];
            Buffer.BlockCopy(hashBytes, 17, storedHash, 0, 32);

            var pbkdf2 = new Rfc2898DeriveBytes(contrasena, salt, 100000);
            byte[] computedHash = pbkdf2.GetBytes(32);

            // Comparación manual (FixedTimeEquals no existe en .NET Framework)
            return CompararBytes(storedHash, computedHash);
        }

        private static bool CompararBytes(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;

            int result = 0;
            for (int i = 0; i < a.Length; i++)
                result |= a[i] ^ b[i]; // bitwise XOR

            return result == 0;
        }*/
    }
}
