using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFromLuiz
{
    public class Pessoa
    {
        internal string Saude;

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }

        public double IMC
        {
            get
            {
                return Peso / (Altura * Altura);
            }
        }
    }
}