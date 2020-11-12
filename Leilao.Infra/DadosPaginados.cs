namespace Leilao.Infra
{
    public class DadosPaginados
    {
        public int Pagina { get; set; }
        public int QuantidadePorPagina { get; set; }
        public dynamic Dados { get; set; }
        public int Total { get; set; }
    }
}
