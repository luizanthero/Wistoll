using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TramitacaoDB
/// </summary>
public class TramitacaoDB
{
    public static DataSet ConsultaUsuario(int set_cod)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select * from fun_funcionario where set_cod = ?set_cod and fun_chefeSetor = 1;";

        objComando = Mapped.Command(sql, objConexao);
        objComando.Parameters.Add(Mapped.Parameter("?set_cod", set_cod));
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public static int Atualizar(Tramitacao tra)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update tra_tramitacao set tra_localAtual=?localAtual, tra_localAnterior=?localAnterior, " + 
                "tra_localEnviado=?localAtual, tra_dataEnvio=?dataEnvio, fun_cod=?fun_cod, cod_fun=?cod_fun where tra_cod=?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?localAtual", tra.Tra_localAtual));
            objComando.Parameters.Add(Mapped.Parameter("?localAnterior", tra.Tra_localAnteriror));
            objComando.Parameters.Add(Mapped.Parameter("?dataEnvio", tra.Tra_dataEnvio));
            objComando.Parameters.Add(Mapped.Parameter("?fun_cod", tra.Funcionario.Fun_cod));
            objComando.Parameters.Add(Mapped.Parameter("?cod_fun", tra.Cod_fun));
            objComando.Parameters.Add(Mapped.Parameter("?codigo", tra.Tra_cod));
            objComando.ExecuteNonQuery();
            objComando.Dispose();
            objConexao.Dispose();
            objConexao.Close();
        }
        catch(Exception e)
        {
            erro = -2;
        }

        return erro;
    }

    public static string SelectDevolver()
    {
        string matricula = "";
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select fun_matricula as matricula from tra_tramitacao inner join fun_funcionario using(fun_cod) inner join pes_pessoa using(pes_cod);";

            objComando = Mapped.Command(sql, objConexao);
            objReader = objComando.ExecuteReader();

            while (objReader.Read())
            {
                matricula = Convert.ToString(objReader["matricula"]);
            }

            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            return matricula;
        }
        catch
        {
            return matricula = "";
        }
    }
}