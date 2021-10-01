using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* Classe que contem a lista de destinos das passagens
*/

namespace ProjetoLetsCode01
{
    public class Voos
    {
        double precopassagem = "150";
        private int codVoo;
        private string destinoVoo; 

        public int CodVoo
        {
            get {return this.codVoo;}
        }

        public string DestinoVoo
        {
            get {return this.destinoVoo;}
        }

        public void DestinosVoo ()
        {
            Dictionary<int, string> destinos = new Dictionary <int, string>();
            destinos.Add(1, "RJ");
            destinos.Add(2, "MG");
            destinos.Add(3, "BA");
            destinos.Add(4, "PR");
            destinos.Add(5, "ES");
        }

    }
}