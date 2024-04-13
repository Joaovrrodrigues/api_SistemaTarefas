using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTarefas1.Models;
using SistemaTarefas1.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios() 
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario =  await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody]UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuariomodel, int id )
        {
            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuariomodel,id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Excluir(int id)
        {
            bool ExcluirUsuario = await _usuarioRepositorio.Apagar(id);
            return Ok(ExcluirUsuario);
        }
    }
}
