using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_04
{
    internal static class Rede
    {
        public static List<User>? users = new List<User>();
        public static int indiceUsuarios = 0;


        public static void AdicionarUsuario(User user)
        {
            users?.Add(user);
            IncrementarIndice();
        }

        public static User ProcurarPorIndice(int indice)
        {
            if (users != null) { 
                return users[indice]; 
            }
            else { 
                throw new InvalidDataException($"Não existem usuários para seguir."); 
            }
        }
        public static void NumeroContas() {
            int contasNaRede = users.Count;
            Console.WriteLine($"\nNossa rede social tem {contasNaRede} usuários e contando!"); ;
        }

        public static void IncrementarIndice() => indiceUsuarios++;

        public static User ContaMaisSeguidores()
        {
            User maiorConta = new User("Ninguém"); // <- Conta fictícia para comparação   

            if (users == null || users.Count == 0)
            {
                return maiorConta;
            }

            foreach (User u in users)
            {
                if (u.NumSeguidores() >= maiorConta.NumSeguidores())
                {
                    maiorConta = u;
                }
            }

            Console.WriteLine($"Conta com maior número de seguidores ({maiorConta.NumSeguidores()}): {maiorConta.Nome}.");
            return maiorConta;
        }
        public static void SeguindoDeVolta(User comparador)
        {
            int numSeguindoDeVolta = 0;
            foreach (User u in comparador.Seguidores)
            {
                if (u.Seguidores.Contains(comparador))
                {
                    numSeguindoDeVolta++;
                }
            }

            Console.WriteLine($"Contas seguidas de volta pela maior conta na rede: {numSeguindoDeVolta}.");
        }
    }
}
