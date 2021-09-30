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

        /* Cadastro da Pessoa */    
        public void CadastrarPessoa()
        {
            Console.WriteLine ("Bem vindo! Por favor, informe seu nome.");
            this.Nome = Console.ReadLine();
            Console.WriteLine ("Informe seu saldo disponível:");
            Double.TryParse(Console.ReadLine(), out saldo);
        }

        /* Verificação: se a pessoa é somente cliente ou se é passageiro. */
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

        /* Atualização de saldo da pessoa após compra de item */
        double ComprarProduto (double precovenda)
        {
            if(ComprarItem())
            {
               saldo -= precovenda;
            }
            return saldo;
        }

        /* Verificação do saldo disponível da pessoa */
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
            foreach (KeyValuePair<int, string> item in destino)
            {
                Console.WriteLine($"Código Voo {item.Key} para {item.Value}");
            }

            //3 - O cliente seleciona o Destino/Preço
            Console.WriteLine ("Selecione o código correspondente ao destino desejado:");
            var destinoCliente = (from e in destinos where e.Key == Console.ReadLine() select e.Value);
            return destinoCliente;

            //4 - Verifica o saldo da pessoa
            if (ComprarItem())
            {
                saldo -= precopassagem;
            }

            //5 - Confirma a compra
            Console.WriteLine ($"A compra da passagem com código {CodVoo} foi confirmada.");
            Console.WriteLine ($"Seu saldo é {saldo}.");

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