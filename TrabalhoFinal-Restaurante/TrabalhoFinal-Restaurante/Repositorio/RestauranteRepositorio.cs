using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TrabalhoFinal_Restaurante.DataBase;

namespace TrabalhoFinal_Restaurante.Repositorio
{
    public class RestauranteRepositorio
    {
        public List<Restaurante> ObterTodos()
        {
            List<Restaurante> restaurante = new List<Restaurante>();
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "SELECT "
        }
    }
}