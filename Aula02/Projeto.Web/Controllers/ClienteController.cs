using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Projeto.Web.Models; //camada de modelo..

namespace Projeto.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [AllowAnonymous]
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        [HttpPost]
        [Route("cadastro")]
        public HttpResponseMessage Post(ClienteModelCadastro model)
        {
            try
            {
                if(ModelState.IsValid)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, "Cliente cadastrado com sucesso.");
                }
                else
                {
                    var errors = new List<string>(); //lista de mensagens..

                    foreach(var state in ModelState)
                    {
                        foreach(var e in state.Value.Errors)
                        {
                            errors.Add(e.ErrorMessage);
                        }
                    }

                    return Request.CreateResponse(HttpStatusCode.Forbidden, errors);
                }
            }
            catch(Exception e)
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

                    return Request.CreateResponse(HttpStatusCode.OK, "Cliente atualizado com sucesso.");
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

                return Request.CreateResponse(HttpStatusCode.OK, "Cliente excluido com sucesso.");
            }
            catch(Exception e)
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

                return Request.CreateResponse(HttpStatusCode.OK);
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

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
