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
                Clientes cliente = new Clientes()
                {
                    Id = Convert.ToInt32(linha[0].ToString()),
                    NomeCompleto = linha[1].ToString(),
                    Login = linha[2].ToString(),
                    Senha = linha[3].ToString(),
                    Celular = Convert.ToInt32(linha[4].ToString()),
                    DataNacimento = linha[5].ToString(),
                    CPF = Convert.ToDouble(linha[6].ToString()),
                    Estado = linha[7].ToString(),
                    Cidade = linha[8].ToString(),
                    Logadouro = linha[9].ToString(),
                    cep = linha[10].ToString()
                };
                clientes.Add(cliente);
            }
            return clientes;
        }

        public int Cadastrar(Clientes clientes)
        {
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = @"INSERT INTO clientes(nome_completo, login, senha, celular, data_nascimento, cpf, estado, cidade, logradoro"
        }

        public Clientes ObterPeloId(int id)
        {
            Clientes cliente = null;
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "SELECT nome_completo, login, senha, celular, data_nascimento, cpf, estado, cidade, logradouro, cep FROM clientes WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            if (table.Rows.Count == 1)
            {
                cliente = new Clientes();
                cliente.Id = id;
                cliente.NomeCompleto = table.Rows[0][0].ToString();
                cliente.Login = table.Rows[0][1].ToString();
                cliente.Senha = table.Rows[0][2].ToString();
                cliente.Celular = Convert.ToDouble(table.Rows[0][3].ToString());
                cliente.CPF = Convert.ToDouble(table.Rows[0][4].ToString());
                cliente.Estado = table.Rows[0][5].ToString();
                cliente.Cidade = table.Rows[0][6].ToString();
                cliente.Logadouro = table.Rows[0][7].ToString();
                cliente.cep = table.Rows[0][8].ToString();
            }
            return cliente;
        }
    }
}