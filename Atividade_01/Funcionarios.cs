using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade_01
{
    internal class Funcionarios
    {
        string nome;
        float salario;
        static float horas_trabalho = 8;
        List<Tarefas> list_tarefas_pessoal = new List<Tarefas>();

        public Funcionarios(string _nome, float _salario)
        {
            nome = _nome;
            salario = _salario;
        }

        public void addTarefa(Tarefas tarefa)
        {
            list_tarefas_pessoal.Add(tarefa);
        }

        public List<Tarefas> getTarefas()
        {
            return list_tarefas_pessoal;
        }

        public float getHoras_trabalhadas()
        {
            float horas_trabalhadas = 0;
            foreach (Tarefas tarefa in list_tarefas_pessoal)
            {
                horas_trabalhadas += tarefa.getDuracao_horas();
            }
            return horas_trabalhadas;
        }

        public string getNome()
        {
            return nome;
        }

        public float getCusto_total_individual()
        {
            float custo_total = getHoras_trabalhadas() * salario;
            foreach (Tarefas tarefa in list_tarefas_pessoal)
            {
                custo_total += tarefa.getCusto_base();
            }

            return custo_total;
        }

        public float getHoras_ociosas()
        {
            float horas_ociosas = 0;
            foreach (Tarefas tarefa in list_tarefas_pessoal)
            {
                horas_ociosas += (tarefa.getDuracao_horas() % horas_trabalho);
            }
            return horas_ociosas;
        }

        public double getDias_conclusao()
        {
            // Se o funcionário não tem tarefas, retorna 0
            if (getHoras_trabalhadas() == 0)
                return 0;

            double dias_conclusao = 0;
            double tempo_restante = horas_trabalho; // Começa com 8 horas disponíveis

            foreach (Tarefas tarefa in list_tarefas_pessoal)
            {
                double duracao = tarefa.getDuracao_horas();

                // Se a tarefa cabe no tempo restante do dia
                if (duracao <= tempo_restante)
                {
                    tempo_restante -= duracao;
                }
                else
                {
                    // A tarefa não cabe no dia atual
                    duracao -= tempo_restante; // Retira o tempo que sobrou do dia
                    dias_conclusao += 1; // Encerra o dia atual

                    // Enquanto a tarefa ainda não couber em um dia completo
                    while (duracao > horas_trabalho)
                    {
                        duracao -= horas_trabalho;
                        dias_conclusao += 1;
                    }

                    // Coloca o restante da tarefa no novo dia
                    tempo_restante = horas_trabalho - duracao;
                }
            }

            // Se sobrou tempo parcial utilizado (não é um dia completo), conta como 1 dia
            if (tempo_restante < horas_trabalho)
            {
                dias_conclusao += 1;
            }

            return dias_conclusao;
        }

        // Método para calcular tempo ocioso do funcionário
        public float getTempo_ocioso(double dias_projeto_total)
        {
            return (float)(dias_projeto_total * horas_trabalho) - getHoras_trabalhadas();
        }
    }
}
