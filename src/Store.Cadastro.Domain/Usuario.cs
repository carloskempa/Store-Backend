using Store.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Cadastro.Domain
{
    public class Usuario : Entity, IAggregateRoot
    {
        public Usuario(string nome, string login, byte[] senha, bool isAdministrador)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            IsAdministrador = isAdministrador;

            Validar();
        }

        public Guid ClienteId { get; private set; }
        public string Nome { get; private set; }
        public string Login { get; private set; }
        public byte[] Senha { get; private set; }
        public bool IsAdministrador { get; set; }
        public string RefleshToken { get; private set; }

        //EF Relation
        public Cliente Cliente { get; private set; }

        public void CriarRefreshToken() => RefleshToken = Guid.NewGuid().ToString().Replace("-", "");

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome não pode estar vazio");
            Validacoes.ValidarSeVazio(Login, "O campo Login não pode estar vazio");
            Validacoes.ValidarSeNulo(Senha, "O campo Senha não pode estar vazio");
        }

    }
}
