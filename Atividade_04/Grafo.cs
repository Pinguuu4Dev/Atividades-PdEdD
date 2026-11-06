using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_04
{
    internal class Grafo
    {
        List<Usuario> usuarios = new List<Usuario>();

        /*
         * Cada usuário que for criado precisa ser adicionado ao grafo main para podermos chamar as conexões de seguidores
         * mais facilmente e fazermos funções para contar seguidores e que calcula quais das contas seguidas seguem de volta
         * tal conta que as seguem:
         *      1. static Seguidores() -> seguidores.Count()
         *      
         *      2. static ContasSeguidasDeVolta() { 
         *          contasSeguemDeVolta = 0;
         *          foreach(Usuario user in seguidores) {
         *              if (user.Seguindo.Contains(self)) {
         *                 contasSeguemDeVolta++;
         *              }
         *          }
         *          return contasSeguemDeVolta;
         *      }
        */

    }
}
