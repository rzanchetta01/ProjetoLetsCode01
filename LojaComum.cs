using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
IMPLEMENTAÇÃO BASE DA CLASE

Precisa adcionar os metodos que darão utilidade a loja, por exemplo comprar roupas

*/

namespace ProjetoLesCode01
{
    public class LojaComum: ILojas
    {
        private string nomeLojaComum;
        private string posShop;

        private List<String> cardapio = new List<String>();
        private List<string> pedidos = new List<string>();

        public string NomeLoja 
        {

            get  { return this.nomeLojaComum; }  
            set   { nomeLojaComum = value; }      
        }
        public string PosShop
        {
            get  {return this.posShop; }

        }

        public List<String> Cardapio 
        {
          get { return this.cardapio; }          
        }
        public List<String> Pedidos
        {

            get { return this.pedidos; }  
            set {this.pedidos = value; }         
        }

        public LojaComum(String nomeLojaComum, string posShop)
        {
            this.posShop = posShop;
            this.nomeLojaComum = nomeLojaComum;
        }

    
    }
}