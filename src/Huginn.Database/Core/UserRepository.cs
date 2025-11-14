using FluentResults;
using Huginn.Database.Common;
using Huginn.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static FluentResults.Result;

namespace Huginn.Database.Core;

internal class UserRepository(ILogger<IRepository<User>> logger, HuginnDbContext context)
    : BaseRepository<User>(logger, context), IUserRepository
{
    public async Task<Result> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email, cancellationToken);
        
        return user is null ? Ok() : Fail($"Email {email} is already used");
    }

    public async Task<Result> IsPhoneNumberUniqueAsync(string phoneNumber, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.PhoneNumber == phoneNumber, cancellationToken);
        
        return user is null ? Ok() : Fail($"PhoneNumber {phoneNumber} is already used");
    }

    public async Task<Result> IsUsernameUniqueAsync(string username, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.PhoneNumber == username, cancellationToken);
        
        return user is null ? Ok() : Fail($"PhoneNumber {username} is already used");
    }
}
    