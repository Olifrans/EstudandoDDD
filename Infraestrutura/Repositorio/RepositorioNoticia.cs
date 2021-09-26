﻿using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioNoticia : RepositorioGenerico<Noticia>, INoticia
    {
        private readonly DbContextOptions<Contexto> _OptionsBuilder;

        public RepositorioNoticia()
        {
            _OptionsBuilder = new DbContextOptions<Contexto>();
        }
        
        public async Task<List<Noticia>> ListarNoticias(Expression<Func<Noticia, bool>> exNoticia)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                return await banco.Noticia.Where(exNoticia).AsNoTracking().ToListAsync();
            }
        }
    }
}
