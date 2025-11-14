using System.Text.RegularExpressions;

namespace Huginn.Common;

public static class Constant
{
    public const string UsernameRegex = "^[a-zA-Z][a-zA-Z0-9_]{2,15}$";
    
    public const string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
    
    public const string EmailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

    public const string PhoneNumberRegex = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
}
