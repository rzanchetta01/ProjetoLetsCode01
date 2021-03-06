using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLesCode01
{
    public class Produto
    {
        private String nome;
        private Double preco;

        public Produto(string nome, double preco)
        {
            this.nome = nome;
            this.preco = preco;
        }

        public string NomeProduto { get => nome; set => nome = value; }
        public double Preco { get => preco; set => preco = value; }

        public override string ToString()
        {
            return NomeProduto + " R$ " + Preco;
        }
    }
}
