using MiminalApi.Dominio.Entidades;
using MiminalApi.DTOs;

namespace MiminalApi.Dominio.Interfaces;

public interface IAdministradorServico
{
    Administrador? Login(LoginDTO loginDTO);
}