using System.Text.RegularExpressions;

namespace Huginn.Common;

public static partial class GeneratedRegex
{
    [GeneratedRegex(Constant.UsernameRegex, RegexOptions.Compiled)]
    public static partial Regex UsernameRegex();
    
    [GeneratedRegex(Constant.PasswordRegex, RegexOptions.Compiled)]
    public static partial Regex PasswordRegex();
    
    [GeneratedRegex(Constant.PhoneNumberRegex, RegexOptions.Compiled)]
    public static partial Regex PhoneNumberRegex();
    
    [GeneratedRegex(Constant.EmailRegex, RegexOptions.Compiled)]
    public static partial Regex EmailRegex();
}
