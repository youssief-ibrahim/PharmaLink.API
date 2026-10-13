using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaLink.Application.DTO_s.Auth.Sign_In_Up
{
    public class AuthModelDto
    {
        public bool IsAuthenticated { get; set; }
        public string phoneNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime ExpireOn { get; set; }
        public ICollection<string> Roles { get; set; } = new HashSet<string>();
    }
}
