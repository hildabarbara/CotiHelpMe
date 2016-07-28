using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping; //mapeamento
using Projeto.Data.Entities; //classes de entidade

namespace Projeto.Data.Mappings
{
    //Classe de mapeamento para a entidade Produto
    public class ProdutoMap : ClassMap<Produto>
    {
        //Construtor -> [ctor] + 2x[tab]
        public ProdutoMap()
        {
            //nome da tabela
            Table("Produto"); //opcional

            //chave primária
            Id(p => p.IdProduto, "IdProduto").
                GeneratedBy.Identity();

            //demais propriedades...
            Map(p => p.Nome, "Nome").
                Length(50).
                Not.Nullable();

            Map(p => p.Preco, "Preco").
                Not.Nullable();

            Map(p => p.Quantidade, "Quantidade").
                Not.Nullable();

            Map(p => p.DataCompra, "DataCompra").
                Not.Nullable();
        }
    }
}
