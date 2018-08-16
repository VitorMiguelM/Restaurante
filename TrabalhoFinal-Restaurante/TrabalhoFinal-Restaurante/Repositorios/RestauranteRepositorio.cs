using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TrabalhoFinal_Restaurante.DataBase;
using TrabalhoFinal_Restaurante.Models;

namespace TrabalhoFinal_Restaurante.Repositorio
{
    public class RestauranteRepositorio
    {
        public List<pratos> ObterTodos()
        {
            List<pratos> Pratos = new List<pratos>();
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = "SELECT id, nome, modo_preparo, propriedade_nutricional, preco, descricao FROM pratos";
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            foreach (DataRow linha in table.Rows)
            {
                pratos pratos = new pratos()
                {
                    Id = Convert.ToInt32(linha[0].ToString()),
                    Nome = linha[1].ToString(),
                    ModoDePreparo = linha[2].ToString(),
                    PropiedadesNaturais = linha[3].ToString(),
                    preco = Convert.ToDouble(linha[4].ToString()),
                    descricao = linha[5].ToString()
                };
                Pratos.Add(pratos);
            }
            return
        }
    }
}