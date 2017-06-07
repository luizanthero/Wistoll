using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for RedefinirSenha
/// </summary>
namespace Wistoll.RedefinirSenha
{
    public class RedefinirSenha
    {
        private static int NumeroRand(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }


        private static string AlfaNumericoRandom(int tamanho, bool Maiuscula)
        {
            StringBuilder sb = new StringBuilder();
            Random r = new Random();

            char c;
            for (int i = 0; i < tamanho; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * r.NextDouble() + 65)));
                sb.Append(c);
            }
            if (Maiuscula == true)
            {
                return sb.ToString().ToUpper();
            }
            else
                return sb.ToString().ToLower();
        }

        public static string JuntarNumeroLetras()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(AlfaNumericoRandom(6, false));
            sb.Append(NumeroRand(1, 1000));
            sb.Append(AlfaNumericoRandom(2, true));
            return sb.ToString();
        }
    }
}