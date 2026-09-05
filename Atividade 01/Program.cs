// Parte 1

/* 
 * Em um estúdio hipotético, há uma lista de funcionários. Os dados desta lista estão contidos no arquivo "funcionarios.txt", 
 * no qual os PARES de linhas representam, respectivamente, o NOME e PAGAMENTO POR HORA trabalhada de cada funcionário.
*/

// Primeiro definimos o caminho que o programa deve seguir para conseguir o acesso as informações dos funcionários
using Atividade_01;

string func_path = "./funcionarios.txt";
string[] func_info = File.ReadAllLines(func_path);

Funcionarios[] lista_funcionarios = new Funcionarios[func_info.Length / 2];
float[] lista_pagamentos = new float[func_info.Length / 2];
string[] lista_nomes = new string[func_info.Length / 2];
    
for (int i = 0; i < func_info.Length; i += 2)
{
    string nome = func_info[i];
    float pagamento = float.Parse(func_info[i + 1]);
    lista_pagamentos[i / 2] = pagamento;
    lista_nomes[i / 2] = nome;

    lista_funcionarios[i / 2] = new Funcionarios(nome, pagamento);
}

/* 
 * Agora cumprimos os requisitos da atividade, sendo elas:
*/

// 1.Quantos funcionários tem o estúdio;
Console.WriteLine("Número de funcionários é: " + lista_funcionarios.Length);

// 2. Qual é o NOME do funcionário com o MAIOR pagamento por hora trabalhada e quanto recebe;
float maior_pgto = 0;
string nome_maior_pgto = "";

maior_pgto = lista_pagamentos.Max();
nome_maior_pgto = lista_nomes[Array.IndexOf(lista_pagamentos, maior_pgto)];

Console.WriteLine("O funcionário com o maior pagamento por hora é: " + nome_maior_pgto + " e recebe " + maior_pgto);

// Parte 2
/*
 * Agora, identificamos as tarefas da empresa de acordo com o arquivo "tarefas.txt",  no qual os TRIOS de linhas representam, 
 * respectivamente, um NÚMERO IDENTIFICADOR, CUSTO BASE e DURAÇÃO EM HORAS de cada tarefa. 
*/

string tar_path = "./tarefas.txt";
string[] tar_info = File.ReadAllLines(tar_path);

Tarefas[] lista_tarefas = new Tarefas[tar_info.Length / 3];
int[] lista_num_id = new int[tar_info.Length / 3];
float[] lista_custo = new float[tar_info.Length / 3];
float[] lista_duracao = new float[tar_info.Length / 3];

for (int i = 0; i < tar_info.Length; i += 3)
{
    int num_id = int.Parse(tar_info[i]);
    float custo_base = float.Parse(tar_info[i + 1]);
    float duracao_horas = float.Parse(tar_info[i + 2]);
    Console.WriteLine("ID: " + num_id + " | Custo Base: " + custo_base + " | Duração em horas: " + duracao_horas);

    lista_tarefas[i / 3] = new Tarefas(num_id, custo_base, duracao_horas);
}
/* 
 * Novamente cumprimos os requisitos da atividade, sendo elas:
*/
// 1. Qual a SOMA das DURAÇÕES das tarefas?

float soma_duracao = lista_duracao.Sum();
Console.WriteLine("A soma das durações das tarefas é: " + soma_duracao);