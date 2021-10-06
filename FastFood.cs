using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        private Dictionary<int, Produto> cardapio = new();

        public FastFood(String nomeFastFood, String posShop)
        {
            this.nomeFastFood = nomeFastFood;
            this.posShop = posShop;
        }

        public String NomeLoja { get => nomeFastFood; }

        public String PosShop { get => posShop; }

        public Dictionary<int, Produto> Cardapio => cardapio;

        public void AddProduto(String nome, Double preco, int id)
        {
            cardapio.Add(id, new Produto(nome, preco));
        }

        public void MostrarProduto()
        {
            foreach (var e in cardapio)
            {
                Console.WriteLine($"Produto{e.Key}: {e.Value}");
            }
        }

        public void RemoverProduto(int nProduto)
        {
            if(cardapio.Keys.Contains(nProduto))
            {
                cardapio.Remove(nProduto);
            }
        }

        public Double FazerVenda(Pessoa pessoa, double totalCompra)
        {
            Console.WriteLine($"\nBem vindo ao {NomeLoja}");
            Console.WriteLine("Esse é o nosso cardapio");           
            MostrarProduto();
            Console.WriteLine("Qual produto deseja? selecione pelo ID");
            Console.WriteLine("\n0 para finalizar a compra");
            Console.WriteLine("Digite o código do produto");
            bool suc = Int32.TryParse(Console.ReadLine(), out int nProduto);

            if (nProduto == 0)
            {
                return totalCompra;
            }
            else if (!cardapio.Keys.Contains(nProduto) || !suc)
            {
                Console.WriteLine("Produto não encontrado, tente novamente");
                Thread.Sleep(1000);
                return FazerVenda(pessoa, totalCompra);
            }
            else
            {
                var p = cardapio.FirstOrDefault(p => p.Key == nProduto);

                totalCompra += p.Value.Preco;
                Console.WriteLine("\n\nAdicionado ao carrinho com sucesso");
                Thread.Sleep(1000);
                return FazerVenda(pessoa, totalCompra);
            }
        }
    }


}
