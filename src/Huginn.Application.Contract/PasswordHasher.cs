using System.Security.Cryptography;
using FluentResults;
using Huginn.Application.Contract.Common;
using static FluentResults.Result;

namespace Huginn.Application.Contract;

internal class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 100000;
    
    private readonly HashAlgorithmName _hashAlgorithm =  HashAlgorithmName.SHA3_512;
    
    public string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, _hashAlgorithm, HashSize);

        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }

    public Result VerifyPassword(string password, string hashedPassword)
    {
        var split = hashedPassword.Split('-');
        var hash = Convert.FromHexString(split[0]);
        var salt = Convert.FromHexString(split[1]);
        var verifyHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, _hashAlgorithm, HashSize);

        return CryptographicOperations.FixedTimeEquals(hash, verifyHash) ? Ok() : Fail("Passwords do not match");
    }
}
