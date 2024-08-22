using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Data.Requests
{
    public record AuthEntrarUsuarioRequest(string Email, string Senha);
}
