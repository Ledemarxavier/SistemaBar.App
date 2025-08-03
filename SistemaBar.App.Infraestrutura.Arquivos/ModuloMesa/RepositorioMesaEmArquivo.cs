using SistemaBar.App.Dominio.ModuloMesa;
using SistemaBar.App.Infraestrutura.Arquivos.Compartilhado;

namespace SistemaBar.App.Infraestrutura.Arquivos.ModuloMesa;

public class RepositorioMesaEmArquivo : RepositorioBaseEmArquivo<Mesa>
{
    public RepositorioMesaEmArquivo(ContextoDados contextoDados) : base(contextoDados)
    {
    }

    protected override List<Mesa> ObterRegistros()
    {
        return contextoDados.Mesas;
    }
}