using FluentResults;
using Huginn.Application.Contract.User.Create;
using MediatR;

namespace Huginn.Application.Contract.Commands.User.Create;

public record CreateUserCommand(Guid Id, string Username, string Email, string PhoneNumber, string Password) : IRequest<Result<CreateUserResponse>>;
