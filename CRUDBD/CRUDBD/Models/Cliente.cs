using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDBD.Models
{
    public class Cliente
    {
        [Required(ErrorMessage ="Favor informar o cpf")]
        [Display(Name = "Cpf")]
        public String cpf { get; set; }



        [Required(ErrorMessage = "Favor informar o Nome")]
        [Display(Name = "Nome")]
        public String Nome { get; set; }




        [Required(ErrorMessage = "Favor informar o sexo")]
        [Display(Name = "Sexo")]
        public String sexo { get; set; }




        [Required(ErrorMessage = "Favor informar a profissão")]
        [Display(Name = "Profissão")]
        public String profissao { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Favor informar a data de nascimento")]
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



        [Required(ErrorMessage = "Favor informar o numero da residencia")]
        [Display(Name = "Numero")]
        public String numero { get; set; }


        [Required(ErrorMessage = "Favor informar o endereço")]
        [Display(Name = "Endereco")]
        public String endereoccad { get; set; }
        public Endereco endereco { get; set; }

        [Required(ErrorMessage = "Favor informar o estado civil")]
        [Display(Name = "Estado civil")]
        public String estadocivil { get; set; }



        public Boolean CadastrarCliente(Cliente clientenovo)
        {
            MySqlConnection Conexao = Models.Banco.GetConexao();
            MySqlCommand Comando = Models.Banco.GetComando(Conexao);
            Comando.CommandText = "insert into NOME,CPF,SEXO,DATADENASCIMENTO,TIPODEDOCUMENTO,NUMERODODOCUMENTO,ORGAOEMISSOR,TELEFONE,ENDERECO,NUMERO,ESTADOCIVIL)VALUES(@NOME,@CPF,@SEXO,@DATADENASCIMENTO,@TIPODEDOCUMENTO,@NUMERODODOCUMENTO,@ORGAOEMISSOR,@TELEFONE,@ENDERECO,@NUMERO,@ESTADOCIVIL)";
            Comando.Parameters.AddWithValue("@NOME",clientenovo.Nome);           
            Comando.Parameters.AddWithValue("@SEXO", clientenovo.sexo);
            Comando.Parameters.AddWithValue("@DATADENASCIMENTO", clientenovo.datadenasicmento);
            Comando.Parameters.AddWithValue("@TIPODEDOCUMENTO", clientenovo.tipodedocumento);
            Comando.Parameters.AddWithValue("@NUMERODODOCUMENTO", clientenovo.numerodocumento);
            Comando.Parameters.AddWithValue("@ORGAOEMISSOR", clientenovo.orgaemissor);
            Comando.Parameters.AddWithValue("@TELEFONE", clientenovo.telefone);
            Comando.Parameters.AddWithValue("@ENDERECO", clientenovo.endereco);
            Comando.Parameters.AddWithValue("@NUMERO", clientenovo.numero);
            Comando.Parameters.AddWithValue("@ESTADOCIVIL", clientenovo.estadocivil);

            Comando.ExecuteNonQuery();
            return true;









        }


    }
}