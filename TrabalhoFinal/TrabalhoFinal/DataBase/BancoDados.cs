﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrabalhoFinal.DataBase
{
    public class BancoDados
    {
        private static string connectionString;

        static BancoDados() => connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public SqlCommand ObterConexcao
        {
            get
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                return command;
            }
        }
    }
}