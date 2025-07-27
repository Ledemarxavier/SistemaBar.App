using SistemaBar.App.Dominio.ModuloConta;
using SistemaBar.App.Dominio.ModuloGarcom;
using SistemaBar.App.Dominio.ModuloMesa;
using SistemaBar.App.Dominio.ModuloProduto;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SistemaBar.App.Infraestrutura.Arquivos.Compartilhado
{
    public class ContextoDados
    {
        public List<Mesa> Mesas { get; set; } = new List<Mesa>();
        public List<Garcom> Garcons { get; set; } = new List<Garcom>();
        public List<Produto> Produtos { get; set; } = new List<Produto>();
        public List<Conta> Contas { get; set; } = new List<Conta>();

        private string pastaArmazenamento = "C:\\temp";
        private string arquivoArmazenamento = "dados-controle-bar.json";

        public ContextoDados()
        { }

        public ContextoDados(bool carregarDados) : this()
        {
            if (carregarDados)
                Carregar();
        }

        public void Salvar()
        {
            string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.WriteIndented = true;
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

            var jsonString = JsonSerializer.Serialize(this, jsonOptions);

            if (!Directory.Exists(pastaArmazenamento))
                Directory.CreateDirectory(pastaArmazenamento);

            File.WriteAllText(caminhoCompleto, jsonString);
        }

        public void Carregar()
        {
            string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

            if (!File.Exists(caminhoCompleto)) return;

            string jsonString = File.ReadAllText(caminhoCompleto);

            if (string.IsNullOrWhiteSpace(jsonString)) return;

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

            ContextoDados? contextoArmazenado = JsonSerializer.Deserialize<ContextoDados>(jsonString, jsonOptions);

            if (contextoArmazenado == null) return;

            Mesas = contextoArmazenado.Mesas;
            Garcons = contextoArmazenado.Garcons;
            Produtos = contextoArmazenado.Produtos;
            Contas = contextoArmazenado.Contas;
        }
    }
}