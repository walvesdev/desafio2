using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2.Mascara
{
    public class MascaraCPF: MascaraBase
    {
        public string Aplicar(string textoCPF)
        {
            var mascarado = AplicarMascara(textoCPF, "###.###.###-##");
            return mascarado;
        } 
    }
}
