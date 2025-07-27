using SistemaBar.App.Infraestrutura.Memoria.ModuloConta;
using SistemaBar.App.Infraestrutura.Memoria.ModuloGarcom;
using SistemaBar.App.Infraestrutura.Memoria.ModuloMesa;
using SistemaBar.App.Infraestrutura.Memoria.ModuloProduto;
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
        repositorioMesa = new RepositorioMesa();
        repositorioGarcom = new RepositorioGarcom();
        repositorioProduto = new RepositorioProduto();
        repositorioConta = new RepositorioConta();

        telaMesa = new TelaMesa(repositorioMesa, repositorioConta);
        telaGarcom = new TelaGarcom(repositorioGarcom, repositorioConta);
        telaProduto = new TelaProduto(repositorioProduto, repositorioConta);

        telaConta = new TelaConta(
            repositorioConta,
            repositorioProduto,
            repositorioMesa,
            repositorioGarcom
        );
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
        if (opcaoEscolhida == '1')
            return telaMesa;

        if (opcaoEscolhida == '2')
            return telaGarcom;

        if (opcaoEscolhida == '3')
            return telaProduto;

        if (opcaoEscolhida == '4')
            return telaConta;

        return null;
    }
}