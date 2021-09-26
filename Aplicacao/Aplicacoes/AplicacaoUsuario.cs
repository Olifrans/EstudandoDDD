using Aplicacao.Interfaces;
using Dominio.Interfaces;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes
{
    public class AplicacaoUsuario : IAplicacaoUsuario
    {
        IUsuario _IUsuario;

        public AplicacaoUsuario(IUsuario iUsuario)
        {
            _IUsuario = iUsuario;
        }

        public async Task<bool> AdicionarUsuario(string email, string senha, int idade, string celular)
        {
            return true;
            //return await _IUsuario.AdicionaUsuario(email, senha, idade, celular);
        }
    }
}
