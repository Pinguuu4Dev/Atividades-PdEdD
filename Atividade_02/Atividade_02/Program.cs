using System;
using System.IO;
using System.Collections.Generic;
using System.Timers;

namespace Atividade_02
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] weapons = File.ReadAllLines("./weapons.txt"); // Transforma o arquivo TXT em um string com as definições de cada arma (nome, raridade e dano).
            List<Armas> armas = new List<Armas>(); // Salva cada arma do TXT como um objeto nesta lista.

            Print.msgCriterio();
            int selCriterio = int.Parse(Console.ReadLine());
            Print.msgAlgoritmo();
            int selAlgoritmo = int.Parse(Console.ReadLine());

            Print.listaInteira(armas, "Desordenado");

            // Verifica as linhas do TXT de 3 em 3, por conta de a cada 3 linhas ter as deifnições das armas.
            for (int i = 0; i + 2 < weapons.Length; i += 3)
            {
                // Ao invés de precisar fazer contas para saber onde cada definição está, apenas fazemos o iterador 'i' pular os espaços com o incremento necessário, como 'i + 2'.
                armas.Add(new Armas(weapons[i], weapons[i + 1], int.Parse(weapons[i + 2])));
            }

            Func<Armas, Armas, bool> comparador = selCriterio switch
            {
                1 => (a, b) => CompareArmas.Nome(a, b),
                2 => (a, b) => CompareArmas.Raridade(a, b),
                3 => (a, b) => CompareArmas.Dano(a, b),
                _ => (a, b) => CompareArmas.Dano(a, b)
            };

            switch (selAlgoritmo)
            {
                case 1:
                    Sort.Merge(armas, comparador);
                    break;
                case 2:
                    Sort.Quick(armas, 0, armas.Count - 1, comparador);
                    break;
                _:
                    Sort.Merge(armas, comparador);
                    break;
            }

            Print.listaInteira(armas, "Ordenado");
        }
    }
}
