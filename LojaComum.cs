using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
IMPLEMENTAÇÃO BASE DA CLASE

Precisa adcionar os metodos que darão utilidade a loja, por exemplo comprar roupas

*/

namespace ProjetoLesCode01
{
    public class LojaComum: ILojas
    {
        private string nomeLojaComum {get; set;}
        private string posShop {get;}


        private List<String> cardapio = new List<String>();
        

        public string NomeLoja {

            get  { return this.nomeLojaComum; }           
        }
        public string PosShop {

            get  {return this.posShop; }
        }

        public List<String> Pedidos {

            get { return this.pedidos; }           
        }

        public LojaComum(String nomeLojaComum, string posShop)
        {
            this.posShop = posShop;
            this.nomeLojaComum = nomeLojaComum;
        }
        public void AddCatalogo(sting algo) 
        {
            catalogo.add(algo);
        }

        public void MostrarCatalogo(string algo)
        {
            foreach(var e in catalogo){
                console.WriteLine(e);
            }
        }

        public void RemoverDoCatalogo(string algo)
        {
            cardapio.remove(algo);
        }

                public  List<String> Produtos {

            get { return this.produtos;}
            set {produtos = AddProduto();}
        }

        public List<String> AddProduto()
        {
            List<String> produto = new List<string>();

            Console.WriteLine("Vamos registrar os produtos que irá vender em sua loja");
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