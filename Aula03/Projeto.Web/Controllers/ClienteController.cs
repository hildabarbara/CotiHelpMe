using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Http.Cors;
using Projeto.Web.Models;
using Projeto.Application.Contracts;
using Projeto.Entities;

namespace Projeto.Web.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [AllowAnonymous]
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        //atributo para interface de aplicação da entidade Cliente..
        private IAppCliente appCliente; //null..

        //construtor..
        //entrada de parametros
        public ClienteController(IAppCliente appCliente)
        {
            //receber uma instancia da interface e passa-la
            //como valor do atributo..
            this.appCliente = appCliente;
        }

        [HttpPost]
        [Route("cadastro")] //api/cliente/cadastro
        public HttpResponseMessage Post(ClienteModelCadastro model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cliente c = new Cliente(); //entidade..
                    c.Nome = model.Nome;
                    c.Email = model.Email;
                    c.DataCadastro = DateTime.Now;

                    appCliente.Cadastrar(c); //gravando..

                    return Request.CreateResponse(HttpStatusCode.OK, "Cliente cadastrado com sucesso.");
                }
                else
                {
                    var errors = new List<string>(); //lista de mensagens..

                    foreach (var state in ModelState)
                    {
                        foreach (var e in state.Value.Errors)
                        {
                            errors.Add(e.ErrorMessage);
                        }
                    }

                    return Request.CreateResponse(HttpStatusCode.Forbidden, errors);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpPut]
        [Route("editar")]
        public HttpResponseMessage Put(ClienteModelEdicao model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //buscando o cliente pelo id..
                    Cliente c = appCliente.ObterPorId(model.ClienteID);

                    if (c != null) //se foi encontrado..
                    {
                        c.Nome = model.Nome;
                        c.Email = model.Email;

                        appCliente.Atualizar(c);

                        return Request.CreateResponse(HttpStatusCode.OK, "Cliente atualizado com sucesso.");
                    }
                    else
                    {
                        throw new Exception("Erro. Cliente não encontrado.");
                    }
                }
                else
                {
                    var errors = new List<string>(); //lista de mensagens..

                    foreach (var state in ModelState)
                    {
                        foreach (var e in state.Value.Errors)
                        {
                            errors.Add(e.ErrorMessage);
                        }
                    }

                    return Request.CreateResponse(HttpStatusCode.Forbidden, errors);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpDelete]
        [Route("excluir")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                //buscar o cliente pelo id..
                Cliente c = appCliente.ObterPorId(id);

                //se cliente foi encontrado..
                if (c != null)
                {
                    appCliente.Excluir(c); //removendo..

                    return Request.CreateResponse(HttpStatusCode.OK, "Cliente excluido com sucesso.");
                }
                else
                {
                    throw new Exception("Erro. Cliente não encontrado.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpGet]
        [Route("obter")]
        public HttpResponseMessage GetValue(int id)
        {
            try
            {
                //buscar o cliente pelo id..
                Cliente c = appCliente.ObterPorId(id);

                //se cliente foi encontrado..
                if (c != null)
                {
                    var model = new ClienteModelConsulta();
                    model.ClienteID = c.IdCliente;
                    model.Nome = c.Nome;
                    model.Email = c.Email;
                    model.DataCadastro = c.DataCadastro;

                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    throw new Exception("Erro. Cliente não encontrado.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpGet]
        [Route("listar")]
        public HttpResponseMessage GetValues()
        {
            try
            {
                var lista = new List<ClienteModelConsulta>();

                //varrer cada cliente da aplicação..
                foreach (Cliente c in appCliente.ListarTodos())
                {
                    var model = new ClienteModelConsulta();
                    model.ClienteID = c.IdCliente;
                    model.Nome = c.Nome;
                    model.Email = c.Email;
                    model.DataCadastro = c.DataCadastro;

                    lista.Add(model); //adicionar na lista..
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
