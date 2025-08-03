using SistemaBar.App.Dominio.ModuloConta;
using SistemaBar.App.Infraestrutura.Arquivos.Compartilhado;

namespace SistemaBar.App.Infraestrutura.Arquivos.ModuloConta;

public class RepositorioContaEmArquivo : RepositorioBaseEmArquivo<Conta>
{
    public RepositorioContaEmArquivo(ContextoDados contextoDados) : base(contextoDados)
    {
    }

    protected override List<Conta> ObterRegistros()
    {
        return contextoDados.Contas;
    }
}