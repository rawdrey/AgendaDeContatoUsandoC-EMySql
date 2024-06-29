using System;
using System.Linq;

namespace AgendaContatos
{
    class Program
    {
        static void Main()
        {
            using (var db = new Data.ContatosContext())
            {
                // Adicionar um novo contato
                var novoContato = new Contato { Nome = "Fulano", Telefone = "123456789", Email = "fulano@example.com" };
                db.Contatos.Add(novoContato);
                db.SaveChanges();

                // Listar todos os contatos
                var contatos = db.Contatos.ToList();
                foreach (var contato in contatos)
                {
                    Console.WriteLine($"ID: {contato.Id}, Nome: {contato.Nome}, Telefone: {contato.Telefone}, Email: {contato.Email}");
                }

                // Atualizar um contato
                var contatoParaAtualizar = db.Contatos.FirstOrDefault(c => c.Nome == "Fulano");
                if (contatoParaAtualizar != null)
                {
                    contatoParaAtualizar.Telefone = "987654321";
                    db.SaveChanges();
                }

                // Remover um contato
                var contatoParaRemover = db.Contatos.FirstOrDefault(c => c.Nome == "Fulano");
                if (contatoParaRemover != null)
                {
                    db.Contatos.Remove(contatoParaRemover);
                    db.SaveChanges();
                }
            }
        }
    }
}
