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
    public class FastFood: ILojas
    {
        private string nomeFastFood {get; set;}
        private string posShop {get;}

        private List<String> produtos = new List<String>();

        public string NomeLoja {

            get  { return this.nomeFastFood; }           
        }
        public string PosShop {

            get  {return this.posShop; }
        }


        public FastFood(String nomeFastFood, string posShop)
        {
            this.posShop = posShop;
            this.nomeFastFood = nomeFastFood;
        }

        public  List<String> Produtos {

            get { return this.produtos;}
            set {produtos = AddProduto();}
        }

        public List<String> AddProduto()
        {
            List<String> produto = new List<string>();

            Console.WriteLine("Vamos cria o seu cardapio");
            Console.WriteLine("Quantos produtos deseja adicionar?");

            int nProdutos;
            Int32.TryParse(Console.ReadLine(), out nProdutos);

            for (int i = 1; i <= nProdutos; i++)
            {   
                Console.Write($"\nProduto nº {i}: "); 
                produto.Add(Console.ReadLine());            
                Console.WriteLine("Produto adicionado com sucesso");
                
            }

            return produto;
        }

    }
}