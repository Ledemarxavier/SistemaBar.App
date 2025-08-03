using SistemaBar.App.Dominio.ModuloGarcom;
using SistemaBar.App.Dominio.ModuloProduto;
using System.ComponentModel.DataAnnotations;

namespace SistemaBar.WebApp.Models
{
    public class CadastrarProdutoViewModel
    {
        [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
        [MinLength(2, ErrorMessage = "O campo \"Nome\" deve conter ao menos 2 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo \"Valor\" é obrigatório.")]
        public decimal Valor { get; set; }

        public CadastrarProdutoViewModel()
        {
        }
    }

    public class EditarProdutoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
        [MinLength(2, ErrorMessage = "O campo \"Nome\" deve conter ao menos 2 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo \"Valor\" é obrigatório.")]
        public decimal Valor { get; set; }

        public EditarProdutoViewModel()
        {
        }

        public EditarProdutoViewModel(int id, string nome, decimal valor)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
        }
    }

    public class ExcluirProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ExcluirProdutoViewModel()
        {
        }

        public ExcluirProdutoViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }

    public class VisualizarProdutosViewModel
    {
        public List<DetalhesProdutoViewModel> Registros { get; set; } = new List<DetalhesProdutoViewModel>();

        public VisualizarProdutosViewModel(List<Produto> produtos)
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