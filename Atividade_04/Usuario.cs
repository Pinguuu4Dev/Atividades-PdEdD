using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_04
{
    internal class Usuario
    {
        string Nome;
        int Indice;
        List<Usuario> ContasSeguidoras = new List<Usuario>(); // <- Contas que seguem o usuário
        List<Usuario> ContasSeguindo = new List<Usuario>(); // <- Contas que o usuário segue

        /*
         * Toda vez que um usuário for criado, ele precisa ter o seu indíce de acordo com a ordem que foi criado:
         *      1. static CreateNewUser -> indice++;
        */ 

        /* 
         * Cada usuário precisa de ter um método de conexão a outros usuários, fazendo possível uma conexão quando as duas
         * contas se seguem ou param de seguir:
         * 
         *      1. public Follow -> seguindo.Add(user; user.Seguidores.Add(self))
         *      
         *      2. public Unfollow -> seguindo.Remove(user.Seguidores.Remove(self); user)
        */

    }
}
