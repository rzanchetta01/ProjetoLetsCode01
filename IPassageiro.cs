using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLetsCode01
{
    public interface IPassageiro
    {
        string NomePassageiro{get;}

        void ComprarPassagem();
        void RegistrarBagagem();
    }
}