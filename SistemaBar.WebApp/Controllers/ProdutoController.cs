using Microsoft.AspNetCore.Mvc;
using SistemaBar.App.Dominio.ModuloMesa;
using SistemaBar.App.Dominio.ModuloProduto;
using SistemaBar.App.Infraestrutura.Arquivos.Compartilhado;
using SistemaBar.App.Infraestrutura.Arquivos.ModuloProduto;
using SistemaBar.WebApp.Models;

namespace SistemaBar.WebApp.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly RepositorioProdutoEmArquivo repositorioProduto;

        public ProdutoController()
        {
            ContextoDados contexto = new ContextoDados(carregarDados: true);

            repositorioProduto = new RepositorioProdutoEmArquivo(contexto);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CadastrarProdutoViewModel cadastrarVm = new CadastrarProdutoViewModel();

            return View(cadastrarVm);
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarProdutoViewModel cadastrarVm)
        {
            if (!ModelState.IsValid)
                return View(cadastrarVm);

            var entidade = new Produto(cadastrarVm.Nome, cadastrarVm.Valor);

            repositorioProduto.CadastrarRegistro(entidade);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Produto> produtos = repositorioProduto.SelecionarRegistros();

            VisualizarProdutosViewModel visualizarVm = new VisualizarProdutosViewModel(produtos);

            return View(visualizarVm);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var registro = repositorioProduto.SelecionarRegistroPorId(id);

            EditarProdutoViewModel editarVm = new EditarProdutoViewModel(
                id,
                registro.Nome,
                registro.Valor
            );

            return View(editarVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarProdutoViewModel editarVm)
        {
            if (!ModelState.IsValid)
                return View(editarVm);

            var produtoEditado = new Produto(editarVm.Nome, editarVm.Valor);

            repositorioProduto.EditarRegistro(editarVm.Id, produtoEditado);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var registro = repositorioProduto.SelecionarRegistroPorId(id);

            ExcluirProdutoViewModel excluirVm = new ExcluirProdutoViewModel(
                id,
                registro.Nome
            );

            return View(excluirVm);
        }

        [HttpPost]
        public IActionResult Excluir(ExcluirProdutoViewModel excluirVm)
        {
            repositorioProduto.ExcluirRegistro(excluirVm.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}