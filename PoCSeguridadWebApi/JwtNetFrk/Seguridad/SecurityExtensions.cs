using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JwtNetFrk.Seguridad
{
    public static class ExtensionesSeguridad
    {
        public static SigningCredentials FormarSigningCredentials(this string jwtSecret)
        {
            var claveSimetrica = jwtSecret.FormarClaveSeguridadSimetrica();
            var credencialesFirmadas = new SigningCredentials(claveSimetrica, SecurityAlgorithms.HmacSha256);

            return credencialesFirmadas;
        }

        public static SymmetricSecurityKey FormarClaveSeguridadSimetrica(this string jwtSecret)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
        }
    }
}