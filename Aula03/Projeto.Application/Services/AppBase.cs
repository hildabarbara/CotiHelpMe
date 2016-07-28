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
    public abstract class AppBase<TEntity> : IAppBase<TEntity>
        where TEntity : class
    {
        //atributo..
        private IDomainServiceBase<TEntity> dominio;

        //construtor..
        public AppBase(IDomainServiceBase<TEntity> dominio)
        {
            this.dominio = dominio;
        }

        public void Cadastrar(TEntity obj)
        {
            dominio.Cadastrar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            dominio.Atualizar(obj);
        }

        public void Excluir(TEntity obj)
        {
            dominio.Excluir(obj);
        }

        public List<TEntity> ListarTodos()
        {
            return dominio.ListarTodos();
        }

        public TEntity ObterPorId(int id)
        {
            return dominio.ObterPorId(id);
        }
    }
}
