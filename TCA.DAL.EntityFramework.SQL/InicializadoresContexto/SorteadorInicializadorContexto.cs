using System.Data.Entity;
using TCA.DAL.EntityFramework.SQL.Contextos;
using TCA.Nucleo.Entidades.ListaSorteio;

namespace TCA.DAL.EntityFramework.SQL.InicializadoresContexto
{
    public class SorteadorInicializadorContexto : DropCreateDatabaseIfModelChanges<ContextoSorteador>
    {
        protected override void Seed(ContextoSorteador contexto)
        {
            contexto.ListasSorteio.Add(new ListaSorteio() { Nome = "Jogadores" });
            contexto.SaveChanges();
            contexto.ItensListaSorteio.Add(new ItemListaSorteio() { IdListaSorteio = 1, Descricao = "Júlio César" });
            contexto.ItensListaSorteio.Add(new ItemListaSorteio() { IdListaSorteio = 1, Descricao = "Thiago Silva" });
            contexto.ItensListaSorteio.Add(new ItemListaSorteio() { IdListaSorteio = 1, Descricao = "David Luiz" });
            contexto.ItensListaSorteio.Add(new ItemListaSorteio() { IdListaSorteio = 1, Descricao = "Hulk" });
            contexto.ItensListaSorteio.Add(new ItemListaSorteio() { IdListaSorteio = 1, Descricao = "Neymar" });
            contexto.ItensListaSorteio.Add(new ItemListaSorteio() { IdListaSorteio = 1, Descricao = "Fred" });
            contexto.ItensListaSorteio.Add(new ItemListaSorteio() { IdListaSorteio = 1, Descricao = "Luiz Gustavo" });
            contexto.SaveChanges();

            contexto.ListasSorteio.Add(new ListaSorteio() { Nome = "Lanches" });
            contexto.SaveChanges();
            contexto.ItensListaSorteio.Add(new ItemListaSorteio() { IdListaSorteio = 2, Descricao = "X-Salada" });
            contexto.ItensListaSorteio.Add(new ItemListaSorteio() { IdListaSorteio = 2, Descricao = "X-Bacon" });
            contexto.ItensListaSorteio.Add(new ItemListaSorteio() { IdListaSorteio = 2, Descricao = "X-Alcatra" });
            contexto.ItensListaSorteio.Add(new ItemListaSorteio() { IdListaSorteio = 2, Descricao = "Misto quente" });
            contexto.ItensListaSorteio.Add(new ItemListaSorteio() { IdListaSorteio = 2, Descricao = "Cachorro quente" });
            contexto.ItensListaSorteio.Add(new ItemListaSorteio() { IdListaSorteio = 2, Descricao = "X-Galinha" });
            contexto.ItensListaSorteio.Add(new ItemListaSorteio() { IdListaSorteio = 2, Descricao = "Batata frita" });
            contexto.SaveChanges();
        }
    }
}