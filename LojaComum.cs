using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/*
IMPLEMENTAÇÃO BASE DA CLASE

Precisa adcionar os metodos que darão utilidade a loja, por exemplo comprar roupas

*/

namespace ProjetoLesCode01
{
    public class LojaComum : ILojas
    {
        private string nomeLojaComum;
        private string posShop;
        private Dictionary<int, Produto> catalogo = new();

        public LojaComum(String nomeLojaComum, string posShop)
        {
            this.posShop = posShop;
            this.nomeLojaComum = nomeLojaComum;
        }
        public string NomeLoja { get => nomeLojaComum; }
        public string PosShop { get => posShop; }
        public Dictionary<int, Produto> Produtos { get => catalogo; }

        public void AddProduto(String nome, Double preco, int id)
        {
            catalogo.Add(id, new Produto(nome, preco));
        }

        public void MostrarProduto()
        {
            foreach (var e in catalogo)
            {
                Console.WriteLine($"Produto {e.Key}: {e.Value}");
            }
        }

        public void RemoverProduto(int nProduto)
        {
            if (catalogo.Keys.Contains(nProduto))
            {
                catalogo.Remove(nProduto);
            }
        }

        public double FazerVenda(double totalCompra)
        {                
            Console.WriteLine($"\nBem vindo a {NomeLoja}");
            Console.WriteLine("Esse é o nosso catálogo");
            MostrarProduto();
            Console.WriteLine("\n0 para finalizar a compra");
            Console.WriteLine("Digite o código do produto");
            bool suc = Int32.TryParse(Console.ReadLine(), out int nProduto);

            if (nProduto == 0)
            {
                return totalCompra;
            }
            else if (!catalogo.Keys.Contains(nProduto) || !suc)
            {
                Console.WriteLine("Produto não encontrado, tente novamente");
                Thread.Sleep(1000);
                return FazerVenda(totalCompra);
            }
            else
            {
                var p = catalogo.FirstOrDefault(p => p.Key == nProduto);

                totalCompra += p.Value.Preco;
                Console.WriteLine("\n\nAdicionado ao carrinho com sucesso");
                Thread.Sleep(1000);
                return FazerVenda(totalCompra);
            }
                           
        }
    }
}