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
<<<<<<< Updated upstream
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
=======
            get { return this.nomeLojaComum; }
        }
        public string PosShop
        {
            get { return this.posShop; }
        }
        
        public void AddProduto( String nome, Double preco )
        {   
                catalogo.Add(new Produto(nome, preco));
        }     
>>>>>>> Stashed changes

            get { return this.produtos;}
            set {produtos = AddProduto();}
        }

<<<<<<< Updated upstream
        public List<String> AddProduto()
        {
            List<String> produto = new List<string>();
=======
        public String RemoverProduto(String produto)
        {
            foreach (var e in catalogo)
            {
                if (e.NomeProduto == produto)
                {
                    catalogo.Remove(e);
                    return "Produto removido com sucesso";
                }
            }
>>>>>>> Stashed changes

            Console.WriteLine("Vamos registrar os produtos que irá vender em sua loja");
            Console.WriteLine("Quantos produtos deseja adicionar?");

            int nProdutos;
            Int32.TryParse(Console.ReadLine(), out nProdutos);

<<<<<<< Updated upstream
            for (int i = 1; i <= nProdutos; i++)
            {   
                Console.Write($"\nProduto nº {i}: "); 
                produto.Add(Console.ReadLine());            
                Console.WriteLine("Produto adicionado com sucesso");
                
            }

            return produto;
=======
        public double FazerVenda(Pessoa pessoa, double totalDaCompra)
        {
            
            Console.WriteLine($"\nBem vindo a {NomeLoja}");
            Console.WriteLine("Esse é o nosso catálogo");
            MostrarProduto();
            Console.WriteLine("\n0 para finalizar a compra");
            String nProduto = Console.ReadLine();

            if(nProduto == "0")
            {
                return totalDaCompra;
            }
            else
            {
                Produto p = catalogo.FirstOrDefault(p => p.NomeProduto.ToUpper() == nProduto.ToUpper());
                if(p == null)
                {
                    return FazerVenda(pessoa, totalDaCompra);
                }

                totalDaCompra += p.Preco;
               
                pessoa.RegistrarBagagem(p);
                Console.WriteLine("\n\n Adicionado ao carrinho com sucesso");
                Thread.Sleep(1000);
                return FazerVenda(pessoa, totalDaCompra);
               
            }                    
>>>>>>> Stashed changes
        }



    }
}