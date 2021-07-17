using Store.Core.DomainObjects;
using System.Collections.Generic;

namespace Store.Cadastro.Domain
{
    public class Cliente : Entity
    {
        protected Cliente() { }
        public Cliente(string nome, Email email, string contato)
        {
            Nome = nome;
            Email = email;
            Contato = contato;

            Validar();
        }

        public string Nome { get;private set; }
        public Email Email { get; private set; }
        public string Contato { get; private set; }

        public ICollection<Usuario> Usuarios { get; private set; }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome não pode estar vazio");
        }

    }
}
