using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //ORM

namespace Projeto.Web.Models
{
    public class ClienteModelCadastro
    {
        [Required(ErrorMessage = "Informe o Nome.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um Email válido.")]
        [Required(ErrorMessage = "Informe o Email.")]
        public string Email { get; set; }
    }

    public class ClienteModelConsulta
    {
        public int ClienteID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
    }

    public class ClienteModelEdicao
    {
        [Required(ErrorMessage = "Informe o Id.")]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "Informe o Nome.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um Email válido.")]
        [Required(ErrorMessage = "Informe o Email.")]
        public string Email { get; set; }
    }
}