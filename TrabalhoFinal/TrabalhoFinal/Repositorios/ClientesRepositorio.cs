using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TrabalhoFinal.DataBase;
using TrabalhoFinal.Models;

namespace TrabalhoFinal.Repositorios
{
    public class ClientesRepositorio
    {
        public List<Clientes> ObterTodos()
        {
            List<Clientes> clientes = new List<Clientes>();
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "SELECT id, nome_completo, login, senha, celular, data_nascimento, cpf, estado, cidade, logradouro, cep FROM clientes";
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            foreach (DataRow linha in table.Rows)
            {
                Clientes cliente
            }
        }
    }
}