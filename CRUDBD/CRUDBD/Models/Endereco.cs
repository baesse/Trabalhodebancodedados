using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDBD.Models
{
    public class Endereco
    {
        [Display(Name = "Cep")]
        public String  cep  { get; set; }
        [Display(Name = "Bairro")]
        public String bairro { get; set; }
        [Display(Name = "País")]
        public int pais { get; set; }
       

    }
}