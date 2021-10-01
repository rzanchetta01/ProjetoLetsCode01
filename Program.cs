using System;
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

            LojasIncial(estabelecimentos);//Cria lojas default, inclusive a empresa aerea
            StartMenu(estabelecimentos, pessoas);//Menu iniciar do sistema
            
            
                       
        }
        public static void LojasIncial(List<ILojas> estabelecimentos)
        {
            ILojas ps = new LojaComum("Carro do perigo", "na entrada do shopping");
            ILojas fs = new FastFood("FoodFast", "na praça de alimentação");
            ILojas sf = new SelfService("ServiceSelf", "na praça de alimentação");
            ILojas v = new Voos("Passagens aereas", "na entrada do shopping");

            ps.AddProduto("Air jordan duvidos", 99);
            ps.AddProduto("Disco vinil", 500);
            ps.AddProduto("Gema do poder que o thanos queria", 99999.99);

            fs.AddProduto("Hamburguer do bom", 25);
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
            estabelecimentos.Add(v);
        }
        public static void StartMenu(List<ILojas> estabelecimentos, List<Pessoa> pessoas)
        {
            Console.WriteLine("\nBem vindo ao sistema do shopping ");
            Console.WriteLine("1 para Registrar loja");
            Console.WriteLine("2 para Registrar pessoa");
            Console.WriteLine("3 para alterar um produto de uma loja existente");
            Console.WriteLine("4 para Simular um cliente");
            Console.WriteLine("0 para Sair");

            int option;
            Int32.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1:

                    AddLoja(estabelecimentos, pessoas);
                    break;

                case 2:

                    Console.Write("\nQual o seu nome: ");
                    string nome = Console.ReadLine();
                    double saldoInicial;
                    bool isPassageiro;
                    Console.Write("\n Qual o seu saldo para futuras compras? ");
                    double.TryParse(Console.ReadLine(), out saldoInicial);

                    isPassageiro = RepitirProcesso("\nVocê é um passageiro?");
                    if(isPassageiro)
                    {
                        Console.Write("\nNão esqueça de comprar sua passagem para conseguir ir embora\n");
                    }

                    Pessoa p = new Pessoa(nome, saldoInicial, isPassageiro);
                    pessoas.Add(p);

                    Thread.Sleep(200);
                    Console.WriteLine("Você foi registrado em nosso sistema");

                    StartMenu(estabelecimentos, pessoas);
                    break;

                case 3:

                    Console.WriteLine("Qual loja deseja alterar os dados?");
                    
                    foreach (var e in estabelecimentos)
                    {
                        Console.WriteLine($"Loja: {e.NomeLoja}");
                        
                    }

                    String lojaNome = Console.ReadLine();

                    foreach (var e in estabelecimentos)
                    {
                        if(lojaNome.ToUpper() == e.NomeLoja.ToUpper())
                        {
                            int AddRemove;
                            Console.WriteLine("1 para Adicionar um novo produto/prato ao estabelecimento");
                            Console.WriteLine("2 para Remover um produto/prato existente ao estabelecimento");
                            Int32.TryParse(Console.ReadLine(), out AddRemove);
                            if(AddRemove == 1)
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
                                StartMenu(estabelecimentos, pessoas);
                            }
                            else if (AddRemove == 2)
                            {
                                Console.WriteLine("Qual produto deseja remover?");
                                e.MostrarProduto();
                                String removeProduto = Console.ReadLine();
                                Console.WriteLine(e.RemoverProduto(removeProduto));
                                Thread.Sleep(500);
                                StartMenu(estabelecimentos, pessoas);
                            }
                            else
                            {
                                Console.WriteLine("Produto não encontrado");
                                Thread.Sleep(500);
                                StartMenu(estabelecimentos, pessoas);
                            }
                        }
                    }

                    break;

                case 4:

                    break;

                case 0:
                    Console.WriteLine("\nTchau Tchau");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Numero incorreto");
                    Thread.Sleep(1000);
                    StartMenu(estabelecimentos, pessoas);
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

            if (tipoLoja == "FASTFOOD")
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
            else if (tipoLoja == "LOJACOMUM")
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
            else if (tipoLoja == "SELFSERVICE")
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
            else if (tipoLoja == "0")
            {

                StartMenu(estabelecimentos, pessoas);

            }
            else
            {
                Console.WriteLine("Tipo de loja não encontrado, tente novamente");
                Thread.Sleep(1000);
                AddLoja(estabelecimentos, pessoas);//Repete o processo de digitar algum tipo de loja errado
            }

            option = RepitirProcesso("\nDesejeita registrar outra loja?");

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

            foreach (var e in estabelecimentos)
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
            else 
            {
                Console.WriteLine("Opção inválida, tente novamente");
                Thread.Sleep(500);
                return AuxAddLojaPos(estabelecimentos);
            }
                             
        }


        public static bool RepitirProcesso(string msg)//Função para repitir todos os processos de descisão de sim ou não
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



        
    }
}

