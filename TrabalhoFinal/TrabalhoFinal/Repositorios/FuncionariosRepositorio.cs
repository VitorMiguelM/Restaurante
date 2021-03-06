﻿using System;
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
            SqlCommand command = new BancoDados().ObterConexcao;
            command.CommandText = "SELECT id, nome, sobrenome, senha, celular, data_nascimento, cpf, estado, cidade, bairro, logradouro, cep, cargo FROM funcionarios";
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            foreach (DataRow linha in table.Rows)
            {
                Funcionarios funcionario = new Funcionarios()
                {
                    Id = Convert.ToInt32(linha[0].ToString()),
                    Nome = linha[1].ToString(),
                    Sobrenome = linha[2].ToString(),
                    Senha = linha[3].ToString(),
                    Celular = linha[4].ToString(),
                    DataDeNascimento = linha[5].ToString(),
                    CPF = linha[6].ToString(),
                    Estado = linha[7].ToString(),
                    Cidade = linha[8].ToString(),
                    Bairro = linha[9].ToString(),
                    Logradouro = linha[10].ToString(),
                    CEP = linha[11].ToString(),
                    Cargo = linha[12].ToString()
                };
                funcionarios.Add(funcionario);
            }
            return funcionarios;
        }

        public int Cadastrar(Funcionarios funcionarios)
        {
            SqlCommand command = new BancoDados().ObterConexcao;
            command.CommandText = @"INSERT INTO funcionarios(nome, sobrenome, senha, celular, data_nascimento, cpf, estado, cidade, bairro, logradouro, cep, cargo) OUTPUT INSERTED.ID VALUES(@NOME, @SOBRENOME, @SENHA, @CELULAR, @DATA_NASCIMENTO, @CPF, @ESTADO, @CIDADE, @BAIRRO, @LOGRADOURO, @CEP, @CARGO)";
            command.Parameters.AddWithValue("@NOME", funcionarios.Nome);
            command.Parameters.AddWithValue("@SOBRENOME", funcionarios.Sobrenome);
            command.Parameters.AddWithValue("@SENHA", funcionarios.Senha);
            command.Parameters.AddWithValue("@CELULAR", funcionarios.Celular);
            command.Parameters.AddWithValue("@DATA_NASCIMENTO", funcionarios.DataDeNascimento);
            command.Parameters.AddWithValue("@CPF", funcionarios.CPF);
            command.Parameters.AddWithValue("@ESTADO", funcionarios.Estado);
            command.Parameters.AddWithValue("@CIDADE", funcionarios.Cidade);
            command.Parameters.AddWithValue("@BAIRRO", funcionarios.Bairro);
            command.Parameters.AddWithValue("@LOGRADOURO", funcionarios.Logradouro);
            command.Parameters.AddWithValue("@CEP", funcionarios.CEP);
            command.Parameters.AddWithValue("@CARGO", funcionarios.Cargo);
            int id = Convert.ToInt32(command.ExecuteScalar().ToString());
            return id;
        }

        public bool Alterar(Funcionarios funcionarios)
        {
            SqlCommand command = new BancoDados().ObterConexcao;
            command.CommandText = "UPDATE funcionarios SET nome = @NOME, sobrenome = @SOBRENOME, senha = @SENHA, celular = @CELULAR, data_nascimento = @DATA_NASCIMENTO, cpf = @CPF, estado = @ESTADO,  cidade = @CIDADE, bairro = @BAIRRO, logradouro = @LOGRADOURO, cep = @CEP, cargo = @CARGO WHERE id = @ID";
            command.Parameters.AddWithValue("@NOME", funcionarios.Nome);
            command.Parameters.AddWithValue("@SOBRENOME", funcionarios.Sobrenome);
            command.Parameters.AddWithValue("@SENHA", funcionarios.Senha);
            command.Parameters.AddWithValue("@CELULAR", funcionarios.Celular);
            command.Parameters.AddWithValue("@DATA_NASCIMENTO", funcionarios.DataDeNascimento);
            command.Parameters.AddWithValue("@CPF", funcionarios.CPF);
            command.Parameters.AddWithValue("@ESTADO", funcionarios.Estado);
            command.Parameters.AddWithValue("@CIDADE", funcionarios.Cidade);
            command.Parameters.AddWithValue("@BAIRRO", funcionarios.Bairro);
            command.Parameters.AddWithValue("@LOGRADOURO", funcionarios.Logradouro);
            command.Parameters.AddWithValue("@CEP", funcionarios.CEP);
            command.Parameters.AddWithValue("@CARGO", funcionarios.Cargo);
            command.Parameters.AddWithValue("@ID", funcionarios.Id);
            return command.ExecuteNonQuery() == 1;
        }

        public bool Excluir(int id)
        {
            SqlCommand command = new BancoDados().ObterConexcao;
            command.CommandText = "DELETE FROM funcionarios WHERE id - @ID";
            command.Parameters.AddWithValue("@ID", id);
            return command.ExecuteNonQuery() == 1;
        }

        public Funcionarios ObterPeloId(int id)
        {
            Funcionarios funcionario = null;
            SqlCommand command = new BancoDados().ObterConexcao;
            command.CommandText = "SELECT nome, sobrenome, senha, celular, data_nascimento, cpf, estado, cidade, bairro, logradouro, cep, cargo FROM funcionarios WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            if (table.Rows.Count == 1)
            {
                funcionario = new Funcionarios();
                funcionario.Id = id;
                funcionario.Nome = table.Rows[0][0].ToString();
                funcionario.Sobrenome = table.Rows[0][1].ToString();
                funcionario.Senha = table.Rows[0][2].ToString();
                funcionario.Celular = table.Rows[0][3].ToString();
                funcionario.DataDeNascimento = table.Rows[0][4].ToString();
                funcionario.CPF = table.Rows[0][5].ToString();
                funcionario.Estado = table.Rows[0][6].ToString();
                funcionario.Cidade = table.Rows[0][7].ToString();
                funcionario.Bairro = table.Rows[0][8].ToString();
                funcionario.Logradouro = table.Rows[0][9].ToString();
                funcionario.CEP = table.Rows[0][10].ToString();
                funcionario.Cargo = table.Rows[0][11].ToString();
            }
            return funcionario;
        }
    }
}