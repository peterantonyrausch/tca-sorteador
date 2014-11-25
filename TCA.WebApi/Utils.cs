using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCA.DAL.EntityFramework.SQL.Repositorios.UnidadeDeTrabalho;
using TCA.WebApi.Models;

namespace TCA.WebApi
{
    public class Utils
    {
        public static UnidadeTrabalhoSorteador ObterUnidadeTrabalhoSorteador()
        {
            return new UnidadeTrabalhoSorteador();
        }

        public static IEnumerable<ItemListaSorteio> ConverterParaItensListaSorteio(IEnumerable<Nucleo.Entidades.ListaSorteio.ItemListaSorteio> itensListaSorteio)
        {
            return itensListaSorteio.Select(itemListaSorteio => new ItemListaSorteio()
            {
                Descricao = itemListaSorteio.Descricao,
                IdItemListaSorteio = itemListaSorteio.Id,
                IdListaSorteio = itemListaSorteio.IdListaSorteio
            });
        }
        
    }
}