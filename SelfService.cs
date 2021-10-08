using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoLesCode01
{
    public class SelfService : ILojas //Para restaurantes do tipo SelfService
    {
        private readonly String nomeSelfService;
        private readonly String posShop;
        private readonly Dictionary<int, Produto> cardapio = new();

        public SelfService(String nomeSelfService, string posShop)
        {
            this.posShop = posShop;
            this.nomeSelfService = nomeSelfService;
        }

        public string NomeLoja { get => nomeSelfService; }
        public string PosShop { get => posShop; }
        public Dictionary<int, Produto> Produtos { get => cardapio; }

        public void AddProduto(String nome, Double preco, int id)//Adiciona um produto ao cardapio do restaurante
        {
            cardapio.Add(id, new Produto(nome, preco));
        }

        public void MostrarProduto()//Mostra o cardapio
        {
            foreach (var e in cardapio)
            {
                Console.WriteLine($"Produto {e.Key}: {e.Value}");
            }
        }

        public void RemoverProduto(int nProduto)//Remove produtos do cardapio
        {
            if (cardapio.Keys.Contains(nProduto))
            {
                cardapio.Remove(nProduto);
            }
        }
        public Double FazerVenda(double totalCompra)//Proceso de venda do restaurante
        {
            Console.WriteLine($"\nBem vindo ao {NomeLoja}");
            Console.WriteLine("Esse é o nosso cardapio");
            MostrarProduto();
            Console.WriteLine("Qual produto deseja? selecione pelo ID");
            Console.WriteLine("\n0 para finalizar a compra");
            Console.WriteLine("Digite o código do produto");
            bool suc = Int32.TryParse(Console.ReadLine(), out int nProduto);

            if (nProduto == 0)//Prosegue ao pagamento
            {
                return totalCompra;
            }
            else if (!cardapio.Keys.Contains(nProduto) || !suc)//Caso não econtre o produto
            {
                Console.WriteLine("Produto não encontrado, tente novamente");
                Thread.Sleep(1000);
                return FazerVenda(totalCompra);
            }
            else
            {
                var p = cardapio.FirstOrDefault(p => p.Key == nProduto);

                totalCompra += p.Value.Preco;
                Console.WriteLine("\n\nAdicionado ao carrinho com sucesso");
                Thread.Sleep(1000);
                return FazerVenda(totalCompra);
            }
        }
    }  
}