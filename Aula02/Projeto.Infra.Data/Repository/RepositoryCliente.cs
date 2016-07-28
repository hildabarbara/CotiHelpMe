using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.Domain.Contracts.Repository;

namespace Projeto.Infra.Data.Repository
{
    public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryCliente
    {
        public List<Cliente> FindByNome(string Nome)
        {
            //SQL -> select * from Cliente where Nome like '%Ana%'
            //LAMBDA (consultas com o entityframework)
            return Con.Clientes
                    .Where(c => c.Nome.Contains(Nome))
                    .ToList();
        }
    }
}
