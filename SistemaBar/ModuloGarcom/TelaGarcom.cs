using SistemaBar.Compartilhado;
using SistemaBar.ModuloConta;
using SistemaBar.ModuloGarcom;

namespace SistemaBar.ModuloGarcom;

public class TelaGarcom : TelaBase<Garcom>, ITela
{
    private RepositorioConta repositorioConta;

    public TelaGarcom(RepositorioGarcom repositorio, RepositorioConta repositorioConta) : base("Garçom", repositorio)
    {
        this.repositorioConta = repositorioConta;
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Garçons");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -30} | {2, -30}", "Id", "Nome", "CPF");

        Garcom[] garcons = repositorio.SelecionarRegistros();

        for (int i = 0; i < garcons.Length; i++)
        {
            Garcom g = garcons[i];

            if (g == null)
                continue;

            Console.WriteLine("{0, -10} | {1, -30} | {2, -30}", g.Id, g.Nome, g.Cpf);
        }

        ApresentarMensagem("Digite ENTER para continuar...", ConsoleColor.DarkYellow);
    }

    protected override Garcom ObterDados()
    {
        string nome = string.Empty;

        while (string.IsNullOrWhiteSpace(nome))
        {
            Console.Write("Digite o nome do garçom: ");
            nome = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(nome))
            {
                ApresentarMensagem("Digite um nome válido!", ConsoleColor.DarkYellow);
                Console.Clear();
            }
        }

        string cpf = string.Empty;

        while (string.IsNullOrWhiteSpace(cpf))
        {
            Console.Write("Digite o CPF do garçom: ");
            cpf = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(cpf))
            {
                ApresentarMensagem("Digite um CPF válido!", ConsoleColor.DarkYellow);
                Console.Clear();
                continue;
            }

            Garcom[] garcons = repositorio.SelecionarRegistros();
            bool cpfJaExiste = garcons.Any(g => g != null && g.Cpf == cpf);

            if (cpfJaExiste)
            {
                ApresentarMensagem("Já existe um garçom com esse CPF!", ConsoleColor.Red);
                cpf = string.Empty;
                Console.Clear();
            }
        }

        return new Garcom(nome, cpf);
    }

    public override void ExcluirRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Exclusão de Garçom");

        Console.WriteLine();

        VisualizarRegistros(false);

        bool conseguiuConverterId = false;
        int idSelecionado = 0;

        while (!conseguiuConverterId)
        {
            Console.Write("Digite o ID do garçom que deseja excluir: ");
            conseguiuConverterId = int.TryParse(Console.ReadLine(), out idSelecionado);

            if (!conseguiuConverterId)
                ApresentarMensagem("Digite um número válido!", ConsoleColor.DarkYellow);
        }

        Console.WriteLine();

        Garcom garcomSelecionado = repositorio.SelecionarRegistroPorId(idSelecionado);

        List<Conta> contas = repositorioConta.SelecionarContas();
        bool garcomEmUso = contas.Any(conta => conta.Garcom.Id == garcomSelecionado.Id);

        if (garcomEmUso)
        {
            ApresentarMensagem("Este garçom está vinculado a uma conta e não pode ser excluído!", ConsoleColor.Red);
            return;
        }

        repositorio.ExcluirRegistro(idSelecionado);

        ApresentarMensagem("Garçom excluído com sucesso!", ConsoleColor.Green);
    }
}