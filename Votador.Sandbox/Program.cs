using System;
using System.Threading;
using System.Threading.Tasks;
using Votador.Data.Context;
using Votador.Business.Models;

namespace Votador.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Incluindo usuários, aguarde...");

            Thread.Sleep(2000);

            using (var context = new VotadorContext())
            {
                IncluirUsuarios(context);

                foreach (var usuario in context.Usuarios)
                {
                    Console.WriteLine(String.Format("Usuário encontrado {0}", usuario.Nome));
                }
            };

            Console.WriteLine("Pressione qualquer tecla para sair...");

            Console.ReadKey(false);
        }

        static void IncluirUsuarios(VotadorContext context)
        {
            context.AddRange(new Usuario
            {
                Nome = "Rafael",
                Email = "brugiolo@hotmail.com",
                Ativo = true,
                Senha = "123",
            }, new Usuario
            {
                Nome = "Laura",
                Email = "laura.brugiolo@gmail.com",
                Ativo = true,
                Senha = "123",
            }, new Usuario
            {
                Nome = "Janine",
                Email = "janinelcarvalho@gmail.com",
                Ativo = true,
                Senha = "123",
            });

            context.SaveChanges();
        }
    }
}
    