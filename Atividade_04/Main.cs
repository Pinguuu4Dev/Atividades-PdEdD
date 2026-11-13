using Atividade_04;

string userLog = File.ReadAllText("log.txt");

User maiorConta = Rede.contaMaisSeguidores();
int contasNaRede = Rede.numeroContas();

User user1 = new User("Igor");
User user2 = new User("Ricka");
User user3 = new User("Enzo");

user2.Follow(0);
user1.Follow(1);
user3.Follow(1);

Console.WriteLine($"Nossa rede social tem {contasNaRede} usuários e contando!");
Console.WriteLine($"Conta com maior número de seguidores ({maiorConta.NumSeguidores()}): {maiorConta.Nome} ");
Console.WriteLine($"Contas seguidas de volta pela maior conta na rede: {Rede.seguindoDeVolta(maiorConta)}");

// Basta criarmos a string do log para criarmos os usuários de acordo com o .txt do professor