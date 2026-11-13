using Atividade_04;

string[] lines = File.ReadAllLines("log.txt");

foreach (string line in lines)
{
    string[] parts = line.Split(' ');
    string command = parts[0];

    switch (command)
    {
        case "account":
            string userName = line.Substring("account ".Length).Replace(".", "");
            new User(userName);
            break;

        case "follow":
            int followerIndex = int.Parse(parts[1]);
            int followingIndex = int.Parse(parts[2]);
            Rede.ProcurarPorIndice(followerIndex).Follow(followingIndex);
            break;

        case "unfollow":
            int unfollowerIndex = int.Parse(parts[1]);
            int unfollowingIndex = int.Parse(parts[2]);
            Rede.ProcurarPorIndice(unfollowerIndex).Unfollow(unfollowingIndex);
            break;
    }
}

Console.WriteLine("\n=== Resumo da Rede Social ===");
Rede.NumeroContas();
User maiorConta = Rede.ContaMaisSeguidores();
Rede.SeguindoDeVolta(maiorConta);
Console.ReadLine();