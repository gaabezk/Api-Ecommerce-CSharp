namespace com.myapi.Application.DTO;

public class CompraDTO
{
    public string CodigoErp { get; set; }
    public string Cpf { get; set; }
    public int Id { get; set; }
    public string? Nome { get; set; }
    public int? QuantidadeEstoque { get; set; }
    public double? Preco { get; set; }
}