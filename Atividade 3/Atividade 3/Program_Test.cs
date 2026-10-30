const string WikiFile = "wiki.txt";
const string LogFile = "log.txt";

if (!File.Exists(WikiFile) || !File.Exists(LogFile))
{
    Console.WriteLine($"Os arquivos {WikiFile} e {LogFile} devem estar no diretório da aplicação.");
    return;
}

var pages = ReadWiki(WikiFile);
var visits = pages.Values.ToDictionary(page => page, _ => 0);

foreach (var line in File.ReadLines(LogFile))
{
    var currentPage = pages["Home"];

    foreach (var action in line.Trim())
    {
        if (action == 'b')
        {
            if (currentPage.Parent is not null)
            {
                currentPage = currentPage.Parent;
            }

            continue;
        }

        if (char.IsDigit(action) && action - '0' < currentPage.Children.Count)
        {
            currentPage = currentPage.Children[action - '0'];
            visits[currentPage]++;
        }
    }
}

static Dictionary<string, Page> ReadWiki(string fileName)
{
    var pages = new Dictionary<string, Page>(StringComparer.OrdinalIgnoreCase);

    foreach (var line in File.ReadLines(fileName))
    {
        var relation = line.Trim();
        if (relation.Length == 0)
        {
            continue;
        }

        var parts = relation.Contains("->", StringComparison.Ordinal)
            ? relation.Split("->", 2, StringSplitOptions.TrimEntries)
            : relation.Split(';', 2, StringSplitOptions.TrimEntries);

        if (parts.Length != 2)
        {
            throw new FormatException($"Relação inválida no wiki.txt: {line}");
        }

        var parent = GetPage(pages, parts[0]);
        var child = GetPage(pages, parts[1]);

        child.Parent = parent;
        parent.Children.Add(child);
    }

    if (!pages.ContainsKey("Home"))
    {
        throw new FormatException("O wiki.txt deve conter a página Home.");
    }

    return pages;
}

static Page GetPage(Dictionary<string, Page> pages, string name)
{
    if (!pages.TryGetValue(name, out var page))
    {
        page = new Page(name);
        pages.Add(name, page);
    }

    return page;
}



static bool IsDescendantOf(Page page, string categoryName)
{
    for (var parent = page.Parent; parent is not null; parent = parent.Parent)
    {
        if (parent.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
    }

    return false;
}

sealed class Page(string name)
{
    public string Name { get; } = name;
    public Page? Parent { get; set; }
    public List<Page> Children { get; } = [];
}