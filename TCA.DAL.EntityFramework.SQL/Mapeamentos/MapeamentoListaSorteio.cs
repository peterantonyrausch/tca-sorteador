using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TCA.Nucleo.Entidades.ListaSorteio;

namespace TCA.DAL.EntityFramework.SQL.Mapeamentos
{
    public class MapeamentoListaSorteio : EntityTypeConfiguration<ListaSorteio>
    {
        public MapeamentoListaSorteio()
        {
            ToTable("ListaSorteio");

            HasKey(item => item.Id);

            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(item => item.Nome).HasMaxLength(300).IsRequired();
        }
    }
}