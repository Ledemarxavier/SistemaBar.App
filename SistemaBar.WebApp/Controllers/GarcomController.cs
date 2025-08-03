using Microsoft.AspNetCore.Mvc;
using SistemaBar.App.Dominio.ModuloGarcom;
using SistemaBar.App.Infraestrutura.Arquivos.Compartilhado;
using SistemaBar.App.Infraestrutura.Arquivos.ModuloGarcom;
using SistemaBar.WebApp.Models;

namespace SistemaBar.WebApp.Controllers
{
    public class GarcomController : Controller
    {
        private readonly RepositorioGarcomEmArquivo repositorioGarcom;

        public GarcomController()
        {
            ContextoDados contextoDados = new ContextoDados(carregarDados: true);
            repositorioGarcom = new RepositorioGarcomEmArquivo(contextoDados);
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Garcom> garcons = repositorioGarcom.SelecionarRegistros();

            VisualizarGarconsViewModel visualizarVm = new VisualizarGarconsViewModel(garcons);

            return View(visualizarVm);
        }

        public IActionResult Cadastrar()
        {
            CadastrarGarcomViewModel cadastrarVm = new CadastrarGarcomViewModel();

            return View(cadastrarVm);
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarGarcomViewModel cadastrarVm)
        {
            if (!ModelState.IsValid)
                return View(cadastrarVm);

            var entidade = new Garcom(cadastrarVm.Nome, cadastrarVm.Cpf);

            repositorioGarcom.CadastrarRegistro(entidade);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var registro = repositorioGarcom.SelecionarRegistroPorId(id);

            EditarGarcomViewModel editarVm = new EditarGarcomViewModel(
                id,
                registro.Nome,
                registro.Cpf
            );

            return View(editarVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarGarcomViewModel editarVm)
        {
            if (!ModelState.IsValid)
                return View(editarVm);

            var garcomEditado = new Garcom(editarVm.Nome, editarVm.Cpf);

            repositorioGarcom.EditarRegistro(editarVm.Id, garcomEditado);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var registro = repositorioGarcom.SelecionarRegistroPorId(id);

            ExcluirGarcomViewModel excluirVm = new ExcluirGarcomViewModel(
                id,
                registro.Nome
            );

            return View(excluirVm);
        }

        [HttpPost]
        public IActionResult Excluir(ExcluirGarcomViewModel excluirVm)
        {
            repositorioGarcom.ExcluirRegistro(excluirVm.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}