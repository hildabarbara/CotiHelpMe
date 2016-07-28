using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;

namespace Projeto.Domain.Contracts.Repository
{
    public interface IRepositoryCliente : IRepositoryBase<Cliente>
    {
        List<Cliente> FindByNome(string Nome);
    }
}
