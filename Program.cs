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
            Console.WriteLine("oii");

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

                estabelecimentos.Add(new FastFood(nomeLoja, posShop));//Cria um novo fast food
                Console.WriteLine($"\nFoi registrado e construido mágicamente na {posShop} um FastFood com o nome de {nomeLoja}");

            }
            else if (tipoLoja == "LOJACOMUM")
            {
                nomeLoja = AuxAddLoja();
                posShop =  "corredores do shopping";
                estabelecimentos.Add(new LojaComum(nomeLoja, posShop));// Cria uma nova loja comum
                Console.WriteLine($"\nFoi registrado e construido mágicamente em algum dos {posShop} uma loja com o nome de {nomeLoja}");
            }
            else if (tipoLoja == "SELFSERVICE")
            {
                nomeLoja = AuxAddLoja();
                posShop =  "Praça de alimentação";
                estabelecimentos.Add(new SelfService(nomeLoja, posShop));// Cria um novo self service
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

            Console.WriteLine($"\n{msg} \n sim ou não");
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
