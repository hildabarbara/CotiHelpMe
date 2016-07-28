using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq; //queries
using Projeto.Data.Entities;
using Projeto.Data.Util;

namespace Projeto.Data.Persistence
{
    //classe para persistencia de dados
    public class ProdutoData
    {
        //Método para inserir/atualizar um Produto
        public void Save(Produto p)
        {
            using(ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.SaveOrUpdate(p); //insert/update
                t.Commit(); //executar a transação...
            }
        }

        //Método para inserir/atualizar um Produto
        public void Delete(Produto p)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Delete(p); //delete
                t.Commit(); //executar a transação...
            }
        }

        //Método para listar os produtos pelo nome...
        public List<Produto> FindAll()
        {
            using(ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                //LINQ -> Language Integrated Query
                var query = from p in s.Query<Produto>()
                            orderby p.Nome ascending
                            select p;
                //retornar...
                return query.ToList();
            }
        }

        //Método para listar os produtos pelo nome...
        public List<Produto> FindByNome(string Nome)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var query = from p in s.Query<Produto>()
                            where p.Nome.Contains(Nome)
                            orderby p.Nome ascending
                            select p;
                //retornar...
                return query.ToList();
            }
        }

        //Método para buscar 1 Produto pelo id...
        public Produto FindById(int IdProduto)
        {
            using(ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                //SQL -> select * from Produto where Idproduto = ?
                return (Produto) s.Get(typeof(Produto), IdProduto);
            }
        }

    }
}
