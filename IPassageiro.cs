using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLesCode01
{
    public interface IPassageiro
    {
        string NomePassageiro{get;}
        bool IsPassageiro { get; }

        void ComprarPassagem(double precopassagem, Voos voo);
        void RegistrarBagagem(Produto produto);       
    }
}