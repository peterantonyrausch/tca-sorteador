using NUnit.Framework;
using TCA.Nucleo.CasosDeUso.Base;
using TCA.Nucleo.CasosDeUso.ListaSorteio.Acoes;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosEntrada;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida;
using TCA.Nucleo.DAL.Interfaces.ListaSorteio;
using TCA.Nucleo.Testes.Mocks;

namespace TCA.Nucleo.Testes.CasosDeUso.ListaSorteio
{
    [TestFixture]
    public class TesteCadastrarLista : RespostaRequisicao<DadosSaidaCadastrarListaSorteio>
    {
        private CadastrarListaSorteio cadastrarLista;
        private RepositorioListaSorteio repositorioListaSorteio;
        private DadosSaidaCadastrarListaSorteio resultadoCadastrarLista;

        [SetUp]
        public void Inicializar()
        {
            DefinirRepositorios();
            InicializarCasoDeUso();
        }

        private void InicializarCasoDeUso()
        {
            cadastrarLista = new CadastrarListaSorteio(repositorioListaSorteio);
        }

        private void DefinirRepositorios()
        {
            this.repositorioListaSorteio = new MockRepositorioListaSorteio();
        }

        [Test]
        public void TestarCadastrarListaSorteio()
        {
            var dadosEntrada = new DadosEntradaCadastrarListaSorteio()
            {
                Nome = "Minha primeira lista"
            };

            cadastrarLista.Executar(dadosEntrada, this);

            Assert.AreEqual(1, resultadoCadastrarLista.IdListaSorteio);
        }

        public void ProcessarResposta(DadosSaidaCadastrarListaSorteio dadosSaida)
        {
            resultadoCadastrarLista = dadosSaida;
        }
    }
}