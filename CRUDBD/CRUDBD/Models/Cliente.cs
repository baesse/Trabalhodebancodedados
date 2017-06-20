using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDBD.Models
{
    public class Cliente
    {
        [Display(Name = "Cpf")]
        public String cpf { get; set; }
        [Display(Name = "Nome")]
        public String Nome { get; set; }
        [Display(Name = "Sexo")]
        public String sexo { get; set; }
        [Display(Name = "Profissão")]
        public String profissao { get; set; }
        [Display(Name = "Data de nascimento")]
        public DateTime datadenasicmento { get; set; }
        [Display(Name = "Tipo de documento")]
        public String tipodedocumento { get; set; }
        [Display(Name = "Numero do documento")]
        public String numerodocumento { get; set; }
        [Display(Name = "Orgão emissor")]
        public String orgaemissor { get; set; }
        [Display(Name = "Nacionalidade")]
        public String nacionalidade { get; set; }
        [Display(Name = "Telefone")]
        public String telefone { get; set; }
        [Display(Name = "Numero")]
        public String numero { get; set; }
        [Display(Name = "Endereco")]
        public String endereoccad { get; set; }
        public Endereco endereco { get; set; }
        public List<string> estadocivil { get; set; }




    }
}