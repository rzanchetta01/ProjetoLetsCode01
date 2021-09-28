using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLesCode01
{
    public class Passageiro: IPessoa
    {
        private string nomePassageiro;
        //private string telefonePassageiro;// Comentado para uso futuro 
        
        public string NomeCliente {
            get {return this.nomeCLiente;}
        }
        //Comentado para uso futuro
        /*public string Telofone {
            get {return this.Telefone;}
            set {this.Telefone = value;}
        }*/
       
        //Criar o Construtor desta Classe para receber apenas o nome//

    }
}