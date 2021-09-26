using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Genericos
{
    public interface IGenericaAplicacao<T> where T : class
    {
        Task Adcionar(T objeto);

        Task Atualizar(T objeto);

        Task Excluir(T objeto);

        Task<T> BucarPorId(int Id);

        Task<List<T>> Listar();
    }
}
