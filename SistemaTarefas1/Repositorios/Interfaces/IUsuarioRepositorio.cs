using SistemaTarefas1.Models;

namespace SistemaTarefas1.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        //contratos de usuario
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id); //recebe o int id de quem ele vai atualizar
        Task<bool> Apagar(int id); //id de quem quero apagar
    }
}
