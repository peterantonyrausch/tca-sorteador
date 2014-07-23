using System;
using TCA.DAL.EntityFramework.SQL.Contextos;
using TCA.DAL.EntityFramework.SQL.Repositorios.ListaSorteio;

namespace TCA.DAL.EntityFramework.SQL.Repositorios.UnidadeDeTrabalho
{
    public class UnidadeTrabalhoSorteador
    {
        #region [ Implementação ]

        private readonly ContextoSorteador contexto;
        private bool disposed;

        public UnidadeTrabalhoSorteador()
        {
            contexto = new ContextoSorteador();
            disposed = false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    contexto.Dispose();

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion [ Implementação ]

        #region [ Repositórios ]

        private static RepositorioItemListaSorteioEF repositorioItemListaSorteio;
        private static RepositorioListaSorteioEF repositorioListaSorteio;

        public RepositorioListaSorteioEF RepositorioListaSorteio
        {
            get
            {
                return repositorioListaSorteio
                       ?? (repositorioListaSorteio = new RepositorioListaSorteioEF(contexto));
            }
        }

        public RepositorioItemListaSorteioEF RepositorioItemListaSorteio
        {
            get
            {
                return repositorioItemListaSorteio
                       ?? (repositorioItemListaSorteio = new RepositorioItemListaSorteioEF(contexto));
            }
        }

        #endregion [ Repositórios ]
    }
}