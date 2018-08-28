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
                    DataNascimento = Convert.ToDateTime(linha[5].ToString()),
                    CPF = Convert.ToDouble(linha[6].ToString()),
                    Estado = linha[7].ToString(),
                    Cidade = linha[8].ToString(),
                    Logradouro = linha[9].ToString(),
                    CEP = linha[10].ToString()
                };
                clientes.Add(cliente);
            }
            return clientes;
        }

        public int Cadastrar(Clientes clientes)
        {
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = @"INSERT INTO clientes(nome_completo, login, senha, celular, data_nascimento, cpf, estado, cidade, logradoro, cep) OUTPUT INSERTED.ID VALUES (@NOME_COMPLETO, @LOGIN, @SENHA, @CELULAR, @DATA_NASCIMENTO, @CPF, @ESTADO, @CIDADE, @LOGRADOURO, @CEP)";
            command.Parameters.AddWithValue("@NOME_COMPLETO", clientes.NomeCompleto);
            command.Parameters.AddWithValue("@LOGIN", clientes.Login);
            command.Parameters.AddWithValue("@SENHA", clientes.Senha);
            command.Parameters.AddWithValue("@CELULAR", clientes.Celular);
            command.Parameters.AddWithValue("@DATA_NASCIMENTO", clientes.DataNascimento);
            command.Parameters.AddWithValue("@CPF", clientes.CPF);
            command.Parameters.AddWithValue("@ESTADO", clientes.Estado);
            command.Parameters.AddWithValue("@CIDADE", clientes.Cidade);
            command.Parameters.AddWithValue("@LOGRADOURO", clientes.Logradouro);
            command.Parameters.AddWithValue("@CEP", clientes.CEP);
            int id = Convert.ToInt32(command.ExecuteScalar().ToString());
            return id;
        }

        public bool Alterar(Clientes clientes)
        {
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "UPDATE clientes SET nome_completo = @NOME_COMPLETO, login = @LOGIN, senha = @SENHA, data_nascimento = @DATA_NASCIMENTO, cpf = @CPF, estado = @ESTADO, cidade = @CIDADE, logradouro = @LOGRADOURO, cep = @CEP WHERE id = @ID";
            command.Parameters.AddWithValue("@NOME_COMPLETO", clientes.NomeCompleto);
            command.Parameters.AddWithValue("@LOGIN", clientes.Login);
            command.Parameters.AddWithValue("@SENHA", clientes.Senha);
            command.Parameters.AddWithValue("@CELULAR", clientes.Celular);
            command.Parameters.AddWithValue("@DATA_NASCIMENTO", clientes.DataNascimento);
            command.Parameters.AddWithValue("@CPF", clientes.CPF);
            command.Parameters.AddWithValue("@ESTADO", clientes.Estado);
            command.Parameters.AddWithValue("@CIDADE", clientes.Cidade);
            command.Parameters.AddWithValue("@LOGRADOURO", clientes.Logradouro);
            command.Parameters.AddWithValue("@CEP", clientes.CEP);
            command.Parameters.AddWithValue("@ID", clientes.Id);
            return command.ExecuteNonQuery() == 1;
        }

        public bool Excluir(int id)
        {
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "DELETE FROM clientes WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            return command.ExecuteNonQuery() == 1;
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
                cliente.NomeCompleto = table.Rows[0]["nome_completo"].ToString();
                cliente.Login = table.Rows[0]["login"].ToString();
                cliente.Senha = table.Rows[0]["senha"].ToString();
                cliente.Celular = table.Rows[0]["celular"].ToString();
                cliente.CPF = table.Rows[0]["cpf"].ToString();
                cliente.Estado = table.Rows[0]["estado"].ToString();
                cliente.Cidade = table.Rows[0]["cidade"].ToString();
                cliente.Logradouro = table.Rows[0]["logradouro"].ToString();
                cliente.CEP = table.Rows[0]["cep"].ToString();
            }
            return cliente;
        }
    }
}