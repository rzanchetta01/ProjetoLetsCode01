using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
IMPLEMENTAÇÃO BASE DA CLASE

Precisa adcionar os metodos que darão utilidade a loja, por exemplo comprar roupas

*/

namespace ProjetoLesCode01
{
    public class LojaComum : ILojas
    {
        private string nomeLojaComum { get; set; }
        private string posShop { get; }
        private List<Produto> catalogo = new List<Produto>();

        public LojaComum(String nomeLojaComum, string posShop)
        {
            this.posShop = posShop;
            this.nomeLojaComum = nomeLojaComum;
        }

        public string NomeLoja
        {

            get { return this.nomeLojaComum; }
        }
        public string PosShop
        {

            get { return this.posShop; }
        }
        
        public void AddProduto(String nome, Double preco )
        {   
                catalogo.Add(new Produto(nome, preco));
        }
            

        

        public void MostrarProduto()
        {
            foreach (var e in catalogo)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public String RemoverProduto(String prato)
        {
            foreach (var e in catalogo)
            {
                if (e.NomeProduto == prato)
                {
                    catalogo.Remove(e);
                    return "Produto removido com sucesso";
                }
            }

            return null;

        }

        public double FazerVenda(Pessoa pessoa, double total)
        {                
            Console.WriteLine($"Bem vindo a {NomeLoja}");
            Console.WriteLine("Esse é o nosso catálogo");
            MostrarProduto();
            Console.WriteLine("0 para finalizar a compra");
            String nProduto = Console.ReadLine();

            if(nProduto == "0")
            {
                return total;
            }
            else
            {
                Produto p = catalogo.First(p => p.NomeProduto.ToUpper() == nProduto.ToUpper());
                total += p.Preco;
                Console.WriteLine(total);
                return FazerVenda(pessoa, total);
            }                    
        }
    }
}