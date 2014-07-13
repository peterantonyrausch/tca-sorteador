using System.Collections.Generic;
using TCA.Nucleo.DAL.Interfaces.Base;
using TCA.Nucleo.Entidades.ListaSorteio;

namespace TCA.Nucleo.DAL.Interfaces.ListaSorteio
{
    public interface RepositorioItemListaSorteio : Repositorio<ItemListaSorteio>
    {
        IEnumerable<ItemListaSorteio> ListarPorListaSorteio(long idListaSorteio);
    }
}