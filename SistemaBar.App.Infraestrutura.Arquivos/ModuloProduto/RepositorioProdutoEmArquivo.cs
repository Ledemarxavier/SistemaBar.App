using SistemaBar.App.Dominio.ModuloProduto;
using SistemaBar.App.Infraestrutura.Arquivos.Compartilhado;

namespace SistemaBar.App.Infraestrutura.Arquivos.ModuloProduto;

public class RepositorioProdutoEmArquivo : RepositorioBaseEmArquivo<Produto>
{
    public RepositorioProdutoEmArquivo(ContextoDados contextoDados) : base(contextoDados)
    {
    }

    protected override List<Produto> ObterRegistros()
    {
        return contextoDados.Produtos;
    }
}