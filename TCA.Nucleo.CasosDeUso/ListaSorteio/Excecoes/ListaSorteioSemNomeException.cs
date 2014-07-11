using System;
using System.Runtime.Serialization;

namespace TCA.Nucleo.CasosDeUso.ListaSorteio.Excecoes
{
    public class ListaSorteioSemNomeException : Exception
    {
        public ListaSorteioSemNomeException()
            : base() { }

        public ListaSorteioSemNomeException(string mensagem)
            : base(mensagem) { }

        public ListaSorteioSemNomeException(string mensagem, Exception excecaoInterna)
            : base(mensagem, excecaoInterna) { }

        public ListaSorteioSemNomeException(SerializationInfo info, StreamingContext contexto)
            : base(info, contexto) { }
    }
}