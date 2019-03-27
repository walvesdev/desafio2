using Desafio2.Mascara;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio2
{
    class Program
    {

        static void Main(string[] args)
        {
            VerificaCPF();
        }

        private static void VerificaCPF()
        {

            try
            {
                CorpoAPP();

                var cpf = GetCPF();
                var cpfVerificado = VerificaCPFNuloOuVazio(cpf);

                SairAPP(cpfVerificado);
                VerificaLetrasCPF(cpfVerificado);
                AplicaMascara(cpfVerificado);

            }

            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro:");
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
            Console.Clear();
            VerificaCPF();

        }

        private static void CorpoAPP()
        {
            Console.WriteLine("Desafio 2");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("O programa abaixo é um formatador de CPF, ele pede que você digite o CPF e logo após exibe o resultado formatado.");
            Console.WriteLine("Até o momento, ele só funciona caso digite os 11 numeros. Ex: 12345678901 => 123.456.789-01");
            Console.WriteLine("Ajuste o codigo existente para que o formatador de CPF também funcione nos seguintes casos:");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("1) Caso digite menos de 11 números, exibir a formatação nos números digitados. Ex: 1234567 => 123.456.7");
            Console.WriteLine("2) Não gerar erro caso digite letras, simbolos ou CPF parcialmente formatado. Ex: 123456789-01 => 123.456.789-01");
            Console.WriteLine("3) Caso não digite nada, exibir a mensagem 'É necessário digitar o CPF'");
            Console.WriteLine("4) Após formatar o CPF, solicitar para digitar novamente até que seja informado SAIR");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("ATENÇÂO: Deve-se implementar os casos acima utilizando como base o codigo já existente.");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("         Formatador de CPF v0.1 ");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Digite um CPF:");
        }

        private static string GetCPF()
        {
            string cpf = Console.ReadLine();
            cpf.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);// remove "." e "-";

            return cpf;
        }

        private static void SairAPP(string cpf)
        {
            if (cpf == "SAIR" || cpf == "sair")
            {
                Console.WriteLine("Fechando Aplicação...");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }

        private static void AplicaMascara(string cpf)
        {
            if (cpf.All(char.IsDigit)) // verifica se o que foi digitado é somente numeros;
            {
                MascaraCPF mascaraCPF = new MascaraCPF();
                string cpfFormatado = mascaraCPF.Aplicar(cpf);

                Console.WriteLine($"CPF Formatado: {cpfFormatado}");
                Console.WriteLine("Aperte qualquer tecla para continuar!");

            }
        }

        private static string VerificaLetrasCPF(string cpf)
        {

            if (cpf.Where(c => char.IsLetter(c)).Count() > 0) // /verifica se o que foi digitado contem letras;
            {
                Console.WriteLine("CPF não pode conter letras!");
            }

            return cpf;
        }

        private static string VerificaCPFNuloOuVazio(string cpf)
        {

            while (string.IsNullOrEmpty(cpf))//verifica se cpf não é nulo nem vazio;
            {
                Console.WriteLine("É necessário digitar o CPF: ");
                cpf = Console.ReadLine();
            }

            return cpf;
        }
    }
}


