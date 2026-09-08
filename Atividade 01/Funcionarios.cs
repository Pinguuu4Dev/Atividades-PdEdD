using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade_01
{
    internal class Funcionarios
    {
        public string nome;
        public float salario;

        private List<Tarefas> list_tarefas_pessoal= new List<Tarefas>();

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

        public float getCusto_total_individual()
        {
            float custo_total = 0;
            foreach (Tarefas tarefa in list_tarefas_pessoal)
            {
                custo_total += this.getHoras_trabalhadas() * salario + tarefa.getCusto_base();
            }

            return custo_total;
        }
    }
}
