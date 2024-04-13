using Microsoft.EntityFrameworkCore;
using SistemaTarefas1.Models;
using SistemaTarefas1.Repositorios.Interfaces;
using SistemaTarefas1.Data;

namespace SistemaTarefas1.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContex _dbContext;
        public UsuarioRepositorio(SistemaTarefasDBContex sistemaTarefasDBContex)
        {
            _dbContext = sistemaTarefasDBContex;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
           return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id); //dbcontext na tabela usuario
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {

            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync(); //Salvar a alteração na base de dados
            return usuario;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id); // pra atualizarmos o usuario primeiro precisamos pesquisar o usuario

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email; //testar ao contrário

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return usuarioPorId;
           
        }
        public async  Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
            
        }


    }
}
