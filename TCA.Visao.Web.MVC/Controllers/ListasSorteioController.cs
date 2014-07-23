using System;
using System.Linq;
using System.Web.Mvc;
using TCA.DAL.EntityFramework.SQL.Repositorios.UnidadeDeTrabalho;
using TCA.Nucleo.CasosDeUso.ListaSorteio.Acoes;
using TCA.Nucleo.CasosDeUso.ListaSorteio.AcoesInterfaces;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosEntrada;
using TCA.Nucleo.CasosDeUso.ListaSorteio.Excecoes;
using TCA.Visao.Web.MVC.Models;
using TCA.Visao.Web.MVC.Presenters;

namespace TCA.Visao.Web.MVC.Controllers
{
    public class ListasSorteioController : Controller
    {
        private readonly ListasSorteioPresenter apresentador;
        private readonly Lazy<RequisicaoParaCadastrarListaSorteio> cadastrarListaSorteio;
        private readonly Lazy<RequisicaoParaVisualizarListasSorteio> visualizarListasSorteio;

        public ListasSorteioController()
        {
            var unidadeTrabalho = new UnidadeTrabalhoSorteador();
            apresentador = new ListasSorteioPresenter();
            visualizarListasSorteio = new Lazy<RequisicaoParaVisualizarListasSorteio>(() => new VisualizarListasSorteio(unidadeTrabalho.RepositorioListaSorteio));
            cadastrarListaSorteio = new Lazy<RequisicaoParaCadastrarListaSorteio>(() => new CadastrarListaSorteio(unidadeTrabalho.RepositorioListaSorteio));
        }

        // GET: ListasSorteio
        public ActionResult Index()
        {
            visualizarListasSorteio.Value.Executar(apresentador);

            return View(apresentador.ListasSorteio);
        }

        // GET: ListasSorteio/Details/5
        public ActionResult VisualizarItens(int id, string nome)
        {
            return RedirectToAction("Index", "ItensListaSorteio", new { IdListaSorteio = id, nomeListaSorteio = nome });
        }

        // GET: ListasSorteio/Create
        public ActionResult Criar()
        {
            return View();
        }

        // POST: ListasSorteio/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(ListaSorteioViewModel listaSorteio)
        {
            try
            {
                cadastrarListaSorteio.Value.Executar(CriarDadosEntrada(listaSorteio), apresentador);

                return RedirectToAction("Index");
            }
            catch (ListaSorteioSemNomeException)
            {
                ModelState.AddModelError(string.Empty, "Por favor, informe um nome para a lista.");
            }
            catch
            {
                ModelState.AddModelError(string.Empty,
                    "Não foi possível criar a lista para sorteio. Erro inesperado. Por favor, tente novamente.");
            }

            return View();
        }

        // GET: ListasSorteio/Edit/5
        public ActionResult Editar(int idListaSorteio)
        {
            visualizarListasSorteio.Value.Executar(apresentador);

            var listaSorteio = apresentador.ListasSorteio.First(ls => ls.IdListaSorteio == idListaSorteio);

            return View(listaSorteio);
        }

        // POST: ListasSorteio/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ListasSorteio/Delete/5
        public ActionResult Excluir(int id)
        {
            return View();
        }

        // POST: ListasSorteio/Delete/5
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

        private static DadosEntradaCadastrarListaSorteio CriarDadosEntrada(ListaSorteioViewModel listaSorteio)
        {
            return new DadosEntradaCadastrarListaSorteio
            {
                Nome = listaSorteio.Nome
            };
        }
    }
}