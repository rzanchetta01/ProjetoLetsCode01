using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLesCode01
{
    public class Passagem
    {
        private string nomePassageiro;
        
        private double precoPassagem;

        public string NomePassageiro { get => nomePassageiro; set => nomePassageiro = value; }
        public double PrecoPassagem { get => precoPassagem; set => precoPassagem = value; }

        public Passagem(string nomePassageiro, double precoPassagem)
        {
            this.nomePassageiro = nomePassageiro;
            this.precoPassagem = precoPassagem;
        }
    }
}