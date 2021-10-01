using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLesCode01
{
    public class Pessoa: ICliente, IPassageiro
    {
        private string nomePessoa;
        private double saldo;
        private bool isPassageiro;

        public Pessoa(string Nome, Double saldoInicial, bool isPassageiro)
        {
            this.nomePessoa = Nome;
            this.saldo = saldoInicial;
            this.isPassageiro = isPassageiro;
        }

        public string NomePessoa
        {
            get{ return this.nomePessoa; }       
        }
      
        public string NomeCliente
        {
            get { return nomePessoa; }
        }

        public string NomePassageiro
        {
            get { return nomePessoa; }
        }

        public Double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public bool IsPassageiro
        {
            get { return isPassageiro; }
        }    

        public double ComprarProduto (double precovenda)
        {
            if(ComprarItem(precovenda))
            {
               Saldo -= precovenda;
            }
            Console.WriteLine($"A compra foi confirmada.");
            Console.WriteLine($"Seu saldo é {Saldo}.");
            return Saldo;
        }

        /* Verificação do saldo disponível da pessoa */
        private bool ComprarItem(double valCompra) 
        {
            
            if(Saldo >= valCompra)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public void ComprarPassagem (double precopassagem, Voos destino)
        {
           
            //1 - Já temos: o nome da pessoa e o fato de que ela é um passageiro

            //2 - O cliente seleciona o Destino/Preço
            Console.WriteLine ("Selecione o código correspondente ao destino desejado");

            //3 - Apresentar Destino/Preço (foreach - destinos) - Program
            Console.WriteLine("Os destinos disponíveis são\n");

            //  return destinoCliente;
            int codVoo;
            foreach(var e in destino.DestinosVoo())
            {
                Console.WriteLine(e.Key + ": " + e.Value);
            }
            Int32.TryParse(Console.ReadLine(), out codVoo);


            //4 - Verifica o saldo da pessoa
            if (ComprarItem(precopassagem))
            {
                saldo -= precopassagem;
            }

            //5 - Confirma a compra
            Console.WriteLine ($"A compra da passagem com código {codVoo} foi confirmada.");
            Console.WriteLine ($"Seu saldo é {Saldo}.");

            //voltar pro menu
        }

        public void RegistrarBagagem ()
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