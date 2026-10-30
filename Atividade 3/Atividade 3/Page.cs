using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade_3
{
    sealed public class Page
    {
        // Valores necessários para os objetos Page
        public string Name { get; }
        public Page? Parent { get; set; }
        public List<Page> Children { get; } = [];
        public int Visits { get; set; } = 0;
        public Page(string name)
        {
            Name = name;
        }
    }
}
