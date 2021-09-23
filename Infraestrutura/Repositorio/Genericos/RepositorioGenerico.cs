using Dominio.Interfaces.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio.Genericos
{
    public class RepositorioGenerico<T> : IGenericos<T>, IDisposable where T : class
    {
        public Task Adcionar(T objeto)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(T objeto)
        {
            throw new NotImplementedException();
        }

        public Task<T> BucarPorId(int id)
        {
            throw new NotImplementedException();
        }
               

        public Task Excluir(T objeto)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Listar()
        {
            throw new NotImplementedException();
        }

        // ver refencia passada na aula copia a refencia do dispoe na microsofit
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
