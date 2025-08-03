using SistemaBar.App.Dominio.ModuloMesa;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeBar.WebApp.Models;

public class VisualizarMesasViewModel
{
    public List<DetalhesMesaViewModel> Registros { get; set; } = new List<DetalhesMesaViewModel>();

    public VisualizarMesasViewModel(List<Mesa> mesas)
    {
        foreach (Mesa m in mesas)
        {
            DetalhesMesaViewModel detalhesVm = new DetalhesMesaViewModel(
                m.Id,
                m.Numero,
                m.Capacidade
            );

            Registros.Add(detalhesVm);
        }
    }
}

public class DetalhesMesaViewModel
{
    public int Id { get; set; }
    public int Numero { get; set; }
    public int Capacidade { get; set; }

    public DetalhesMesaViewModel(int id, int numero, int capacidade)
    {
        Id = id;
        Numero = numero;
        Capacidade = capacidade;
    }
}