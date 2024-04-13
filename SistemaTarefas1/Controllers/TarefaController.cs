using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTarefas1.Models;
using SistemaTarefas1.Repositorios.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace SistemaTarefas1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> BuscarTodasTarefas()
        {
            List<TarefaModel> tarefas = await _tarefaRepositorio.BuscarTodasTarefas();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarPorId(int id)
        {
            TarefaModel tarefa = await _tarefaRepositorio.BuscarTarefaId(id);
            return Ok(tarefa);
        }


        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _tarefaRepositorio.AdicionarTarefa(tarefaModel);
            return Ok(tarefa);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            TarefaModel tarefa = await _tarefaRepositorio.AtualizarTarefa(tarefaModel, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> Excluir(int id)
        {
            bool tarefaExcluida = await _tarefaRepositorio.ExcluirTarefa(id);
            return Ok(tarefaExcluida);
        }


    }
}
