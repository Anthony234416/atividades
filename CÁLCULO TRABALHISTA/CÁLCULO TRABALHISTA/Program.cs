using System;

class CalculoTrabalhista
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Informe o valor da hora (ou 0 para sair): ");
            double valorHora = double.Parse(Console.ReadLine());

            if (valorHora == 0) break;

            Console.Write("Informe a quantidade de horas trabalhadas: ");
            double horas = double.Parse(Console.ReadLine());

            Console.Write("Vale-transporte (S/N)? ");
            string valeTransporte = Console.ReadLine().ToUpper();

            Console.Write("Outras deduções (R$): ");
            double outrasDeducoes = double.Parse(Console.ReadLine());

            double salarioBruto = valorHora * horas;
            double inss = CalcularINSS(salarioBruto);
            double irpf = CalcularIRPF(salarioBruto, inss);
            double descontoVT = (valeTransporte == "S") ? salarioBruto * 0.06 : 0.0;
            double salarioLiquido = salarioBruto - inss - irpf - descontoVT - outrasDeducoes;

            Console.WriteLine("\nCÁLCULO TRABALHISTA");
            Console.WriteLine($"Salário Bruto          R$ {salarioBruto:F2}");
            Console.WriteLine($"Desconto INSS          - R$ {inss:F2}");
            Console.WriteLine($"Desconto IRPF          - R$ {irpf:F2}");
            Console.WriteLine($"Desconto Vale Transporte - R$ {descontoVT:F2}");
            Console.WriteLine($"Outras Deduções        - R$ {outrasDeducoes:F2}");
            Console.WriteLine($"Salário Líquido        R$ {salarioLiquido:F2}");
            Console.WriteLine("\n-----------------------------\n");
        }
    }

    static double CalcularINSS(double salario)
    {
        double total = 0;

        if (salario > 0)
        {
            if (salario > 3856.94)
                total += (salario > 7507.49 ? 7507.49 : salario - 3856.94) * 0.14;
            if (salario > 2571.30)
                total += (salario > 3856.94 ? 1285.64 : salario - 2571.30) * 0.12;
            if (salario > 1320.00)
                total += (salario > 2571.30 ? 1251.30 : salario - 1320.00) * 0.09;
            if (salario > 0)
                total += (salario > 1320.00 ? 1320.00 : salario) * 0.075;
        }

        return total;
    }

    static double CalcularIRPF(double salario, double inss)
    {
        double baseCalculo = salario - inss;
        double imposto = 0;

        if (baseCalculo <= 2112.00)
        {
            imposto = 0;
        }
        else if (baseCalculo <= 2826.65)
        {
            imposto = baseCalculo * 0.075 - 158.40;
        }
        else if (baseCalculo <= 3751.05)
        {
            imposto = baseCalculo * 0.15 - 370.40;
        }
        else if (baseCalculo <= 4664.68)
        {
            imposto = baseCalculo * 0.225 - 651.73;
        }
        else
        {
            imposto = baseCalculo * 0.275 - 884.96;
        }

        return imposto < 0 ? 0 : imposto;
    }
}
