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
<<<<<<< Updated upstream
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
=======
        private String posShop;
>>>>>>> Stashed changes

        private Dictionary<int, Produto> cardapio = new();
        
        public FastFood(String nomeFastFood, String posShop)
        {
            this.nomeFastFood = nomeFastFood;
            this.posShop = posShop;
        }

<<<<<<< Updated upstream
        public void AddCardapio(String algo)
        {
            cardapio.Add(algo);
=======
        public String NomeLoja { get => nomeFastFood; }
 
        public String PosShop { get => posShop; }

        public Dictionary<int, Produto> Cardapio => cardapio;
     
        public void AddProduto(String nome, Double preco, int id)
        {
            Cardapio.Add(id, new Produto(nome, preco));
>>>>>>> Stashed changes
        }

        public void MostrarCardapio()
        {
            foreach(var e in cardapio)
            {
<<<<<<< Updated upstream
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
=======
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
>>>>>>> Stashed changes
        }
    }


}