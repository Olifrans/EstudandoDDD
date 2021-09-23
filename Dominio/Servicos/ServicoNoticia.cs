using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ServicoNoticia : IServicoNoticia
    {
        private readonly INoticia _inoticia;

        public ServicoNoticia(INoticia noticia)
        {
            _inoticia = noticia;
        }

        public async Task AdcionaNoticia(Noticia noticia)
        {
            var validarTitulo = noticia.ValidaPropriedadeSting(noticia.Titulo, "Titulo");
            var validarInformacao = noticia.ValidaPropriedadeSting(noticia.Informacao, "Informacao");

            if (validarTitulo && validarInformacao)
            {
                noticia.DataAlteracao = DateTime.Now;
                noticia.DataCadastro = DateTime.Now;
                noticia.Ativo = true;
                await _inoticia.Adcionar(noticia);
            }
        }

        public async Task AtualizaNoticia(Noticia noticia)
        {
            var validarTitulo = noticia.ValidaPropriedadeSting(noticia.Titulo, "Titulo");
            var validarInformacao = noticia.ValidaPropriedadeSting(noticia.Informacao, "Informacao");

            if (validarTitulo && validarInformacao)
            {
                noticia.DataAlteracao = DateTime.Now;
                noticia.DataCadastro = DateTime.Now;
                noticia.Ativo = true;
                await _inoticia.Atualizar(noticia);
            }
        }

        public async Task<List<Noticia>> ListaNoticiasAtivas()
        {
            return await _inoticia.ListarNoticias(n=>n.Ativo);
        }
    }
}