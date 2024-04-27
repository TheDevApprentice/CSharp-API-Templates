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

    //private const int SaltSize = 325;
    //private const int KeySize = 256;

    //private readonly byte[] _fixedSalt = new byte[SaltSize];

    //private readonly string _password;

    //public EncryptionHelper(IConfiguration configuration)
    //{
    //    _password = configuration["Jwt:Key"];
    //}

    public string HashPassword(string password)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltedPasswordBytes = new byte[passwordBytes.Length + _fixedSalt.Length];

        Buffer.BlockCopy(passwordBytes, 0, saltedPasswordBytes, 0, passwordBytes.Length);
        Buffer.BlockCopy(_fixedSalt, 0, saltedPasswordBytes, passwordBytes.Length, _fixedSalt.Length);

        using (var sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(saltedPasswordBytes);
            return Convert.ToBase64String(hashedBytes);
        }
    }

    public string Verify(string cipherText)
    {
        throw new NotImplementedException();
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        string hashedInputPassword = HashPassword(password); // Utiliser le même sel
        return string.Equals(hashedInputPassword, hashedPassword);
    }
}