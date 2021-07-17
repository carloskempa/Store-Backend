using Store.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Cadastro.Domain
{
    public  interface IUsuarioRepository : IRepository<Usuario>
    {
        //Usuario
        Task<Usuario> ObterPorId(Guid id);
        Task<IEnumerable<Usuario>> ObterTodos(Guid usuarioId);
        void Adicionar(Usuario usuario);
        void Atualizar(Usuario usuario);


        //Cliente
        Task<Cliente> ObterClientePorId(Guid id);
        Task<IEnumerable<Cliente>> ObterListaCliente(Guid clienteId);
        void AdicionarCliente(Cliente cliente);
        void AtualizarCliente(Cliente cliente);
    }
}
