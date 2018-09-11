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
    public class ReservaRepositorio
    {
        public List<Reserva> ObterTodos()
        {
            List<Reserva> reservas = new List<Reserva>();
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "SELECT id, nome, celular, cpf, pagamento FROM reservas";
            DataTable table = new DataTable();
            
            table.Load(command.ExecuteReader());
            foreach (DataRow linha in table.Rows)
            {
                Reserva reserva = new Reserva()
                {
                    Id = Convert.ToInt32(linha[0].ToString()),
                    Nome = linha[1].ToString(),
                    Celular = linha[2].ToString(),
                    CPF = linha[3].ToString(),
                    Pagamento = linha[4].ToString()
                };
                reservas.Add(reserva);
            }
            return reservas;
        }
        
        public int Cadastrar(Reserva reserva)
        {
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = @"INSERT INTO reservas (nome, celular, cpf, pagamento) OUTPUT INSERTED.ID VALUES (@NOME, @CELULAR, @CPF, @HORARIO, @PAGAMENTO)";
            command.Parameters.AddWithValue("@NOME", reserva.Nome);
            command.Parameters.AddWithValue("@CELULAR", reserva.Celular);
            command.Parameters.AddWithValue("@CPF", reserva.CPF);
            command.Parameters.AddWithValue("@PAGAMENTO", reserva.Pagamento);
            int id = Convert.ToInt32(command.ExecuteScalar().ToString());
            return id;
        }

        public bool Alterar(Reserva reserva)
        {
            SqlCommand comando = new BancoDados().ObterConexcao();
            comando.CommandText = "UPDATE reservas SET nome = @NOME, celular = @CELULAR, cpf = @CPF, pagamento = @PAGAMENTO WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", reserva.Nome);
            comando.Parameters.AddWithValue("@CELULAR", reserva.Celular);
            comando.Parameters.AddWithValue("@CPF", reserva.CPF);
            comando.Parameters.AddWithValue("@PAGAMENTO", reserva.Pagamento);
            comando.Parameters.AddWithValue("@ID", reserva.Id);
            return comando.ExecuteNonQuery() == 1;
        }

        public bool Excluir(int id)
        {

            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "DELETE FROM reservas WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            return command.ExecuteNonQuery() == 1;
        }

        public Reserva ObterPeloId(int id)
        {
            Reserva reserva = null;
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "SELECT nome, celular, cpf, pagamento FROM Reservas WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable tabela = new DataTable();
            tabela.Load(command.ExecuteReader());
            if (tabela.Rows.Count == 1)
            {
                reserva = new Reserva();
                reserva.Id = id;
                reserva.Nome = tabela.Rows[0][0].ToString();
                reserva.Celular = tabela.Rows[0][1].ToString();
                reserva.CPF = tabela.Rows[0][2].ToString();
                reserva.Pagamento = tabela.Rows[0][3].ToString();
            }
            return reserva;
        }

        public LoginSenhaReserva ObterLogin(string login, string senha)
        {
            LoginSenhaReserva loginsenha = null;
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "SELECT login, senha FROM reservas WHERE login = @LOGIN AND senha = @SENHA";
            command.Parameters.AddWithValue("@LOGIN", login);
            command.Parameters.AddWithValue("@SENHA", senha);
            DataTable tabela = new DataTable();
            tabela.Load(command.ExecuteReader());
            if (tabela.Rows.Count == 1)
            {
                loginsenha = new LoginSenhaReserva();
                loginsenha.Login = tabela.Rows[0][0].ToString();
                loginsenha.Senha = tabela.Rows[0][0].ToString();
            }
            return loginsenha;
        }
    }
}