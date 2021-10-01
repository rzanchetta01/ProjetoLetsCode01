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
        List<String> AddProduto();
    }
    
}