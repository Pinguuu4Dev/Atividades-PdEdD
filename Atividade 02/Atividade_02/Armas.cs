using System;

public class Armas
{
	string nome { get, private set };
	string raridade { get, private set };
	string dano { get, private set };

    public Armas(string _nome, string _raridade, string _dano)
	{
		nome.set(_nome);
		raridade.set(_raridade);
        dano.set(_dano);
    }

	public string getProperties()
	{
		return $"Nome: {nome}, Raridade: {raridade}, Dano: {dano}";
    }
}
