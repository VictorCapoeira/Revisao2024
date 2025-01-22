// See https://aka.ms/new-console-template for more information
Console.WriteLine("Gerador de senhas!");
Console.WriteLine("Insira o tamanho da senha: ");
while(!(int.TryParse(Console.ReadLine(), out int resultado))){
    Console.WriteLine("Insira um valor válido! Somente números inteiros!");
}
