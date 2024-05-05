using Microsoft.IdentityModel.Tokens;
using YamlDotNet.Core.Tokens;

namespace WebScanner.DOMAIN;

public static class ValidityCheck
{
    public static void VerifyNullValue(string valueToVerify)
    {
        if (valueToVerify.IsNullOrEmpty()) { throw new Exception("NullValue"); }
        else
        {
        }
    }
}
