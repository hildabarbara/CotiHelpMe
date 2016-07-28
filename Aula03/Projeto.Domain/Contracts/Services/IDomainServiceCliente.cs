using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities; //entidades

namespace Projeto.Domain.Contracts.Services
{
    /// <summary>
    /// Interface para Regras de Negocio do Cliente
    /// </summary>
    public interface IDomainServiceCliente : IDomainServiceBase<Cliente>
    {
        List<Cliente> ListarPorNome(string Nome);
    }
}
