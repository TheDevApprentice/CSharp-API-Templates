using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

public class EncryptionHelper
{
    private const int SaltSize = 32; // Taille du sel en octets (256 bits)
    private const int HashSize = 32; // Taille du hachage en octets (256 bits)

    private readonly byte[] _fixedSalt;
    private readonly string _password;

    public EncryptionHelper(IConfiguration configuration)
    {
        #region ENV

        var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");

        #endregion

        _password = jwtKey;
        _fixedSalt = new byte[SaltSize];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cipherText"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public string Verify(string cipherText)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Hashes a password using SHA256 hashing algorithm and a fixed salt.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <returns>The hashed password.</returns>
    public string HashPassword(string password)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltedPasswordBytes = new byte[passwordBytes.Length + _fixedSalt.Length];

        // Concatenate password bytes and fixed salt bytes
        Buffer.BlockCopy(passwordBytes, 0, saltedPasswordBytes, 0, passwordBytes.Length);
        Buffer.BlockCopy(_fixedSalt, 0, saltedPasswordBytes, passwordBytes.Length, _fixedSalt.Length);

        // Compute hash using SHA256 algorithm
        using (var sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(saltedPasswordBytes);
            return Convert.ToBase64String(hashedBytes);
        }
    }

    /// <summary>
    /// Verifies a password against a hashed password.
    /// </summary>
    /// <param name="password">The password to verify.</param>
    /// <param name="hashedPassword">The hashed password to compare against.</param>
    /// <returns>True if the password is verified, otherwise false.</returns>
    public bool VerifyPassword(string password, string hashedPassword)
    {
        // Hash the input password using the same salt
        string hashedInputPassword = HashPassword(password);
        // Compare the hashed passwords
        return string.Equals(hashedInputPassword, hashedPassword);
    }
}