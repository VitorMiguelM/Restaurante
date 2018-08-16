using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Data.SqlClient;
using System.Linq;
using System.Web;
=======
using System.Data;
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

            SqlCommand command = new BancoDados

            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "SELECT id, nome, modo_preparo, propriedade_nutricional, preco, descricao FROM pratos";
            command.CommandText = "SELECT id, nome FROM ingredientes";
            DataTable table = new DataTable();

        }
    }
}