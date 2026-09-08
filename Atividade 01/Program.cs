// Parte 1

using Atividade_01;

string func_path = "./funcionarios.txt";
string[] func_info = File.ReadAllLines(func_path);

List<Funcionarios> l_funcionarios = new List<Funcionarios>();
List<float> l_pagamentos = new List<float>();
List<string> l_nomes = new List<string>();

for (int i = 0; i < func_info.Length; i += 2)
{
    string nome = func_info[i];
    float pagamento = float.Parse(func_info[i + 1]);
    l_pagamentos.Add(pagamento);
    l_nomes.Add(nome);

    l_funcionarios.Add(new Funcionarios(nome, pagamento));
}

// 1.Quantos funcionários tem o estúdio;
Console.WriteLine("Número de funcionários é: " + l_funcionarios.Count);

// 2. Qual é o NOME do funcionário com o MAIOR pagamento por hora trabalhada e quanto recebe;
float maior_pgto = 0;
string nome_maior_pgto = "";

maior_pgto = l_pagamentos.Max();
nome_maior_pgto = l_nomes[l_pagamentos.IndexOf(maior_pgto)];

Console.WriteLine("O funcionário com o maior pagamento por hora é: " + nome_maior_pgto + " e recebe " + maior_pgto);

// Parte 2

string tar_path = "./tarefas.txt";
string[] tar_info = File.ReadAllLines(tar_path);

List<Tarefas> l_tarefas = new List<Tarefas>();
List<int> l_id_tarefa = new List<int>();
List<float> l_custo_tarefas = new List<float>();
List<float> l_duracao_tarefas = new List<float>();

for (int i = 0; i < tar_info.Length; i += 3)
{
    int num_id = int.Parse(tar_info[i]);
    float custo_base = float.Parse(tar_info[i + 1]);
    float duracao_horas = float.Parse(tar_info[i + 2]);
    l_duracao_tarefas.Add(duracao_horas);
    l_custo_tarefas.Add(custo_base);
    l_id_tarefa.Add(num_id);

    l_tarefas.Add(new Tarefas(num_id, custo_base, duracao_horas));
}
// 1. Qual a SOMA das DURAÇÕES das tarefas?

float soma_duracao = l_duracao_tarefas.Sum();
Console.WriteLine("A soma das durações das tarefas é: " + soma_duracao);

//2 Qual é o NÚMERO IDENTIFICADOR da tarefa com menor CUSTO BASE? E qual é o custo?

float menor_custo = 0;
string id_menor_custo = "";
menor_custo = l_custo_tarefas.Min();
int index = l_custo_tarefas.IndexOf(menor_custo);
id_menor_custo = l_id_tarefa[index].ToString();
Console.WriteLine("O ID da tarefa com menor custo é: " + id_menor_custo + " e o custo é: " + menor_custo);


// Parte 3

for (int i = 0; i < l_tarefas.Count; i++)
{
    if (i >= l_funcionarios.Count)
    {
        i = 0;
    }
    l_funcionarios[i].addTarefa(l_tarefas[0]);
    l_tarefas.RemoveAt(0);
}

// 1 - Qual o NOME do funcionário que precisará trabalhar MAIS tempo para concluir suas atividades? E quanto tempo será?

List<float> l_tempo_tarefas_individual = new List<float>();

for (int i = 0; i < l_funcionarios.Count; i++)
{
    float tempo_total = 0;
    foreach (Tarefas tarefa in l_funcionarios[i].getTarefas())
    {
        tempo_total += tarefa.getDuracao_horas();
    }
    l_tempo_tarefas_individual.Add(tempo_total);

}

float maior_tempo = l_tempo_tarefas_individual.Max();
Console.WriteLine("O funcionário que precisará trabalhar mais tempo é: " + l_funcionarios[l_tempo_tarefas_individual.IndexOf(maior_tempo)].nome + " e precisará trabalhar " + maior_tempo + " horas.");

// 2 - Qual o CUSTO TOTAL para a execução de TODAS as tarefas, considerando o PAGAMENTO por HORA dos funcionários responsáveis e o CUSTO BASE das tarefas? Considere que os funcionários recebem apenas por hora TRABALHADA.
Console.WriteLine("O custo total para a execução de todas as tarefas é: " + l_funcionarios.Sum(f => f.getCusto_total_individual()));

// Parte 4

