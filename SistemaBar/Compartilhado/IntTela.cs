namespace SistemaBar.Compartilhado;

public interface ITela
{
    char ApresentarMenu();

    void CadastrarRegistro();

    void EditarRegistro();

    void ExcluirRegistro();

    void VisualizarRegistros(bool exibirCabecalho);
}