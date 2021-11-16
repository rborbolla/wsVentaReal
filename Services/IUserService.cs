using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wsVentaReal.Models.Response;
using wsVentaReal.Models.Request;

namespace wsVentaReal.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
