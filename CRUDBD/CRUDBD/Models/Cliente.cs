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
            clientenovo.cpf = cpf.Replace(".", "");
            clientenovo.cpf = cpf.Replace("-", "");
            clientenovo.cpf = cpf.Replace("_", "");
            clientenovo.endereco.cep = clientenovo.endereco.cep.Replace("_", "");
            clientenovo.endereco.cep = clientenovo.endereco.cep.Replace("-", "");
            clientenovo.telefone = clientenovo.telefone.Replace("(", "");
            clientenovo.telefone = clientenovo.telefone.Replace(")", "");
            clientenovo.telefone = clientenovo.telefone.Replace("_", "");
            clientenovo.telefone = clientenovo.telefone.Replace("-", "");
            clientenovo.telefone = clientenovo.telefone.Replace(" ", "");

            MySqlConnection Conexao = Models.Banco.GetConexao();
            MySqlCommand Comando = Models.Banco.GetComando(Conexao);
            Comando.CommandText = " INSERT INTO cliente(cpf,nome,sexo,datanascimento,tipodedocumento,numerododocumento,orgaoemissor,telefone,numeroresidencia,estadocivil,cep)VALUES(@cpf,@nome,@sexo,@datanascimento,@tipodedocumento,@numerododocumento,@orgaoemissor,@telefone,@numeroresidencia,@estadocivil,@cep)";
            Comando.Parameters.AddWithValue("@NOME",clientenovo.Nome);
            Comando.Parameters.AddWithValue("@cpf", clientenovo.cpf);
            Comando.Parameters.AddWithValue("@SEXO", clientenovo.sexo);
            Comando.Parameters.AddWithValue("@datanascimento", clientenovo.datadenasicmento);
            Comando.Parameters.AddWithValue("@tipodedocumento", clientenovo.tipodedocumento);
            Comando.Parameters.AddWithValue("@numerododocumento", clientenovo.numerodocumento);
            Comando.Parameters.AddWithValue("@orgaoemissor", clientenovo.orgaemissor);
            Comando.Parameters.AddWithValue("@telefone", clientenovo.telefone);            
            Comando.Parameters.AddWithValue("@numeroresidencia", clientenovo.numero);
            Comando.Parameters.AddWithValue("@estadocivil", clientenovo.estadocivil);
            Comando.Parameters.AddWithValue("@cep", clientenovo.endereco.cep);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();



            //insert do pais
            Comando.CommandText = "SELECT cod_pais from pais where nomepais=@pais ";
            Comando.Parameters.AddWithValue("@pais",clientenovo.endereco.pais);
            MySqlDataReader reader = Comando.ExecuteReader();
            int codpais = Convert.ToInt32(Comando.LastInsertedId);
            while (reader.Read())
            {
                codpais= reader.GetInt32(0);
            }
            reader.Close();

            if (codpais < 0)
            {
                if (!reader.Read())
                {

                    Comando.CommandText = "INSERT INTO pais(NOMEPAIS)VALUES(@NOMEPAIS)";
                    Comando.Parameters.AddWithValue("@NOMEPAIS", clientenovo.endereco.pais);
                    Comando.ExecuteNonQuery();
                    codpais = Convert.ToInt32(Comando.LastInsertedId);
                    Comando.Parameters.Clear();
                }
            }
            reader.Close();





            //insert do uf
            Comando.CommandText = "SELECT cod_uf from uf where nomeuf=@nomeuf ";
            Comando.Parameters.AddWithValue("@nomeuf", clientenovo.endereco.uf);
            reader = Comando.ExecuteReader();
            int coduf = Convert.ToInt32(Comando.LastInsertedId);
           
            while (reader.Read())
            {
                coduf = reader.GetInt32(0);
            }
            reader.Close();

            if (coduf < 0)
            {

                Comando.CommandText = "INSERT INTO uf(NOMEUF,COD_PAIS_FK)VALUES(@uf,@COD_PAIS_FK)";
                Comando.Parameters.AddWithValue("@uf", clientenovo.endereco.uf);
                Comando.Parameters.AddWithValue("@COD_PAIS_FK", codpais);
                Comando.ExecuteNonQuery();
                Comando.Parameters.Clear();
                coduf = Convert.ToInt32(Comando.LastInsertedId);

            }
            reader.Close();




            //insert do cidade
            Comando.CommandText = "INSERT INTO cidade(NOMECIDADE,COD_UF_FK)VALUES(@NOMECIDADE,@COD_UF_FK)";
            Comando.Parameters.AddWithValue("@NOMECIDADE", clientenovo.endereco.cidade);
            Comando.Parameters.AddWithValue("@COD_UF_FK", coduf);            
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            var codcidade = Comando.LastInsertedId;
            //insert do bairro
            Comando.CommandText = "INSERT INTO bairro(NOMEBAIRRO,COD_CID_FK)VALUES(@NOMEBAIRRO,@COD_CID_FK)";           
            Comando.Parameters.AddWithValue("@NOMEBAIRRO", clientenovo.endereco.cep);
            Comando.Parameters.AddWithValue("@COD_CID_FK", codcidade);           
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            var codbairro = Comando.LastInsertedId;
            //insert do endereço
            Comando.CommandText = "INSERT INTO endereco(CEP,LOGRADOURO,COD_BAIRRO_FK)VALUES(@CEP,@LOGRADOURO,@COD_BAIRRO_FK)";
            Comando.Parameters.AddWithValue("@CEP", clientenovo.endereco.cep);
            Comando.Parameters.AddWithValue("@LOGRADOURO", clientenovo.endereco.cep);
            Comando.Parameters.AddWithValue("@COD_BAIRRO_FK",codbairro);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            return true;









        }


    }
}