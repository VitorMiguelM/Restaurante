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
            command.CommandText = "SELECT id, nome_completo, email, senha, celular, data_nascimento, cpf, estado, cidade, bairro, logradouro, cep FROM clientes";
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            foreach (DataRow linha in table.Rows)
            {
                Clientes cliente = new Clientes()
                {
                    Id = Convert.ToInt32(linha[0].ToString()),
                    NomeCompleto = linha[1].ToString(),
                    Email = linha[2].ToString(),
                    Senha = linha[3].ToString(),
                    Celular = linha[4].ToString(),
                    DataNascimento = Convert.ToDateTime(linha[5].ToString()),
                    CPF = linha[6].ToString(),
                    Estado = linha[7].ToString(),
                    Cidade = linha[8].ToString(),
                    Bairro = linha[9].ToString(),
                    Logradouro = linha[10].ToString(),
                    CEP = linha[11].ToString()
                };
                clientes.Add(cliente);
            }
            return clientes;
        }

        public int Cadastrar(Clientes clientes)
        {
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = @"INSERT INTO clientes(nome_completo, email, senha, celular, data_nascimento, cpf, estado, cidade, bairro, logradouro, cep) OUTPUT INSERTED.ID VALUES (@NOME_COMPLETO, @EMAIL, @SENHA, @CELULAR, @DATA_NASCIMENTO, @CPF, @ESTADO, @CIDADE, @BAIRRO, @LOGRADOURO, @CEP)";
            command.Parameters.AddWithValue("@NOME_COMPLETO", clientes.NomeCompleto);
            command.Parameters.AddWithValue("@EMAIL", clientes.Email);
            command.Parameters.AddWithValue("@SENHA", clientes.Senha);
            command.Parameters.AddWithValue("@CELULAR", clientes.Celular);
            command.Parameters.AddWithValue("@DATA_NASCIMENTO", clientes.DataNascimento);
            command.Parameters.AddWithValue("@CPF", clientes.CPF);
            command.Parameters.AddWithValue("@ESTADO", clientes.Estado);
            command.Parameters.AddWithValue("@CIDADE", clientes.Cidade);
            command.Parameters.AddWithValue("@BAIRRO", clientes.Bairro);
            command.Parameters.AddWithValue("@LOGRADOURO", clientes.Logradouro);
            command.Parameters.AddWithValue("@CEP", clientes.CEP);
            int id = Convert.ToInt32(command.ExecuteScalar().ToString());
            return id;
        }

        public bool Alterar(Clientes clientes)
        {
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "UPDATE clientes SET nome_completo = @NOME_COMPLETO, email = @EMAIL, senha = @SENHA, data_nascimento = @DATA_NASCIMENTO, cpf = @CPF, estado = @ESTADO, cidade = @CIDADE, bairro = @BAIRRO, logradouro = @LOGRADOURO, cep = @CEP WHERE id = @ID";
            command.Parameters.AddWithValue("@NOME_COMPLETO", clientes.NomeCompleto);
            command.Parameters.AddWithValue("@EMAIL", clientes.Email);
            command.Parameters.AddWithValue("@SENHA", clientes.Senha);
            command.Parameters.AddWithValue("@CELULAR", clientes.Celular);
            command.Parameters.AddWithValue("@DATA_NASCIMENTO", clientes.DataNascimento);
            command.Parameters.AddWithValue("@CPF", clientes.CPF);
            command.Parameters.AddWithValue("@ESTADO", clientes.Estado);
            command.Parameters.AddWithValue("@CIDADE", clientes.Cidade);
            command.Parameters.AddWithValue("@BAIRRO", clientes.Bairro);
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
            command.CommandText = "SELECT nome_completo, email, senha, celular, data_nascimento, cpf, estado, cidade, bairro, logradouro, cep FROM clientes WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            if (table.Rows.Count == 1)
            {
                cliente = new Clientes();
                cliente.Id = id;
                cliente.NomeCompleto = table.Rows[0]["nome_completo"].ToString();
                cliente.Email = table.Rows[0]["email"].ToString();
                cliente.Senha = table.Rows[0]["senha"].ToString();
                cliente.Celular = table.Rows[0]["celular"].ToString();
                cliente.DataNascimento = Convert.ToDateTime(table.Rows[0]["data_nascimento"].ToString());
                cliente.CPF = table.Rows[0]["cpf"].ToString();
                cliente.Estado = table.Rows[0]["estado"].ToString();
                cliente.Cidade = table.Rows[0]["cidade"].ToString();
                cliente.Bairro = table.Rows[0]["bairro"].ToString();
                cliente.Logradouro = table.Rows[0]["logradouro"].ToString();
                cliente.CEP = table.Rows[0]["cep"].ToString();
            }
            return cliente;
        }
    }
}