using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Helpers
{
    public static class Validators
    {
        public static void ValidateNullOrEmpty(string value, string propertyName)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(propertyName, "O campo é obrigatório.");
        }

        public static void ValidateDecimal(decimal value, string propertyName)
        {
            if (value.ToString().Length == 0)
                throw new ArgumentException(propertyName, "O campo é obrigatório.");
        }

        #region Validar Cpf/Cnpj
        public static void ValidarCpfCnpj(string numero)
        {
            string rawNumero = GetRawNumero(numero);

            if (rawNumero.Length == 11)
                ValidarCpf(rawNumero);
            else
                ValidarCnpj(rawNumero);
        }

        private static string GetRawNumero(string numero) => numero.Trim()
                                                                     .Replace(".", "")
                                                                     .Replace("-", "")
                                                                     .Replace("/", "");

        private static void ValidarCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                throw new ArgumentException("O número do CNPJ é inválido.");
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            if (!cnpj.EndsWith(digito))
                throw new ArgumentException("O número do CNPJ é inválido.");
        }

        private static void ValidarCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                throw new ArgumentException("O número do CPF é inválido.");
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

            if (!cpf.EndsWith(digito))
                throw new ArgumentException("O número do CPF é inválido.");
        }
        #endregion
    }
}
