using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; //connectionstring
using System.Data.Entity; //entityframework
using Projeto.Infra.Data.Configurations; //mapeamento
using Projeto.Entities; //entidades

namespace Projeto.Infra.Data.Context
{
    //1º) Herdar DbContext
    public class DataContext : DbContext
    {
        //2º) Construtor que envie a connectionstring para o DbContext
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["aula"].ConnectionString)
        {

        }
        
        //3º) Sobrescrever o método OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //configurar convenções e preferencias do entityframework
            //definir para o DbContext as classes de mapeamento com Fluent
            modelBuilder.Configurations.Add(new ClienteConfiguration());
        }

        //4º) Declarar um DbSet (Unit of Work) para cada entidades..
        public DbSet<Cliente> Clientes { get; set; } //CRUD
    }
}
