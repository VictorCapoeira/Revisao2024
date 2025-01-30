using System;
using System.IO;
using System.Text;
using Classes;
// See https://aka.ms/new-console-template for more information
string user = "";
string pass = "";
string action = "";
string rotulo = "";
string rotulo_vef;
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

do
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("=====================================");
    Console.WriteLine("        SISTEMA DE LOGIN          ");
    Console.WriteLine("=====================================");
    Console.ResetColor();

    Console.Write("Informe o user: ");
    user = Console.ReadLine();
    Console.Write("Informe a senha: ");
    pass = Console.ReadLine();
    if (user != "Isaac" || pass != "12345")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nUsuário ou senha inválidos! Tente novamente.");
        Console.ResetColor();
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
} while (user != "Isaac" || pass != "12345");

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\nLogin bem-sucedido! Bem-vindo, " + user + "!");
Console.ResetColor();
Console.WriteLine("\nPressione qualquer tecla para continuar...");
Console.ReadKey();
do
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("=====================================");
    Console.WriteLine("      GERENCIADOR DE SENHAS    ");
    Console.WriteLine("=====================================");
    Console.ResetColor();


    Console.WriteLine("\nEscolha uma opção:\n");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("  [1] -> Criar uma senha");
    Console.WriteLine("  [2] -> Listar senhas");
    Console.WriteLine("  [3] -> Sair");
    Console.ResetColor();

    Console.Write("\n-> Opção: ");
    action = Console.ReadLine();


    switch (action)
    {
        case "1":
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=====================================");
            Console.WriteLine("        CRIAÇÃO DE SENHAS SEGURAS     ");
            Console.WriteLine("=====================================");
            Console.ResetColor();

            Console.WriteLine("Insira o tamanho da senha: ");
            while (!(int.TryParse(Console.ReadLine(), out tamanho_senha)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insira um número válido maior que 0 ou um valor válido!");
                Console.ResetColor();
                Console.Write("\nInsira o tamanho da senha: ");
            }
            Console.Clear();
            Console.WriteLine("Informe se deseja números nas senha (S/N): ");
            do
            {
                senha_numero_vef = Console.ReadLine().ToLower();
                if (senha_numero_vef != "s" && senha_numero_vef != "n")
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Informe uma reposta válida! (S/N)");
                Console.ResetColor();
            } while (senha_numero_vef != "s" && senha_numero_vef != "n");

            Console.Clear();
            Console.WriteLine("Informe se deseja letras nas senha (S/N): ");
            do
            {
                senha_letras_vef = Console.ReadLine().ToLower();
                if (senha_letras_vef != "s" && senha_letras_vef != "n")
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Informe uma reposta válida! (S/N)");
                Console.ResetColor();
            } while (senha_letras_vef != "s" && senha_letras_vef != "n");
            Console.Clear();

            Console.WriteLine("Informe se deseja caracteres especiais nas senha (S/N): ");
            do
            {
                senha_especiais_vef = Console.ReadLine().ToLower();
                if (senha_especiais_vef != "s" && senha_especiais_vef != "n")
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Informe uma reposta válida! (S/N)");
                Console.ResetColor();
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
            string senha_gerada = string.Join("", senha);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSenha gerada com sucesso!");
            Console.WriteLine("Sua senha: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{senha_gerada}");
            Console.ResetColor();

            Console.WriteLine("Deseja adicionar um rotulo a essa senha? (S/N)");
            rotulo_vef = Console.ReadLine().ToLower();
            if (rotulo_vef == "s")
            {
                Console.WriteLine("Nome do rotulo: ");
                rotulo = Console.ReadLine();
                senha_gerada = rotulo + ": " + senha_gerada;
            }
            File.AppendAllText(caminhoArquivo, senha_gerada + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Senha salva com sucesso!");
            Console.ResetColor();
            Console.WriteLine("Pressione enter para continuar!");
            Console.ReadKey();
            break;
        case "2":
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=====================================");
            Console.WriteLine("         LISTAGEM DE SENHAS           ");
            Console.WriteLine("=====================================");
            Console.ResetColor();
            
            if (File.Exists(caminhoArquivo))
            {
                string[] senhasSalvas = File.ReadAllLines(caminhoArquivo);
                if (senhasSalvas.Length > 0)
                {   
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Senhas salvas:");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    foreach (string senhas in senhasSalvas)
                    {
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("- " + senhas);
                        Console.WriteLine("----------------------------------------");
                    }
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Nenhuma senha salva ainda.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Arquivo de senhas não encontrado.");
                Console.ResetColor();
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            break;
        case "3":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Obrigado por utilizar o programa.");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n Volte sempre que precisar gerar ou visualizar suas senhas!");
            Console.ResetColor();
            Console.WriteLine("\nAté logo!\n");
            break;
    }
} while (action != "3");

