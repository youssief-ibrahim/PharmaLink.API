using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaLink.Application.Common;
using PharmaLink.Application.DTO_s.Auth.Sign_In_Up;
using PharmaLink.Application.DTO_s.Sign_In_Up;

namespace PharmaLink.Application.IServices
{
    public interface IAuthenticationService
    {
        Task<Result<AuthModelDto>> LoginAsync(LoginDto LoginDTO);
        Task<Result<AuthModelDto>> RegisterAsync(RegisterDto RegisterDTO);
    }
}
