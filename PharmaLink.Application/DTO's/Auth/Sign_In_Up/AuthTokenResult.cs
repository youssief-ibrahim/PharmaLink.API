using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaLink.Application.DTO_s.Auth.Sign_In_Up
{
    public class AuthTokenResult
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpireOn { get; set; }
    }
}
