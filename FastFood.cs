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
        private List<Produto> cardapio = new List<Produto>();
     
        public String NomeLoja
        {
            get{ return nomeFastFood; }
            set{ nomeFastFood = value; }
        }


        public String PosShop
        {
            get { return posShop; }
        }

        public List<Produto> Cardapio => cardapio;

        public FastFood (String nomeFastFood, String posShop)
        {
            this.nomeFastFood = nomeFastFood;
            this.posShop = posShop;
        }

        public void AddProduto(String nome, Double preco)
        {
            cardapio.Add(new Produto(nome, preco));
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

        public Double FazerVenda(Pessoa pessoa, double total)
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
    }
}