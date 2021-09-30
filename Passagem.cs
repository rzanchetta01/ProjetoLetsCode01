using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLetsCode01
{
    public class Passagem: IPassageiro
    {
        private string nomePassageiro;

        public string NomePassageiro
        {
            get {return this.nomePassageiro;}
            set {this.nomePassageiro = value;}
        }

        public void ComprarPassagem //colocar em pessoa
        {
            //1 - Já temos: o nome da pessoa e o fato de que ela é um passageiro
            //2 - Apresentar Destino/Preço (foreach - destinos) - Program
            //3 - O cliente seleciona o Destino/Preço
            //4 - Verifica o saldo da pessoa
            //5 - Confirma a compra
        }

        public void RegistrarBagagem () //colocar em pessoa
        {
            /*
            1- Já temos: o nome da pessoa e a compra da passagem confirmada
            2- Quantos itens ela quer registrar?
            3- O passageiro seleciona
            4- O passageiro registra os itens
            5- Confirmação dos itens
            6- Pronto
            */
        }
    }
}