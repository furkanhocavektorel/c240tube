﻿using c240tube.context;
using c240tube.dto.request;
using c240tube.dto.response;
using c240tube.entity;
using c240tube.entity.enums;
using c240tube.service.abstracts;

namespace c240tube.service.concrete
{
    public class AuthService : IAuthService
    {


        private C240tubeContext _context;

        private IStreamerService _streamerService;
        private IAdminService _adminService;
        private ICustomerService _customerService;

        public AuthService(ICustomerService customerService, C240tubeContext context, IStreamerService streamerService, IAdminService adminService)
        {
            _context = context;
            _streamerService = streamerService;
            _adminService = adminService;
            _customerService = customerService;
        }

        public void save(AuthSaveRequestDto dto)
        {
            Auth? auth1 = getAuthByEmail(dto.email);
            
         
            if (auth1 != null) // false
            {
                throw new Exception("bu maile kayıtlı biri var");
            }

            string hashPass= BCrypt.Net.BCrypt.HashPassword(dto.password);
         

            Auth auth = new Auth();
            auth.Email = dto.email;
            auth.Password = hashPass;
            auth.Role = (ERole)Enum.Parse(typeof(ERole), dto.role);

            _context.Auths.Add(auth);
            _context.SaveChanges();

            Auth ekliAuth= getAuthByEmail(dto.email);

            if (dto.role.Equals("ADMIN"))
            {
                _adminService.save(dto.name, dto.surname, dto.phone, ekliAuth);
            }
            else if (dto.role.Equals("STREAMER"))
            {
                _streamerService.save(dto.name, dto.phone, ekliAuth);

            }else if (dto.role.Equals("CUSTOMER"))
            {
                _customerService.save(dto.name,dto.phone, ekliAuth);
            }

        }


        public Auth getAuthByEmail(string mail)
        {
            Auth? auth = _context.Auths
                .FirstOrDefault(x => x.Email.Equals(mail));
            return auth;
        }


        public AuthResponseDto getAuthByEmailResponse(string email)
        {
            Auth? auth = _context.Auths
                .FirstOrDefault(x => x.Email.Equals(email));

            if (auth == null)
            {
                throw new Exception("bu maile kayitli biri bulunamadi...");
            }

            AuthResponseDto authResponse= new AuthResponseDto();
            authResponse.id = auth.Id;
            authResponse.email = auth.Email;
            authResponse.createAt = auth.CreateAt;

            return authResponse;

        }

        public bool login(LoginRequestDto dto)
        {
            Auth auth = _context.Auths
                .FirstOrDefault(x => x.Email.Equals(dto.email));

            if(auth == null)
            {
                throw new Exception("kayitli mail adresi bulunamadi...");
            }

            if (!BCrypt.Net.BCrypt
                .Verify(dto.password, auth.Password))
            {
                throw new Exception("Yanlis Sifre");
            }
            return true;
            
            
        }



    }
}
