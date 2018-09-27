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
            command.CommandText = "SELECT id, nome_completo, email, login, senha, celular, data_nascimento, cpf, estado, cidade, bairro, logradouro, cep FROM clientes";
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            foreach (DataRow linha in table.Rows)
            {
                Clientes cliente = new Clientes()
                {
                    Id = Convert.ToInt32(linha[0].ToString()),
                    NomeCompleto = linha[1].ToString(),
                    Email = linha[2].ToString(),
                    Login = linha[3].ToString(),
                    Senha = linha[4].ToString(),
                    Celular = linha[5].ToString(),
                    DataNascimento = Convert.ToDateTime(linha[6].ToString()),
                    CPF = linha[7].ToString(),
                    Estado = linha[8].ToString(),
                    Cidade = linha[9].ToString(),
                    Bairro = linha[10].ToString(),
                    Logradouro = linha[11].ToString(),
                    CEP = linha[12].ToString()
                };
                clientes.Add(cliente);
            }
            return clientes;
        }

        public int Cadastrar(Clientes clientes)
        {
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = @"INSERT INTO clientes(nome_completo, email, login, senha, celular, data_nascimento, cpf, estado, cidade, bairro, logradouro, cep) OUTPUT INSERTED.ID VALUES (@NOME_COMPLETO, @EMAIL, @LOGIN, @SENHA, @CELULAR, @DATA_NASCIMENTO, @CPF, @ESTADO, @CIDADE, @BAIRRO, @LOGRADOURO, @CEP)";
            command.Parameters.AddWithValue("@NOME_COMPLETO", clientes.NomeCompleto);
            command.Parameters.AddWithValue("@EMAIL", clientes.Email);
            command.Parameters.AddWithValue("@LOGIN", clientes.Login);
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
            command.CommandText = "UPDATE clientes SET nome_completo = @NOME_COMPLETO, email = @EMAIL, login = @LOGIN, data_nascimento = @DATA_NASCIMENTO, cpf = @CPF, estado = @ESTADO, cidade = @CIDADE, bairro = @BAIRRO, logradouro = @LOGRADOURO, cep = @CEP WHERE id = @ID";
            command.Parameters.AddWithValue("@NOME_COMPLETO", clientes.NomeCompleto);
            command.Parameters.AddWithValue("@EMAIL", clientes.Email);
            command.Parameters.AddWithValue("@LOGIN", clientes.Login);
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
            command.CommandText = "SELECT nome_completo, email, login, senha, celular, data_nascimento, cpf, estado, cidade, bairro, logradouro, cep FROM clientes WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            if (table.Rows.Count == 1)
            {
                cliente = new Clientes
                {
                    Id = id,
                    NomeCompleto = table.Rows[0]["nome_completo"].ToString(),
                    Email = table.Rows[0]["email"].ToString(),
                    Login = table.Rows[0]["login"].ToString(),
                    Senha = table.Rows[0]["senha"].ToString(),
                    Celular = table.Rows[0]["celular"].ToString(),
                    DataNascimento = Convert.ToDateTime(table.Rows[0]["data_nascimento"].ToString()),
                    CPF = table.Rows[0]["cpf"].ToString(),
                    Estado = table.Rows[0]["estado"].ToString(),
                    Cidade = table.Rows[0]["cidade"].ToString(),
                    Bairro = table.Rows[0]["bairro"].ToString(),
                    Logradouro = table.Rows[0]["logradouro"].ToString(),
                    CEP = table.Rows[0]["cep"].ToString()
                };
            }
            return cliente;
        }

        public Clientes ObterLogin(string login, string senha)
        {
            Clientes loginSenha = null;
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "SELECT login, senha FROM clientes WHERE login = @LOGIN AND senha = @SENHA";
            command.Parameters.AddWithValue("@LOGIN", login);
            command.Parameters.AddWithValue("@SENHA", senha);
            DataTable tabela = new DataTable();
            tabela.Load(command.ExecuteReader());
            if (tabela.Rows.Count == 1)
            {
                loginSenha = new Clientes
                {
                    Login = tabela.Rows[0]["login"].ToString(),
                    Senha = tabela.Rows[0]["senha"].ToString()
                };
            }
            return loginSenha;
            
        }

        public static bool ValidarCPF (string CPF)
        {
            string valor = CPF.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];
            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                valor[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;

            }
            else
                if (numeros[10] != 11 - resultado)
                return false;
            return true;

        }
    }
}