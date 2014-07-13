using System.Collections.Generic;
using System.Linq;
using TCA.Nucleo.DAL.Interfaces.ListaSorteio;
using TCA.Nucleo.Entidades.ListaSorteio;
using TCA.Nucleo.Testes.Base;

namespace TCA.Nucleo.Testes.Mocks
{
    public class MockRepositorioItemListaSorteio : Mock<ItemListaSorteio>, RepositorioItemListaSorteio
    {
        public IEnumerable<ItemListaSorteio> ListarPorListaSorteio(long idListaSorteio)
        {
            return Entidades.Where(item => item.IdListaSorteio == idListaSorteio);
        }
    }
}