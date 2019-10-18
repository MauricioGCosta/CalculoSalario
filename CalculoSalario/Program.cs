using System;
using System.Globalization;
using CalculoSalario.Entidades;
using CalculoSalario.Enumeracoes;

namespace CalculoSalario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre com o nome do Departamento: ");
            string nomeDepartamento = Console.ReadLine();

            Console.WriteLine("Entre com os dados do trabalhador: ");
            Console.Write("Entre com o nome do trabalhador: ");
            string nomeTrabalhador = Console.ReadLine();

            Console.Write("Entre com o nível do trabalhador (Junior/Nivel_Medio/Senior): ");
            NivelDoTrabalhador nivelDoTrabalhador = Enum.Parse<NivelDoTrabalhador>(Console.ReadLine());

            Console.Write("Éntre com o salário base: ");
            double salarioBase = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Quantos contratos tem este trabalhador? ");
            int numContratos = int.Parse(Console.ReadLine());

            Departamento departamento = new Departamento(nomeDepartamento);
            Trabalhador trabalhador = new Trabalhador(nomeTrabalhador, nivelDoTrabalhador, salarioBase, departamento);

            for (int i = 1; i <= numContratos; i++)
            {
                Console.WriteLine("Entre com os dados do contrato #" + i);
                Console.Write("Entre com a data no formato (DD/MM/AAAA): ");
                DateTime data = DateTime.Parse(Console.ReadLine());
                Console.Write("Entre com o valor por hora: ");
                double valorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Entre com a duração em horas: ");
                int horas = int.Parse(Console.ReadLine());

                Contrato contrato = new Contrato(data, valorHora, horas);

                trabalhador.AdicionaContrato(contrato);
            }

            Console.WriteLine("Nome: " + nomeTrabalhador);
            Console.WriteLine("Departamento: " + nomeDepartamento);

            Console.Write("Entre com o mês e o ano para o cálculo da renda (MM/AAAA): ");
            string mesAno = Console.ReadLine();
            string[] mesAnoSeparados = mesAno.Split("/");

            Console.WriteLine("Renda para " + mesAno + ": " + trabalhador.Renda(int.Parse(mesAnoSeparados[1]), int.Parse(mesAnoSeparados[0])).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
