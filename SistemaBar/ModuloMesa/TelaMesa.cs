using SistemaBar.App.Dominio.ModuloConta;
using SistemaBar.App.Dominio.ModuloMesa;
using SistemaBar.App.Infraestrutura.Memoria.ModuloConta;
using SistemaBar.App.Infraestrutura.Memoria.ModuloMesa;
using SistemaBar.Compartilhado;
using SistemaBar.ModuloConta;

namespace SistemaBar.ModuloMesa;

public class TelaMesa : TelaBase<Mesa>, ITela
{
    private RepositorioConta repositorioConta;

    public TelaMesa(RepositorioMesa repositorioMesa, RepositorioConta repositorioConta) : base("Mesa", repositorioMesa)
    {
        this.repositorioConta = repositorioConta;
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Mesas");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -20} | {3, -30}",
            "Id", "Número", "Capacidade", "Status"
        );

        Mesa[] mesas = repositorio.SelecionarRegistros();

        for (int i = 0; i < mesas.Length; i++)
        {
            Mesa m = mesas[i];

            if (m == null)
                continue;

            string statusMesa = m.EstaOcupada ? "Ocupada" : "Disponível";

            Console.WriteLine(
              "{0, -10} | {1, -20} | {2, -20} | {3, -30}",
                m.Id, m.Numero, m.Capacidade, statusMesa
            );
        }

        ApresentarMensagem("Digite ENTER para continuar...", ConsoleColor.DarkYellow);
    }

    protected override Mesa ObterDados()
    {
        bool conseguiuConverterNumero = false;
        int numero = 0;

        while (!conseguiuConverterNumero)
        {
            Console.Write("Digite o número da mesa: ");
            conseguiuConverterNumero = int.TryParse(Console.ReadLine(), out numero);

            if (!conseguiuConverterNumero)
            {
                ApresentarMensagem("Digite um número válido!", ConsoleColor.DarkYellow);
                Console.Clear();
                continue;
            }

            Mesa[] mesas = repositorio.SelecionarRegistros();
            bool numeroJaExiste = mesas.Any(m => m != null && m.Numero == numero);

            if (numeroJaExiste)
            {
                conseguiuConverterNumero = false;
                ApresentarMensagem("Já existe uma mesa com esse número!", ConsoleColor.Red);
                Console.Clear();
            }
        }

        bool conseguiuConverterCapacidade = false;
        int capacidade = 0;

        while (!conseguiuConverterCapacidade)
        {
            Console.Write("Digite a capacidade da mesa: ");
            conseguiuConverterCapacidade = int.TryParse(Console.ReadLine(), out capacidade);

            if (!conseguiuConverterCapacidade)
            {
                ApresentarMensagem("Digite um número válido!", ConsoleColor.DarkYellow);
                Console.Clear();
            }
        }

        return new Mesa(numero, capacidade);
    }

    public override void ExcluirRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine($"Exclusão de Mesa");

        Console.WriteLine();

        VisualizarRegistros(false);

        bool conseguiuConverterId = false;
        int idSelecionado = 0;

        while (!conseguiuConverterId)
        {
            Console.Write("Digite o ID da mesa que deseja excluir: ");
            conseguiuConverterId = int.TryParse(Console.ReadLine(), out idSelecionado);

            if (!conseguiuConverterId)
                ApresentarMensagem("Digite um número válido!", ConsoleColor.DarkYellow);
        }

        Console.WriteLine();

        Mesa mesaSelecionada = repositorio.SelecionarRegistroPorId(idSelecionado);

        List<Conta> contas = repositorioConta.SelecionarContas();
        bool mesaEmUso = contas.Any(conta => conta.Mesa.Id == mesaSelecionada.Id);

        if (mesaEmUso)
        {
            ApresentarMensagem("Esta mesa está vinculada a uma conta e não pode ser excluída!", ConsoleColor.Red);
            return;
        }

        repositorio.ExcluirRegistro(idSelecionado);

        ApresentarMensagem($"Mesa excluída com sucesso!", ConsoleColor.Green);
    }
}