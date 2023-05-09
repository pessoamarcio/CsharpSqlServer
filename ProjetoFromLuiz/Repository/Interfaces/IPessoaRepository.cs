using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFromLuiz.Models;


namespace ProjetoFromLuiz.Repository.Interfaces
{
    public interface IPessoaRepository
    {
        Task<Pessoa> ListarPessoaPorId(int id);
        Task<List<Pessoa>> ListarTodos();
        Task<Pessoa> AdicionarPessoa(Pessoa pessoa);
        Task<Pessoa> AtualizacaoDaPessoa(Pessoa pessoa, int id);
        Task<bool> ExcluirPessoa(int id);

    }
}
