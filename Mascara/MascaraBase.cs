using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2.Mascara
{
    public abstract class MascaraBase
    {
        protected string AplicarMascara(string valor, string mascara)
        {
            if (string.IsNullOrEmpty(valor)) { throw new ArgumentNullException(nameof(valor)); }
            if (string.IsNullOrEmpty(mascara)) { throw new ArgumentNullException(nameof(mascara)); }

            StringBuilder sb = new StringBuilder();

            int idx = 0;
            if (valor.Length == 11)
            {
                for (int i = 0; i < mascara.Length; i++)
                {
                    var c = mascara[i];
                    if (c == '#')
                    {
                        sb.Append(valor[idx]);
                        idx++;
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                var formatado = sb.ToString();
                return formatado;
            }
            else 
            {
                string response = valor.Trim();

                if (response.Length < 3)
                {
                    return response;
                }
                else if (response.Length >= 3  && response.Length < 6)
                {
                    response = response.Insert(3, ".");
                    return response;
                }
                else if (response.Length >= 6 && response.Length < 10)
                {
                    response = response.Insert(3, ".");
                    response = response.Insert(7, ".");
                    return response;
                }
                else
                {
                    response = response.Insert(3, ".");
                    response = response.Insert(7, ".");
                    response = response.Insert(11, "-");
                    return response;
                }
            }

        }

    }
}

