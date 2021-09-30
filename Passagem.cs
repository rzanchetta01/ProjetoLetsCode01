using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLetsCode01
{
    public class Passagem: IPassageiro
    {
        // string codPassagem;
        string nomePassageiro;
        private string codVoo;

        public string NomePassageiro
        {
            get{return this.nomePassageiro;}
            set{this.nomePassageiro = value;}
        }

        public string CodVoo
        {
            get {return this.codVoo;}
        }
    }
}