using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioUsuario : RepositorioGenerico<ApplicationUser>, IUsuario
    {
        private readonly DbContextOptions<Contexto> _OptionsBuilder;
        public RepositorioUsuario()
        {
            _OptionsBuilder = new DbContextOptions<Contexto>();
        }

        public async Task<bool> AdicionarUsuario(string email, string senha, int idade, string celular)
        {
            try
            {
                using (var data = new Contexto(_OptionsBuilder))
                {
                   await data.ApplicationUser.AddAsync(
                       new ApplicationUser
                       {
                           Email = email,
                           PasswordHash = senha,
                           Idade = idade,
                           Celular = celular,
                           //Tipo = TipoUsuario.Comum
                       });
                    await data.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> ExisteUsuario(string email, string senha)
        {
            try
            {
                using (var data = new Contexto(_OptionsBuilder))
                {
                    return await data.ApplicationUser.
                        Where(u => u.Email.Equals(email) && u.PasswordHash.Equals(senha))
                        .AsNoTracking()
                        .AnyAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
