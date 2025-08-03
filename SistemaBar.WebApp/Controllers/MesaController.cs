using SistemaBar.App.Infraestrutura.Arquivos.Compartilhado;

using Microsoft.AspNetCore.Mvc;
using SistemaBar.App.Dominio.ModuloMesa;
using SistemaDeBar.WebApp.Models;
using SistemaBar.App.Infraestrutura.Arquivos.ModuloMesa;

namespace SistemaBar.WebApp.Controllers;

public class MesaController : Controller
{
    private readonly RepositorioMesaEmArquivo repositorioMesa;

    public MesaController()
    {
        ContextoDados contexto = new ContextoDados(carregarDados: true);

        repositorioMesa = new RepositorioMesaEmArquivo(contexto);
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<Mesa> mesas = repositorioMesa.SelecionarRegistros();

        VisualizarMesasViewModel visualizarVm = new VisualizarMesasViewModel(mesas);

        return View(visualizarVm);
    }
}