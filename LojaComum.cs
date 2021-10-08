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
    public class LojaComum : ILojas //Todo e qualquer tipo de loja que não seja alimenticia
    {
        private readonly string nomeLojaComum;
        private readonly string posShop;
        private readonly Dictionary<int, Produto> catalogo = new();

        public LojaComum(String nomeLojaComum, string posShop)//construtor
        {
            this.posShop = posShop;
            this.nomeLojaComum = nomeLojaComum;
        }
        public string NomeLoja { get => nomeLojaComum; }
        public string PosShop { get => posShop; }
        public Dictionary<int, Produto> Produtos { get => catalogo; }

        public void AddProduto(String nome, Double preco, int id)// add produto no catalogo
        {
            catalogo.Add(id, new Produto(nome, preco));
        }

        public void MostrarProduto()//mostra o catalogo
        {
            foreach (var e in catalogo)
            {
                Console.WriteLine($"Produto {e.Key}: {e.Value}");
            }
        }

        public void RemoverProduto(int nProduto)//Remove um produto do catalogo
        {
            if (catalogo.Keys.Contains(nProduto))
            {
                catalogo.Remove(nProduto);
            }
        }

        public double FazerVenda(double totalCompra)//Processo de venda da loja
        {                
            Console.WriteLine($"\nBem vindo a {NomeLoja}");
            Console.WriteLine("Esse é o nosso catálogo");
            MostrarProduto();
            Console.WriteLine("\n0 para finalizar a compra");
            Console.WriteLine("Digite o código do produto");
            bool suc = Int32.TryParse(Console.ReadLine(), out int nProduto);

            if (nProduto == 0)//Encerra o processo de compra
            {
                return totalCompra;
            }
            else if (!catalogo.Keys.Contains(nProduto) || !suc)//se não econtrar o produto
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