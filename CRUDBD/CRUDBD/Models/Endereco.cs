using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDBD.Models
{
    public class Endereco
    {
        [Required(ErrorMessage = "Favor informar o cep")]
        [Display(Name = "Cep")]
        public String  cep  { get; set; }

        [Required(ErrorMessage = "Favor informar o bairro")]
        [Display(Name = "Bairro")]
        public String bairro { get; set; }

        [Required(ErrorMessage = "Favor informar o país")]
        [Display(Name = "País")]
        public String pais { get; set; }
        [Required(ErrorMessage = "Favor informar o logradouro")]
        [Display(Name = "Logradouro")]
        public String logradouro { get; set; }
        [Required(ErrorMessage = "Favor informar a uf")]
        [Display(Name = "uf")]
        public String uf { get; set; }
        [Required(ErrorMessage = "Favor informar a cidade")]
        [Display(Name = "cidade")]
        public String cidade { get; set; }


    }
}