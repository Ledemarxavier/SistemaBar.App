using SistemaBar.Compartilhado;
using SistemaBar.ModuloConta;
using SistemaBar.ModuloGarcom;
using SistemaBar.ModuloMesa;
using SistemaBar.ModuloProduto;

namespace SistemaBar.Compartilhado;

public class TelaPrincipal
{
    private char opcaoEscolhida;

    private RepositorioMesa repositorioMesa;
    private TelaMesa telaMesa;

    private RepositorioGarcom repositorioGarcom;
    private TelaGarcom telaGarcom;

    private RepositorioProduto repositorioProduto;
    private TelaProduto telaProduto;

    private RepositorioConta repositorioConta;
    private TelaConta telaConta;

    public TelaPrincipal()
    {
        repositorioProduto = new RepositorioProduto();

        telaProduto = new TelaProduto(repositorioProduto);
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|           Controle de Bar            |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Mesas");
        Console.WriteLine("2 - Controle de Garçons");
        Console.WriteLine("3 - Controle de Produtos");
        Console.WriteLine("4 - Controle de Contas");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        opcaoEscolhida = Console.ReadLine()![0];
    }

    public ITela ObterTela()
    {
        if (opcaoEscolhida == '3')
            return telaProduto;

        return null;
    }
}