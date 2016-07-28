using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Projeto.Data.Entities;
using Projeto.Data.Persistence;
using Projeto.Web.Models;

namespace Projeto.Web.Controllers
{    
    //api/Produtos
    public class ProdutosController : ApiController
    {
        /*
         * Classe de Controle padrão WebApi, seus métodos são acessados
         * por GET ou POST, mas não retornam páginas e sim dados em
         * formato XML ou JSON
         */

        //POST: /api/Produtos/{JSON}
        public HttpResponseMessage Post( [FromBody] ProdutoModelCadastro model)
        {
            try
            {
                if(ModelState.IsValid) //verificar se a model passou nas validações
                {
                    //resgatar os dados do produtos...
                    Produto p = new Produto(); //entidade
                    p.Nome       = model.Nome;
                    p.Preco      = Convert.ToDouble(model.Preco);
                    p.Quantidade = Convert.ToInt32(model.Quantidade);
                    p.DataCompra = DateTime.Now;

                    //gravar na base de dados...
                    ProdutoData d = new ProdutoData(); //persistencia
                    d.Save(p); //inserir o produto...

                    return Request.CreateResponse(HttpStatusCode.Created, 
                                "Produto cadastrado com sucesso.");
                }
                else
                {
                    //lista para armazenar os erros gerados na model
                    List<string> erros = new List<string>();
                    //varrer cada erro trazido pelo ModelState
                    foreach(var state in ModelState)
                    {
                        foreach(var e in state.Value.Errors)
                        {
                            erros.Add(e.ErrorMessage); //adicionar na lista...
                        }
                    }
                    //retornar erro com as mensagens...
                    return Request.CreateResponse(HttpStatusCode.Forbidden, erros);
                }
            }
            catch(Exception e)
            {
                //retornar erro para o cliente...
                return Request.CreateResponse(HttpStatusCode.Forbidden, e.Message);
            }
        }

        //GET: /api/Produtos (REST)
        public List<Produto> GetValues()
        {
            try
            {
                ProdutoData d = new ProdutoData(); //persistencia...
                return d.FindAll(); //retornar todos os produtos...
            }
            catch
            {
                //retornar erro de servidor...
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        //GET: /api/Produtos?Nome=A (REST)
        public List<Produto> GetValues(string Nome)
        {
            try
            {
                ProdutoData d = new ProdutoData(); //persistencia...
                return d.FindByNome(Nome); //retornar todos os produtos...
            }
            catch
            {
                //retornar erro de servidor...
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        //DELETE: /api/Produtos/id
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                ProdutoData d = new ProdutoData(); //persistencia...

                //buscar o produto pelo id...
                Produto p = d.FindById(id);
                //excluir o produto...
                d.Delete(p);

                return Request.CreateResponse(HttpStatusCode.Created, 
                        "Produto excluido com sucesso.");
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, e.Message);
            }
        }

    }
}
