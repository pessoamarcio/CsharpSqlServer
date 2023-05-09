using ProjetoFromLuiz.Data;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjetoFromLuiz.Repository.Interfaces;
using System.Threading.Tasks;
using ProjetoFromLuiz.Models;
using System.Xml.Linq;


namespace ProjetoFromLuiz.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        public readonly SistemaPessoasDBContext _dbContext;

        public PessoaRepository(SistemaPessoasDBContext sitemaPessoasDBContext)
        {
            _dbContext = sitemaPessoasDBContext;
        }
  
        public async Task<Pessoa> ListarPessoaPorId(int id)
        {
            return await _dbContext.PessoaSistema.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Pessoa>> ListarTodos()
        {
            return await _dbContext.PessoaSistema.ToListAsync();
        }

        public async Task<Pessoa> AdicionarPessoa(Pessoa pessoa)
        {
            await _dbContext.PessoaSistema.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();

            return pessoa;
        }

        public async Task<Pessoa> AtualizacaoDaPessoa(Pessoa atualizacaoDaPessoa, int id)
        {
            Pessoa pessoaId = await ListarPessoaPorId(id);

            if (pessoaId == null)
            {
                throw new Exception("Não localizado!");
            }

            pessoaId.Nome = atualizacaoDaPessoa.Nome;
            pessoaId.Idade = atualizacaoDaPessoa.Idade;
            pessoaId.Email = atualizacaoDaPessoa.Email;
            pessoaId.Peso = atualizacaoDaPessoa.Peso;
            pessoaId.Altura = atualizacaoDaPessoa.Altura;

            _dbContext.PessoaSistema.Update(pessoaId);
            await _dbContext.SaveChangesAsync();
            return pessoaId;
        }

        public async Task<bool> ExcluirPessoa(int id)
        {
            Pessoa pessoaId = await ListarPessoaPorId(id);

            if (pessoaId == null)
            {
                throw new Exception("Não localizado!");
            }

            _dbContext.PessoaSistema.Remove(pessoaId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
