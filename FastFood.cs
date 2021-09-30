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
        private string nomeFastFood 
        { 
          get {return nomeFastFood;}
          set {nomeFastFood = value;}
        } 
        private string posShop 
        {
            get {return posShop;}
        }
        private List<String> cardapio = new List<String>();
        public void Cardapio()
        {
            Console.WriteLine("hamburguer da casa");
            Console.WriteLine("suco da fruta");
            Console.WriteLine("batata frita");

        } 
        private List<String> pedidos = new List<String>();
        public void Pedidos()
        {
           Cardapio();
           Console.WriteLine($"{nomeFastFood} - pedido feito");
        }

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