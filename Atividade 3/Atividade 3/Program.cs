using Atividade_3;

const string WikiFile = "wiki.txt";
const string LogFile = "log.txt";

if (!File.Exists(WikiFile) || !File.Exists(LogFile))
{
    Console.WriteLine($"Os arquivos {WikiFile} e {LogFile} devem estar no diretório da aplicação.");
    return;
}

var pages = PageManager.CreateWiki(WikiFile);
