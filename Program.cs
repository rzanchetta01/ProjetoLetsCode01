using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLesCode01
{
    class Program
    {
        static void Main(string[] args)
        {

            List<ILojas> estabelecimentos = new List<ILojas>();//Lista que armazena os estabelecimentos
            AddLoja(estabelecimentos);//Chama o Registro de Lojas e salva e estabelecimentos

        }

        public static void AddLoja(List<ILojas> estabelecimentos)//Função para adcionar estabelecimentos
        {
            
            string tipoLoja;
            string nomeLoja;
            string posShop;
            bool option;

            Console.WriteLine("Qual o tipo de loja?");
            Console.WriteLine("Temos disponivel para registro : FastFood, LojaComum e SelfService");
            tipoLoja = Console.ReadLine().ToUpper();//Le o tipo de loja e deixa tudo em caixa alta para evitar problemas

            if(tipoLoja == "FASTFOOD")
            {

                nomeLoja = AuxAddLoja();
                posShop = "Praça de alimentação";

                FastFood ff = new FastFood(nomeLoja, posShop);//Cria um novo fast food
                ff.AddProduto();//adiciona o cardapio do fastfood
                estabelecimentos.Add(ff);//Salva em estabelecimentos o fast food criado
                
                Console.WriteLine($"\nFoi registrado e construido mágicamente na {posShop} um FastFood com o nome de {nomeLoja}");
            }
            else if (tipoLoja == "LOJACOMUM")
            {
                nomeLoja = AuxAddLoja();
                posShop =  "corredores do shopping";

                LojaComum lc = new LojaComum(nomeLoja, posShop);//Cria um nova loja comum
                lc.AddProduto();//adiciona os produtos dessa loja
                estabelecimentos.Add(lc);//Salva em estabelecimentos a loja criada

                Console.WriteLine($"\nFoi registrado e construido mágicamente em algum dos {posShop} uma loja com o nome de {nomeLoja}");
            }
            else if (tipoLoja == "SELFSERVICE")
            {
                nomeLoja = AuxAddLoja();
                posShop =  "Praça de alimentação";

                SelfService sf = new SelfService(nomeLoja, posShop);//Cria um novo Self Service
                sf.AddProduto();//adiciona o cardapio do self service
                estabelecimentos.Add(sf);//Salva em estabelecimentos o self service criado

                Console.WriteLine($"\nFoi registrado e construido mágicamente na {posShop} um self service com o nome de {nomeLoja}");
            }
            else
            {   
                Console.WriteLine("Tipo de loja não encontrado, tente novamente");
                AddLoja(estabelecimentos);//Repete o processo de digitar algum tipo de loja errado
            }


            option = RepitirProcesso("Desejeita registrar outra loja?");
            if(option)
            {
                AddLoja(estabelecimentos);
            }
        }
        public static String AuxAddLoja()//Função auxiliar do AddLoja
        {
            string nomeLoja;
            
            Console.Write("\nQual o nome da loja que você vai registrar? ");
            nomeLoja = Console.ReadLine();

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
    
    
    }
}
