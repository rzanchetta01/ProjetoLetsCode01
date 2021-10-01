﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoLesCode01
{
    class Program
    {   
        //tudo que fosse fazer tem que atraves de um unico menu --> 
        static void Main(string[] args)
        {

            List<ILojas> estabelecimentos = new List<ILojas>();//Lista que armazena os estabelecimentos
            List<Pessoa> pessoas = new List<Pessoa>();
            
            LojasIncial(estabelecimentos, pessoas);//Cria lojas default, inclusive a empresa aerea
            StartMenu(estabelecimentos, pessoas);//Menu iniciar do sistema
            
        }
        public static void LojasIncial(List<ILojas> estabelecimentos, List<Pessoa> pessoas)
        {
            ILojas ps = new LojaComum("Carro do perigo", "na entrada do shopping");
            ILojas fs = new FastFood("FoodFast", "na praça de alimentação");
            ILojas sf = new SelfService("ServiceSelf", "na praça de alimentação");
            
            Pessoa p = new Pessoa("r", 1000, false);
            

            ps.AddProduto("Air jordan duvidos", 99);
            ps.AddProduto("Disco vinil", 500);
            ps.AddProduto("Gema do poder que o thanos queria", 99999.99);

            fs.AddProduto("a", 25);
            fs.AddProduto("Hamburguer quase bom", 15);
            fs.AddProduto("HAmburguer da promoção do dia", 5);
            fs.AddProduto("Refri free refil", 0);

            sf.AddProduto("Arroz e feijão", 20);
            sf.AddProduto("Carne", 20);
            sf.AddProduto("Frango", 20);
            sf.AddProduto("Bebibas genericas", 6);

            estabelecimentos.Add(fs);
            estabelecimentos.Add(sf);
            estabelecimentos.Add(ps);           
            pessoas.Add(p);

            
        }
        public static void StartMenu(List<ILojas> estabelecimentos, List<Pessoa> pessoas)//Mostra o menu inicial do sistema
        {   
            //Menu inicial
            Console.WriteLine("\nBem vindo ao sistema do shopping ");
            Console.WriteLine("1 para Registrar loja");
            Console.WriteLine("2 para Registrar pessoa");
            Console.WriteLine("3 para alterar um produto de uma loja existente");
            Console.WriteLine("4 para Simular um cliente");
            Console.WriteLine("9 para Sair");

            int option;//variavel que descide a movimentação do menu pelo codigo
            Int32.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1:

                    AddLoja(estabelecimentos, pessoas);//Cria estabelecimentos novos
                    break;

                case 2:

                    AddCliente(estabelecimentos, pessoas);//Registra clientes novos
                    break;

                case 3:

                    AlteraDadosLoja(estabelecimentos, pessoas);//Altera o catalogo/cardapio da loja es questão
                    break;

                case 4:
                    Console.WriteLine("");

                    FazerCompra(estabelecimentos, pessoas);
                    Thread.Sleep(1000);
                    StartMenu(estabelecimentos, pessoas);//Caso digite um numero fora do menu, reinicia o processo
                    break;

                case 9:
                    Console.WriteLine("\nTchau Tchau");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Numero incorreto");
                    Thread.Sleep(1000);
                    StartMenu(estabelecimentos, pessoas);//Caso digite um numero fora do menu, reinicia o processo
                    break;
            }
        }
     
        public static void AddLoja(List<ILojas> estabelecimentos, List<Pessoa> pessoas)//Função para adcionar estabelecimentos
        {

            string tipoLoja;
            string nomeLoja;
            string posShop;
            bool option;

            Console.WriteLine("\nQual o tipo de loja?");
            Console.WriteLine("Para voltar digite 0");
            Console.WriteLine("Temos disponivel para registro : FastFood, LojaComum e SelfService");
            tipoLoja = Console.ReadLine().ToUpper();//Le o tipo de loja e deixa tudo em caixa alta para evitar problemas

            if (tipoLoja == "FASTFOOD")//Criação de um futuro fastfood
            {

                Console.WriteLine("Criando um FastFood");
                nomeLoja = AuxAddLojaNome(estabelecimentos);
                posShop = AuxAddLojaPos(estabelecimentos);
                FastFood ff = new FastFood(nomeLoja, posShop);
                estabelecimentos.Add(ff);

                Console.WriteLine("Agora vamos criar o seu cardapio inicial, você pode complementar ele depois através do menu inicial");
                Console.WriteLine("Quantos pratos deseja adicionar inicialmente");
                int nProduto;
                string nomePrato;
                double precoPrato;
                Int32.TryParse(Console.ReadLine(), out nProduto);

                for (int i = 1; i <= nProduto; i++)
                {
                    Console.WriteLine($"Produto n{i}");

                    Console.Write("Nome: ");
                    nomePrato = Console.ReadLine();

                    Console.Write("\nPreco: ");
                    double.TryParse(Console.ReadLine(), out precoPrato);

                    ff.AddProduto(nomePrato, precoPrato);
                }

            }
            else if (tipoLoja == "LOJACOMUM")//criação de uma futura loja comum
            {

                Console.WriteLine("Criando uma LojaComum");
                nomeLoja = AuxAddLojaNome(estabelecimentos);
                posShop = AuxAddLojaPos(estabelecimentos);
                LojaComum lc = new LojaComum(nomeLoja, posShop);
                estabelecimentos.Add(lc);

                Console.WriteLine("Agora vamos registrar seus produtos iniciais, você pode adicionar outros através do menu inicial");
                Console.WriteLine("Quantos produtos deseja adicionar inicialmente?");

                int nProduto;
                string nomeProduto;
                double precoProduto;
                Int32.TryParse(Console.ReadLine(), out nProduto);

                for (int i = 1; i <= nProduto; i++)
                {
                    Console.WriteLine($"Prato n{i}");

                    Console.Write("Nome: ");
                    nomeProduto = Console.ReadLine();

                    Console.Write("\nPreco: ");
                    double.TryParse(Console.ReadLine(), out precoProduto);  
                    
                    lc.AddProduto(nomeProduto, precoProduto);
                }

            }
            else if (tipoLoja == "SELFSERVICE")//Criação de um selfservice
            {

                Console.WriteLine("Criando um SelfService");
                nomeLoja = AuxAddLojaNome(estabelecimentos);
                posShop = AuxAddLojaPos(estabelecimentos);
                SelfService sf = new SelfService(nomeLoja, posShop);
                estabelecimentos.Add(sf);

                Console.WriteLine("Agora vamos criar o seu cardapio inicial, você pode complementar ele depois através do menu inicial");
                Console.WriteLine("Quantos pratos deseja adicionar inicialmente");
                int nProduto;
                string nomePrato;
                double precoPrato;
                Int32.TryParse(Console.ReadLine(), out nProduto);

                for (int i = 1; i <= nProduto; i++)
                {
                    Console.WriteLine($"Prato n{i}");

                    Console.Write("Nome: ");
                    nomePrato = Console.ReadLine();

                    Console.Write("\nPreco: ");
                    double.TryParse(Console.ReadLine(), out precoPrato);

                    sf.AddProduto(nomePrato, precoPrato);
                }

            }
            else if (tipoLoja == "0")//caso queira voltar ao menu incial
            {

                StartMenu(estabelecimentos, pessoas);

            }
            else
            {
                Console.WriteLine("Tipo de loja não encontrado, tente novamente");
                Thread.Sleep(1000);
                AddLoja(estabelecimentos, pessoas);//Repete o processo de digitar, caso digite algum tipo de loja errado
            }

            option = RepitirProcesso("\nDesejeita registrar outra loja?");//Descide se quer adicionar uma nova loja

            if (option)
            {
                Thread.Sleep(1000);
                AddLoja(estabelecimentos, pessoas);
            }
            else
            {
                Thread.Sleep(1000);
                StartMenu(estabelecimentos, pessoas);
            }

        }
       
        public static String AuxAddLojaNome(List<ILojas> estabelecimentos)//Função auxiliar do AddLoja
        {
            string nomeLoja;

            Console.Write("\nQual o nome da loja que você vai registrar? ");
            nomeLoja = Console.ReadLine();

            foreach (var e in estabelecimentos)//Verificação para saber se ja não existe uma loja com o nome que quer criar
            {
                if (e.NomeLoja.ToUpper() == nomeLoja.ToUpper())
                {
                    Console.WriteLine("\nJa existe uma loja com esse nome tente novamente");
                    Thread.Sleep(1000);
                    AuxAddLojaNome(estabelecimentos);
                }
            }

            return nomeLoja;
        }
        
        public static String AuxAddLojaPos(List<ILojas> estabelecimentos)//Função auxiliar do AddLoja
        {

            int option;
                
            Console.Write("\nQual será o local onde a loja sera montada? ");
            Console.WriteLine("Temos\n1: Praça de Alimentação\n2:Corredores do shopping");
            Int32.TryParse(Console.ReadLine(), out option);

            if(option == 1)
            {
                return "Praça de alimentação";  
            }
            else if (option == 2)
            {
                return "Corredores do shopping";
            }
            else //valida erros novamente
            {
                Console.WriteLine("Opção inválida, tente novamente");
                Thread.Sleep(500);
                return AuxAddLojaPos(estabelecimentos);
            }
                             
        }
        
        public static bool RepitirProcesso(string msg)//Função para repitir todas as tomadas de descisão de sim ou não
        {
            string option;

            Console.WriteLine($"\n{msg} \nsim ou não");
            option = Console.ReadLine();
            Console.WriteLine("");

            if (option.ToUpper() == "SIM")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        public static void AddCliente(List<ILojas> estabelecimentos, List<Pessoa> pessoas)//Registra novos clientes
        {
            Console.Write("\nQual o seu nome: ");
            string nome = Console.ReadLine();
            double saldoInicial;
            bool isPassageiro;
            Console.Write("\nQual o seu saldo para futuras compras? ");
            double.TryParse(Console.ReadLine(), out saldoInicial);

            isPassageiro = RepitirProcesso("\nVocê é um passageiro?");


            Pessoa p = new Pessoa(nome, saldoInicial, isPassageiro);
            pessoas.Add(p);

            if (isPassageiro)
            {
                Console.WriteLine("Qual a sua bagagem\nDigite 0 para sair");
                Console.Write("Bagagem: ");
                String bag = Console.ReadLine();
                while (bag != "0")
                {
                    p.RegistrarBagagemInicial(bag);
                    Console.Write("Bagagem: ");
                    bag = Console.ReadLine();
                }

                Console.Write("\nNão esqueça de comprar sua passagem para conseguir ir embora\n");
            }

            Thread.Sleep(200);
            Console.WriteLine("Você foi registrado em nosso sistema");

            StartMenu(estabelecimentos, pessoas);
        }
       
        public static void AlteraDadosLoja(List<ILojas> estabelecimentos, List<Pessoa> pessoas)//Altera o catalogo/produto das lojas
        {
            Console.WriteLine("Qual loja deseja alterar os dados?");

            foreach (var e in estabelecimentos)//mostra as lojas registradas no sistema
            {
                Console.WriteLine($"Loja: {e.NomeLoja}");

            }

            String lojaNome = Console.ReadLine();

            foreach (var e in estabelecimentos)//busca qual loja tem o mesmo nome
            {
                if (lojaNome.ToUpper() == e.NomeLoja.ToUpper())// se for igual, começa a parte de alteração de catalogo
                {
                    int AddRemove;
                    Console.WriteLine("1 para Adicionar um novo produto/prato ao estabelecimento");
                    Console.WriteLine("2 para Remover um produto/prato existente ao estabelecimento");
                    Int32.TryParse(Console.ReadLine(), out AddRemove);
                    if (AddRemove == 1)
                    {

                        string nomePrato;
                        double precoPrato;

                        Console.Write("Nome: ");
                        nomePrato = Console.ReadLine();

                        Console.Write("\nPreco: ");
                        double.TryParse(Console.ReadLine(), out precoPrato);

                        e.AddProduto(nomePrato, precoPrato);
                        Console.WriteLine("Produto adicionado com sucesso");
                        Thread.Sleep(500);
                        StartMenu(estabelecimentos, pessoas);//Volta ao menu inicial
                    }
                    else if (AddRemove == 2)
                    {
                        Console.WriteLine("Qual produto deseja remover?");
                        e.MostrarProduto();
                        String removeProduto = Console.ReadLine();
                        Console.WriteLine(e.RemoverProduto(removeProduto));
                        Thread.Sleep(500);
                        StartMenu(estabelecimentos, pessoas);//Volta ao menu inicial
                    }
                    else//Validação de digitação errada
                    {
                        Console.WriteLine("Produto não encontrado");
                        Thread.Sleep(500);
                        StartMenu(estabelecimentos, pessoas);
                    }
                }
            }
        }
       
        public static Pessoa SelectCliente(List<Pessoa> pessoas)
        {
            Console.WriteLine("Quem você é?\n");

            foreach (var e in pessoas)
            {
                Console.WriteLine(e.NomePessoa);
            }

            Console.WriteLine("");

            string selectPessoa = Console.ReadLine();

            foreach (var e in pessoas)
            {
                if(e.NomePessoa.ToUpper() == selectPessoa.ToUpper())
                {
                    return e;
                }
            }

            Console.WriteLine("Cliente não econtrado, tente novamente");
            return SelectCliente(pessoas);
        }
       
        public static ILojas SelectEstabelecimento(List<ILojas> estabelecimentos)
        {
            Console.WriteLine("Qual estabelecimento deseja gastar seu dinheirinho?\n");

            foreach (var e in estabelecimentos)
            {
                Console.WriteLine(e.NomeLoja);
            }

            Console.WriteLine("");

            string selectNomeEstabelecimento = Console.ReadLine();

            foreach (var e in estabelecimentos)
            {
                if (e.NomeLoja.ToUpper() == selectNomeEstabelecimento.ToUpper())
                {
                    return e;
                }
            }

            Console.WriteLine("Loja não econtrada, tente novamente");
            Thread.Sleep(1000);
            return SelectEstabelecimento(estabelecimentos);
        }
       
        public static void FazerCompra(List<ILojas> estabelecimentos, List<Pessoa> pessoas)
        {
            Pessoa cliente = SelectCliente(pessoas);
            if(cliente.IsPassageiro)
            {
                if (RepitirProcesso("Deseja comprar sua passagem?"))
                {
                    cliente.ComprarPassagem(340, TAP());
                }
            }


            ILojas loja = SelectEstabelecimento(estabelecimentos);
            
            double totalCompra = 0;
            totalCompra = loja.FazerVenda(cliente, 0);

            cliente.ComprarProduto(totalCompra);
        }   
      
        public static Voos TAP()
        {
            return new Voos("Passagens aereas", "na entrada do shopping");
        }
    
    }
}

