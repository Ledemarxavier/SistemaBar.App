using SistemaBar.App.Dominio.ModuloConta;
using SistemaBar.App.Dominio.ModuloProduto;
using SistemaBar.App.Infraestrutura.Memoria.ModuloConta;
using SistemaBar.App.Infraestrutura.Memoria.ModuloProduto;
using SistemaBar.Compartilhado;
using SistemaBar.ModuloConta;

namespace SistemaBar.ModuloProduto;

public class TelaProduto : TelaBase<Produto>, ITela
{
    private RepositorioConta repositorioConta;

    public TelaProduto(RepositorioProduto repositorio, RepositorioConta repositorioConta) : base("Produto", repositorio)
    {
        this.repositorioConta = repositorioConta;
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Produtos");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -30} | {2, -30}", "Id", "Nome", "Valor");

        Produto[] produtos = repositorio.SelecionarRegistros();

        for (int i = 0; i < produtos.Length; i++)
        {
            Produto p = produtos[i];

            if (p == null)
                continue;

            Console.WriteLine("{0, -10} | {1, -30} | {2, -30}", p.Id, p.Nome, p.Valor.ToString("C2"));
        }

        ApresentarMensagem("Digite ENTER para continuar...", ConsoleColor.DarkYellow);
    }

    protected override Produto ObterDados()
    {
        string nome = string.Empty;

        while (string.IsNullOrWhiteSpace(nome))
        {
            Console.Write("Digite o nome do produto: ");
            nome = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(nome))
            {
                ApresentarMensagem("Digite um nome válido!", ConsoleColor.DarkYellow);
                Console.Clear();
                continue;
            }

            Produto[] produtos = repositorio.SelecionarRegistros();
            bool nomeJaExiste = produtos.Any(p => p != null && p.Nome == nome);

            if (nomeJaExiste)
            {
                ApresentarMensagem("Já existe um produto com esse nome!", ConsoleColor.Red);
                nome = string.Empty;
                Console.Clear();
            }
        }

        bool conseguiuConverterValor = false;

        decimal valor = 0.0m;

        while (!conseguiuConverterValor)
        {
            Console.Write("Digite o valor do produto: ");
            conseguiuConverterValor = decimal.TryParse(Console.ReadLine(), out valor);

            if (!conseguiuConverterValor)
            {
                ApresentarMensagem("Digite um valor numérico válido!", ConsoleColor.DarkYellow);
                Console.Clear();
            }
        }

        return new Produto(nome, valor);
    }

    public override void ExcluirRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine($"Exclusão de Produto");

        Console.WriteLine();

        VisualizarRegistros(false);

        bool conseguiuConverterId = false;

        int idSelecionado = 0;

        while (!conseguiuConverterId)
        {
            Console.Write("Digite o ID do produto que deseja excluir po: ");
            conseguiuConverterId = int.TryParse(Console.ReadLine(), out idSelecionado);

            if (!conseguiuConverterId)
                ApresentarMensagem("Digite um número válido!", ConsoleColor.DarkYellow);
        }

        Console.WriteLine();

        Produto produtoSelecionado = repositorio.SelecionarRegistroPorId(idSelecionado);

        List<Conta> contas = repositorioConta.SelecionarContas();
        bool produtoEmUso = contas.Any(conta =>
            conta.Pedidos.Any(p => p != null && p.Produto.Id == produtoSelecionado.Id));

        if (produtoEmUso)
        {
            ApresentarMensagem("Este produto está vinculado a um pedido e não pode ser excluído!", ConsoleColor.Red);
            return;
        }

        repositorio.ExcluirRegistro(idSelecionado);

        ApresentarMensagem($"Produto excluído com sucesso!", ConsoleColor.Green);
    }
}