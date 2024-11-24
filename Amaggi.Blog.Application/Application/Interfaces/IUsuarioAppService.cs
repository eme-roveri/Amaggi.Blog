﻿using Amaggi.Blog.Application.DTO;

namespace Amaggi.Blog.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        Task<UsuarioDTO> LoginAsync(CredencialDTO credencial);
        Task RegistrarAsync(UsuarioDTO usuarioDTO);
    }
}