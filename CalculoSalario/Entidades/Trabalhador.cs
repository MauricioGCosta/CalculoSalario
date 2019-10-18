using CalculoSalario.Enumeracoes;
using CalculoSalario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoSalario.Entidades
{
    class Trabalhador
    {
        public string Nome { get; set; }
        public NivelDoTrabalhador Level { get; set; }
        public double SalarioBase { get; set; }
        public List<Contrato> Contratos { get; private set; } = new List<Contrato>();
        public Departamento Departamento { get; set; }

        public Trabalhador()
        {

        }

        public Trabalhador(string nome, NivelDoTrabalhador level, double salarioBase, Departamento departamento)
        {
            Nome = nome;
            Level = level;
            SalarioBase = salarioBase;
            Departamento = departamento;
            Contratos = new List<Contrato>();
        }

        public void AdicionaContrato(Contrato contrato)
        {
            Contratos.Add(contrato);
        }

        public void RemoveContrato(Contrato contrato)
        {
            Contratos.Remove(contrato);
        }

        public double Renda(int ano, int mes)
        {
            double soma = SalarioBase;

            foreach (var item in Contratos)
            {                
                string[] diaMesAno = item.Data.ToString().Split('/');

                if (item.Data.Year == ano && item.Data.Month == mes)
                {
                    soma += item.ValorTotal();
                }
            }

            return soma;
        }
    }
}
