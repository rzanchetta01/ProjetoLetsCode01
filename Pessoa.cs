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
            get{return this.nomePessoa;}
            set{this.nomePessoa = value;}
        }

        public Pessoa (string Nome) 
        {
            this.nomePessoa = Nome;
        }

        public void ComprarProduto() 
        {
           Console.WriteLine($"Você efetuou a compra do {/*nomedoproduto*/} com sucesso!");
        }

        public void ComprarPassagem()
        {
            Console.WriteLine($"Você efetuou a compra da passagem código: {/*codigodapassagem*/} com sucesso!");
        }

        public void RegistrarBagagem()
        {
            Console.WriteLine($"Você registrou a sua bagagem {/*bagagem*/} com sucesso!");
        }
    }
}