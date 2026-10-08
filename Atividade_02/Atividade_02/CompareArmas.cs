using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade_02
{
    internal class CompareArmas
    {
        public static bool Nome(Armas arma_1, Armas arma_2)
        {
            return arma_1.getNome().CompareTo(arma_2.getNome()) < 0;
        }

        public static bool Raridade(Armas arma_1, Armas arma_2)
        {
            return arma_1.getRaridade() < arma_2.getRaridade();
        }

        public static bool Dano(Armas arma_1, Armas arma_2)
        {
            return arma_1.getDano() < arma_2.getDano();
        }
    }
}
