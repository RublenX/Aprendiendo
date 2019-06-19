using System;
using System.Configuration;
using System.Threading.Tasks;
using JwtNetFrk.Seguridad;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security.Jwt;
using Owin;

[assembly: OwinStartup(typeof(JwtNetFrk.Startup))]

namespace JwtNetFrk
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                TokenValidationParameters = new TokenValidationParameters
                {
                    // AuthenticationType = "Bearer",
                    // Deben coincidir el secreto y el dominio al generar el token para el cliente
                    IssuerSigningKey = ConfigurationManager.AppSettings["SecretoJwt"].FormarClaveSeguridadSimetrica(),
                    ValidIssuer = ConfigurationManager.AppSettings["DominioJwt"],
                    ValidAudience = ConfigurationManager.AppSettings["DominioJwt"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(0)
                }
            });
        }
    }
}
