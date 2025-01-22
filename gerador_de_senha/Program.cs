// See https://aka.ms/new-console-template for more information
string senha_numero_vef;
string senha_letras_vef;
string senha_especiais_vef;
string [][] padroes = {
    new string[] {"0","1","2","3","4","5","6","7","8","9"},
    new string[] {"A","a","B","b","C","c","D","d","E","e","F","f","G","g","H","h","I","i","J","j","K","k","L","l","M","m","N","n","O","o","P","p","Q","q","R","r","S","s","T","t","U","u","V","v","W","w","X","x","Y","y","Z","z"},
    new string[] {"!","@","#","$","%","&","*","/","?",".",","}
};
int tamanho_senha;
Random random = new Random();
int random_now;

Console.WriteLine("Gerador de senhas!");
Console.WriteLine("Insira o tamanho da senha: ");
while(!(int.TryParse(Console.ReadLine(), out tamanho_senha))){
    Console.WriteLine("Insira um valor válido! Somente números inteiros!");
}
Console.Clear();
Console.WriteLine("Informe se deseja números nas senha (S ou N): ");
do{
    senha_numero_vef = Console.ReadLine().ToLower();
    if(senha_numero_vef != "s" && senha_numero_vef != "n"  )
        Console.WriteLine("Informe um reposta válida! (somente S ou N)");
}while(senha_numero_vef != "s" && senha_numero_vef != "n"  );

Console.Clear();
Console.WriteLine("Informe se deseja letras nas senha (S ou N): ");
do{
    senha_letras_vef = Console.ReadLine().ToLower();
    if(senha_letras_vef != "s" && senha_letras_vef != "n"  )
        Console.WriteLine("Informe um reposta válida! (somente S ou N)");
}while(senha_letras_vef != "s" && senha_letras_vef != "n"  );
Console.Clear();
Console.WriteLine("Informe se deseja caracteres especiais nas senha (S ou N): ");

do{
    senha_especiais_vef = Console.ReadLine().ToLower();
    if(senha_especiais_vef != "s" && senha_especiais_vef != "n"  )
        Console.WriteLine("Informe um reposta válida! (somente S ou N)");
}while(senha_especiais_vef != "s" && senha_especiais_vef != "n"  );
Console.Clear();

String[] senha = new String[tamanho_senha];

for(int i = 0; i <= tamanho_senha; i++){
    if(senha_numero_vef == "s" && senha_letras_vef == "n" && senha_especiais_vef == "n"){
        senha[i] = padroes[0][random.Next(0, padroes[0].Length)];
    }
    if(senha_numero_vef == "n" && senha_letras_vef == "s" && senha_especiais_vef == "n"){
        senha[i] = padroes[1][random.Next(0, padroes[1].Length)];
    }
    if(senha_numero_vef == "n" && senha_letras_vef == "n" && senha_especiais_vef == "s"){
        senha[i] = padroes[2][random.Next(0, padroes[2].Length)];
    }
    if(senha_numero_vef == "s" && senha_letras_vef == "s" && senha_especiais_vef == "n"){
        switch(random.Next(0,1)){
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
    if(senha_numero_vef == "s" && senha_letras_vef == "n" && senha_especiais_vef == "s"){
        random_now = random.Next(0,2);
        while(random_now == 1){
            random_now = random.Next(0,2);
        }
        switch(random_now){
            case 0:
                senha[i] = padroes[0][random.Next(0, padroes[0].Length)];
                break;
            case 2:
                senha[i] = padroes[2][random.Next(0, padroes[2].Length)];
                break;
            default:
                Console.WriteLine("Error!");
                break;
            }  
    }
    if(senha_numero_vef == "n" && senha_letras_vef == "s" && senha_especiais_vef == "s"){
        switch(random.Next(1,2)){
            case 1:
                senha[i] = padroes[1][random.Next(0, padroes[1].Length)];
                break;
            case 2:
                senha[i] = padroes[2][random.Next(0, padroes[2].Length)];
                break;
            default:
                Console.WriteLine("Error!");
                break;
            }   
    }
    if(senha_numero_vef == "s" && senha_letras_vef == "s" && senha_especiais_vef == "s"){
        switch(random.Next(0,2)){
            case 0:
                senha[i] = padroes[0][random.Next(0, padroes[0].Length)];
                break;
            case 1:
                senha[i] = padroes[1][random.Next(0, padroes[1].Length)];
                break;
            case 2:
                senha[i] = padroes[2][random.Next(0, padroes[2].Length)];
                break;
            default:
                Console.WriteLine("Error!");
                break;
            }   
    }
}


