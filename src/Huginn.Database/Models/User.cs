using System.ComponentModel.DataAnnotations;
using Huginn.Database.Common;

namespace Huginn.Database.Models;

public class User : IEntity
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    
    public string Username { get; init; } = string.Empty;
    
    public string HashPassword { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    public string PhoneNumber { get; set; } = string.Empty;
    
    public ulong Balance { get; set; }
}
