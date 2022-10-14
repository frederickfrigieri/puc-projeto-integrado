namespace Application.Queries.ObterEstoques
{
    public class ObterEstoquesResponse
    {
        public string Descricao { get; set; }
        public string Sku { get; set; }
        public string Parceiro { get; set; }
        public int Quantidade { get; set; }
        public string Armazem { get; set; }
    }
}
