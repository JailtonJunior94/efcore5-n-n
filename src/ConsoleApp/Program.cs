using System;
using System.Linq;
using ConsoleApp.Models;
using ConsoleApp.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await using var context = new ConsoleContext();

            /* Deleta o banco de dados caso exista */
            await context.Database.EnsureDeletedAsync();

            /* Cria o banco de dados caso não exista */
            await context.Database.EnsureCreatedAsync();

            /* Definindo usuários */
            var jailton = new Usuario { Nome = "Jailton" };
            var stefany = new Usuario { Nome = "Stefany" };
            var antony = new Usuario { Nome = "Antony" };

            /* Definindo grupos e usuários */
            var filmes = new Grupo { Nome = "Filmes", Usuarios = new List<Usuario> { jailton, stefany } };
            var receitas = new Grupo { Nome = "Receitas", Usuarios = new List<Usuario> { stefany } };
            var bebes = new Grupo { Nome = "Bebês", Usuarios = new List<Usuario> { stefany, antony } };

            /* Incluindo usuários e grupos no banco de dados */
            context.AddRange(jailton, stefany, antony, filmes, receitas, bebes);
            await context.SaveChangesAsync();

            /* Consultando usuários */
            var usuarios = await context.Usuarios
                .Where(u => u.Grupos.Any(g => g.Nome == "Filmes"))
                .ToListAsync();

            /* Exibindo os usuários do grupo filmes */
            Console.WriteLine("Grupo - Filmes");
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"Usuário: {usuario.Nome}");
            }

            Console.ReadLine();
        }
    }
}
