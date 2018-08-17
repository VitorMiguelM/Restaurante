using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TrabalhoFinal.DataBase;
using TrabalhoFinal.Models;

namespace TrabalhoFinal.Repositorio
{
    public class RestauranteRepositorio
    {
        public List<Pratos> ObterTodos()
        {
            List<Pratos> pratos = new List<Pratos>();
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "SELECT id, nome, modo_preparo, propriedade_nutricional, preco, descricao FROM pratos";
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            foreach (DataRow linha in table.Rows)
            {
                Pratos prato = new Pratos()
                {
                    Id = Convert.ToInt32(linha[0].ToString()),
                    Nome = linha[1].ToString(),
                    ModoDePreparo = linha[2].ToString(),
                    PropiedadesNaturais = linha[3].ToString(),
                    preco = Convert.ToDouble(linha[4].ToString()),
                    descricao = linha[5].ToString()
                };
                pratos.Add(prato);
            }
            return pratos;
        }

        public int Cadastrar(Pratos pratos)
        {
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = @"INSERT INTO pratos(nome, modo_preparo, propriedades_nutricionais, preco, descricao) OUTPUT INSERTED.ID VALUES (@NOME, @MODO_PREPARO, @PROPRIEDADES_NUTRICIONAIS, @PRECO, @DESCRICAO)";
            command.Parameters.AddWithValue("@NOME", pratos.Nome);
            command.Parameters.AddWithValue("@MODO_PREPARO", pratos.ModoDePreparo);
            command.Parameters.AddWithValue("@PROPRIEDADES_NUTRICIONAIS", pratos.PropiedadesNaturais);
            command.Parameters.AddWithValue("@PRECO", pratos.preco);
            command.Parameters.AddWithValue("@DESCRICAO", pratos.descricao);
            int id = Convert.ToInt32(command.ExecuteScalar().ToString());
            return id;
        }

        public bool Alterar(Pratos pratos)
        {
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "UPDATE pratos SET nome = @NOME, modo_preparo = @MODO_PREPARO, propriedades_nutricionais = @PROPRIEDADES_NUTRICIONAIS, preco = @PRECO, descricao = @DESCRICAO WHERE id = @ID";
            command.Parameters.AddWithValue("@NOME", pratos.Nome);
            command.Parameters.AddWithValue("@MODO_PREPARO", pratos.ModoDePreparo);
            command.Parameters.AddWithValue("@PROPRIEDADES_NUTRICIONAIS", pratos.PropiedadesNaturais);
            command.Parameters.AddWithValue("@PRECO", pratos.preco);
            command.Parameters.AddWithValue("@DESCRICAO", pratos.descricao);
            command.Parameters.AddWithValue("@ID", pratos.Id);
            return command.ExecuteNonQuery() == 1;
        }

        public bool Excluir(int id)
        {
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "DELETE FROM pratos WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            return command.ExecuteNonQuery() == 1;
        }

        public Pratos ObterPeloId(int id)
        {
            Pratos prato = null;
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "SELECT nome, modo_preparo, propriedades_nutricionais, preco, descricao FROM pratos WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            if (table.Rows.Count == 1)
            {
                prato = new Pratos();
                prato.Id = id;
                prato.Nome = table.Rows[0][0].ToString();
                prato.ModoDePreparo = table.Rows[0][1].ToString();
                prato.PropiedadesNaturais = table.Rows[0][2].ToString();
                prato.preco = Convert.ToDouble(table.Rows[0][3].ToString());
                prato.descricao = table.Rows[0][4].ToString();
            }
            return prato;
        }
    }
}