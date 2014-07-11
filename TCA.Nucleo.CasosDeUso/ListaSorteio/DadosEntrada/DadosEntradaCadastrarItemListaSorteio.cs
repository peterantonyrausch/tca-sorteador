namespace TCA.Nucleo.CasosDeUso.ListaSorteio.DadosEntrada
{
    public struct DadosEntradaCadastrarItemListaSorteio : Base.DadosEntrada
    {
        public long IdListaSorteio { get; set; }

        public string Descricao { get; set; }
    }
}