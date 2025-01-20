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

        [HttpPost]
        public void save(string email, string password, string role)
        {
            _authService.save(email, password, role);
        }




    }
}
