using SistemaBar.App.Dominio.ModuloGarcom;
using SistemaBar.App.Dominio.ModuloProduto;

namespace SistemaBar.WebApp.Models
{
    public class VizualizarProdutosViewModel
    {
        public List<DetalhesProdutoViewModel> Registros { get; set; } = new List<DetalhesProdutoViewModel>();

        public VizualizarProdutosViewModel(List<Produto> produtos)
        {
            foreach (Produto m in produtos)
            {
                DetalhesProdutoViewModel detalhesVm = new DetalhesProdutoViewModel(
                    m.Id,
                    m.Nome,
                    m.Valor
                );

                Registros.Add(detalhesVm);
            }
        }
    }

    public class DetalhesProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public DetalhesProdutoViewModel(int id, string nome, decimal valor)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
        }
    }
}