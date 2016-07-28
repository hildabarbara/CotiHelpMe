using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Configuration;
using Projeto.Data.Mappings;

namespace Projeto.Data.Util
{
    public class HibernateUtil
    {
        //Atributo para armazenar a SessionFactory
        private static ISessionFactory factory;

        //Método para configurar e retornar a SessionFactory
        public static ISessionFactory GetSessionFactory()
        {
            if(factory == null) //se não possui espaço de memória...
            {
                factory = Fluently.Configure().Database(
                            MsSqlConfiguration.MsSql2008.ConnectionString(
                            ConfigurationManager.ConnectionStrings["aula04"].ConnectionString)).
                            Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProdutoMap>()).
                            BuildSessionFactory();
            }

            return factory; //retornar o atributo...
        }

    }
}
