using FluentValidation;
using Huginn.Application.Contract.Commands.User.Create;
using Huginn.Database.Common;
using static Huginn.Common.Enums.ErrorCodes;
using static Huginn.Common.GeneratedRegex;

namespace Huginn.Application.User.Create;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator(IUserRepository repository)
    {
        RuleFor(command => command.Username)
            .NotEmpty().WithErrorCode(nameof(UserNameIsRequired))
            .Must(username => UsernameRegex().IsMatch(username)).WithErrorCode(nameof(UserNameIsInvalid))
            .MustAsync(async (username, cancellationToken) => (await repository.IsUsernameUniqueAsync(username, cancellationToken)).IsSuccess).WithErrorCode(nameof(UserNameIsAlreadyUsed));

        RuleFor(command => command.Password)
            .NotEmpty().WithErrorCode(nameof(PasswordIsRequired))
            .Must(password => PasswordRegex().IsMatch(password)).WithErrorCode(nameof(PasswordIsInvalid));
        
        RuleFor(command => command.PhoneNumber)
            .NotEmpty().WithErrorCode(nameof(PhoneNumberIsRequired))
            .Must(phoneNumber => PhoneNumberRegex().IsMatch(phoneNumber)).WithErrorCode(nameof(PhoneNumberIsInvalid))
            .MustAsync(async (phoneNumber, cancellationToken) => (await repository.IsPhoneNumberUniqueAsync(phoneNumber, cancellationToken)).IsSuccess).WithErrorCode(nameof(PhoneNumberIsAlreadyUsed));
        
        RuleFor(command => command.Email)
            .NotEmpty().WithErrorCode(nameof(EmailIsRequired))
            .Must(email => EmailRegex().IsMatch(email)).WithErrorCode(nameof(EmailIsInvalid))
            .MustAsync(async (email, cancellationToken) => (await repository.IsEmailUniqueAsync(email, cancellationToken)).IsSuccess).WithErrorCode(nameof(EmailIsAlreadyUsed));
    }
}
