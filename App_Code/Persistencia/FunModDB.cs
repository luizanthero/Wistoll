using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for FunModPflDB
/// </summary>
public class FunModDB
{
    public static FunMod Select(int fun_cod)
    {
        FunMod fmp = null;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from fun_mod where fun_cod=?fun_cod;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?fun_cod", fun_cod));
            objReader = objComando.ExecuteReader();

            int modulo = 0;
            int funcionario = 0;

            while (objReader.Read())
            {
                fmp = new FunMod();
                modulo = Convert.ToInt32(objReader["mod_cod"]);
                funcionario = Convert.ToInt32(objReader["fun_cod"]);
                if (objReader["cod_fun"] == DBNull.Value)
                {
                    fmp.Cod_fun = null;
                }
                else
                {
                    fmp.Cod_fun = Convert.ToInt32(objReader["cod_fun"]);
                }
            }

            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();

            fmp.Funcionario = FuncionarioDB.Select(funcionario);
            fmp.Modulo = ModuloDB.Select(modulo);

            return fmp;
        }
        catch (Exception e)
        {
            return fmp = null;
        }
    }

    public static DataSet SelectMenu(int fun_cod)
    {
        DataSet ds = null;
        try
        {
            ds = new DataSet();
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

            string sql = "select mod_descricao, mod_pagina from fun_funcionario inner join fun_mod using(fun_cod) " +
                            "inner join mod_modulo using (mod_cod) where fun_cod=?fun_cod; ";

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

    //public static DataSet SelectMenu()
    //{
    //    DataSet ds = null;
    //    try
    //    {
    //        ds = new DataSet();
    //        IDbConnection objConexao;
    //        IDbCommand objComando;
    //        IDataAdapter objDataAdapter;
    //        objConexao = Mapped.Connection();

    //        string sql = "select men.men_descricao, pag.pag_descricao from fun_mod_pfl_men as fmp " +
    //                        "inner join fun_funcionario as fun on fun.fun_cod = fmp.fun_cod " +
    //                            "inner join men_menu as men on men.men_cod = fmp.men_cod " +
    //                                "inner join pag_paginas as pag on pag.pag_cod = men.pag_cod";

    //        objComando = Mapped.Command(sql, objConexao);
    //        objDataAdapter = Mapped.Adapter(objComando);
    //        objDataAdapter.Fill(ds);
    //        objConexao.Close();
    //        objComando.Dispose();
    //        objConexao.Dispose();
    //        return ds;
    //    }
    //    catch
    //    {
    //        return ds = null;
    //    }
    //}

    public static DataSet SelectAll(int codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        objConexao = Mapped.Connection();

        string sql = "select * from fun_mod where fun_cod=?codigo;";

        objComando = Mapped.Command(sql, objConexao);
        objComando.Parameters.Add(Mapped.Parameter("?codigo", codigo));
        objComando.ExecuteNonQuery();
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }
}