﻿using System;
using System.IO;

// See https://aka.ms/new-console-template for more information
string senha_numero_vef;
string senha_letras_vef;
string senha_especiais_vef;
string[][] padroes = {
    new string[] {"0","1","2","3","4","5","6","7","8","9"},
    new string[] {"A","a","B","b","C","c","D","d","E","e","F","f","G","g","H","h","I","i","J","j","K","k","L","l","M","m","N","n","O","o","P","p","Q","q","R","r","S","s","T","t","U","u","V","v","W","w","X","x","Y","y","Z","z"},
    new string[] {"!","@","#","$","%","&","*","/","?",".",","}
};
int tamanho_senha;
Random random = new Random();
int random_now;
int quantidade_caracteres_especiais = 0;
int limite_caracteres_especiais = 0;
string caminhoArquivo = "bkp.txt";


Console.WriteLine("Gerador de senhas!");
Console.WriteLine("Insira o tamanho da senha: ");
while (!(int.TryParse(Console.ReadLine(), out tamanho_senha)))
{
    Console.WriteLine("Insira um valor válido! Somente números inteiros!");
}
Console.Clear();
Console.WriteLine("Informe se deseja números nas senha (S ou N): ");
do
{
    senha_numero_vef = Console.ReadLine().ToLower();
    if (senha_numero_vef != "s" && senha_numero_vef != "n")
        Console.WriteLine("Informe um reposta válida! (somente S ou N)");
} while (senha_numero_vef != "s" && senha_numero_vef != "n");

Console.Clear();
Console.WriteLine("Informe se deseja letras nas senha (S ou N): ");
do
{
    senha_letras_vef = Console.ReadLine().ToLower();
    if (senha_letras_vef != "s" && senha_letras_vef != "n")
        Console.WriteLine("Informe um reposta válida! (somente S ou N)");
} while (senha_letras_vef != "s" && senha_letras_vef != "n");
Console.Clear();

Console.WriteLine("Informe se deseja caracteres especiais nas senha (S ou N): ");
do
{
    senha_especiais_vef = Console.ReadLine().ToLower();
    if (senha_especiais_vef != "s" && senha_especiais_vef != "n")
        Console.WriteLine("Informe um reposta válida! (somente S ou N)");
} while (senha_especiais_vef != "s" && senha_especiais_vef != "n");
Console.Clear();
if (senha_especiais_vef == "s")
{
    Console.WriteLine("Informe a quantidade máxima de caracteres especiais que deseja: ");
    do
    {
        quantidade_caracteres_especiais = int.Parse(Console.ReadLine());
        if (quantidade_caracteres_especiais > tamanho_senha)
        {
            Console.WriteLine("Informe um valor menor que o tamanho da senha!");
        }

    } while (quantidade_caracteres_especiais > tamanho_senha);

}
Console.Clear();

String[] senha = new String[tamanho_senha];

for (int i = 0; i < tamanho_senha; i++)
{
    if (senha_numero_vef == "s" && senha_letras_vef == "n" && senha_especiais_vef == "n")
    {
        senha[i] = padroes[0][random.Next(0, padroes[0].Length)];
    }
    if (senha_numero_vef == "n" && senha_letras_vef == "s" && senha_especiais_vef == "n")
    {
        senha[i] = padroes[1][random.Next(0, padroes[1].Length)];
    }
    if (senha_numero_vef == "n" && senha_letras_vef == "n" && senha_especiais_vef == "s")
    {
        senha[i] = padroes[2][random.Next(0, padroes[2].Length)];
    }
    if (senha_numero_vef == "s" && senha_letras_vef == "s" && senha_especiais_vef == "n")
    {
        switch (random.Next(0, 2))
        {
            case 0:
                senha[i] = padroes[0][random.Next(0, padroes[0].Length)];
                break;
            case 1:
                senha[i] = padroes[1][random.Next(0, padroes[1].Length)];
                break;
            default:
                Console.WriteLine("Error!");
                break;
        }
    }
    if (senha_numero_vef == "s" && senha_letras_vef == "n" && senha_especiais_vef == "s")
    {
        random_now = random.Next(0, 3);
        while (random_now == 1)
        {
            random_now = random.Next(0, 3);
        }
        if (limite_caracteres_especiais < quantidade_caracteres_especiais)
        {
            switch (random_now)
            {
                case 0:
                    senha[i] = padroes[0][random.Next(0, padroes[0].Length)];
                    break;
                case 2:
                    senha[i] = padroes[2][random.Next(0, padroes[2].Length)];
                    limite_caracteres_especiais++;
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
        }
        else
        {
            senha[i] = padroes[0][random.Next(0, padroes[0].Length)];
        }

    }
    if (senha_numero_vef == "n" && senha_letras_vef == "s" && senha_especiais_vef == "s")
    {
        if (limite_caracteres_especiais < quantidade_caracteres_especiais)
        {
            switch (random.Next(1, 3))
            {
                case 1:
                    senha[i] = padroes[1][random.Next(0, padroes[1].Length)];
                    break;
                case 2:
                    senha[i] = padroes[2][random.Next(0, padroes[2].Length)];
                    limite_caracteres_especiais++;
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
        }
        else
        {
            senha[i] = padroes[1][random.Next(0, padroes[1].Length)];
        }

    }
    if (senha_numero_vef == "s" && senha_letras_vef == "s" && senha_especiais_vef == "s")
    {
        if (limite_caracteres_especiais < quantidade_caracteres_especiais)
        {
            switch (random.Next(0, 3))
            {
                case 0:
                    senha[i] = padroes[0][random.Next(0, padroes[0].Length)];
                    break;
                case 1:
                    senha[i] = padroes[1][random.Next(0, padroes[1].Length)];
                    break;
                case 2:
                    senha[i] = padroes[2][random.Next(0, padroes[2].Length)];
                    limite_caracteres_especiais++;
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
        }
        else
        {
            switch (random.Next(0, 3))
            {
                case 0:
                    senha[i] = padroes[0][random.Next(0, padroes[0].Length)];
                    break;
                case 1:
                    senha[i] = padroes[1][random.Next(0, padroes[1].Length)];
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
        }
    }
}
Console.Clear();
Console.Write("Senha gerada e salva em arquivo: ");
for (int i = 0; i < senha.Length; i++)
{
    Console.Write(senha[i]);
}
string senha_gerada = string.Join("",senha);
File.AppendAllText(caminhoArquivo, senha_gerada + Environment.NewLine);
