using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFromLuiz.Repository;
using ProjetoFromLuiz.Services;
using ProjetoFromLuiz.Models;
using ProjetoFromLuiz.Repository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ProjetoFromLuiz.Controllers 
{
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private static PessoaService pessoaService;
        private readonly IPessoaRepository _pessoaRepository;

       internal PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpPost]
        [Route("api/pessoas")]
        public async Task<ActionResult<Pessoa>> AdicionarPessoa([FromBody] Pessoa novaPessoa)
        {
            Pessoa pessoa = await _pessoaRepository.AdicionarPessoa(novaPessoa);

            return Ok(pessoa);
        }

        [HttpGet]
        [Route("api/pessoas")]
        public async Task<ActionResult<List<Pessoa>>> ListarTodasPessoas()
        {
            List<Pessoa> pessoas = await _pessoaRepository.ListarTodos();
            return Ok(pessoas);
        }

        [HttpGet]
        [Route("api/pessoas/{id}")]
        public async Task<ActionResult<Pessoa>> ListarPessoasId(int id)
        {
            Pessoa pessoa = await _pessoaRepository.ListarPessoaPorId(id);

            return Ok(pessoa);
        }

        [HttpPut]
        [Route("api/pessoas/{id}")]
        public async Task<ActionResult<Pessoa>> AtualizarPessoas([FromBody] Pessoa PessoaAtualizada, int id)
        {
                       
            Pessoa pessoa = await _pessoaRepository.AtualizacaoDaPessoa(PessoaAtualizada, id);

            return Ok(pessoa);
        }

        [HttpDelete]
        [Route("api/pessoas/{id}")]
        public async Task<ActionResult<Pessoa>> ExcluirPessoa(int id)
        {
            bool pessoa = await _pessoaRepository.ExcluirPessoa(id);

            return Ok(pessoa);
        }

    }
}