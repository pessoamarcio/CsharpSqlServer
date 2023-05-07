using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ProjetoFromLuiz.Repository
{
    public class PessoaRepository
    {
        private static List<Pessoa> baseDePessoas = new List<Pessoa>
        {
            new Pessoa { Id = 1, Nome = "João", Idade = 25, Email = "joao@email.com", Peso = 70, Altura = 1.80},
            new Pessoa { Id = 2, Nome = "Maria", Idade = 30, Email = "maria@email.com", Peso = 55, Altura = 1.65},
            new Pessoa { Id = 3, Nome = "Pedro", Idade = 18, Email = "pedro@email.com", Peso = 84, Altura = 1.90}
        };

        public void AdicionarPessoa(Pessoa novaPessoa)
        {
            novaPessoa.Id = baseDePessoas.Count + 1;
            baseDePessoas.Add(novaPessoa);
        }

        public List<Pessoa> ListarTodos()
        {
            return baseDePessoas;
        }

        public Pessoa ListarPessoaPorId(int id)
        {
            return baseDePessoas.FirstOrDefault(p => p.Id == id);
        }

        public void AtualizacaoDaPessoa(int id, Pessoa atualizacaoDaPessoa)
        {
            var pessoa = baseDePessoas.FirstOrDefault(p => p.Id == id);
            if (pessoa != null)
            {
                pessoa.Nome = atualizacaoDaPessoa.Nome;
                pessoa.Idade = atualizacaoDaPessoa.Idade;
                pessoa.Email = atualizacaoDaPessoa.Email;
                pessoa.Peso = atualizacaoDaPessoa.Peso;
                pessoa.Altura = atualizacaoDaPessoa.Altura;
            }

        }

        public bool AtualizacaoDaPessoaTeste(int id, Pessoa pessoaAtualizada)
        {
            var pessoa1 = baseDePessoas.FirstOrDefault(p => p.Id == id);

            if (pessoa1 == null)
            {
                return false;
            }

            else
            {
                pessoa1.Nome = pessoaAtualizada.Nome;
                pessoa1.Idade = pessoaAtualizada.Idade;
                pessoa1.Email = pessoaAtualizada.Email;
                pessoa1.Peso = pessoaAtualizada.Peso;
                pessoa1.Altura = pessoaAtualizada.Altura;
            }

            return true;
        }

        public void ExcluirPessoa(int id)
        {
            var pessoa = baseDePessoas.FirstOrDefault(p => p.Id == id);

            if (pessoa != null)
            {
                baseDePessoas.Remove(pessoa);
            }
        }

        public List<Pessoa> FiltrarPessoasPorMediaIdade(int media)
        {
            var pessoasFiltradas = baseDePessoas.Where(p => p.Idade > media).ToList();
            return pessoasFiltradas;
        }

        public int ContarPessoasComLetraL()
        {
            var pessoasComLetraL = baseDePessoas.Where(p => p.Nome.ToLower().Contains("l")).Count();
            return pessoasComLetraL;
        }

        public List<Pessoa> FiltrarPessoasPorPeso(double min, double max)
        {
            var pessoasFiltradas = baseDePessoas.Where(p => p.Peso >= min && p.Peso <= max).ToList();
            return pessoasFiltradas;
        }

        public double CalCularIMC(int id)
        {
            var pessoaIMC = baseDePessoas.FirstOrDefault(p => p.Id == id);

            if (pessoaIMC == null)
            {
                throw new Exception("Não encontrada ou não cadastrada!");
            }

            return pessoaIMC.IMC;
        }

    }
}
