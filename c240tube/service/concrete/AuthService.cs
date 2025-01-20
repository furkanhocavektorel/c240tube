using c240tube.context;
using c240tube.entity;
using c240tube.entity.enums;
using c240tube.service.abstracts;

namespace c240tube.service.concrete
{
    public class AuthService : IAuthService
    {
        private C240tubeContext _context;
        public AuthService(C240tubeContext context)
        {
            _context = context;
        }

        public void save(string email, string password, string role)
        {
            Auth? auth1 = getAuthByEmail(email);
            
            if (auth1 != null)
            {
                throw new Exception("bu maile kayıtlı biri var");
            }

            Auth auth = new Auth();
            auth.Email = email;
            auth.Password = password;
            auth.Role = (ERole)Enum.Parse(typeof(ERole), role);

            _context.Auths.Add(auth);
            _context.SaveChanges();

        }

        public Auth getAuthByEmail(string mail)
        {
            Auth? auth = _context.Auths
                .FirstOrDefault(x => x.Email.Equals(mail));
            return auth;
        }

    }
}
