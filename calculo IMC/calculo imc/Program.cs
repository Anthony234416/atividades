using System;

class CalculoIMC
{
    static void Main()
    {
        // Entrada de dados
        Console.Write("Digite o nome: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o sexo (m/f): ");
        string sexo = Console.ReadLine().ToLower();

        Console.Write("Digite o peso (kg): ");
        double peso = double.Parse(Console.ReadLine());

        Console.Write("Digite a altura (m): ");
        double altura = double.Parse(Console.ReadLine());

        // Cálculo do IMC
        double imc = peso / (altura * altura);

        // Determinação da condição
        string condicao = ClassificarCondicao(imc, sexo);

        // Peso ideal para faixa "normal"
        (double pesoMin, double pesoMax) = PesoIdeal(altura, sexo);

        // Exibição de resultados
        Console.WriteLine($"\nNome: {nome}");
        Console.WriteLine($"IMC: {imc:F2}");
        Console.WriteLine($"Condição: {condicao}");

        if (condicao != "no peso normal")
        {
            if (peso < pesoMin)
                Console.WriteLine($"Você precisa GANHAR pelo menos {(pesoMin - peso):F2} kg para atingir o peso normal.");
            else if (peso > pesoMax)
                Console.WriteLine($"Você precisa PERDER pelo menos {(peso - pesoMax):F2} kg para atingir o peso normal.");
        }
    }

    static string ClassificarCondicao(double imc, string sexo)
    {
        if (sexo == "f")
        {
            if (imc < 19.1) return "abaixo do peso";
            else if (imc <= 25.8) return "no peso normal";
            else if (imc <= 27.3) return "marginalmente acima do peso";
            else if (imc <= 32.3) return "acima do peso ideal";
            else return "obeso";
        }
        else if (sexo == "m")
        {
            if (imc < 20.7) return "abaixo do peso";
            else if (imc <= 26.4) return "no peso normal";
            else if (imc <= 27.8) return "marginalmente acima do peso";
            else if (imc <= 31.1) return "acima do peso ideal";
            else return "obeso";
        }
        else
        {
            return "sexo inválido";
        }
    }

    static (double, double) PesoIdeal(double altura, string sexo)
    {
        double imcMin, imcMax;

        if (sexo == "f")
        {
            imcMin = 19.1;
            imcMax = 25.8;
        }
        else // masculino
        {
            imcMin = 20.7;
            imcMax = 26.4;
        }

        double pesoMin = imcMin * altura * altura;
        double pesoMax = imcMax * altura * altura;
        return (pesoMin, pesoMax);
    }
}
