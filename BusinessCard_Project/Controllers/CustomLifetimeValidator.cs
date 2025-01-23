using Microsoft.IdentityModel.Tokens;

namespace BusinessCard_Project.Controllers
{
    public class CustomLifetime
    {
        static public bool CustomLifetimeValidator(DateTime? notBefore, DateTime? expires,
            SecurityToken tokenToValidate, TokenValidationParameters @params)
        {
            if (expires != null)
            {
                return expires > DateTime.UtcNow;
            }

            return false;
        }
    }
}