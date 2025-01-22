// See https://aka.ms/new-console-template for more information
string senha_numero_vef;
string senha_letras_vef;
Console.WriteLine("Gerador de senhas!");
Console.WriteLine("Insira o tamanho da senha: ");
while(!(int.TryParse(Console.ReadLine(), out int resultado))){
    Console.WriteLine("Insira um valor válido! Somente números inteiros!");
}
Console.WriteLine("Informe se deseja números nas senha (S ou N): ");
do{
    senha_numero_vef = Console.ReadLine();
    if(senha_numero_vef != "s" && senha_numero_vef != "s" && senha_numero_vef != "N" && senha_numero_vef != "n"  )
        Console.WriteLine("Informe um reposta válida! (somente S ou N)");
}while(senha_numero_vef != "s" && senha_numero_vef != "s" && senha_numero_vef != "N" && senha_numero_vef != "n"  );
Console.WriteLine("Informe se deseja letras nas senha (S ou N): ");
do{
    senha_letras_vef = Console.ReadLine();
    if(senha_numero_vef != "s" && senha_numero_vef != "s" && senha_numero_vef != "N" && senha_numero_vef != "n"  )
        Console.WriteLine("Informe um reposta válida! (somente S ou N)");
}while(senha_numero_vef != "s" && senha_numero_vef != "s" && senha_numero_vef != "N" && senha_numero_vef != "n"  );