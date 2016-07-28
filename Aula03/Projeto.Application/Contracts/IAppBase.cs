using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Contracts
{
    /// <summary>
    /// Interface para operações base de Aplicação
    /// </summary>
    public interface IAppBase<TEntity>
        where TEntity : class
    {
        void Cadastrar(TEntity obj);
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);
        List<TEntity> ListarTodos();
        TEntity ObterPorId(int id);
    }
}
