using SistemaBar.App.Dominio.ModuloGarcom;
using SistemaBar.App.Infraestrutura.Arquivos.Compartilhado;

namespace SistemaBar.App.Infraestrutura.Arquivos.ModuloGarcom;

public class RepositorioGarcomEmArquivo : RepositorioBaseEmArquivo<Garcom>
{
    public RepositorioGarcomEmArquivo(ContextoDados contextoDados) : base(contextoDados)
    {
    }

    protected override List<Garcom> ObterRegistros()
    {
        return contextoDados.Garcons;
    }
}