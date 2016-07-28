using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Entities
{
    //Entidade
    public class Produto
    {
        public virtual int IdProduto { get; set; }
        public virtual string Nome { get; set; }
        public virtual double Preco { get; set; }
        public virtual int Quantidade { get; set; }
        public virtual DateTime DataCompra { get; set; }
    }
}
