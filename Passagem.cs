using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLetsCode01
{
    public class Passagem: IPassageiro
    {
        private string nomePassageiro;

        public string NomePassageiro
        {
            get {return this.nomePassageiro;}
            set {this.nomePassageiro = value;}
        }
    }
}