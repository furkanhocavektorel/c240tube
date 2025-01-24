using c240tube.dto.request;
using c240tube.dto.response;
using c240tube.entity;
using c240tube.service.abstracts;
using Microsoft.AspNetCore.Mvc;

namespace c240tube.controller
{

    [ApiController]
    [Route("/auth")]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // DTO 
        [HttpPost("save")]
        public void save([FromBody]AuthSaveRequestDto dto)
        {

                _authService.save(dto);
        }

        [HttpGet("by-mail")]
        public AuthResponseDto getAuthByMail(string mail)
        {
            return _authService.getAuthByEmailResponse(mail);
        }




    }
}
