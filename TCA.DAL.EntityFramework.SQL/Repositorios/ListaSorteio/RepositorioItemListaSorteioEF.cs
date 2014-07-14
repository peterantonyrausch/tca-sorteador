using System.Collections.Generic;
using TCA.DAL.EntityFramework.SQL.Contextos;
using TCA.DAL.EntityFramework.SQL.Repositorios.Base;
using TCA.Nucleo.DAL.Interfaces.ListaSorteio;

namespace TCA.DAL.EntityFramework.SQL.Repositorios.ListaSorteio
{
    public class RepositorioItemListaSorteioEF :
        RepositorioEF<Nucleo.Entidades.ListaSorteio.ItemListaSorteio>,
        RepositorioItemListaSorteio
    {
        public RepositorioItemListaSorteioEF(ContextoSorteador contexto)
            : base(contexto) { }

        public IEnumerable<Nucleo.Entidades.ListaSorteio.ItemListaSorteio> ListarPorListaSorteio(long idListaSorteio)
        {
            return Listar(expressaoWhere: e => e.IdListaSorteio == idListaSorteio);
        }
    }
}