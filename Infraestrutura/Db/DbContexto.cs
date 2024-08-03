using Microsoft.EntityFrameworkCore;
using MiminalApi.Dominio.Entidades;
namespace MiminalApi.Infraestrutura.Db;
public class DbContexto : DbContext
{
    private readonly IConfiguration _configuracaoAppSettings;
    public DbContexto(IConfiguration configuracaoAppSettings)
    {
        _configuracaoAppSettings = configuracaoAppSettings;
        
    }
    public DbSet<Administrador> Administradores { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>().HasData(
            new Administrador {
                Id = 1,
                Email = "Administrador@teste.com",
                Senha = "123456",
                Perfil = "Adm" 
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            var StringConexao = _configuracaoAppSettings.GetConnectionString("mysql")?.ToString();
            if(!String.IsNullOrEmpty(StringConexao))
            {
                optionsBuilder.UseMySql(
                StringConexao, 
                ServerVersion.AutoDetect(StringConexao)
                
                );

            }
        }

       
    }
}