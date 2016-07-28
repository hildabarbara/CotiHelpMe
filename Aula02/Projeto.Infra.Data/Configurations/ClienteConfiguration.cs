using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration; //ORM
using Projeto.Entities; //entidades

namespace Projeto.Infra.Data.Configurations
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        //construtor [ctor] + 2x[tab]
        public ClienteConfiguration()
        {
            ToTable("CLIENTE"); //nome da tabela..

            //chave primária..
            HasKey(c => c.IdCliente);

            //demais propriedades..
            Property(c => c.IdCliente)
                .HasColumnName("IDCLIENTE")
                .IsRequired();

            Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            Property(c => c.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(50)
                .IsRequired();

            Property(c => c.DataCadastro)
                .HasColumnName("DATACADASTRO")
                .IsRequired();
        }
    }
}
