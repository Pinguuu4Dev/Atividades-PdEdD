using System;

namespace Atividade_02
{
    internal class Armas
    {
        // Definições dos objetos do tipo Armas.
        private string nome { get; set; }
        private string raridade { get; set; }
        private int dano { get; set; }

        private Dictionary<string, int> valorRaridade = new Dictionary<string, int>()
        {
            { "common", 1 },
            { "rare", 2 },
            { "epic", 3 },
            { "legendary", 4 }
        };

        // Construtor da classe Armas que recebe as definições da arma.
        public Armas(string _nome, string _raridade, int _dano)
        {
            nome = _nome;
            raridade = _raridade;
            dano = _dano;
        }

        // Função que retorna as definições da arma em uma string formatada.
        public string getValores()
        {
            return $"Nome: {nome}, Raridade: {raridade}, Dano: {dano}";
        }
        public int getDano()
        {
            return dano;
        }
        public string getNome()
        {
            return nome;
        }
        public int getRaridade()
        {
            return valorRaridade.ContainsKey(raridade) ? valorRaridade[raridade] : 0;
        }
    }
}
