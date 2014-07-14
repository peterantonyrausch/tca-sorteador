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

        public void Save()
        {
            contexto.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    contexto.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion [ Implementação ]

        #region [ Repositórios ]

        private RepositorioListaSorteioEF repositorioListaSorteio;

        public RepositorioListaSorteioEF RepositorioListaSorteio
        {
            get
            {
                return repositorioListaSorteio
                    ?? (repositorioListaSorteio = new RepositorioListaSorteioEF(contexto));
            }
        }

        private RepositorioItemListaSorteioEF repositorioItemListaSorteio;

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