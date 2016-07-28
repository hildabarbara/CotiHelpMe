using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities; //entidades..
using Projeto.Domain.Contracts.Services; //interfaces
using Projeto.Domain.Contracts.Repository; //repositorio

namespace Projeto.Domain.Services
{
    public class DomainServiceCliente : DomainServiceBase<Cliente>, IDomainServiceCliente
    {
        //atributo..
        private IRepositoryCliente repositorio;
        
        //construtor..
        public DomainServiceCliente(IRepositoryCliente repositorio)
            : base(repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Cliente> ListarPorNome(string Nome)
        {
            return repositorio.FindByNome(Nome);
        }
    }  

}
