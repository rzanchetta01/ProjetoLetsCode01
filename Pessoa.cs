using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLetsCode01
{
    public class Pessoa: ICliente, IPassageiro
    {
        string nomePessoa;
        
        public string NomePessoa
        {
            get{ return this.nomePessoa; }
            set{ this.nomePessoa = value; }
        }
      
        public Pessoa (string Nome) 
        {
            this.nomePessoa = Nome;
        }

        public void VerificarPessoa()
        {
            Console.WriteLine("Você é um passageiro? sim ou nao. ");
            string resposta = Console.ReadLine().ToLower();

            if(resposta == "sim")
            {
                Console.WriteLine("Por favor adquira sua passagem.");
                //chamar um metodoComprarPassagem
            }
            else if(resposta == "nao")
            {
                Console.WriteLine("Conheça nossas lojas.");
            }

        }

        double ComprarProduto(double precovenda)
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
    }
}