using System;
using System.Runtime.Serialization;

namespace TCA.Nucleo.CasosDeUso.ListaSorteio.Excecoes
{
    public class ItemListaSorteioSemDescricaoException : Exception
    {
        public ItemListaSorteioSemDescricaoException()
            : base() { }

        public ItemListaSorteioSemDescricaoException(string mensagem)
            : base(mensagem) { }

        public ItemListaSorteioSemDescricaoException(string mensagem, Exception excecaoInterna)
            : base(mensagem, excecaoInterna) { }

        public ItemListaSorteioSemDescricaoException(SerializationInfo info, StreamingContext contexto)
            : base(info, contexto) { }
    }
}