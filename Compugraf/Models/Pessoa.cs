using Compugraf.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Compugraf.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Nacionalidade { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }


        public bool CadastrarPessoa(Pessoa pessoa)
        {
            try
            {
                var obj = new Pessoa
                {
                    Nome = pessoa.Nome,
                    Sobrenome = pessoa.Sobrenome,
                    Nacionalidade = pessoa.Nacionalidade,
                    Cep = pessoa.Cep,
                    Estado = pessoa.Estado,
                    Cidade = pessoa.Cidade,
                    Logradouro = pessoa.Logradouro,
                    Email = pessoa.Email,
                    Telefone = (!string.IsNullOrEmpty(pessoa.Telefone) ? RetirarMascaraTelefone(pessoa.Telefone) : string.Empty),
                };

                if (new PessoaDAO().CadastrarPessoa(obj))
                    return true;
                return false;
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
                if (new PessoaDAO().ExcluirPessoa(pessoa))
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        

        private string RetirarMascaraTelefone(string numero)
        {
            return numero = numero.Replace("(", "").Replace(")", "").Replace("-", "");
        }

        private string IncluirMascaraTelefone(string numero)
        {
            var lote1 = numero.Substring(0, 2);
            var lote2 = numero.Substring(2, 4);
            var lote3 = numero.Substring(4,10);
            return numero = "(" + lote1 + ")" + lote2 + "-" + lote3;
        }

        public List<Pessoa> ConsultarPessoa(Pessoa pessoa)
        {
            try
            {
                return new PessoaDAO().ConsultarPessoa(pessoa);
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
                return new PessoaDAO().ConsultarPessoaByID(pessoa);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}