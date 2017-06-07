using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ObservacaoDB
/// </summary>
public class ObservacaoDB
{
    public static int Insert(Observacao obs)
    {
        int retorno = 0; // 0 = OK / -2 = Erro

        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;

            string sql = "insert into obs_observacao values (0, ?obs_valor, ?obs_dataObservacao, ?tra_cod, ?fun_cod);";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?obs_valor", obs.Obs_valor));
            objCommand.Parameters.Add(Mapped.Parameter("?obs_dataObservacao", obs.Obs_dataObservacao));
            objCommand.Parameters.Add(Mapped.Parameter("?tra_cod", obs.Tramitacao.Tra_cod));
            objCommand.Parameters.Add(Mapped.Parameter("?fun_cod", obs.Funcionario.Fun_cod));
            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            retorno = 0;
        }
        catch (Exception e)
        {
            retorno = -2;
        }
        return retorno;
    }

    public static DataSet Select(int tra_cod)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select * from obs_observacao where tra_cod=?tra_cod order by obs_cod desc;";

        objComando = Mapped.Command(sql, objConexao);
        objComando.Parameters.Add(Mapped.Parameter("?tra_cod", tra_cod));
        objDataAdapter = Mapped.Adapter(objComando);
        objComando.ExecuteNonQuery();
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }
}