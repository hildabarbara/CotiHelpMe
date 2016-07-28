using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //mapeamento...

namespace Projeto.Web.Models
{
    //classe para o formulário de cadastro de produtos
    public class ProdutoModelCadastro
    {
        [RegularExpression("^[A-Za-zÀ-Üà-ü0-9\\s]{5,50}$",
            ErrorMessage = "Erro. Informe o nome do produto corretamente.")]
        [Required(ErrorMessage = "Erro. Informe o nome do produto.")]
        public string Nome { get; set; } //campo

        //[Range(1, Double.MaxValue, 
          //  ErrorMessage = "Erro. Informe o preço do produto corretamente.")]
        [Required(ErrorMessage = "Erro. Informe preço do produto.")]
        public string Preco { get; set; } //campo
                
        //[Range(1, 100, 
          //  ErrorMessage = "Erro. Informe a quantidade do produto corretamente.")]
        [Required(ErrorMessage = "Erro. Informe a quantidade do produto.")]
        public string Quantidade { get; set; } //campo
    }
}