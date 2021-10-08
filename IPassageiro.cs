using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLesCode01
{
    public interface IPassageiro//Interface para pessoa que é passageiro
    {
        string NomePassageiro{get;}
        bool IsPassageiro { get; }

        void ComprarPassagem(double precopassagem, Voos voo);
        void RegistrarBagagem(Produto produto);       
    }
}