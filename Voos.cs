using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* Classe que contem a lista de destinos das passagens
*/

namespace ProjetoLesCode01
{
    public class Voos : ILojas //Loja de passagens aereas
    {
        readonly Dictionary<int, string> destinos = new();
        private readonly string nome;
        private readonly string posShop;
        
        public Voos(string nome, string posShop)
        {
            this.nome = nome;
            this.posShop = posShop;
        }

        public string NomeLoja { get => nome; }
        public string PosShop { get => posShop; }

        public void AddProduto(string nome, double preco, int id)//não tem um catálogo, apenas os destinos de voo
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, string> DestinosVoo ()
        {
           
            destinos.Add(1, "RJ");
            destinos.Add(2, "MG");
            destinos.Add(3, "BA");
            destinos.Add(4, "PR");
            destinos.Add(5, "ES");

            return destinos;
        }

        public Dictionary<int, Produto> Produtos => throw new NotImplementedException();

        public double FazerVenda(double totalCompra)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Produto> Produtos => throw new NotImplementedException(); //não tem um catalogo

        public double FazerVenda(double totalCompra) //não tem um catalogo
        {
            throw new NotImplementedException();
        }

        public void MostrarProduto() //não tem um catalogo
        {
            throw new NotImplementedException();
        }

        public void RemoverProduto(int nProduto) //não tem um catalogo
        {
            throw new NotImplementedException();
        }
    }
}