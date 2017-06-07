using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PerfilDB
/// </summary>
public class PerfilDB
{
    public static Perfil Select(int pfl_cod)
    {
        Perfil pfl = null;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from pfl_perfil where pfl_cod = ?pfl_cod";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?pfl_cod", pfl_cod));
            //objComando.Parameters.Add(Mapped.Parameter("?senha", senha));
            objReader = objComando.ExecuteReader();

            while (objReader.Read())
            {
                pfl = new Perfil();
                pfl.Pfl_cod = Convert.ToInt32(objReader["pfl_cod"]);
                pfl.Pfl_descricao = Convert.ToString(objReader["pfl_descricao"]);
                pfl.Pfl_imagem = Convert.ToString(objReader["pfl_imagem"]);
                if (objReader["cod_fun"] == DBNull.Value)
                {
                    pfl.Cod_fun = null;
                }
                else
                {
                    pfl.Cod_fun = Convert.ToInt32(objReader["cod_fun"]);
                }
            }

            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            return pfl;
        }
        catch
        {
            return pfl = null;
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

            string sql = "select * from pfl_perfil where pfl_descricao <> 'Administrador';";

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