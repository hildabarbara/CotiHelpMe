using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities; //entidades
using Projeto.Domain.Contracts.Services; //interfaces
using Projeto.Domain.Contracts.Repository; //repositorio

namespace Projeto.Domain.Services
{
    public abstract class DomainServiceBase<TEntity> : IDomainServiceBase<TEntity>
        where TEntity : class
    {
        private IRepositoryBase<TEntity> repositorio; //atributo..

        //Injeção de dependência..
        public DomainServiceBase(IRepositoryBase<TEntity> repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Cadastrar(TEntity obj)
        {
            repositorio.Insert(obj);
        }

        public void Atualizar(TEntity obj)
        {
            repositorio.Update(obj);
        }

        public void Excluir(TEntity obj)
        {
            repositorio.Delete(obj);
        }

        public List<TEntity> ListarTodos()
        {
            return repositorio.FindAll();
        }

        public TEntity ObterPorId(int id)
        {
            return repositorio.FindById(id);
        }
    }
}
