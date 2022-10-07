namespace com.myapi.Application.DTO;

public class ProdutoDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CodigoErp { get; set; }
    public int QuantidadeEstoque { get; set; }
    public double Preco { get; set; }
}