using FluentResults;
using Huginn.Application.Contract.Commands.User.Create;
using Huginn.Application.Contract.Common;
using Huginn.Application.Contract.User.Create;
using Huginn.Database.Common;
using MediatR;
using static FluentResults.Result;

namespace Huginn.Application.User.Create;

public class CreateUserHandler(IUserRepository repository, IPasswordHasher passwordHasher)
    : IRequestHandler<CreateUserCommand, Result<CreateUserResponse>>
{
    private readonly IUserRepository _repository = repository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    
    public async Task<Result<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = _passwordHasher.HashPassword(request.Password);
        var user = new Database.Models.User
        {
            Balance = 0,
            Email = request.Email,
            HashPassword = hashedPassword,
            Username = request.Username,
            Id = request.Id,
        };

        var result = await _repository.AddAsync(user, cancellationToken);

        return result.IsSuccess ? Ok(new CreateUserResponse(result.Value.Id)) : result.ToResult();
    }
}
