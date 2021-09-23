using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Genericos
{
    public interface IGenericos<T> where T : class
    {
        Task Adcionar(T objeto);

        Task Atualizar(T objeto);

        Task Excluir(T objeto);

        Task<T> BucarPorId(int id);

        Task<List<T>> Listar();
        
    }
}
