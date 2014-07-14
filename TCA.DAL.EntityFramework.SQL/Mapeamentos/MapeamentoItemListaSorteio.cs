using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TCA.Nucleo.Entidades.ListaSorteio;

namespace TCA.DAL.EntityFramework.SQL.Mapeamentos
{
    public class MapeamentoItemListaSorteio : EntityTypeConfiguration<ItemListaSorteio>
    {
        public MapeamentoItemListaSorteio()
        {
            ToTable("ItemListaSorteio");

            HasKey(item => new { item.Id, item.IdListaSorteio });

            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(item => item.IdListaSorteio).IsRequired();
            Property(item => item.Descricao).HasMaxLength(500).IsRequired();

            HasRequired(item => item.ListaSorteio)
                .WithMany(lista => lista.ItensListaSorteio)
                .HasForeignKey(item => item.IdListaSorteio)
                .WillCascadeOnDelete(false);
        }
    }
}