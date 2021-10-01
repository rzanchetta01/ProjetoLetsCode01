using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLesCode01
{
    public class SelfService : ILojas
    {

        private string nomeSelfService;
        private string posShop;
        private List<Produto> cardapio = new List<Produto>();


        public SelfService(String nomeSelfService, string posShop)
        {
            this.posShop = posShop;
            this.nomeSelfService = nomeSelfService;
        }

        public string NomeLoja 
        {
            get  { return this.nomeSelfService; }   
            set {nomeSelfService = value; }        
        }

        public string PosShop
        {
          get  {return posShop; }
        }

        public List<Produto> Cardapio
        {
          get { return cardapio; }          
        }

        public void AddProduto(String nome, Double preco)
        {
            cardapio.Add(new Produto(nome, preco));
        }

        public double FazerVenda(Pessoa pessoa, double total)
        {                
            Console.WriteLine($"Bem vindo ao {NomeLoja}");
            Console.WriteLine("Esse é o nosso cardapio");
            MostrarProduto();
            Console.WriteLine("0 para finalizar a compra");
            String nProduto = Console.ReadLine();

            if(nProduto == "0")
            {
                return total;
            }
            else
            {
                Produto p = cardapio.First(p => p.NomeProduto.ToUpper() == nProduto.ToUpper());
                total += p.Preco;
                Console.WriteLine(total);
                return FazerVenda(pessoa, total);
            }                    
        }

        public void MostrarProduto()
        {
            foreach(var e in cardapio)
            {
                Console.WriteLine(e.ToString());
            }            
        }

        public String RemoverProduto(String prato)
        {
            foreach (var e in cardapio)
            {
                if (e.NomeProduto == prato)
                {
                    cardapio.Remove(e);
                    return "Produto removido com sucesso";
                }
            }

            return null;

        }        
    }  
}