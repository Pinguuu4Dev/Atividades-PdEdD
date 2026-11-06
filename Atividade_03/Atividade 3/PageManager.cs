using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade_3
{
    internal static class PageManager
    {
        // Transforma cada página do "wiki.txt" em um objeto Page e organiza a hierarquia.
        public static Dictionary<string, Page> CreateWiki(string fileName)
        {
            // Faz com que cada nome da página seja acessível independente de maiúsculas ou minúsculas.
            var pages = new Dictionary<string, Page>(StringComparer.OrdinalIgnoreCase);

            // Cria os níveis que estamos verificando para poder dizer quem é pai de cada página.
            Page currentLevel1 = null;
            Page currentLevel2 = null;

            // Verifica cada linha, cria uma página e diz a hierarquia de tal.
            foreach (string line in File.ReadLines(fileName))
            {
                // Apenas formatando as linhas para não ter problemas com espaços em branco.
                string trimmedLine = line.Trim();
                if (trimmedLine.Length == 0)
                {
                    continue;
                }

                // Faz a contagem de pontos no início da linha para determinar o nível da página.
                int dotCount = 0;
                while (dotCount < trimmedLine.Length && trimmedLine[dotCount] == '.')
                {
                    dotCount++;
                }
                string pageName = trimmedLine.Substring(dotCount);

                Page newPage = new Page(pageName);
                pages.Add(newPage.Name, newPage);

                // Verificando nível da página, iniciando com Home
                if (dotCount == 0)
                {
                    currentLevel1 = newPage;
                    currentLevel2 = null;
                }
                else if (dotCount == 1)
                {
                    // Categorias com apenas 1 ponto (.Monsters, .Cards)
                    newPage.Parent = pages.ContainsKey("Home") ? pages["Home"] : null;
                    currentLevel1 = newPage;
                    newPage.Parent.Children.Add(pages[newPage.Name]);
                    currentLevel2 = null;
                }
                else if (dotCount == 2)
                {
                    // Categorias com 2 pontos (..Dune Dome, ..Glacial Library)
                    newPage.Parent = currentLevel1;
                    currentLevel1.Children.Add(pages[newPage.Name]);
                    currentLevel2 = newPage;
                }
                else
                {
                    // Como páginas a partir de 3 pontos não tem filhos, não precisa verificar ou guardar como um nível de verificação.
                    newPage.Parent = currentLevel2;
                    currentLevel2.Children.Add(pages[newPage.Name]);
                }
            }

            // Failsafe caso não exista Home para ser a página inicial.
            if (!pages.ContainsKey("Home"))
            {
                throw new FormatException("O wiki.txt deve conter a página Home.");
            }

            return pages;
        }

        // Lê cada input que o usuário deu em "log.txt" para dizer qual página foi visitada.
        public static void BrowseWiki(string fileName, Dictionary<string, Page> pages)
        {
            foreach (var line in File.ReadLines(fileName))
            {
                var currentPage = pages["Home"];

                foreach (var action in line.Trim())
                {
                    if (action == 'b')
                    {
                        Console.WriteLine($"Ação: {action} -> Página: {currentPage.Parent?.Name ?? "Nenhum"}");
                        if (currentPage?.Parent is not null)
                        {
                            currentPage = currentPage.Parent;
                            currentPage.Visits++;
                        }

                        continue;
                    }

                    else if (char.IsDigit(action) && action - '0' < currentPage.Children.Count)
                    {
                        Console.WriteLine($"Ação: {action} -> Página: {currentPage.Children[action - '0'].Name}");
                        currentPage = currentPage.Children[action - '0'];
                        currentPage.Visits++;
                    }
                }
            }
        }

        public static string GetPageVisits(Dictionary<string, Page> pages, string categoria)
        {
            int pageVisits = 0;
            string mostVisitedPage = string.Empty;
            foreach (var page in pages.Values)
            {
                if (page.Children.Count == 0)
                {
                    if (page.Parent.Parent.Name == categoria && page.Visits >= pageVisits)
                    {
                        pageVisits = page.Visits;
                        mostVisitedPage = page.Name;
                    }
                }
            }

            return $"Página mais visitada da categoria {categoria}: {mostVisitedPage}, Número de Visitas: {pageVisits}";
        }
    }
}
