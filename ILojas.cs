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

        void AddProduto(String nome, Double preco);

        void MostrarProduto();

        String RemoverProduto(String algo);

        Double FazerVenda(Pessoa pessoa, double total);
    }
    
}