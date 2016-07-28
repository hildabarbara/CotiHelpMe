using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;

namespace Projeto.Application.Contracts
{
    public interface IAppCliente : IAppBase<Cliente>
    {
        List<Cliente> ListarPorNome(string Nome);
    }
}
