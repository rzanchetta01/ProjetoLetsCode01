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
    public class SelfService: ILojas
    {
        private string nomeSelfService;
        private string posShop;
        private List<String> cardapio = new List<String>();
        private List<string> pedidos = new List<string>();

        public string NomeLoja 
        {
            get  { return this.nomeSelfService; }   
            set  {nomeSelfService = value; }        
        }
        public string PosShop
        {
          get  { return posShop; }
        }
        public List<String> Cardapio
        {
          get { return cardapio; }          
        }
         public List<String> Pedidos
        {

            get { return this.pedidos; }  
            set {this.pedidos = value; }         
        }

        public SelfService(String nomeSelfService, string posShop)
        {   
            this.nomeSelfService = nomeSelfService;
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