using System.Security.Cryptography;

namespace Classes
{
    public class Login
    {
        public string? user, pass;
        Dictionary<string, string> usuariosESenhas = new Dictionary<string, string>();
        public void Adicionar()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=====================================");
            Console.WriteLine("        SISTEMA DE CADASTRO         ");
            Console.WriteLine("=====================================");
            Console.ResetColor();
            Console.Write("Informe o user: ");
            user = Console.ReadLine();
            Console.Write("Informe a senha: ");
            pass = Console.ReadLine();
            R1:
            Console.Write("Informe o user: ");
            user = Verificar.Texto(Console.ReadLine(),"Erro");
            if(user==null)
            {
               goto R1;
            }
            R2:
            Console.Write("Informe a senha: ");
            pass = Verificar.Texto(Console.ReadLine(),"Erro");
            if(user==null)
            {
               goto R2;
            }
            usuariosESenhas.Add(user,pass);

        }
        public void Fazer()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=====================================");
            Console.WriteLine("        SISTEMA DE LOGIN          ");
            Console.WriteLine("=====================================");
            Console.ResetColor();

            R1:
            Console.Write("Informe o user: ");
            user = Verificar.Texto(Console.ReadLine(),"Erro");
            if(user==null)
            {
               goto R1;
            }
            R2:
            Console.Write("Informe a senha: ");
            pass = Verificar.Texto(Console.ReadLine(),"Erro");
            if(user==null)
            {
               goto R2;
            }
            if (usuariosESenhas.ContainsKey(user))
            {
                if (usuariosESenhas[user] != pass)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nUsuário ou senha inválidos! Tente novamente.");
                    Console.ResetColor();
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }

        }
    }
    public class Verificar
    {
        public static string Texto(string valor, string mensagem)
        {
            if(string.IsNullOrEmpty(valor))
            {   
                Console.WriteLine(mensagem);
                return null;
            }else
            {
                return valor;
            }
        }
    }
}