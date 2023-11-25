using DAL.Base;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using Dapper;

namespace DAL
{
    public class ODSDAL : IODSDAL
    {
        public List<Indicador> BuscarObjetivos(IRepositoryBase repository)
        {
            SqlConnection con = new SqlConnection(repository.ConnectionString);
            StringBuilder strSql = new StringBuilder();

            try
            {
                con.Open();

                strSql.AppendLine("SELECT DISTINCT descricao, codigo ");
                strSql.AppendLine("FROM INDICADOR");

                SqlCommand cmd = new SqlCommand(strSql.ToString(), con);
                cmd.CommandTimeout = 120;
                SqlDataReader reader = cmd.ExecuteReader();

                List<Indicador> lLstObj = new List<Indicador>();

                while (reader.Read())
                {
                    Indicador lObj = new Indicador();

                    // Certifique-se de ajustar os índices de coluna para corresponder à ordem da sua consulta SELECT
                    lObj.descricao = reader.IsDBNull(0) ? "" : reader.GetString(0);
                    lObj.codigo = reader.IsDBNull(1) ? "" : reader.GetString(1);

                    lLstObj.Add(lObj);
                }

                con.Close();
                return lLstObj;
            }
            catch (Exception e)
            {
                throw new System.InvalidOperationException("Desculpa, estamos com um problema! Por favor avise a nossa equipe. Erro: " + e.Message);
            }
        }

        public List<ObjetivoIndicador> BuscarObjetivosIndicadores(IRepositoryBase repository)
        {
            SqlConnection con = new SqlConnection(repository.ConnectionString);
            StringBuilder strSql = new StringBuilder();

            try
            {
                con.Open();

                strSql.AppendLine("SELECT  distinct o.brasil, o.global, i.descricao");
                strSql.AppendLine("FROM objetivo o");
                strSql.AppendLine("JOIN ods od ON o.id_objetivo = od.id_objetivo");
                strSql.AppendLine("JOIN indicador i ON od.id_ods = i.id_ods;");

                SqlCommand cmd = new SqlCommand(strSql.ToString(), con);               
                SqlDataReader reader = cmd.ExecuteReader();

                List<ObjetivoIndicador> lLstObj = new List<ObjetivoIndicador>();

                while (reader.Read())
                {
                    ObjetivoIndicador lObj = new ObjetivoIndicador();

                    // Certifique-se de ajustar os índices de coluna para corresponder à ordem da sua consulta SELECT
                    lObj.brasil = reader.IsDBNull(0) ? "" : reader.GetString(0);
                    lObj.global = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    lObj.descricao = reader.IsDBNull(2) ? "" : reader.GetString(2);

                    lLstObj.Add(lObj);
                }

                con.Close();
                return lLstObj;
            }
            catch (Exception e)
            {
                throw new System.InvalidOperationException("Desculpa, estamos com um problema! Por favor avise a nossa equipe. Erro: " + e.Message);
            }
        }


        public IEnumerable<Indicador> BuscarIndicador(IRepositoryBase repository, string codigo)
        {
            SqlConnection con = new SqlConnection(repository.ConnectionString);
            StringBuilder strSql = new StringBuilder();

            try
            {
                con.Open();

                strSql.AppendLine("SELECT ano, regiao, codigo, consumo");
                strSql.AppendLine("FROM INDICADOR");
                strSql.AppendLine("WHERE codigo = '" + codigo + "' ");

                IEnumerable<Indicador> lLstIndicador = con.Query<Indicador>(strSql.ToString());
               
                con.Close();
                return lLstIndicador;
            }
            catch (Exception e)
            {
                throw new System.InvalidOperationException("Desculpa, estamos com um problema! Por favor avise a nossa equipe. Erro: " + e.Message.ToString());
            }
        }

        public List<Indicador> BuscarIndicadorPorRegiao(IRepositoryBase repository, Indicador indicador)
        {
            SqlConnection con = new SqlConnection(repository.ConnectionString);
            StringBuilder strSql = new StringBuilder();

            try
            {
                con.Open();

                strSql.AppendLine("SELECT ano, regiao, consumo");
                strSql.AppendLine("FROM INDICADOR");
                strSql.AppendLine("WHERE codigo = '" + indicador.codigo + "' ");
                strSql.AppendLine("AND regiao = '" + indicador.regiao + "' ");

                SqlCommand cmd = new SqlCommand(strSql.ToString(), con);
                SqlDataReader reader = cmd.ExecuteReader();
                List<Indicador> lLstIndicador = new List<Indicador>();
                while (reader.Read())
                {
                    Indicador lObjIndicador = new Indicador();

                    lObjIndicador.ano = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    lObjIndicador.regiao = reader.IsDBNull(1) ? "" : reader.GetString(1);                    
                    lObjIndicador.consumo = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);

                    lLstIndicador.Add(lObjIndicador);
                }
                con.Close();
                return lLstIndicador;
            }
            catch (Exception e)
            {
                throw new System.InvalidOperationException("Desculpa, estamos com um problema! Por favor avise a nossa equipe. Erro: " + e.Message.ToString());
            }
        }


    }
}
