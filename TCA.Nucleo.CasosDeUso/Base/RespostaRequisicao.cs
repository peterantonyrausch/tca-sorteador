namespace TCA.Nucleo.CasosDeUso.Base
{
    public interface RespostaRequisicao { }

    public interface RespostaRequisicao<in TDadosSaida> : RespostaRequisicao
        where TDadosSaida : DadosSaida
    {
        void ProcessarResposta(TDadosSaida dadosSaida);
    }
}