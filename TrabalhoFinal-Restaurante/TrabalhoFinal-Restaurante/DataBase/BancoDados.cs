using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrabalhoFinal_Restaurante.DataBase
{
    public class BancoDados
    {
        private static string connectionString;

        static BancoDados()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        }

        public SqlCommand
    }
}