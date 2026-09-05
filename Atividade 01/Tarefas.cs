using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade_01
{
    internal class Tarefas
    {
        int num_id;
        float custo_base;
        float duracao_horas;
        public Tarefas(int _num_id, float _custo_base, float _duracao_horas)
        {
            num_id = _num_id;
            custo_base = _custo_base;
            duracao_horas = _duracao_horas;
        }
    }
}
