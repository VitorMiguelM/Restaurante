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
            command.CommandText = "SELECT id, nome, celular, cpf, horario, pagamento FROM reservas";
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
                    Horario = Convert.ToDateTime(linha[4].ToString()),
                    Pagamento = linha[5].ToString()
                };
                reservas.Add(reserva);
            }
            return reservas;
        }
        
        public int Cadastro(Reserva reserva)
        {
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = @"INSERT INTO reservas (nome, celular, cpf, horario, pagamento) OUTPUT INSERTED.ID VALUES (@NOME, @CELULAR, @CPF, @HORARIO, @PAGAMENTO)";
            command.Parameters.AddWithValue("@NOME", reserva.Nome);
            command.Parameters.AddWithValue("@CELULAR", reserva.Celular);
            command.Parameters.AddWithValue("@CPF", reserva.CPF);
            command.Parameters.AddWithValue("@HORARIO", reserva.Horario);
            command.Parameters.AddWithValue("@PAGAMENTO", reserva.Pagamento);
            int id = Convert.ToInt32(command.ExecuteScalar().ToString());
            return id;
        }

        public bool Alterar(Reserva reserva)
        {
            SqlCommand comando = new BancoDados().ObterConexcao();
            comando.CommandText = "UPDATE reservas SET nome = @NOME, celular = @CELULAR, cpf = @CPF, horario = @HORARIO, pagamento = @PAGAMENTO WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", reserva.Nome);
            comando.Parameters.AddWithValue("@CELULAR", reserva.Celular);
            comando.Parameters.AddWithValue("@CPF", reserva.CPF);
            comando.Parameters.AddWithValue("@HORARIO", reserva.Horario);
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
            command.CommandText = "SELECT nome, celular, cpf, horario, pagamento FROM Reservas WHERE id = @ID";
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
                reserva.Horario = Convert.ToDateTime(tabela.Rows[0][3].ToString());
                reserva.Pagamento = tabela.Rows[0][4].ToString();
            }
            return reserva;
        }
    }
}