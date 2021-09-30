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
        private String nomeFastFood;
        private String posShop; 

        private List<String> cardapio = new List<String>();
     
        public String NomeLoja
        {
            get{ return nomeFastFood; }
            set{ nomeFastFood = value; }
        }

        public String PosShop
        {
            get { return posShop; }
        }

        public List<String> Cardapio
        {
            get { return cardapio; }          
        }

        public FastFood (String nomeFastFood, String posShop)
        {
            this.nomeFastFood = nomeFastFood;
            this.posShop = posShop;
        }

        public void AddCardapio(String algo)
        {
            cardapio.Add(algo);
        }

        public void MostrarCardapio()
        {
            foreach(var e in cardapio)
            {
                Console.WriteLine(e);
            }            
        }

        public void RemoverDoCardapio(String algo)
        {
           Cardapio.Remove(algo);
        }

        public double RealizarVenda(List<String> itens)
        {
            double precoTotal = 0;

            foreach(var e in itens)
            {
                precoTotal = precoTotal + 5;
            }

            return precoTotal;
        }
    }
}