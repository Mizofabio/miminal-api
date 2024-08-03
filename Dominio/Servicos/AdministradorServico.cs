using System.Data.Common;
using Microsoft.EntityFrameworkCore.Query;
using MiminalApi.Dominio.Entidades;
using MiminalApi.Dominio.Interfaces;
using MiminalApi.DTOs;
using MiminalApi.Infraestrutura.Db;

namespace MiminalApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;
    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }
    public Administrador? Login(LoginDTO loginDTO)
    {
        var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
         return adm;
    }
       

}