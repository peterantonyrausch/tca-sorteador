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
    public class ListasSorteioController : Controller,
        RespostaRequisicao<DadosSaidaVisualizarListasSorteio>,
        RespostaRequisicao<DadosSaidaCadastrarListaSorteio>
    {
        private readonly VisualizarListasSorteio visualizarListasSorteio;
        private readonly CadastrarListaSorteio cadastrarListaSorteio;
        private readonly UnidadeTrabalhoSorteador unidadeTrabalho;
        private IEnumerable<ListaSorteioViewModel> listasSorteio;

        public ListasSorteioController()
        {
            this.unidadeTrabalho = new UnidadeTrabalhoSorteador();
            visualizarListasSorteio = new VisualizarListasSorteio(unidadeTrabalho.RepositorioListaSorteio);
            cadastrarListaSorteio = new CadastrarListaSorteio(unidadeTrabalho.RepositorioListaSorteio);
        }

        // GET: ListasSorteio
        public ActionResult Index()
        {
            visualizarListasSorteio.Executar(this);

            return View(listasSorteio);
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
                cadastrarListaSorteio.Executar(CriarDadosEntrada(listaSorteio), this);

                return RedirectToAction("Index");
            }
            catch (ListaSorteioSemNomeException)
            {
                ModelState.AddModelError(string.Empty, "Por favor, informe um nome para a lista.");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Não foi possível criar a lista para sorteio. Erro inesperado. Por favor, tente novamente.");
            }

            return View();
        }

        // GET: ListasSorteio/Edit/5
        public ActionResult Editar(int id)
        {
            visualizarListasSorteio.Executar(this);

            var listaSorteio = listasSorteio.First(ls => ls.IdListaSorteio == id);

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

        public void ProcessarResposta(DadosSaidaVisualizarListasSorteio dadosSaida)
        {
            this.listasSorteio = ConverterParaViewModel(dadosSaida.ListasSorteio);
        }

        public void ProcessarResposta(DadosSaidaCadastrarListaSorteio dadosSaida)
        {
            unidadeTrabalho.Save();
        }

        private static IEnumerable<ListaSorteioViewModel> ConverterParaViewModel(IEnumerable<ListaSorteio> listasSorteio)
        {
            return listasSorteio.Select(listaSorteio =>
                new ListaSorteioViewModel()
                {
                    IdListaSorteio = listaSorteio.Id,
                    Nome = listaSorteio.Nome
                });
        }

        private static DadosEntradaCadastrarListaSorteio CriarDadosEntrada(ListaSorteioViewModel listaSorteio)
        {
            return new DadosEntradaCadastrarListaSorteio()
            {
                Nome = listaSorteio.Nome
            };
        }
    }
}