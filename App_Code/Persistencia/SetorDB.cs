using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

/// <summary>
/// Summary description for SetorDB
/// </summary>
public class SetorDB
{

    public static int Insert(Setor setor)
    {
        int retorno = 0; // 0 = OK / -2 = Erro

        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;

            string sql = "insert into Set_Setor(set_nome, set_descricao, dep_cod) values "
                + "(?set_nome, ?set_descricao, ?dep_cod);";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?set_nome", setor.Set_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?set_descricao", setor.Set_descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?dep_cod", setor.Departamento.Dep_cod));
            objCommand.Parameters.Add(Mapped.Parameter("?cod_fun", setor.Cod_fun));
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

    public static Setor Select(int set_cod)
    {
        Setor set = null;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from set_setor where set_cod=?set_cod;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?set_cod", set_cod));
            objReader = objComando.ExecuteReader();

            int departamento = 0;

            while (objReader.Read())
            {
                set = new Setor();
                set.Set_cod = Convert.ToInt32(objReader["set_cod"]);
                set.Set_descricao = Convert.ToString(objReader["set_descricao"]);
                set.Set_nome = Convert.ToString(objReader["set_nome"]);
                set.Set_ativo = Convert.ToString(objReader["set_ativo"]);
                if (objReader["cod_fun"] == DBNull.Value)
                {
                    set.Cod_fun = null;
                }
                else
                {
                    set.Cod_fun = Convert.ToInt32(objReader["cod_fun"]);
                }
                departamento = Convert.ToInt32(objReader["dep_cod"]);
            }

            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            set.Departamento = DepartamentoDB.Select(departamento);
            return set;
        }
        catch
        {
            return set = null;
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

            string sql = "select * from set_setor where set_nome <> 'Wistoll';";

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

    public static DataSet SelectAllAtivo()
    {
        DataSet ds = new DataSet();
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

            string sql = "select * from set_setor where set_nome <> 'Wistoll' and set_ativo <> 'Inativo';";

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

    public static DataSet SelectAllAdministrador()
    {
        DataSet ds = new DataSet();
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

            string sql = "select * from set_setor;";

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

    public static int Atualizar(Setor set)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update set_setor set set_descricao=?descricao, set_nome=?nome, cod_fun=?cod_fun where set_cod=?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?descricao", set.Set_descricao));
            objComando.Parameters.Add(Mapped.Parameter("?nome", set.Set_nome));
            objComando.Parameters.Add(Mapped.Parameter("?codigo", set.Set_cod));
            objComando.Parameters.Add(Mapped.Parameter("?cod_fun", set.Cod_fun));
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

    public static int Excluir(Setor set)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update set_setor set set_ativo = 'Inativo', cod_fun=?cod_fun where set_cod = ?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?codigo", set.Set_cod));
            objComando.Parameters.Add(Mapped.Parameter("?cod_fun", set.Cod_fun));
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

    public static int Ativar(Setor set)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update set_setor set set_ativo = 'Ativo', cod_fun=?cod_fun where set_cod = ?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?codigo", set.Set_cod));
            objComando.Parameters.Add(Mapped.Parameter("?cod_fun", set.Cod_fun));
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

        string sql = "select * from (select distinct set_cod, set_nome, set_descricao, set_ativo, dep_cod, dep_nome, pes_nome as nome, fun_matricula as matricula, fun_chefeSetor as chefe " +
                        "from dep_departamento inner join set_setor using (dep_cod) inner join fun_funcionario using (set_cod) inner join pes_pessoa using (pes_cod) " +
                            "where fun_chefeSetor = 1 " +
                                "union " +
                    "select distinct set_cod, set_nome, set_descricao, set_ativo, dep_cod, dep_nome, 'Não Definido!' as nome, 'Não Definido!' as matricula, 'Não Definido!' as chefe from dep_departamento " +
                        "inner join set_setor using (dep_cod) where set_nome <> 'Wistoll') as consultaSetor where set_ativo = ?ativo group by set_cod;";

        objComando = Mapped.Command(sql, objConexao);
        objComando.Parameters.Add(Mapped.Parameter("?ativo", ativo));
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }

    //select
    public static DataSet SelectAllChefe()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select distinct fun_cod, pfl_descricao, pes_nome, pes_sobrenome, fun_matricula " +
                        "from pes_pessoa inner join fun_funcionario using(pes_cod) inner join pfl_perfil using(pfl_cod) " +
                            "where pfl_descricao <> 'Administrador';";

        objComando = Mapped.Command(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }

    //select
    public static DataSet SelectDepartamento()
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("select * from dep_departamento where dep_nome <> 'Wistoll' order by dep_nome;", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o DataSet com os dados do BD, 
        //O método Fill é o responsável por preencher o DataSet 
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    public static DataSet CountSetor()
    {

        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select count(set_cod) from set_setor where set_ativo <> 'Inativo' and set_nome <> 'Wistoll';";

        objComando = Mapped.Command(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public static DataSet CountSetorInativo()
    {

        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select count(set_cod) from set_setor where set_ativo = 'Inativo' and set_nome <> 'Wistoll';";

        objComando = Mapped.Command(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;

    }
}