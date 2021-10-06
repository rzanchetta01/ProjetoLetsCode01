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
            Cardapio.Add(id, new Produto(nome, preco));
        }

        public void MostrarProduto()
        {
            foreach(var e in cardapio)
            {
                Console.WriteLine($"Produto {e.Key}: {e.Value}");
            }
        }

        public void RemoverProduto(int idProduto)
        {
           cardapio.Remove(idProduto);
        }

        public Double FazerVenda(Pessoa pessoa, double totalCompra)
        {
            
            Console.WriteLine($"\nBem vindo ao {NomeLoja}");
            Console.WriteLine("Esse é o nosso cardapio");           
            MostrarProduto();
            Console.WriteLine("Qual produto deseja? selecione pelo ID");
            Console.WriteLine("\n0 para finalizar a compra");
            bool suc = Int32.TryParse(Console.ReadLine(), out int nProduto);
            if (nProduto == 0)
            {
                return totalCompra;
            }
            else if (!cardapio.Keys.Contains(nProduto) || !suc)
            {
                Console.WriteLine("Numero inválido, tente novamente");
                return FazerVenda(pessoa, totalCompra);
            }
            else
            {
                var p = cardapio.FirstOrDefault(p => p.Key == nProduto);

                totalCompra += p.Value.Preco;               
                return FazerVenda(pessoa, totalCompra);
            }
        }

        public void AddProduto(string nome, double preco)
        {
            throw new NotImplementedException();
        }

        public string RemoverProduto(string algo)
        {
            throw new NotImplementedException();
        }
    }


}