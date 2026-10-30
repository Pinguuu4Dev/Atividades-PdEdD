using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade_3
{
    sealed public class Page
    {
        public string Name { get; }
        public Page? Parent { get; set; }
        public List<Page> Children { get; } = [];

        public Page(string name)
        {
            Name = name;
        }
    }
}
