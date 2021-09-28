using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
IMPLEMENTAÇÃO BASE DA CLASE

Precisa adcionar os metodos de preparar pedidos e adcionar os pratos no cardapio

*/

namespace ProjetoLesCode01
{
    public class FastFood: ILojas
    {
        private string nomeFastFood {get; set;}
        private string posShop {get;}

        private List<String> cardapio = new List<String>();
        private List<String> pedidos = new List<String>();

        public string NomeLoja {

            get  { return this.nomeFastFood; }           
        }
        public string PosShop {

            get  {return this.posShop; }
        }

        public List<String> Cardapio {

            get { return this.cardapio; }          
        }
        public List<String> Pedidos {

            get { return this.pedidos; }           
        }

        public FastFood(String nomeFastFood, string posShop)
        {
            this.posShop = posShop;
            this.nomeFastFood = nomeFastFood;
        }

    }
}