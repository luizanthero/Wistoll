using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AuditoriaDB
/// </summary>
public class AuditoriaDB
{
    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

            string sql = "select aud_cod, aud_funcionario, pes_nome as funcionario, pes_sobrenome as sobrenome, " + 
                            "fun_matricula as matricula, " +
                                "aud_tabela, aud_acao as acao, aud_campoNome as campo, aud_tabela as tabela, aud_data as dataAcao, aud_data as dataHora " + 
                                    "from aud_auditoria " +
                                        "inner join fun_funcionario on fun_cod = aud_funcionario inner " +
                                            "join pes_pessoa using (pes_cod)" +
                                                "where aud_tabela <> 'Funcionário Processo' and aud_tabela <> " + 
                                                    "'Detalhe Processo' and aud_tabela <> 'Funcionário Modulo' " +
                                                        "and aud_tabela <> 'Contato';";

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

    public static DataSet SelectPerfilAud()
    {
        DataSet ds = new DataSet();
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

           string sql = "select aud_cod, aud_funcionario, pes_nome as funcionario, pes_sobrenome as sobrenome, " +
                            "fun_matricula as matricula, " +
                                "aud_tabela, aud_acao as acao, aud_campoNome as campo, aud_tabela as tabela, aud_data as dataAcao, aud_data as dataHora " +
                                    "from aud_auditoria " +
                                        "inner join fun_funcionario on fun_cod = aud_funcionario inner " +
                                            "join pes_pessoa using (pes_cod)" +
                                                "order by dataAcao desc LIMIT 4;";

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

    public static DataSet SelectPerfilAudCon(int fun_cod)
    {
        DataSet ds = new DataSet();
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

            string sql = @"select aud_cod, aud_funcionario, pes_nome as funcionario, pes_sobrenome as sobrenome, 
                            fun_matricula as matricula,
                              aud_tabela, aud_acao as acao, aud_campoNome as campo, aud_tabela as tabela, aud_data as dataAcao, aud_data as dataHora 
                                from aud_auditoria 
                                    inner join fun_funcionario on fun_cod = aud_funcionario inner 
                                        join pes_pessoa using (pes_cod) where fun_cod = ?fun_cod 
                                            order by dataAcao desc LIMIT 4;";

//            string texto = @"jonatas
//leon dias
// truco 
//pede 6 ladrão";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?fun_cod", fun_cod));
            objDataAdapter = Mapped.Adapter(objComando);
            objDataAdapter.Fill(ds);
            
            objComando.Dispose();
            objConexao.Dispose();
            objConexao.Close();
            return ds;
        }
        catch (Exception e)
        {
            return ds = null;
        }
    }
}