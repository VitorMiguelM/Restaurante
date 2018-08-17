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
                    cpf
                };

            }
        }
    }
}