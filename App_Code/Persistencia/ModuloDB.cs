using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ModuloDB
/// </summary>
public class ModuloDB
{
    public static Modulo Select(int mod_cod)
    {
        Modulo mod = null;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from mod_modulo where mod_cod = ?mod_cod";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?mod_cod", mod_cod));
            objReader = objComando.ExecuteReader();

            while (objReader.Read())
            {
                mod = new Modulo();
                mod.Mod_cod = Convert.ToInt32(objReader["mod_cod"]);
                mod.Mod_descricao = Convert.ToString(objReader["mod_descricao"]);
                mod.Mod_pagina = Convert.ToString(objReader["mod_pagina"]);
                mod.Mod_padrao = Convert.ToInt32(objReader["mod_padrao"]);
                if (objReader["cod_fun"] == DBNull.Value)
                {
                    mod.Cod_fun = null;
                }
                else
                {
                    mod.Cod_fun = Convert.ToInt32(objReader["cod_fun"]);
                }
            }

            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            return mod;
        }
        catch
        {
            return mod = null;
        }
    }

    public static int Insert(Modulo mod)
    {
        int retorno = 0;

        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;

            string sql = "insert into mod_modulo(mod_descricao, mod_pagina, mod_padrao, cod_fun) values " + 
                            "(?mod_descricao, ?mod_pagina, ?mod_padrao, ?cod_fun);";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?mod_descricao", mod.Mod_descricao));
            if (mod.Mod_pagina == "")
            {
                objCommand.Parameters.Add(Mapped.Parameter("?mod_pagina", null));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?mod_pagina", mod.Mod_pagina));
            }
            objCommand.Parameters.Add(Mapped.Parameter("?mod_padrao", mod.Mod_padrao));
            objCommand.Parameters.Add(Mapped.Parameter("?cod_fun", mod.Cod_fun));
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

    public static DataSet ModuloUsuario(int fun_cod)
    {
        DataSet ds = new DataSet();
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

            string sql = "select * from mod_modulo inner join fun_mod using(mod_cod) where fun_cod=?fun_cod;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?fun_cod", fun_cod));
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

            string sql = "select * from mod_modulo;";

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

    public static DataSet SelectPadrao()
    {
        DataSet ds = new DataSet();
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

            string sql = "select * from mod_modulo where mod_padrao = 1;";

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

    public static DataSet SelectPadraoAdmin()
    {
        DataSet ds = new DataSet();
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

            string sql = "select * from mod_modulo where mod_padrao = 1 and mod_descricao <> 'Acessar o Sistema';";

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

    public static DataSet SelectAdicinoal()
    {
        DataSet ds = new DataSet();
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

            string sql = "select * from mod_modulo where mod_padrao <> 1 and mod_descricao <> 'Acessar o Sistema';";

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

    public static DataSet SelectAdicinoalAdmin()
    {
        DataSet ds = new DataSet();
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

            string sql = "select * from mod_modulo where mod_padrao <> 1;";

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

    public static DataSet SelectAdicinoalFuncionario(int fun_cod)
     {
         DataSet ds = new DataSet();
         try
         {
             IDbConnection objConexao;
             IDbCommand objComando;
             IDataAdapter objDataAdapter;
             objConexao = Mapped.Connection();

             string sql = "select * from fun_mod  where fun_cod = ?fun_cod;";

             objComando = Mapped.Command(sql, objConexao);
             objComando.Parameters.Add(Mapped.Parameter("?fun_cod", fun_cod));
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