using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
IMPLEMENTAÇÃO BASE DA CLASE

Precisa adcionar os metodos de preparar pedidos e adcionar os pratos no cardapio

*/

namespace ProjetoLesCode01
{
    public class SelfService: ILojas
    {
        private string nomeSelfService {get; set;}
        private string posShop {get;}
         private List<String> produtos = new List<String>();

        public SelfService(String nomeSelfService, string posShop)
        {
            this.posShop = posShop;
            this.nomeSelfService = nomeSelfService;
        }

        public string NomeLoja {

            get  { return this.nomeSelfService; }           
        }
        public string PosShop {

            get  {return this.posShop; }
        }

        public  List<String> Produtos {

            get { return this.produtos;}
            set {produtos = AddProduto();}
        }

        public List<String> AddProduto()
        {
            List<String> produto = new List<string>();

            Console.WriteLine("Vamos cria o seu cardapio");
            Console.WriteLine("Quantos pratos deseja adicionar?");

            int nProdutos;
            Int32.TryParse(Console.ReadLine(), out nProdutos);

            for (int i = 1; i <= nProdutos; i++)
            {   
                Console.Write($"\nPrato nº {i}: "); 
                produto.Add(Console.ReadLine());            
                Console.WriteLine("Prato adicionado com sucesso");             
            }

            return produto;
        }
    }
}