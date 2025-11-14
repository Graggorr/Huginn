using FluentResults;
using Huginn.Database.Models;

namespace Huginn.Database.Common;

public interface IUserRepository : IRepository<User>
{
    public Task<Result> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default);

    public Task<Result> IsPhoneNumberUniqueAsync(string phoneNumber, CancellationToken cancellationToken = default);
    
    public Task<Result> IsUsernameUniqueAsync(string username, CancellationToken cancellationToken = default);
}
