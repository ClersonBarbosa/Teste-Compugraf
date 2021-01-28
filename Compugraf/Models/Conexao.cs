using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Compugraf.Models
{
    public class Conexao
    {
        public string strConn { get; set; }

        public Conexao()
        {
            this.strConn = WebConfigurationManager.ConnectionStrings["Compugraf"].ConnectionString;
        }

 
    }
}