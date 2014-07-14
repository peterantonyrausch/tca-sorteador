using System.Data.Entity;
using TCA.DAL.EntityFramework.SQL.InicializadoresContexto;
using TCA.DAL.EntityFramework.SQL.Mapeamentos;
using TCA.Nucleo.Entidades.ListaSorteio;

namespace TCA.DAL.EntityFramework.SQL.Contextos
{
    public class ContextoSorteador : DbContext
    {
        public DbSet<ListaSorteio> ListasSorteio { get; set; }

        public DbSet<ItemListaSorteio> ItensListaSorteio { get; set; }

        public ContextoSorteador()
            : base("SorteadorConnectionString")
        {
            Database.SetInitializer(new SorteadorInicializadorContexto());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MapeamentoListaSorteio());
            modelBuilder.Configurations.Add(new MapeamentoItemListaSorteio());

            base.OnModelCreating(modelBuilder);
        }
    }
}