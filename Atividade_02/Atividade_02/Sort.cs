using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade_02
{
    internal class Sort
    {
        private static void Swap<T>(List<T> lista, int index1, int index2)
        {
            T aux = lista[index1];
            lista[index1] = lista[index2];
            lista[index2] = aux;
        }
        public static void Merge<T>(List<T> lista, Func<T, T, bool> compare)
        {
            // Caso a lista for menor que 2 elementos, não irá executar a função inteiramente.
            if (lista.Count <= 1)
            {
                return;
            }
            // Variáveis para irmos divindo a lista inicial.
            int metadeLista = lista.Count / 2;

            List<T> listaEsq = new List<T>();
            List<T> listaDir = new List<T>();

            Console.WriteLine("Separando a lista");
            // Adiciona os elementos da lista ESQUERDA até o limite definido -> (metadeLista).
            for (int i = 0; i < metadeLista; i++)
            {
                listaEsq.Insert(i, lista[i]); // Coloca o elemento da lista na lista esquerda.
            }
            Print.fim();

            // Adiciona os elementos da lista DIREITA até o limite definido -> (lista.Count - metadeLista).
            for (int i = 0; i < lista.Count - metadeLista; i++)
            {
                listaDir.Insert(i, lista[i + metadeLista]); // Coloca o elemento da lista na lista direita.
            }
            Print.fim();

            // Divide as listas até termos listas com apenas 1 elemento.
            Merge(listaEsq, compare);
            Merge(listaDir, compare);

            // Verifica todos os elementos, agora divididos, para colocarmos em ordem.
            int indFinal = 0; // Indíce da lista final para podermos avançar e adicionar os elementos ordenados.

            int indEsq = 0; // Indíce da lista esquerda para podermos avançar entre a lista esquerda sem perder o último elemento da listaDir.
            int indDir = 0; // Indíce da lista direita para podermos avançar entre a lista direita sem perder o último elemento da listaEsq.

            // Enquanto os indíces das listas esquerda e direita forem menores que o tamanho das listas, iremos comparar os elementos.
            while (indEsq < listaEsq.Count && indDir < listaDir.Count)
            {
                // Comparamos elementos das 2 listas para colocar na lista completa.
                if (compare(listaEsq[indEsq], listaDir[indDir])) // Se o elemento da lista esquerda for menor, irá colocar ela no início da lista final e iremos passar para o próximo elemento da lista ESQUERDA.
                { lista[indFinal] = listaEsq[indEsq++]; }
                else // Se não, irá colocar o elemento da lista DIREITA na lista final e passaremos para o próximo elemento da lista DIREITA.
                { lista[indFinal] = listaDir[indDir++]; }
                indFinal++;
            }

            // Por fim, copiamos quaisquer elementos restantes que "sobraram" nas duas partes
            while (indEsq < listaEsq.Count)
            {
                lista[indFinal++] = listaEsq[indEsq++];
            }
            while (indDir < listaDir.Count)
            {
                lista[indFinal++] = listaDir[indDir++];
            }
        }

        public static void Quick<T>(List<T> lista, int inicio, int fim, Func<T, T, bool> compare)
        {
            // Mesma lógica do Merge Sort, onde quando uma lista tiver apenas 1 elemento, irémos parar de ordernar.
            if (inicio >= fim)
            {
                return;
            }

            // O pivô é selecionado através do cálculo inicio + fim / 2, pois daí irémos levar em consideração a diferença entre posição
            // dos elementos de um array comparado com o tamanho do array.
            int meio = (inicio + fim) / 2; 
            T pivo = lista[meio];

            // Cria um valor para mantermos a organização de qual elemento de cada lado da lista estamos verificando.
            int i = inicio;
            int j = fim;

            while (i <= j)
            {
                // Encontra elemento maior ou igual ao pivô pela esquerda
                while (compare(lista[i], pivo))
                    i++;

                // Encontra elemento menor que o pivô pela direita
                while (compare(pivo, lista[j]))
                    j--;

                // Se encontrou dois elementos fora de ordem, troca eles de lugar com a função Swap
                if (i <= j)
                {
                    Swap(lista, i, j);
                    i++;
                    j--;
                }
            }

            // Depois de fazer o Sort, verifica se os elementos iniciais (i e j) estão na posição correta, e faz com que começemos o Quick
            // Sort em uma posição diferente.
            if (inicio < j)
                Quick(lista, inicio, j, compare);
            if (i < fim)
                Quick(lista, i, fim, compare);
        }

        public static void Selection<T>(List <T> lista, Func<T, T, bool> compare)
        {
            for (int i = 0; i < lista.Count - 1; i++)
            {
                // Primeiro selecionamos o menor ou maior valor usando a função de comparação
                int selected = i;
                for (int j = i + 1; j < lista.Count; j++)
                {
                    if (compare(lista[j], lista[selected]))
                    {
                        selected = j;
                    }
                }

                // Depois, apenas fazendo a troca dos elementos, até "empurrarmos" todos os elementos menores do valor selecionado
                // para a esquerda.
                Swap(lista, i, selected);
            }
        }

        public static void Selection<T>(List <T> lista) where T : IComparable
        {
            Selection(lista, (a, b) => a.CompareTo(b) < 0);
        }
    }
}