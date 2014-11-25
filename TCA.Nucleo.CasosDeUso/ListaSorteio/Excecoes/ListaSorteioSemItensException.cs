using System;
using System.Runtime.Serialization;

namespace TCA.Nucleo.CasosDeUso.ListaSorteio.Excecoes
{
    public class ListaSorteioSemItensException : Exception
    {
        public ListaSorteioSemItensException() : base() { }

        public ListaSorteioSemItensException(string mensagem) : base(mensagem) { }

        public ListaSorteioSemItensException(string mensagem, Exception excecaoInterna) : base(mensagem, excecaoInterna) { }

        public ListaSorteioSemItensException(SerializationInfo info, StreamingContext contexto) : base(info, contexto) { }
    }
}
