using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCA.WebApi.Models
{
    public class ListaSorteio
    {
        public ListaSorteio()
        {
            
        }

        public ListaSorteio(Nucleo.Entidades.ListaSorteio.ListaSorteio listaSorteio)
        {
            this.Nome = listaSorteio.Nome;
            this.Id = listaSorteio.Id;
        }
        
        //TODO Com esta data annotation no controller se usar ModelState.IsValid verifica se foi preechido
        [Required]
        public string Nome { get; set; }

        public long Id { get; set; }
    }
}