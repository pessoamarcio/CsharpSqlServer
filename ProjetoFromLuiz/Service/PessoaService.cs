using System.Collections.Generic;
using System.Linq;
using ProjetoFromLuiz.Repository;

namespace ProjetoFromLuiz.Services
{
    public class PessoaService
    {
        public List<Pessoa> FiltrarPorMediaIdade(List<Pessoa> pessoas, int mediaIdade)
        {
            return pessoas.Where(p => p.Idade >= mediaIdade).ToList();

        }

        public List<Pessoa> FiltrarPorLetra(List<Pessoa> pessoas, char letra)
        {
            return pessoas.Where(p => p.Nome.ToUpper().Contains(letra.ToString().ToUpper())).ToList();
        }

        public List<Pessoa> FiltrarPorPeso(List<Pessoa> pessoas, double pesoMin, double pesoMax)
        {
            return pessoas.Where(p => p.Peso >= pesoMin && p.Peso <= pesoMax).ToList();
        }

        public List<Pessoa> FiltrarPorIMC(List<Pessoa> pessoas, double imcMin, double imcMax)
        {
            return pessoas.Where(p => p.IMC >= imcMin && p.IMC <= imcMax).ToList();
        }

        public string ObterNivelDeSaude(double imc)
        {
            if (imc < 18.5)
            {
                return "Abaixo do peso";
            }
            else if (imc >= 18.5 && imc <= 24.9)
            {
                return "Peso normal";
            }
            else if (imc >= 25 && imc <= 29.9)
            {
                return "Sobrepeso";
            }
            else if (imc >= 30 && imc <= 34.9)
            {
                return "Obesidade grau 1";
            }
            else if (imc >= 35 && imc <= 39.9)
            {
                return "Obesidade grau 2";
            }
            else
            {
                return "Obesidade grau 3";
            }

        }
    }
}
