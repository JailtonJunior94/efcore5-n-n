using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Grupo> Grupos { get; set; }
    }
}
