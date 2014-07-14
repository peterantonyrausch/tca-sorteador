using NUnit.Framework;
using System.Web.Mvc;
using TCA.Visao.Web.MVC.Controllers;
using TCA.Visao.Web.MVC.Models;

namespace TCA.Visao.Web.MVC.Testes.Controllers
{
    [TestFixture]
    public class TestarListaSorteioController
    {
        private ListasSorteioController controller;

        [SetUp]
        public void Inicializar()
        {
            InicializarController();
        }

        private void InicializarController()
        {
            controller = new ListasSorteioController();
        }

        public void TestarVisualizarListaSorteio()
        {
            var viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult);

            var viewModel = viewResult.Model as ListaSorteioViewModel;
            Assert.IsNotNull(viewModel);
        }
    }
}