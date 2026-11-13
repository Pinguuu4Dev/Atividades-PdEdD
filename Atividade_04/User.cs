using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_04
{
    internal class User
    {
        public string Nome { get; set; }

        public int Indice {get; set;}
        public List<User> Seguidores { get; set; } // <- Contas que seguem o usuário
        public List<User> Seguindo { get; set; } // <- Contas que o usuário segue

        public User(string nome)
        {
            Nome = nome;
            Indice = Rede.indiceUsuarios;
            if (Seguidores == null && Seguindo == null) {
                Seguidores = new List<User>();
                Seguindo = new List<User>();
            }
            Rede.AdicionarUsuario(this);
        }

        public int NumSeguidores()
        {
            return Seguidores.Count;
        }
        public void Follow(int contaSeguir)
        {
            if (contaSeguir != this.Indice)
            {
                User seguindo = Rede.ProcurarPorIndice(contaSeguir);
                Seguindo.Add(seguindo);
                seguindo.Seguidores.Add(this);
            }
        }

        public void Unfollow(int contaSeguir)
        {
            if (contaSeguir != this.Indice)
            {
                User seguindo = Rede.ProcurarPorIndice(contaSeguir);
                Seguindo.Remove(seguindo);
                seguindo.Seguidores.Remove(this);
            }
        }

    }
}
