using System.Linq;
using TCA.Nucleo.CasosDeUso.Base;
using TCA.Nucleo.CasosDeUso.ListaSorteio.AcoesInterfaces;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosEntrada;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida;
using TCA.Nucleo.DAL.Interfaces.ListaSorteio;

namespace TCA.Nucleo.CasosDeUso.ListaSorteio.Acoes
{
    public class CadastrarListaSorteio : RequisicaoParaCadastrarListaSorteio
    {
        private readonly RepositorioListaSorteio repositorioListaSorteio;

        public CadastrarListaSorteio(RepositorioListaSorteio repositorioListaSorteio)
        {
            this.repositorioListaSorteio = repositorioListaSorteio;
        }

        public void Executar(DadosEntradaCadastrarListaSorteio dadosEntrada,
            RespostaRequisicao<DadosSaidaCadastrarListaSorteio> respostaRequisicao)
        {
            var novaListaSorteio = ObterListaSorteio(dadosEntrada);

            this.repositorioListaSorteio.Inserir(novaListaSorteio);

            respostaRequisicao.ProcessarResposta(CriarDadosSaida());
        }

        private DadosSaidaCadastrarListaSorteio CriarDadosSaida()
        {
            return new DadosSaidaCadastrarListaSorteio()
            {
                IdListaSorteio = this.repositorioListaSorteio.Listar().Max(listaSorteio => listaSorteio.Id)
            };
        }

        private Entidades.ListaSorteio.ListaSorteio ObterListaSorteio(DadosEntradaCadastrarListaSorteio dadosEntrada)
        {
            return new Entidades.ListaSorteio.ListaSorteio()
            {
                Nome = dadosEntrada.Nome
            };
        }
    }
}