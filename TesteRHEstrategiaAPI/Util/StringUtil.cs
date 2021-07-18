using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteRHEstrategiaAPI.Util
{
    public  static class StringUtil
    {
        public static bool CpfValido(this string cpf)
        {

            if (string.IsNullOrWhiteSpace(cpf))
            {

                return false;
            }
            string cpfValidado = cpf.Replace(".", "").Replace("/", "").Replace("-", "");

            if (cpfValidado == null)
            {
                return false;
            }

            var cpfInvalido = new[]
         {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999",
            };

            if (cpfInvalido.Contains(cpfValidado))
            {

                return false;
            }

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf, digito;
            int soma, resto;

            cpf = cpfValidado;

            if (cpf.Length != 11)
                return false;


            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
        
    }
}

