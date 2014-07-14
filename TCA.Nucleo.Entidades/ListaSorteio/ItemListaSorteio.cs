using TCA.Nucleo.Entidades.Base;

namespace TCA.Nucleo.Entidades.ListaSorteio
{
    public class ItemListaSorteio : Entidade
    {
        public long IdListaSorteio { get; set; }

        public virtual ListaSorteio ListaSorteio { get; set; }

        public string Descricao { get; set; }
    }
}