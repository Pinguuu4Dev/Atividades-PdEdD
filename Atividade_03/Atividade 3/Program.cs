using Atividade_3;

const string WikiFile = "wiki.txt";
const string LogFile = "log.txt";

// Failsafe para caso os arquivos não estejam no diretório certo
if (!File.Exists(WikiFile) || !File.Exists(LogFile))
{
    Console.WriteLine($"Os arquivos {WikiFile} e {LogFile} devem estar no diretório da aplicação.");
    return;
}

// Cria a árvore das páginas do wiki, e depois verifica quais foram mais visitadas através da função BrowseWiki.
var pages = PageManager.CreateWiki(WikiFile);
PageManager.BrowseWiki(LogFile, pages);

Console.WriteLine(PageManager.GetPageVisits(pages, "Monsters") + "\n" + PageManager.GetPageVisits(pages, "Cards"));
