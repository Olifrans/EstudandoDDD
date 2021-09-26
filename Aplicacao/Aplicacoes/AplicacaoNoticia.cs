using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes
{
    public class AplicacaoNoticia : IAplicacaoNoticia
    {
        INoticia _INoticia;
        IServicoNoticia _IServicoNoticia;
        public AplicacaoNoticia(INoticia iNoticia, IServicoNoticia iServicoNoticia)
        {
            _INoticia = iNoticia;
            _IServicoNoticia = iServicoNoticia;
        }

        //Metodos Customizados
        public async Task AdcionaNoticia(Noticia noticia)
        {
            await _IServicoNoticia.AdcionaNoticia(noticia);
        }              

        public async Task AtualizaNoticia(Noticia noticia)
        {
            await _IServicoNoticia.AtualizaNoticia(noticia);
        }

        public async Task<List<Noticia>> ListaNoticiasAtivas()
        {
            return await _IServicoNoticia.ListaNoticiasAtivas();
        }


        //Metodos Genericos
        public async Task Adcionar(Noticia objeto)
        {
            await _INoticia.Adcionar(objeto);
        }

        public async Task Atualizar(Noticia objeto)
        {
            await _INoticia.Atualizar(objeto);
        }

        public async Task<Noticia> BucarPorId(int Id)
        {
            return await _INoticia.BucarPorId(Id);
        }

        public async Task Excluir(Noticia objeto)
        {
            await _INoticia.Excluir(objeto);
        }              

        public async Task<List<Noticia>> Listar()
        {
            return await _INoticia.Listar();
        }
    }
}
