using TCA.DAL.EntityFramework.SQL.Contextos;
using TCA.DAL.EntityFramework.SQL.Repositorios.Base;
using TCA.Nucleo.DAL.Interfaces.ListaSorteio;

namespace TCA.DAL.EntityFramework.SQL.Repositorios.ListaSorteio
{
    public class RepositorioListaSorteioEF
        : RepositorioEF<Nucleo.Entidades.ListaSorteio.ListaSorteio>,
        RepositorioListaSorteio
    {
        public RepositorioListaSorteioEF(ContextoSorteador contexto)
            : base(contexto) { }
    }
}