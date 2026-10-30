using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade_3
{
    internal static class PageManager
    {
        public static Dictionary<string, Page> CreateWiki(string fileName)
        {
            var pages = new Dictionary<string, Page>(StringComparer.OrdinalIgnoreCase);
            Page currentLevel1 = null;
            Page currentLevel2 = null;

            foreach (string line in File.ReadLines(fileName))
            {
                string trimmedLine = line.Trim();
                if (trimmedLine.Length == 0)
                {
                    continue;
                }

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
                else if (dotCount == 1) {
                    // Categorias com apenas 1 ponto (.Monsters, .Cards)
                    newPage.Parent = pages.ContainsKey("Home") ? pages["Home"] : null;
                    currentLevel1 = newPage;
                    currentLevel2 = null;
                } 
                else if (dotCount == 2) 
                {
                    // Categorias com 2 pontos (..Dune Dome, ..Glacial Library)
                    newPage.Parent = currentLevel1;
                    currentLevel2 = newPage;
                }
                else
                {
                    newPage.Parent = currentLevel2;
                }

                Console.WriteLine($"Nome: {newPage.Name}, Pai: {newPage.Parent?.Name ?? "Nenhum"}");
            }

            if (!pages.ContainsKey("Home"))
            {
                throw new FormatException("O wiki.txt deve conter a página Home.");
            }

            return pages;
        }

    }
}
