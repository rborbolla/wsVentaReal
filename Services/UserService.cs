using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wsVentaReal.Models.Response;
using wsVentaReal.Models.Request;
using wsVentaReal.Models;
using wsVentaReal.Tools;
using wsVentaReal.Models.Common;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace wsVentaReal.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserResponse Auth(AuthRequest model)
        {
            UserResponse userResponse = new UserResponse();
            using (var db = new VentaRealContext())
            {
                string spassword = Encrypt.GetSHA256(model.Password);

                var usuario = db.AppUsuarios.Where(d => d.Email == model.Email &&
                                                    d.Password == spassword).FirstOrDefault();

                if (usuario == null) return null;

                userResponse.Email = usuario.Email;
                userResponse.Token = GetToken(usuario);
            }

            return userResponse;
        }

        private string GetToken(AppUsuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Email, usuario.Email),
                    }
                    ),
                    Expires = DateTime.UtcNow.AddDays(60),
                    SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
