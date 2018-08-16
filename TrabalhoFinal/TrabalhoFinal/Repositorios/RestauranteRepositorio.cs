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
        public int Cadastro(Pratos prato)
        {
            SqlCommand comando = new BancoDados().ObterConexao();
            comando.CommandText = @"INSERT  INTO restaurante(Nome ,Modo_Preparo,Propiedades_Naturais,Preco,E-mail,Telefone-Celular)output INSERT.ID VALUES(@NOME,@MODO_PREPARO,@PROPIEDADES_NATURAIS,@PRECO,@e-MAIL,@TELEFOMNE_CELULAR)";
            comando.Parameters.AddWithValue("@NOME",prato.Nome)
            return id;
        }

        /*public int Cadastrar(Pratos pratos)
        {
            SqlCommand command = new BancoDados().ObterConexcao();
            command.CommandText = @"INSERT INTO pratos(nome, modo_preparo, propriedades_nutricionais, preco, descricao) OUTPUT INSERTED.ID VALUES (@NOME, @MODO_PREPARO, @PROPRIEDADES"
        }*/
    }
}