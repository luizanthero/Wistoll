using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

/// <summary>
/// Summary description for DepartamentoDB
/// </summary>
public class DepartamentoDB
{
    public static int Insert(Departamento departamento)
    {
        int retorno = 0; // 0 = OK / -2 = Erro

        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;

            string sql = "insert into Dep_Departamento(dep_nome, dep_descricao, cod_fun) values "
                + "(?dep_nome, ?dep_descricao, ?cod_fun);";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?dep_nome", departamento.Dep_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?dep_descricao", departamento.Dep_descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?cod_fun", departamento.Cod_fun));
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

    public static Departamento Select(int dep_cod)
    {
        Departamento dep = null;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from dep_departamento where dep_cod=?dep_cod;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?dep_cod", dep_cod));
            objReader = objComando.ExecuteReader();

            while (objReader.Read())
            {
                dep = new Departamento();
                dep.Dep_cod = Convert.ToInt32(objReader["dep_cod"]);
                dep.Dep_descricao = Convert.ToString(objReader["dep_descricao"]);
                dep.Dep_nome = Convert.ToString(objReader["dep_nome"]);
                dep.Dep_ativo = Convert.ToString(objReader["dep_ativo"]);
                if (objReader["cod_fun"] == DBNull.Value)
                {
                    dep.Cod_fun = null;
                }
                else
                {
                    dep.Cod_fun = Convert.ToInt32(objReader["cod_fun"]);
                }
            }

            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            return dep;
        }
        catch
        {
            return dep = null;
        }
    }

    public static int Atualizar(Departamento dep)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update dep_departamento set dep_descricao=?descricao, dep_nome=?nome, cod_fun=?cod_fun where dep_cod=?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?descricao", dep.Dep_descricao));
            objComando.Parameters.Add(Mapped.Parameter("?nome", dep.Dep_nome));
            objComando.Parameters.Add(Mapped.Parameter("?codigo", dep.Dep_cod));
            objComando.Parameters.Add(Mapped.Parameter("?cod_fun", dep.Cod_fun));
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

    public static int Excluir(Departamento dep)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update dep_departamento set dep_ativo = 'Inativo', cod_fun=?cod_fun where dep_cod = ?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?codigo", dep.Dep_cod));
            objComando.Parameters.Add(Mapped.Parameter("?cod_fun", dep.Cod_fun));
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

    public static int Ativar(Departamento dep)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update dep_departamento set dep_ativo = 'Ativo', cod_fun=?cod_fun where dep_cod = ?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?codigo", dep.Dep_cod));
            objComando.Parameters.Add(Mapped.Parameter("?cod_fun", dep.Cod_fun));
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

    public static DataSet Consulta(string ativo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select * from (select distinct dep_cod, dep_nome, dep_descricao, dep_ativo, pes_nome as nome, fun_matricula as matricula, fun_chefeDepartamento as chefe " +
                        "from dep_departamento inner join set_setor using (dep_cod) " +
                            "inner join fun_funcionario using (set_cod) inner join pes_pessoa using (pes_cod) " +
                                "where fun_chefeDepartamento = 1 " +
                                    "union " +
                    "select distinct dep_cod, dep_nome, dep_descricao, dep_ativo, 'Não Definido!' as nome, 'Não Definido!' as matricula, 'Não Definido!' as chefe from dep_departamento " +
                        "left join set_setor using (dep_cod) where dep_nome <> 'Wistoll') as consultaDepartamento where dep_ativo = ?ativo group by dep_cod;";

        objComando = Mapped.Command(sql, objConexao);
        objComando.Parameters.Add(Mapped.Parameter("?ativo", ativo));
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public static DataSet CountDepartamento()
    {

        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select count(dep_cod) from dep_departamento where dep_ativo <> 'Inativo' and dep_nome <> 'Wistoll';";

        objComando = Mapped.Command(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;

    }

    public static DataSet CountDepartamentoInativo()
    {

        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select count(dep_cod) from dep_departamento where dep_ativo = 'Inativo' and dep_nome <> 'Wistoll';";

        objComando = Mapped.Command(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;

    }
}