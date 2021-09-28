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

        private List<String> cardapio = new List<String>();
        private List<String> pedidos = new List<String>();

        public string NomeLoja {

            get  { return this.nomeSelfService; }           
        }
        public string PosShop {

            get  {return this.posShop; }
        }

        public List<String> Cardapio {

            get { return this.cardapio; }          
        }
        public List<String> Pedidos {

            get { return this.pedidos; }           
        }

        public SelfService(String nomeSelfService, string posShop)
        {
            this.posShop = posShop;
            this.nomeSelfService = nomeSelfService;
        }

    }
}