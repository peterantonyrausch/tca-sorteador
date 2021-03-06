﻿using NUnit.Framework;
using TCA.Nucleo.CasosDeUso.Base;
using TCA.Nucleo.CasosDeUso.ListaSorteio.Acoes;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosEntrada;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida;
using TCA.Nucleo.CasosDeUso.ListaSorteio.Excecoes;
using TCA.Nucleo.DAL.Interfaces.ListaSorteio;
using TCA.Nucleo.Testes.Mocks;

namespace TCA.Nucleo.Testes.CasosDeUso.ListaSorteio
{
    [TestFixture]
    public class TesteCadastrarItemLista : RespostaRequisicao<DadosSaidaCadastrarItemListaSorteio>
    {
        private CadastrarItemListaSorteio cadastrarItemLista;
        private RepositorioItemListaSorteio repositorioItemLista;
        private DadosSaidaCadastrarItemListaSorteio resultadoCadastrarItemLista;

        [SetUp]
        public void Inicializar()
        {
            DefinirRepositorios();
            InicializarCasoDeUso();
        }

        private void InicializarCasoDeUso()
        {
            this.cadastrarItemLista = new CadastrarItemListaSorteio(repositorioItemLista);
        }

        private void DefinirRepositorios()
        {
            this.repositorioItemLista = new MockRepositorioItemListaSorteio();
        }

        [Test]
        public void TestarCadastroDeUmItemListaSorteio()
        {
            var dadosEntrada = new DadosEntradaCadastrarItemListaSorteio()
            {
                IdListaSorteio = 1,
                Descricao = "Meu primeiro item de lista"
            };

            cadastrarItemLista.Executar(dadosEntrada, this);

            Assert.AreEqual(1, this.resultadoCadastrarItemLista.IdItemListaSorteio);
        }

        [Test]
        public void TestarCadsatroDeUmItemListaSorteioSemDescricao()
        {
            var dadosEntrada = new DadosEntradaCadastrarItemListaSorteio()
            {
                IdListaSorteio = 1
            };

            Assert.Throws<ItemListaSorteioSemDescricaoException>(
                () => cadastrarItemLista.Executar(dadosEntrada, this));
        }

        [Test]
        public void TestarCadastroDeUmItemListaSorteioSemReferenciaParaLista()
        {
            var dadosEntrada = new DadosEntradaCadastrarItemListaSorteio()
            {
                Descricao = "Meu primeiro item de lista"
            };

            Assert.Throws<ItemListaSorteioSemReferenciaParaListaException>(
                () => cadastrarItemLista.Executar(dadosEntrada, this));
        }

        public void ProcessarResposta(DadosSaidaCadastrarItemListaSorteio dadosSaida)
        {
            this.resultadoCadastrarItemLista = dadosSaida;
        }
    }
}