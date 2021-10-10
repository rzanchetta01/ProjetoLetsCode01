using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLesCode01
{
    public interface ILojas
    {
         
        string NomeLoja {get;}
        string PosShop {get;}

        Dictionary<int, Produto> Produtos { get; }

        void AddProduto(String nome, Double preco, int id);

        void MostrarProduto();

        void RemoverProduto(int nProduto);

        Double FazerVenda(double totalCompra);
    }
    
}