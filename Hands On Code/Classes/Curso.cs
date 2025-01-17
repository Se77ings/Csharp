using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Classes
{
    internal record Curso
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return ($"{Id} - {Name}");
        }
    }

    public record CursoImutavel (int ID, string Descricao)
    {
        public override string ToString()
        {
            return ($"{ID} - {Descricao}");
        }
    };
}
