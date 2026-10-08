using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Atividade_02
{
    internal class Print
    {
        private const string DIVISOR = " ---------------------------------------------------------------------- ";
        public static void divisor()
        {
            Console.WriteLine(DIVISOR);
        }
        public static void inicio(string lista)
        {
            divisor();
            Console.WriteLine($" -> Lista {lista}:");
        }
        public static void elemento(string elemento)
        {
            Console.WriteLine($" -> {elemento}");
        }
        public static void fim()
        {
            divisor();
        }

        public static void listaInteira<T>(List<T> lista, string titulo)
        {
            Console.WriteLine($"--------------- Lista {titulo} ----------------");
            foreach (T arma in lista) {
                Console.WriteLine((arma as Armas)?.getValores());
            }
            divisor();
        }

        public static void msgCriterio()
        {
            Console.WriteLine("----- Favor escolha uma das opções ----- ");
            Console.WriteLine(" 1 - Ordenar por ordem alfabética ");
            Console.WriteLine(" 2 - Ordenar por raridade ");
            Console.WriteLine(" 3 - Ordenar por dano ");
            Console.WriteLine("");
        }

        public static void msgAlgoritmo()
        {
            Console.WriteLine("----- Favor escolha uma das opções ----- ");
            Console.WriteLine(" 1 - Utilizar Merge Sort ");
            Console.WriteLine(" 2 - Utilizar Quick Sort ");
            Console.WriteLine(" 3 - Utilizar Selection ");
            Console.WriteLine("");
        }

        public static void finalizado_sort()
        {
            Console.WriteLine("Sort concluido");
        }
    }
}
