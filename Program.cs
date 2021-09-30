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
            LojasIncial(estabelecimentos);
            StartMenu(estabelecimentos);//Menu iniciar do sistema
        }

        public static void StartMenu(List<ILojas> estabelecimentos)
        {
            Console.WriteLine("\nBem vindo ao sistema do shopping ");
            Console.WriteLine("1 para Registrar loja");
            Console.WriteLine("2 para Registrar cliente");
            Console.WriteLine("3 para Registrar um produto de uma loja existente");
            Console.WriteLine("4 para Simular um cliente");
            Console.WriteLine("0 para Sair");

            int option;
            Int32.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1:

                    AddLoja(estabelecimentos);
                    break;

                case 2:

                    break;

                case 3:

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
                    StartMenu(estabelecimentos);
                    break;
            }
        }
       
        public static void AddLoja(List<ILojas> estabelecimentos)//Função para adcionar estabelecimentos
        {
            
            string tipoLoja;
            string nomeLoja;
            string posShop;
            bool option;

            Console.WriteLine("\nQual o tipo de loja?");
            Console.WriteLine("Para voltar digite 0");
            Console.WriteLine("Temos disponivel para registro : FastFood, LojaComum e SelfService");
            tipoLoja = Console.ReadLine().ToUpper();//Le o tipo de loja e deixa tudo em caixa alta para evitar problemas

            if(tipoLoja == "FASTFOOD")
            {

                nomeLoja = AuxAddLoja(estabelecimentos);
                posShop = "Praça de alimentação";

                FastFood ff = new FastFood(nomeLoja, posShop);//Cria um novo fast food
                ff.AddProduto();//adiciona o cardapio do fastfood
                estabelecimentos.Add(ff);//Salva em estabelecimentos o fast food criado
                Thread.Sleep(1000);
                Console.WriteLine($"\nFoi registrado e construido mágicamente na {posShop} um FastFood com o nome de {nomeLoja}");
            }
            else if (tipoLoja == "LOJACOMUM")
            {
                nomeLoja = AuxAddLoja(estabelecimentos);
                posShop =  "corredores do shopping";

                LojaComum lc = new LojaComum(nomeLoja, posShop);//Cria um nova loja comum
                lc.AddProduto();//adiciona os produtos dessa loja
                estabelecimentos.Add(lc);//Salva em estabelecimentos a loja criada
                Thread.Sleep(1000);
                Console.WriteLine($"\nFoi registrado e construido mágicamente em algum dos {posShop} uma loja com o nome de {nomeLoja}");
            }
            else if (tipoLoja == "SELFSERVICE")
            {
                nomeLoja = AuxAddLoja(estabelecimentos);
                posShop =  "Praça de alimentação";

                SelfService sf = new SelfService(nomeLoja, posShop);//Cria um novo Self Service
                sf.AddProduto();//adiciona o cardapio do self service
                estabelecimentos.Add(sf);//Salva em estabelecimentos o self service criado
                Thread.Sleep(500);
                Console.WriteLine($"\nFoi registrado e construido mágicamente na {posShop} um self service com o nome de {nomeLoja}");
            }
            else if (tipoLoja == "0")
            {
                StartMenu(estabelecimentos);
            }
            else 
            {   
                Console.WriteLine("Tipo de loja não encontrado, tente novamente");
                Thread.Sleep(1000);
                AddLoja(estabelecimentos);//Repete o processo de digitar algum tipo de loja errado
            }


            option = RepitirProcesso("\nDesejeita registrar outra loja?");
            if(option)
            {
                Thread.Sleep(1000);
                AddLoja(estabelecimentos);
            }
            else
            {
                Thread.Sleep(1000);
                StartMenu(estabelecimentos);
            }
        }
        public static String AuxAddLoja(List<ILojas> estabelecimentos)//Função auxiliar do AddLoja
        {
            string nomeLoja;
            
            Console.Write("\nQual o nome da loja que você vai registrar? ");
            nomeLoja = Console.ReadLine();

            foreach (var e in estabelecimentos)
            {
                if(e.NomeLoja.ToUpper() == nomeLoja.ToUpper())
                {
                    Console.WriteLine("\nJa existe uma loja com esse nome tente novamente");
                    Thread.Sleep(1000);
                    AuxAddLoja(estabelecimentos);
                }
            }

            return nomeLoja;
        }
       
        public static bool RepitirProcesso(string msg)//Função para repitir todos os processos de descisão de sim ou não
        {
            string option;

            Console.WriteLine($"\n{msg} \nsim ou não");
            option = Console.ReadLine().ToUpper();
            Console.WriteLine("");

            if(option == "SIM")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static void LojasIncial (List<ILojas> estabelecimentos)
        {
            estabelecimentos.Add(new FastFood("FoodFast", "na praça de alimentação"));
            estabelecimentos.Add(new SelfService("ServiceSelf", "na praça de alimentação"));
            estabelecimentos.Add(new LojaComum("Passagens aereas", "na entrada do shopping"));
        }
    }
}