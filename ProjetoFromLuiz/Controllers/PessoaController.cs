using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFromLuiz.Repository;
using ProjetoFromLuiz.Services;

namespace ProjetoFromLuiz.Controllers
{
    [ApiController]
    public class PessoaController : Controller
    {
        private static PessoaService pessoaService;
        private static PessoaRepository pessoaRepository;

       
        public PessoaController()
        {
            pessoaRepository = new PessoaRepository();
            pessoaService = new PessoaService();
        }

        [HttpPost]
        [Route("api/pessoas")]
        public IActionResult AdicionarPessoa([FromBody] Pessoa novaPessoa)
        {
            if (novaPessoa == null)
            {
                return BadRequest();
            }

            pessoaRepository.AdicionarPessoa(novaPessoa);

            return Ok(novaPessoa);
        }

        [HttpGet]
        [Route("api/pessoas")]
        public IActionResult ListarTodasPessoas()
        {
            var pessoas = pessoaRepository.ListarTodos();
            return Ok(pessoas);
        }

        [HttpGet]
        [Route("api/pessoas/{id}")]
        public IActionResult ListarPessoasId(int id)
        {
            var pessoa = pessoaRepository.ListarPessoaPorId(id);

            if (pessoa == null)
            {
                return NotFound("Falhou!");

            }

            return Ok(pessoa);
        }

        [HttpPut]
        [Route("api/pessoas/{id}")]
        public IActionResult AtualizarPessoas(int id, [FromBody] Pessoa PessoaAtualizada)
        {
            if (PessoaAtualizada == null)
            {
                return BadRequest();

            }

            pessoaRepository.AtualizacaoDaPessoa(id, PessoaAtualizada);

            return Ok("Cadastro atualizado com sucesso!");
        }

        [HttpDelete]
        [Route("api/pessoas/{id}")]
        public IActionResult ExcluirPessoa(int id)
        {
            pessoaRepository.ExcluirPessoa(id);

            return Ok("Cadastro Deletado!");
        }

        [HttpGet]
        [Route("api/pessoas/filtro-media-idade/")]
        public IActionResult CalcularMediaDeIdade()
        {
            var mediaPessoas = pessoaRepository.ListarTodos();
            var media = Math.Round(mediaPessoas.Average(p => p.Idade), 2);
            return Ok(media);
        }

        [HttpGet]
        [Route("api/pessoas/contar-com-letra-l")]
        public IActionResult ContarPessoasComLetraL()
        {
            var count = pessoaRepository.ContarPessoasComLetraL();
            return Ok(count);
        }

        [HttpGet]
        [Route("api/pessoas/filtro-peso/{min}/{max}")]
        public IActionResult FiltrarPessoasPorPeso(double min, double max)
        {
            var pessoasFiltradas = pessoaRepository.FiltrarPessoasPorPeso(min, max);
            return Ok(pessoasFiltradas);
        }
               
        [HttpGet]
        [Route("api/pessoas/nivel-saude")]
        public IActionResult ListarPessoasComNivelDeSaude()
        {
            var pessoas = pessoaRepository.ListarTodos();
            var pessoasComSaude = new List<dynamic>();

            foreach (var pessoa in pessoas)
            {
                var saude = pessoaService.ObterNivelDeSaude(pessoa.IMC);
                pessoasComSaude.Add(new { pessoa, saude });
            }

            return Ok(pessoasComSaude);
        }

        [HttpGet]
        [Route("api/pessoas/imc/{id}")]
        public IActionResult CalcularIMCPessoa(int id)
        {
            var pessoa = pessoaRepository.ListarPessoaPorId(id);
            if (pessoa == null)
            {
                return NotFound("Pessoa não encontrada!");
            }

            var imc = pessoa.IMC;
            var nome = pessoa.Nome;
            var dadosPessoa = new {nome = nome, IMC = imc};
            return Ok(dadosPessoa);
        }

    }
}