using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_04
{
    internal class Rede
    {
        public static List<User>? users = new List<User>();
        public static int indiceUsuarios = 0;


        public static void AdicionarUsuario(User user)
        {
            if (users == null)
            {
                users = new List<User>();
            }

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
        public static int numeroContas() => users.Count;

        public static void IncrementarIndice() => indiceUsuarios++;

        public static User contaMaisSeguidores()
        {
            User conta = new User("Ninguém");

            if (users == null || users.Count == 0)
            {
                return conta;
            }

            foreach (User u in users)
            {
                if (u.NumSeguidores() >= conta.NumSeguidores())
                {
                    conta = u;
                }
            }

            return conta;
        }

        public static int seguindoDeVolta(User conta)
        {
            int seguidasDeVolta = 0;

            foreach (User u in conta.Seguidores)
            {
                if (u.Seguidores.Contains(conta))
                {
                    seguidasDeVolta++;
                }
            }

            return seguidasDeVolta;
        }
    }
}
