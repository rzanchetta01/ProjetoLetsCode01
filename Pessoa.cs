using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLetsCode01
{
    public class Pessoa: ICliente, IPassageiro
    {
        string nomePessoa;
        double saldo;
        
        public string NomePessoa
        {
            get{ return this.nomePessoa; }
            set{ this.nomePessoa = value; }
        }
      
        public Pessoa (string Nome) 
        {
            this.nomePessoa = Nome;
        }

        public void CadastrarPessoa()
        {
            Console.WriteLine ("Bem vindo! Por favor, informe seu nome.");
            string Nome = Console.ReadLine();
            Console.WriteLine ("Informe seu saldo disponível:");
            Double.TryParse(Console.ReadLine(), out saldo);
        }

        public void VerificarPessoa()
        {
            Console.WriteLine("Você é um passageiro? Sim ou Não.");
            string resposta = Console.ReadLine().ToLower();

            if(resposta == "sim")
            {
                Console.WriteLine("Por favor adquira sua passagem.");
                ComprarPassagem();
            }
            else if(resposta == "nao")
            {
                Console.WriteLine("Conheça nossas lojas.");
                //chamar o metodo para menu de compras
            }

        }

        double ComprarProduto (double precovenda)
        {
            if(ComprarItem())
            {
               saldo -= precovenda;
            }
            return saldo;
        }

        public bool ComprarItem(double saldo, double valCompra) 
        {
            
            if(saldo >= valCompra)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public void ComprarPassagem (double precopassagem)
        {
            //1 - Já temos: o nome da pessoa e o fato de que ela é um passageiro
            //2 - Apresentar Destino/Preço (foreach - destinos) - Program
            Console.WriteLine ("Os destinos disponíveis são:");
            foreach (var DestinoVoo in destinos.Value)
            {
                Console.WriteLine($"{DestinoVoo}, por {precopassagem} reais");
            }

            //3 - O cliente seleciona o Destino/Preço
            Console.WriteLine ("Selecione o código correspondente ao destino desejado:");
            var destinoCliente = (from e in destinos where e.Key == Console.ReadLine() select e.Value);
            return destinoCliente;
            //Console.WriteLine ($"{destinoCliente}");

            //4 - Verifica o saldo da pessoa
            if (ComprarItem())
            {
                saldo -= precopassagem;
            }

            //5 - Confirma a compra
            Console.WriteLine ($"A compra da passagem com código {CodVoo} foi confirmada.");
            Console.WriteLine ($"Seu saldo é {saldo}.");
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