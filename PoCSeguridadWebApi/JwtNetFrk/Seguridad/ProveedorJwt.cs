using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JwtNetFrk.Seguridad
{
    public class ProveedorJwt
    {
        #region Métodos Públicos
        /// <summary>
        /// Genera un token de tipo JSW Bearer
        /// </summary>
        /// <param name="credencial">Credencial de autenticación</param>
        /// <param name="dominio">Dominio web donde se autentica</param>
        /// <param name="secreto">Clave secreta para generar el hash</param>
        /// <param name="caducidad">Tiempo que dura el token como activo</param>
        /// <returns></returns>
        public string GenerarToken(Credencial credencial, string dominio, string secreto, TimeSpan caducidad)
        {
            var jwtSeguro = new JwtSecurityToken
            (
                issuer: dominio,
                audience: dominio,
                claims: GenerarClaims(credencial),
                // Cuando más corto sea el tiempo de caducidad más aumentará la seguridad
                expires: DateTime.UtcNow.Add(caducidad),
                signingCredentials: secreto.FormarSigningCredentials()
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSeguro);

            return token;
        }
        #endregion

        #region Métodos Auxiliares
        /// <summary>
        /// Genera una colección de claims basados en la credencial pasada como parámetro
        /// </summary>
        /// <param name="credencial">Credencial contiene la información del usuario</param>
        /// <returns>Devuleve una colección de Claims para JWT</returns>
        private IEnumerable<Claim> GenerarClaims(Credencial credencial)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, credencial.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, credencial.Nombre),
                // Se pueden añadir más claims aquí
            };

            if (credencial.Roles != null)
            {
                foreach (var role in credencial.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            return claims;
        }
        #endregion
    }
}