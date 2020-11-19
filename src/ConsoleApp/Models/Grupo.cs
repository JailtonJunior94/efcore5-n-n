using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
