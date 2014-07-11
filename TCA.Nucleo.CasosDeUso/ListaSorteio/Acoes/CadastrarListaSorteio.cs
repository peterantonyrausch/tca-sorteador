using TCA.Nucleo.CasosDeUso.Base;
using TCA.Nucleo.CasosDeUso.ListaSorteio.AcoesInterfaces;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosEntrada;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida;
using TCA.Nucleo.CasosDeUso.ListaSorteio.Excecoes;
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
            ValidarDadosEntrada(dadosEntrada);

            var novaListaSorteio = CriarListaSorteio(dadosEntrada);

            this.repositorioListaSorteio.Inserir(novaListaSorteio);

            respostaRequisicao.ProcessarResposta(CriarDadosSaida(novaListaSorteio));
        }

        private static void ValidarDadosEntrada(DadosEntradaCadastrarListaSorteio dadosEntrada)
        {
            if (string.IsNullOrWhiteSpace(dadosEntrada.Nome))
                throw new ListaSorteioSemNomeException();
        }

        private static DadosSaidaCadastrarListaSorteio CriarDadosSaida(Entidades.ListaSorteio.ListaSorteio novaListaSorteio)
        {
            return new DadosSaidaCadastrarListaSorteio()
            {
                IdListaSorteio = novaListaSorteio.Id
            };
        }

        private static Entidades.ListaSorteio.ListaSorteio CriarListaSorteio(DadosEntradaCadastrarListaSorteio dadosEntrada)
        {
            return new Entidades.ListaSorteio.ListaSorteio()
            {
                Nome = dadosEntrada.Nome
            };
        }
    }
}