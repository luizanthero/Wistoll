using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StatusDB
/// </summary>
public class StatusDB
{
    public static int Insert(Status sta)
    {
        int retorno = 0; // 0 = OK / -2 = Erro

        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;

            string sql = "insert into sta_status(sta_valor, cod_fun) values (?sta_valor, ?cod_fun);";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?sta_valor", sta.Sta_valor));
            objCommand.Parameters.Add(Mapped.Parameter("?cod_fun", sta.Cod_fun));
            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            retorno = 0;
        }
        catch (Exception)
        {
            retorno = -2;
        }
        return retorno;
    }

    public static Status Select(int sta_cod)
    {
        Status sta = null;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from sta_status where sta_cod=?sta_cod;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?sta_cod", sta_cod));
            objReader = objComando.ExecuteReader();

            while (objReader.Read())
            {
                sta = new Status();
                sta.Sta_cod = Convert.ToInt32(objReader["sta_cod"]);
                sta.Sta_valor = Convert.ToString(objReader["sta_valor"]);
                if (objReader["cod_fun"] == DBNull.Value)
                {
                    sta.Cod_fun = null;
                }
                else
                {
                    sta.Cod_fun = Convert.ToInt32(objReader["cod_fun"]);
                }
            }

            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            return sta;
        }
        catch
        {
            return sta = null;
        }
    }

    public static int Update(Status sta)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update sta_status set sta_valor=?valor, cod_fun=?cod_fun where sta_cod=?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?valor", sta.Sta_valor));
            objComando.Parameters.Add(Mapped.Parameter("?codigo", sta.Sta_cod));
            objComando.Parameters.Add(Mapped.Parameter("?cod_fun", sta.Cod_fun));
            objComando.ExecuteNonQuery();
            objComando.Dispose();
            objConexao.Dispose();
            objConexao.Close();
        }
        catch
        {
            erro = -2;
        }

        return erro;
    }

    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select * from sta_status;";

        objComando = Mapped.Command(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }
}