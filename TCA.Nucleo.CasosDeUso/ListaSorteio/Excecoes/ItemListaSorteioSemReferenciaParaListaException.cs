using System;
using System.Runtime.Serialization;

namespace TCA.Nucleo.CasosDeUso.ListaSorteio.Excecoes
{
    public class ItemListaSorteioSemReferenciaParaListaException : Exception
    {
        public ItemListaSorteioSemReferenciaParaListaException()
            : base() { }

        public ItemListaSorteioSemReferenciaParaListaException(string mensagem)
            : base(mensagem) { }

        public ItemListaSorteioSemReferenciaParaListaException(string mensagem, Exception excecaoInterna)
            : base(mensagem, excecaoInterna) { }

        public ItemListaSorteioSemReferenciaParaListaException(SerializationInfo info, StreamingContext contexto)
            : base(info, contexto) { }
    }
}