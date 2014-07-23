using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TCA.DAL.EntityFramework.SQL.Repositorios.UnidadeDeTrabalho;
using TCA.Nucleo.CasosDeUso.Base;
using TCA.Nucleo.CasosDeUso.ListaSorteio.Acoes;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosEntrada;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida;
using TCA.Nucleo.CasosDeUso.ListaSorteio.Excecoes;
using TCA.Nucleo.Entidades.ListaSorteio;
using TCA.Visao.Web.MVC.Models;

namespace TCA.Visao.Web.MVC.Controllers
{
    public class ItensListaSorteioController : Controller,
        RespostaRequisicao<DadosSaidaVisualizarItensListaSorteio>,
        RespostaRequisicao<DadosSaidaCadastrarItemListaSorteio>
    {
        private readonly CadastrarItemListaSorteio cadastrarItemListaSorteio;
        private readonly VisualizarItensListaSorteio visualizarItensListaSorteio;
        private IEnumerable<ItemListaSorteioViewModel> itensListaSorteio;
        private long idItemListaSorteioCriado { get; set; }

        public ItensListaSorteioController()
        {
            var unidadeTrabalho = new UnidadeTrabalhoSorteador();
            visualizarItensListaSorteio = new VisualizarItensListaSorteio(unidadeTrabalho.RepositorioItemListaSorteio);
            cadastrarItemListaSorteio = new CadastrarItemListaSorteio(unidadeTrabalho.RepositorioItemListaSorteio);
        }

        public void ProcessarResposta(DadosSaidaCadastrarItemListaSorteio dadosSaida)
        {
            idItemListaSorteioCriado = dadosSaida.IdItemListaSorteio;
        }

        public void ProcessarResposta(DadosSaidaVisualizarItensListaSorteio dadosSaida)
        {
            itensListaSorteio = ConverterParaViewModel(dadosSaida.ItensListaSorteio);
        }

        // GET: ItensListaSorteio
        public ActionResult Index(long idListaSorteio, string nomeListaSorteio)
        {
            visualizarItensListaSorteio.Executar(CriarEntradaVisualizarItensListaSorteio(idListaSorteio), this);

            ViewBag.NomeListaSorteio = nomeListaSorteio;
            ViewBag.IdListaSorteio = idListaSorteio;

            return View(itensListaSorteio);
        }

        // GET: ItensListaSorteio/Create
        public ActionResult Criar(long idListaSorteio, string nomeListaSorteio)
        {
            ViewBag.NomeListaSorteio = nomeListaSorteio;

            var novo = new ItemListaSorteioViewModel
            {
                IdListaSorteio = idListaSorteio,
                NomeListaSorteio = nomeListaSorteio
            };

            return View(novo);
        }

        // POST: ItensListaSorteio/Create
        [HttpPost]
        public ActionResult Criar(ItemListaSorteioViewModel itemListaSorteioViewModel)
        {
            try
            {
                cadastrarItemListaSorteio
                    .Executar(
                        CriarEntradaCadastrarItemListaSorteio(itemListaSorteioViewModel),
                        this);

                return RedirectToAction("Index",
                    new
                    {
                        idListaSorteio = itemListaSorteioViewModel.IdListaSorteio,
                        nomeListaSorteio = itemListaSorteioViewModel.NomeListaSorteio
                    });
            }
            catch (ItemListaSorteioSemReferenciaParaListaException)
            {
                ModelState.AddModelError(string.Empty, "Por favor, informe uma lista para adicionar o item.");
            }
            catch (ItemListaSorteioSemDescricaoException)
            {
                ModelState.AddModelError(string.Empty, "Por favor, informe a descrição do item.");
            }
            catch
            {
                ModelState.AddModelError(string.Empty,
                    "Não foi possível adicionar o item. Erro inesperado. Por favor, tente novamente.");
            }

            return View();
        }

        // GET: ItensListaSorteio/Edit/5
        public ActionResult Editar(long id, long idListaSorteio, string nomeListaSorteio)
        {
            ViewBag.NomeListaSorteio = nomeListaSorteio;
            ViewBag.IdListaSorteio = idListaSorteio;

            visualizarItensListaSorteio.Executar(CriarEntradaVisualizarItensListaSorteio(idListaSorteio), this);

            var itemListaSorteio = itensListaSorteio.First(item => item.IdItemListaSorteio == id);

            itemListaSorteio.IdListaSorteio = idListaSorteio;
            itemListaSorteio.NomeListaSorteio = nomeListaSorteio;

            return View(itemListaSorteio);
        }

        // POST: ItensListaSorteio/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, ItemListaSorteioViewModel itemListaSorteio)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index",
                    new
                    {
                        idListaSorteio = itemListaSorteio.IdListaSorteio,
                        nomeListaSorteio = itemListaSorteio.NomeListaSorteio
                    });
            }
            catch
            {
                return View();
            }
        }

        // GET: ItensListaSorteio/Delete/5
        public ActionResult Excluir(int id)
        {
            return View();
        }

        // POST: ItensListaSorteio/Delete/5
        [HttpPost]
        public ActionResult Excluir(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private static DadosEntradaVisualizarItensListaSorteio CriarEntradaVisualizarItensListaSorteio(
            long idListaSorteio)
        {
            return new DadosEntradaVisualizarItensListaSorteio
            {
                IdListaSorteio = idListaSorteio
            };
        }

        private static DadosEntradaCadastrarItemListaSorteio CriarEntradaCadastrarItemListaSorteio(
            ItemListaSorteioViewModel itemListaSorteioViewModel)
        {
            return new DadosEntradaCadastrarItemListaSorteio
            {
                IdListaSorteio = itemListaSorteioViewModel.IdListaSorteio,
                Descricao = itemListaSorteioViewModel.Descricao
            };
        }

        private IEnumerable<ItemListaSorteioViewModel> ConverterParaViewModel(
            IEnumerable<ItemListaSorteio> itensListaSorteio)
        {
            return itensListaSorteio.Select(item =>
                new ItemListaSorteioViewModel
                {
                    IdItemListaSorteio = item.Id,
                    IdListaSorteio = item.IdListaSorteio,
                    Descricao = item.Descricao
                });
        }
    }
}