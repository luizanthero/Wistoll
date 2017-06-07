using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ContatoDB
/// </summary>
public class ContatoDB
{
    public static int Insert(Contato con)
    {
        int retorno = 0; // 0 = OK / -2 = Erro

        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;

            string sql = "insert into con_contato values (0, ?tipo, ?valor, ?pes_cod, ?cod_fun); ";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?tipo", con.Con_tipo));
            objCommand.Parameters.Add(Mapped.Parameter("?valor", con.Con_valor));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_cod", con.Pessoa.Pes_cod));
            objCommand.Parameters.Add(Mapped.Parameter("?cod_fun", con.Cod_fun));
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

    public static Contato Select(int pes_cod)
    {
        Contato con = null;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from con_contato where pes_cod=?pes_cod;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?pes_cod", pes_cod));
            objReader = objComando.ExecuteReader();

            int pessoa = 0;

            while (objReader.Read())
            {
                con = new Contato();
                con.Con_cod = Convert.ToInt32(objReader["con_cod"]);
                con.Con_tipo = Convert.ToString(objReader["con_tipo"]);
                con.Con_valor = Convert.ToString(objReader["con_valor"]);
                if (objReader["cod_fun"] == DBNull.Value)
                {
                    con.Cod_fun = null;
                }
                else
                {
                    con.Cod_fun = Convert.ToInt32(objReader["cod_fun"]);
                }
                pessoa = Convert.ToInt32(objReader["pes_cod"]);
            }

            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            con.Pessoa = PessoaDB.Select(pessoa);
            return con;
        }
        catch
        {
            return con = null;
        }
    }

    public static int Excluir(int codigo)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "delete from con_contato where con_cod=?codigo";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?codigo", codigo));
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

    public static int Atualizar(Contato con)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update con_contato set con_valor=?valor, cod_fun=?cod_fun where con_cod=?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?valor", con.Con_valor));
            objComando.Parameters.Add(Mapped.Parameter("?codigo", con.Con_cod));
            objComando.Parameters.Add(Mapped.Parameter("?cod_fun", con.Cod_fun));
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

    public static DataSet SelectContatos(int pes_cod)
    {
        DataSet ds = new DataSet();

        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

            string sql = "select * from con_contato where pes_cod=?pes_cod;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?pes_cod", pes_cod));
            objDataAdapter = Mapped.Adapter(objComando);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            return ds;
        }
        catch
        {
            return ds = null;
        }
    }


    public static DataSet SelectContatoEmail(string box)
    {
        DataSet ds = new DataSet();

        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

            string sql = "select con_valor from con_contato where con_valor = ?email;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?email", box));
            objDataAdapter = Mapped.Adapter(objComando);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            return ds;
        }
        catch
        {
            return ds = null;
        }
    }


    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();

        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

            string sql = "select * from con_contato;";

            objComando = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objComando);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            return ds;
        }
        catch
        {
            return ds = null;
        }
    }

}