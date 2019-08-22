using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEssentials.Entities.DTO
{
    public class JWTLoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
