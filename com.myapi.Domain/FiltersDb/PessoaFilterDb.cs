using com.myapi.Domain.Repositories;

namespace com.myapi.Domain.FiltersDb;

public class PessoaFilterDb : PageBaseRequest
{
    public string Nome { get; set; }
}