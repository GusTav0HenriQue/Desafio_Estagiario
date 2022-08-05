using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTOs.UserDtos
{
    public class LoginOutPutUserDto
    {
        public UserDto Usurario { get; set; }
        public string Token { get; set; }
    }
}
