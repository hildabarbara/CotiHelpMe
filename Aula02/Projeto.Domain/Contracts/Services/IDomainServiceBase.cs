using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Contracts.Services
{
    /// <summary>
    /// Interface para as regras de negocio genericas
    /// </summary>
    /// <typeparam name="TEntity">Entidade</typeparam>
    public interface IDomainServiceBase<TEntity>
        where TEntity : class
    {
        void Cadastrar(TEntity obj);
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);
        List<TEntity> ListarTodos();
        TEntity ObterPorId(int id);
    }
}
