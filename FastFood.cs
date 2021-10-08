using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoLesCode01
{
    public class FastFood: ILojas//Loja do tipo fastfood
    {
        private readonly String nomeFastFood;
        private readonly String posShop;
        private readonly Dictionary<int, Produto> cardapio = new();

        public FastFood(String nomeFastFood, String posShop)//construtor
        {
            this.nomeFastFood = nomeFastFood;
            this.posShop = posShop;
        }

        public string NomeLoja { get => nomeFastFood; }

        public string PosShop { get => posShop; }

        public Dictionary<int, Produto> Produtos => cardapio;

        public void AddProduto(String nome, Double preco, int id)//adiciona um produto ao cardapio
        {
            cardapio.Add(id, new Produto(nome, preco));
        }

        public void MostrarProduto()//mostra o cardapio
        {
            foreach(var e in cardapio)
            {
                Console.WriteLine($"Produto {e.Key}: {e.Value}");
            }
        }

        public void RemoverProduto(int nProduto)//remove produto especifico do cardapio
        {
            if(cardapio.Keys.Contains(nProduto))
            {
                cardapio.Remove(nProduto);
            }
        }

        public Double FazerVenda(double totalCompra)//processo de realizar venda do fastfood
        {
            Console.WriteLine($"\nBem vindo ao {NomeLoja}");
            Console.WriteLine("Esse é o nosso cardapio");           
            MostrarProduto();
            Console.WriteLine("Qual produto deseja? selecione pelo ID");
            Console.WriteLine("\n0 para finalizar a compra");
            Console.WriteLine("Digite o código do produto");
            bool suc = Int32.TryParse(Console.ReadLine(), out int nProduto);

            if (nProduto == 0)//sair do cardapio e prosegue a compra
            {
                return totalCompra;
            }
            else if (!cardapio.Keys.Contains(nProduto) || !suc)//se não encontrar o produto
            {
                Console.WriteLine("Produto não encontrado, tente novamente");
                Thread.Sleep(1000);//delay para retornar ao menu
                return FazerVenda(totalCompra);
            }
            else
            {
                var p = cardapio.FirstOrDefault(p => p.Key == nProduto);//seleciona o produto especifico

                totalCompra += p.Value.Preco;
                Console.WriteLine("\n\nAdicionado ao carrinho com sucesso");
                Thread.Sleep(1000);//delay para retornar ao menu
                return FazerVenda(totalCompra);
            }
        }
    }


}
