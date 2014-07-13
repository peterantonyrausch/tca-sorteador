using NUnit.Framework;
using System.Linq;
using TCA.Nucleo.CasosDeUso.Base;
using TCA.Nucleo.CasosDeUso.ListaSorteio.Acoes;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosEntrada;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida;
using TCA.Nucleo.DAL.Interfaces.ListaSorteio;
using TCA.Nucleo.Entidades.ListaSorteio;
using TCA.Nucleo.Testes.Mocks;

namespace TCA.Nucleo.Testes.CasosDeUso.ListaSorteio
{
    [TestFixture]
    public class TestarVisualizarItensListaSorteio : RespostaRequisicao<DadosSaidaVisualizarItensListaSorteio>
    {
        private VisualizarItensListaSorteio visualizarItensSorteio;
        private RepositorioItemListaSorteio repositorioItemListaSorteio;
        private DadosSaidaVisualizarItensListaSorteio resultadoVisualizarItensSorteio;

        [SetUp]
        public void Inicializar()
        {
            DefinirRepositorios();
            InicializarCasoDeUso();
            InicializarRepositorios();
        }

        private void DefinirRepositorios()
        {
            this.repositorioItemListaSorteio = new MockRepositorioItemListaSorteio();
        }

        private void InicializarCasoDeUso()
        {
            this.visualizarItensSorteio = new VisualizarItensListaSorteio(repositorioItemListaSorteio);
        }

        private void InicializarRepositorios()
        {
            repositorioItemListaSorteio.Inserir(CriarItemListaSorteio(1, "Item Lista Sorteio 01-01"));
            repositorioItemListaSorteio.Inserir(CriarItemListaSorteio(1, "Item Lista Sorteio 01-02"));
            repositorioItemListaSorteio.Inserir(CriarItemListaSorteio(1, "Item Lista Sorteio 01-03"));
            repositorioItemListaSorteio.Inserir(CriarItemListaSorteio(1, "Item Lista Sorteio 01-04"));
            repositorioItemListaSorteio.Inserir(CriarItemListaSorteio(2, "Item Lista Sorteio 02-01"));
            repositorioItemListaSorteio.Inserir(CriarItemListaSorteio(2, "Item Lista Sorteio 02-02"));
            repositorioItemListaSorteio.Inserir(CriarItemListaSorteio(2, "Item Lista Sorteio 02-03"));
            repositorioItemListaSorteio.Inserir(CriarItemListaSorteio(2, "Item Lista Sorteio 02-04"));
            repositorioItemListaSorteio.Inserir(CriarItemListaSorteio(2, "Item Lista Sorteio 02-05"));
            repositorioItemListaSorteio.Inserir(CriarItemListaSorteio(3, "Item Lista Sorteio 03-01"));
            repositorioItemListaSorteio.Inserir(CriarItemListaSorteio(3, "Item Lista Sorteio 03-02"));
        }

        private static ItemListaSorteio CriarItemListaSorteio(long idListaSorteio, string descricaoItem)
        {
            return new ItemListaSorteio()
            {
                IdListaSorteio = idListaSorteio,
                Descricao = descricaoItem
            };
        }

        [Test]
        public void TestarVisualizarItensListaSorteio1()
        {
            var dadosEntrada = new DadosEntradaVisualizarItensListaSorteio()
            {
                IdListaSorteio = 1
            };

            visualizarItensSorteio.Executar(dadosEntrada, this);

            Assert.AreEqual(1, resultadoVisualizarItensSorteio.IdListaSorteio);
            Assert.AreEqual(4, resultadoVisualizarItensSorteio.ItensListaSorteio.Count());
            Assert.AreEqual(1, resultadoVisualizarItensSorteio.ItensListaSorteio.First().IdListaSorteio);
        }

        [Test]
        public void TestarVisualizarItensListaSorteio2()
        {
            var dadosEntrada = new DadosEntradaVisualizarItensListaSorteio()
            {
                IdListaSorteio = 2
            };

            visualizarItensSorteio.Executar(dadosEntrada, this);

            Assert.AreEqual(2, resultadoVisualizarItensSorteio.IdListaSorteio);
            Assert.AreEqual(5, resultadoVisualizarItensSorteio.ItensListaSorteio.Count());
            Assert.AreEqual(2, resultadoVisualizarItensSorteio.ItensListaSorteio.First().IdListaSorteio);
        }

        [Test]
        public void TestarVisualizarItensListaSorteio3()
        {
            var dadosEntrada = new DadosEntradaVisualizarItensListaSorteio()
            {
                IdListaSorteio = 3
            };

            visualizarItensSorteio.Executar(dadosEntrada, this);

            Assert.AreEqual(3, resultadoVisualizarItensSorteio.IdListaSorteio);
            Assert.AreEqual(2, resultadoVisualizarItensSorteio.ItensListaSorteio.Count());
            Assert.AreEqual(3, resultadoVisualizarItensSorteio.ItensListaSorteio.First().IdListaSorteio);
        }

        public void ProcessarResposta(DadosSaidaVisualizarItensListaSorteio dadosSaida)
        {
            this.resultadoVisualizarItensSorteio = dadosSaida;
        }
    }
}