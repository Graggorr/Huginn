using FluentResults;

namespace Huginn.Application.Contract.Common;

public interface IPasswordHasher
{
    public string HashPassword(string password);

    public Result VerifyPassword(string password, string hashedPassword);
}