using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceServicos
{
    public interface IServicoNoticia
    {
        Task AdcionaNoticia(Noticia noticia);

        Task AtualizaNoticia(Noticia noticia);

        Task<List<Noticia>> ListaNoticiasAtivas();
    }
}
