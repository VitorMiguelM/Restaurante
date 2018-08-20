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
    public class FuncionariosRepositorio
    {
        public List<Funcionarios> ObterTodos()
        {
            List<Funcionarios> funcionarios = new List<Funcionarios>();
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "SELECT id, nome, sobrenome, senha, celular, data_nascimento, cpf, estado, cidade, logradouro, cep, cargo FROM clientes";
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            foreach (DataRow linha in table.Rows)
            {
                Funcionarios funcionario = new Funcionarios()
                {
                    Id = Convert.ToInt32(linha[0].ToString()),
                    Nome = linha[1].ToString(),
                    SobreNome = linha[2].ToString(),
                    Senha = linha[3].ToString(),
                    Celular = Convert.ToInt32(linha[4].ToString()),
                    DataDeNacimento = Convert.ToDateTime(linha[5].ToString()),
                    CPF = Convert.ToDouble(linha[6].ToString()),
                    Estado = linha[7].ToString(),
                    Cidade = linha[8].ToString(),
                    Logradouro = linha[9].ToString(),
                    CEP = Convert.ToDouble(linha[10].ToString()),
                    Cargo = linha[11].ToString()
                };
                funcionarios.Add(funcionario);
            }
            return funcionarios;
        }

        public int Cadastrar(Funcionarios funcionarios)
        {
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = @"INSERT INTO funcionarios(nome, sobrenome, senha, celular, data_nascimento, cpf, estado, cidade, logradouro, cep, cargo) OUTPUT INSERTED.ID VALUES(@NOME, @SOBRENOME, @SENHA, @CELULAR, @DATA_NASCIMENTO, @CPF, @ESTADO, @CIDADE, @LOGRADOURO, @CEP, @CARGO)";
            command.Parameters.AddWithValue("@NOME", funcionarios.Nome);
            command.Parameters.AddWithValue("@SOBRENOME", funcionarios.SobreNome);
            command.Parameters.AddWithValue("@SENHA", funcionarios.Senha);
            command.Parameters.AddWithValue("@CELULAR", funcionarios.Celular);
            command.Parameters.AddWithValue("@DATA_NASCIMENTO", funcionarios.DataDeNacimento);
            command.Parameters.AddWithValue("@CPF", funcionarios.CPF);
            command.Parameters.AddWithValue("@ESTADO", funcionarios.Estado);
            command.Parameters.AddWithValue("@CIDADE", funcionarios.Cidade);
            command.Parameters.AddWithValue("@LOGRADOURO", funcionarios.Logradouro);
            command.Parameters.AddWithValue("@CEP", funcionarios.CEP);
            command.Parameters.AddWithValue("@CARGO", funcionarios.Cargo);
            int id = Convert.ToInt32(command.ExecuteScalar().ToString());
            return id;
        }

        public bool Alterar(Funcionarios funcionarios)
        {
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "UPDATE funcionarios SET nome = @NOME, sobrenome = @SOBRENOME, senha = @SENHA, celular = @CELULAR, data_nascimento = @DATA_NASCIMENTO, cpf = @CPF, estado = @ESTADO, cidade = @CIDADE, logradouro = @LOGRADOURO, cep = @CEP, cargo = @CARGO WHERE id = @ID";
            command.CommandText = @"INSERT INTO funcionarios(nome, sobrenome, senha, celular, data_nascimento, cpf, estado, cidade, logradouro, cep, cargo) OUTPUT INSERTED.ID VALUES(@NOME, @SOBRENOME, @SENHA, @CELULAR, @DATA_NASCIMENTO, @CPF, @ESTADO, @CIDADE, @LOGRADOURO, @CEP, @CARGO)";
            command.Parameters.AddWithValue("@NOME", funcionarios.Nome);
            command.Parameters.AddWithValue("@SOBRENOME", funcionarios.SobreNome);
            command.Parameters.AddWithValue("@SENHA", funcionarios.Senha);
            command.Parameters.AddWithValue("@CELULAR", funcionarios.Celular);
            command.Parameters.AddWithValue("@DATA_NASCIMENTO", funcionarios.DataDeNacimento);
            command.Parameters.AddWithValue("@CPF", funcionarios.CPF);
            command.Parameters.AddWithValue("@ESTADO", funcionarios.Estado);
            command.Parameters.AddWithValue("@CIDADE", funcionarios.Cidade);
            command.Parameters.AddWithValue("@LOGRADOURO", funcionarios.Logradouro);
            command.Parameters.AddWithValue("@CEP", funcionarios.CEP);
            command.Parameters.AddWithValue("@CARGO", funcionarios.Cargo);
            command.Parameters.AddWithValue("@ID", funcionarios.Id);
            return command.ExecuteNonQuery() == 1;
        }

        public bool Excluir(int id)
        {
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "DELETE FROM funcionarios WHERE id - @ID";
            command.Parameters.AddWithValue("@ID", id);
            return command.ExecuteNonQuery() == 1;
        }

        public Funcionarios ObterPeloId(int id)
        {
            Funcionarios funcionario = null;
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "SELECT nome, sobrenome, senha, celular, data_nascimento, cpf, estado, cidade, logradouro, cep, cargo FROM funcionarios WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            if (table.Rows.Count == 1)
            {
                funcionario = new Funcionarios();
                funcionario.Id = id;
                funcionario.Nome = table.Rows[0][0].ToString();
                funcionario.SobreNome = table.Rows[0][1].ToString();
                funcionario.Senha = table.Rows[0][2].ToString();
                funcionario.Celular = Convert.ToDouble(table.Rows[0][3].ToString());
                funcionario.DataDeNacimento = Convert.ToDateTime(table.Rows[0][4].ToString());
                funcionario.CPF = Convert.ToDouble(table.Rows[0][5].ToString());
                funcionario.Estado = table.Rows[0][6].ToString();
                funcionario.Cidade = table.Rows[0][7].ToString();
                funcionario.Logradouro = table.Rows[0][7].ToString();
                funcionario.CEP = Convert.ToDouble(table.Rows[0][8].ToString());
                funcionario.Cargo = table.Rows[0][9].ToString();
            }
            return funcionario;
        }
    }
}