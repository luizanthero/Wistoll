using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AnexosDB
/// </summary>
public class AnexosDB
{
    public static int Insert(Anexos anx)
    {
        int retorno = 0; // 0 = OK / -2 = Erro

        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;

            string sql = "insert into anx_anexos values (0, ?nome, ?descricao, ?dpr_cod, ?cod_fun); ";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?nome", anx.Anx_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?descricao", anx.Anx_descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?dpr_cod", anx.Dpr_cod));
            objCommand.Parameters.Add(Mapped.Parameter("?cod_fun", anx.Cod_fun));
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

    public static DataSet Select(int codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select * from anx_anexos where dpr_cod = ?codigo";

        objComando = Mapped.Command(sql, objConexao);
        objComando.Parameters.Add(Mapped.Parameter("?codigo", codigo));
        objDataAdapter = Mapped.Adapter(objComando);
        objComando.ExecuteNonQuery();
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }
}