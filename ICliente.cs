using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLesCode01
{
    public interface ICliente
    {
        string NomeCliente{get;}
        void ComprarProduto(Produto precovenda);
    }
}