using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoLesCode01
{
    public class Pessoa: IPassageiro //Toda e qualquer pessoa, podendo ser passageiro
    {
        private readonly string nomePessoa;
        private double saldo;
        private readonly bool isPassageiro;
        private bool hasPassagem;

        public Pessoa(string Nome, Double saldoInicial, bool isPassageiro)//Construtor
        {
            this.nomePessoa = Nome;
            this.saldo = saldoInicial;
            this.isPassageiro = isPassageiro;
        }      

        public string NomePessoa { get => nomePessoa; }
      
        public string NomePassageiro { get => nomePessoa; }

        public Double Saldo { get => saldo; set => saldo = value; }

        public bool IsPassageiro { get => isPassageiro; }

        public void ComprarProduto (double precovenda)//Processo de comprar algo das lojas
        {            
            if (ComprarItem(precovenda))
            {
                Saldo -= precovenda;
                Console.WriteLine($"A compra foi confirmada.");
                Console.WriteLine($"Seu saldo é R$ {Saldo}.");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente, retornando ao menu");
                Thread.Sleep(500);
            }
        }
      
        private bool ComprarItem(double valProduto)//Função aux para o pagamento
        {            
            if(Saldo >= valProduto)
            {
                return true;
            }
            else
            {
                return false;
            }         
        }

        public void ComprarPassagem (double precopassagem, Voos destino)//Processo de comprar passagem
        {                   
            Console.WriteLine ("Selecione o código correspondente ao destino desejado");            
            Console.WriteLine("Os destinos disponíveis são\n");
                        
            foreach(var e in destino.DestinosVoo())
            {
                Console.WriteLine(e.Key + ": " + e.Value);
            }
            Int32.TryParse(Console.ReadLine(), out int codVoo);
          
            if (ComprarItem(precopassagem))
            {              
                saldo -= precopassagem;
                Console.WriteLine($"A compra da passagem com código {codVoo} foi confirmada");
                Console.WriteLine($"Seu saldo é R$ {Saldo}");
                hasPassagem = true;
            }
            else
            {
                Console.WriteLine("Vai dormir no shopping, ta sem dinheiro pra voltar pra casa");
            }
        }

        public void RegistrarBagagem (Produto produto)//Registra a bagagem
        {
            List<string> bagagem = new();         
            bagagem.Add(produto.NomeProduto);
        }

        public void RegistrarBagagemInicial(String produto)//Registra a baganem inicial
        {
            List<string> bagagem = new();
            bagagem.Add(produto);
        }
    }
}