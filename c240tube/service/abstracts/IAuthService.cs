﻿using c240tube.dto;
using c240tube.entity;

namespace c240tube.service.abstracts
{
    public interface IAuthService
    {
        public void save(AuthSaveRequestDto dto);
        Auth getAuthByEmail(string mail);
        AuthResponseDto getAuthByEmailResponse(string email);
    }
}
