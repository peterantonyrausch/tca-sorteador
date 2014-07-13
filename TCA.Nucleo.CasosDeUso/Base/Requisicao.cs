namespace TCA.Nucleo.CasosDeUso.Base
{
    public interface Requisicao { }

    public interface Requisicao<in TDadosEntrada, in TRespostaRequisicao> : Requisicao
        where TDadosEntrada : DadosEntrada
        where TRespostaRequisicao : RespostaRequisicao
    {
        void Executar(TDadosEntrada dadosEntrada, TRespostaRequisicao respostaRequisicao);
    }

    public interface Requisicao<in TRespostaRequisicao> : Requisicao
        where TRespostaRequisicao : RespostaRequisicao
    {
        void Executar(TRespostaRequisicao respostaRequisicao);
    }
}