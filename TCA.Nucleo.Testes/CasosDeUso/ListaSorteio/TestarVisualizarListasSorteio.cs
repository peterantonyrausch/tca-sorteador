using System.Linq;
using NUnit.Framework;
using TCA.Nucleo.CasosDeUso.Base;
using TCA.Nucleo.CasosDeUso.ListaSorteio.Acoes;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida;
using TCA.Nucleo.DAL.Interfaces.ListaSorteio;
using TCA.Nucleo.Testes.Mocks;

namespace TCA.Nucleo.Testes.CasosDeUso.ListaSorteio
{
    [TestFixture]
    public class TestarVisualizarListasSorteio : RespostaRequisicao<DadosSaidaVisualizarListasSorteio>
    {
        private VisualizarListasSorteio visualizarListasSorteio;
        private RepositorioListaSorteio repositorioListaSorteio;
        private DadosSaidaVisualizarListasSorteio resultadoVisualizarListasSorteio;

        [SetUp]
        public void Inicializar()
        {
            DefinirRepositorios();
            InicializarCasoDeUso();
            InicializarRepositorios();
        }

        private void DefinirRepositorios()
        {
            this.repositorioListaSorteio = new MockRepositorioListaSorteio();
        }

        private void InicializarCasoDeUso()
        {
            this.visualizarListasSorteio = new VisualizarListasSorteio(repositorioListaSorteio);
        }

        private void InicializarRepositorios()
        {
            this.repositorioListaSorteio.Inserir(CriarListaSorteio("Lista Sorteio 01"));
            this.repositorioListaSorteio.Inserir(CriarListaSorteio("Lista Sorteio 02"));
            this.repositorioListaSorteio.Inserir(CriarListaSorteio("Lista Sorteio 03"));
            this.repositorioListaSorteio.Inserir(CriarListaSorteio("Lista Sorteio 04"));
            this.repositorioListaSorteio.Inserir(CriarListaSorteio("Lista Sorteio 05"));
        }

        private static Entidades.ListaSorteio.ListaSorteio CriarListaSorteio(string nome)
        {
            return new Entidades.ListaSorteio.ListaSorteio()
            {
                Nome = nome
            };
        }

        [Test]
        public void TestarVisualizacaoListasSorteio()
        {
            visualizarListasSorteio.Executar(this);

            Assert.AreEqual(5, this.resultadoVisualizarListasSorteio.ListasSorteio.Count());
        }

        public void ProcessarResposta(DadosSaidaVisualizarListasSorteio dadosSaida)
        {
            this.resultadoVisualizarListasSorteio = dadosSaida;
        }
    }
}