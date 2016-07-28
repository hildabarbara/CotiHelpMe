using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.Domain.Contracts.Services;
using Projeto.Application.Contracts;

namespace Projeto.Application.Services
{
    public class AppCliente : AppBase<Cliente>, IAppCliente
    {
        //atributo..
        private IDomainServiceCliente dominio;

        //construtor
        public AppCliente(IDomainServiceCliente dominio)
            : base(dominio)
        {
            this.dominio = dominio;
        }
        
        public List<Cliente> ListarPorNome(string Nome)
        {
            return dominio.ListarPorNome(Nome);
        }
    }
}
