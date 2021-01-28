using Compugraf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Compugraf.DAO
{
    public class PessoaDAO : Conexao
    {

        public bool CadastrarPessoa(Pessoa pessoa)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("STP_INS_PESSOA", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@NOME", pessoa.Nome));
                    cmd.Parameters.Add(new SqlParameter("@SOBRENOME", pessoa.Sobrenome));
                    cmd.Parameters.Add(new SqlParameter("@NACIONALIDADE", pessoa.Nacionalidade));
                    cmd.Parameters.Add(new SqlParameter("@CEP", pessoa.Cep));
                    cmd.Parameters.Add(new SqlParameter("@ESTADO", pessoa.Estado));
                    cmd.Parameters.Add(new SqlParameter("@CIDADE", pessoa.Cidade));
                    cmd.Parameters.Add(new SqlParameter("@LOGRADOURO", pessoa.Logradouro));
                    cmd.Parameters.Add(new SqlParameter("@EMAIL", pessoa.Email));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONE", pessoa.Telefone));

                    if (cmd.ExecuteNonQuery() == 0)
                        return false;
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ExcluirPessoa(Pessoa pessoa)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("STP_DEL_PESSOA", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ID", pessoa.Id));

                    if (cmd.ExecuteNonQuery() == 0)
                        return false;
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<Pessoa> ConsultarPessoa(Pessoa pessoa)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("STP_SEL_PESSOA", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@NOME", pessoa.Nome));
                    cmd.Parameters.Add(new SqlParameter("@SOBRENOME", pessoa.Sobrenome));
                    cmd.Parameters.Add(new SqlParameter("@NACIONALIDADE", pessoa.Nacionalidade));
                    cmd.Parameters.Add(new SqlParameter("@CEP", pessoa.Cep));
                    cmd.Parameters.Add(new SqlParameter("@ESTADO", pessoa.Estado));
                    cmd.Parameters.Add(new SqlParameter("@CIDADE", pessoa.Cidade));
                    cmd.Parameters.Add(new SqlParameter("@LOGRADOURO", pessoa.Logradouro));
                    cmd.Parameters.Add(new SqlParameter("@EMAIL", pessoa.Email));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONE", pessoa.Telefone));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Pessoa> ltab_Pessoa = new List<Pessoa>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ltab_Pessoa.Add(
                                    new Pessoa()
                                    {
                                        Id = Convert.ToInt32(reader["ID"]),
                                        Nome = Convert.ToString(reader["NOME"]),
                                        Sobrenome = Convert.ToString(reader["SOBRENOME"]),
                                        Nacionalidade = Convert.ToString(reader["NACIONALIDADE"]),
                                        Cep = Convert.ToString(reader["CEP"]),
                                        Estado = Convert.ToString(reader["ESTADO"]),
                                        Cidade = Convert.ToString(reader["CIDADE"]),
                                        Logradouro = Convert.ToString(reader["LOGRADOURO"]),
                                        Email = Convert.ToString(reader["EMAIL"]),
                                        Telefone = Convert.ToString(reader["TELEFONE"])
                                    }
                                );
                            }
                        }
                        return ltab_Pessoa;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public Pessoa ConsultarPessoaByID(Pessoa pessoa)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("STP_SEL_PESSOA_ByID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ID", pessoa.Id));


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Pessoa obj = new Pessoa();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj.Id = Convert.ToInt32(reader["ID"]);
                                obj.Nome = Convert.ToString(reader["NOME"]);
                                obj.Sobrenome = Convert.ToString(reader["SOBRENOME"]);
                                obj.Nacionalidade = Convert.ToString(reader["NACIONALIDADE"]);
                                obj.Cep = Convert.ToString(reader["CEP"]);
                                obj.Estado = Convert.ToString(reader["ESTADO"]);
                                obj.Cidade = Convert.ToString(reader["CIDADE"]);
                                obj.Logradouro = Convert.ToString(reader["LOGRADOURO"]);
                                obj.Email = Convert.ToString(reader["EMAIL"]);
                                obj.Telefone = Convert.ToString(reader["TELEFONE"]);
                            }
                        }
                        return obj;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}