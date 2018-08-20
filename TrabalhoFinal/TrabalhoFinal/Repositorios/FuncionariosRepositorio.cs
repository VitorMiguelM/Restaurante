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

        public bool Alterar
    }
}