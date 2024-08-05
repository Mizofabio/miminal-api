using MiminalApi.Dominio.Entidades;
using MiminalApi.DTOs;

namespace MiminalApi.Dominio.Interfaces;

public interface IAdministradorServico
{
    Administrador? Login(LoginDTO loginDTO);
    Administrador Incluir(Administrador administrador);
    
    List<Administrador> Todos (int? pagina );
    Administrador? BuscaPorId (int id );

    
}