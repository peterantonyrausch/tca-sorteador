using System.ComponentModel.DataAnnotations;

namespace TCA.WebApi.Models
{
    public class ItemListaSorteio
    {
        [Required]
        public string Descricao { get; set; }

        [Required]
        public long IdListaSorteio { get; set; }

        public long IdItemListaSorteio { get; set; }
    }
}
