using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

/// <summary>
/// Summary description for Processo
/// </summary>
public class ProcessoDB
{
    public static string Insert(Processo pro, string setor)
    {
        string retorno = ""; // 0 = OK / -2 = Erro

        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;

            string sql = "call cadastroProcesso" +
                "(?pro_numeroProcesso, ?pro_dataPedido, ?pro_ativo, ?pro_mrq, ?pro_req, ?pro_sta, ?pro_fun, " +
                    "?fun_cod, ?pfu_fun, null, ?dpr_fun, ?tra_localAtual, null, null, null, ?tra_fun, ?tra_cfu);";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pro_numeroProcesso", pro.Pro_numeroProcesso));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_dataPedido", pro.Pro_dataPedido));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_ativo", pro.Pro_ativo));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_mrq", pro.ModeloRequerimento.Mrq_cod));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_req", pro.Requerente.Req_cod));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_sta", pro.Status.Sta_cod));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_fun", pro.Cod_fun));
            objCommand.Parameters.Add(Mapped.Parameter("?fun_cod", pro.Cod_fun));
            objCommand.Parameters.Add(Mapped.Parameter("?pfu_fun", pro.Cod_fun));
            objCommand.Parameters.Add(Mapped.Parameter("?dpr_fun", pro.Cod_fun));
            objCommand.Parameters.Add(Mapped.Parameter("?tra_localAtual", setor));
            objCommand.Parameters.Add(Mapped.Parameter("?tra_fun", pro.Cod_fun));
            objCommand.Parameters.Add(Mapped.Parameter("?tra_cfu", pro.Cod_fun));
            retorno = objCommand.ExecuteScalar().ToString();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            retorno = "";
        }
        catch (Exception e)
        {
            retorno = "Erro ao chamar procedure";
        }
        return retorno;
    }

    //select
    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = @"select pro.pro_cod, pep.pes_nome as redator, pep.pes_sobrenome as redatorSobrenome, fup.fun_matricula as matriculaRedator, pro.pro_numeroProcesso as numeroProcesso, 
                        per.pes_nome as requerente, per.pes_sobrenome as requerenteSobrenome, pro.pro_dataPedido as dataPedido, mrq.mrq_descricao as modelo, 
                            dpr.dpr_datafinalizar as dataFinalizar, pes.pes_nome as portador, pes.pes_sobrenome as portadorSobrenome, fun.fun_matricula as matriculaPortador, sta.sta_valor as situacao, tra.tra_localAtual as localAtual 
                                from pro_processo as pro inner join sta_status as sta on sta.sta_cod = pro.sta_cod 
                                    inner join mrq_modeloRequerimento as mrq on mrq.mrq_cod = pro.mrq_cod 
                                        inner join dpr_detalheProcesso as dpr on dpr.pro_cod = pro.pro_cod inner join tra_tramitacao as tra on tra.dpr_cod = dpr.dpr_cod 
                                            inner join fun_funcionario as fun on fun.fun_cod = tra.fun_cod 
                                                inner join pes_pessoa as pes on pes.pes_cod = fun.pes_cod inner join pro_fun as prf on prf.pro_cod = pro.pro_cod 
                                                    inner join fun_funcionario as fup on fup.fun_cod = prf.fun_cod inner join pes_pessoa as pep on pep.pes_cod = fup.pes_cod 
                                                        inner join req_requerente as req on req.req_cod = pro.req_cod inner join pes_pessoa as per on per.pes_cod = req.pes_cod 
                                                            order by pro.pro_cod desc;";

        objComando = Mapped.Command(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public static DataSet SelectAllPendente()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = @"select pro.pro_cod, concat(pep.pes_nome,' ', pep.pes_sobrenome) as redator, fup.fun_matricula as matriculaRedator, pro.pro_numeroProcesso as numeroProcesso, 
                        concat(per.pes_nome,' ', per.pes_sobrenome) as requerente, pro.pro_dataPedido as dataPedido, mrq.mrq_descricao as modelo, 
                            dpr.dpr_datafinalizar as dataFinalizar, concat(pes.pes_nome,' ', pes.pes_sobrenome) as portador, fun.fun_matricula as matriculaPortador, sta.sta_valor as situacao, tra.tra_localAtual as localAtual 
                                from pro_processo as pro inner join sta_status as sta on sta.sta_cod = pro.sta_cod 
                                    inner join mrq_modeloRequerimento as mrq on mrq.mrq_cod = pro.mrq_cod 
                                        inner join dpr_detalheProcesso as dpr on dpr.pro_cod = pro.pro_cod inner join tra_tramitacao as tra on tra.dpr_cod = dpr.dpr_cod 
                                            inner join fun_funcionario as fun on fun.fun_cod = tra.fun_cod 
                                                inner join pes_pessoa as pes on pes.pes_cod = fun.pes_cod inner join pro_fun as prf on prf.pro_cod = pro.pro_cod 
                                                    inner join fun_funcionario as fup on fup.fun_cod = prf.fun_cod inner join pes_pessoa as pep on pep.pes_cod = fup.pes_cod 
                                                        inner join req_requerente as req on req.req_cod = pro.req_cod inner join pes_pessoa as per on per.pes_cod = req.pes_cod 
															where sta.sta_valor = 'Pendente'
																order by pro.pro_cod desc;";

        objComando = Mapped.Command(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public static DataSet SelectAllDeferido()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = @"select pro.pro_cod, concat(pep.pes_nome,' ', pep.pes_sobrenome) as redator, fup.fun_matricula as matriculaRedator, pro.pro_numeroProcesso as numeroProcesso, 
                        concat(per.pes_nome,' ', per.pes_sobrenome) as requerente, pro.pro_dataPedido as dataPedido, mrq.mrq_descricao as modelo, 
                            dpr.dpr_datafinalizar as dataFinalizar, concat(pes.pes_nome,' ', pes.pes_sobrenome) as portador, fun.fun_matricula as matriculaPortador, sta.sta_valor as situacao, tra.tra_localAtual as localAtual 
                                from pro_processo as pro inner join sta_status as sta on sta.sta_cod = pro.sta_cod 
                                    inner join mrq_modeloRequerimento as mrq on mrq.mrq_cod = pro.mrq_cod 
                                        inner join dpr_detalheProcesso as dpr on dpr.pro_cod = pro.pro_cod inner join tra_tramitacao as tra on tra.dpr_cod = dpr.dpr_cod 
                                            inner join fun_funcionario as fun on fun.fun_cod = tra.fun_cod 
                                                inner join pes_pessoa as pes on pes.pes_cod = fun.pes_cod inner join pro_fun as prf on prf.pro_cod = pro.pro_cod 
                                                    inner join fun_funcionario as fup on fup.fun_cod = prf.fun_cod inner join pes_pessoa as pep on pep.pes_cod = fup.pes_cod 
                                                        inner join req_requerente as req on req.req_cod = pro.req_cod inner join pes_pessoa as per on per.pes_cod = req.pes_cod 
															where sta.sta_valor = 'Deferido'
																order by pro.pro_cod desc;";

        objComando = Mapped.Command(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }
    public static DataSet SelectAllFinalizado()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = @"select pro.pro_cod, concat(pep.pes_nome,' ', pep.pes_sobrenome) as redator, fup.fun_matricula as matriculaRedator, pro.pro_numeroProcesso as numeroProcesso, 
                        concat(per.pes_nome,' ', per.pes_sobrenome) as requerente, pro.pro_dataPedido as dataPedido, mrq.mrq_descricao as modelo, 
                            dpr.dpr_datafinalizar as dataFinalizar, concat(pes.pes_nome,' ', pes.pes_sobrenome) as portador, fun.fun_matricula as matriculaPortador, sta.sta_valor as situacao, tra.tra_localAtual as localAtual 
                                from pro_processo as pro inner join sta_status as sta on sta.sta_cod = pro.sta_cod 
                                    inner join mrq_modeloRequerimento as mrq on mrq.mrq_cod = pro.mrq_cod 
                                        inner join dpr_detalheProcesso as dpr on dpr.pro_cod = pro.pro_cod inner join tra_tramitacao as tra on tra.dpr_cod = dpr.dpr_cod 
                                            inner join fun_funcionario as fun on fun.fun_cod = tra.fun_cod 
                                                inner join pes_pessoa as pes on pes.pes_cod = fun.pes_cod inner join pro_fun as prf on prf.pro_cod = pro.pro_cod 
                                                    inner join fun_funcionario as fup on fup.fun_cod = prf.fun_cod inner join pes_pessoa as pep on pep.pes_cod = fup.pes_cod 
                                                        inner join req_requerente as req on req.req_cod = pro.req_cod inner join pes_pessoa as per on per.pes_cod = req.pes_cod 
															where sta.sta_valor = 'Finalizado'
																order by pro.pro_cod desc;";

        objComando = Mapped.Command(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }


    public static DataSet SelectAllIndeferido()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = @"select pro.pro_cod, concat(pep.pes_nome,' ', pep.pes_sobrenome) as redator, fup.fun_matricula as matriculaRedator, pro.pro_numeroProcesso as numeroProcesso, 
                        concat(per.pes_nome,' ', per.pes_sobrenome) as requerente, pro.pro_dataPedido as dataPedido, mrq.mrq_descricao as modelo, 
                            dpr.dpr_datafinalizar as dataFinalizar, concat(pes.pes_nome,' ', pes.pes_sobrenome) as portador, fun.fun_matricula as matriculaPortador, sta.sta_valor as situacao, tra.tra_localAtual as localAtual 
                                from pro_processo as pro inner join sta_status as sta on sta.sta_cod = pro.sta_cod 
                                    inner join mrq_modeloRequerimento as mrq on mrq.mrq_cod = pro.mrq_cod 
                                        inner join dpr_detalheProcesso as dpr on dpr.pro_cod = pro.pro_cod inner join tra_tramitacao as tra on tra.dpr_cod = dpr.dpr_cod 
                                            inner join fun_funcionario as fun on fun.fun_cod = tra.fun_cod 
                                                inner join pes_pessoa as pes on pes.pes_cod = fun.pes_cod inner join pro_fun as prf on prf.pro_cod = pro.pro_cod 
                                                    inner join fun_funcionario as fup on fup.fun_cod = prf.fun_cod inner join pes_pessoa as pep on pep.pes_cod = fup.pes_cod 
                                                        inner join req_requerente as req on req.req_cod = pro.req_cod inner join pes_pessoa as per on per.pes_cod = req.pes_cod 
															where sta.sta_valor = 'Indeferido'
																order by pro.pro_cod desc;";

        objComando = Mapped.Command(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }

    //select
    public static DataSet SelectConsulta(string codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select * from (select distinct pro.pro_cod as codigo, pep.pes_nome as redator, pep.pes_sobrenome as redatorSobrenome, fup.fun_cod as codRedator, fup.fun_matricula as matriculaRedator, pro.pro_cod, pro.pro_numeroProcesso as numeroProcesso, " +
                        "per.pes_nome as requerente, per.pes_sobrenome as requerenteSobrenome, pro.pro_dataPedido as dataPedido, mrq.mrq_descricao as modelo, " +
                            "dpr.dpr_cod as dpr_cod, dpr.dpr_datafinalizar as dataFinalizar, pes.pes_nome as portador, pes.pes_sobrenome as portadorSobrenome, fun.fun_matricula as matriculaPortador, sta.sta_valor as situacao, " +
		                        "tra.tra_cod, tra.tra_localAtual as localAtual, tra.tra_dataEnvio, obs.obs_valor as observacao, obs.obs_dataObservacao as dataObservacao " +
                                    "from pro_processo as pro inner join sta_status as sta on sta.sta_cod = pro.sta_cod " +
                                        "inner join mrq_modeloRequerimento as mrq on mrq.mrq_cod = pro.mrq_cod " +
                                            "inner join dpr_detalheProcesso as dpr on dpr.pro_cod = pro.pro_cod inner join tra_tramitacao as tra on tra.dpr_cod = dpr.dpr_cod " +
                                                "inner join obs_observacao as obs on obs.tra_cod = tra.tra_cod " +
                                                    "inner join fun_funcionario as fun on fun.fun_cod = tra.fun_cod " +
                                                        "inner join pes_pessoa as pes on pes.pes_cod = fun.pes_cod inner join pro_fun as prf on prf.pro_cod = pro.pro_cod " +
                                                            "inner join fun_funcionario as fup on fup.fun_cod = prf.fun_cod inner join pes_pessoa as pep on pep.pes_cod = fup.pes_cod " +
                                                                "inner join req_requerente as req on req.req_cod = pro.req_cod inner join pes_pessoa as per on per.pes_cod = req.pes_cod " +
                                                                    "union " +
                    "select distinct pro.pro_cod as codigo, pep.pes_nome as redator, pep.pes_sobrenome as redatorSobrenome, fup.fun_cod as codRedator, fup.fun_matricula as matriculaRedator, pro.pro_cod, pro.pro_numeroProcesso as numeroProcesso, " +
	                    "per.pes_nome as requerente, per.pes_sobrenome as requerenteSobrenome, pro.pro_dataPedido as dataPedido, mrq.mrq_descricao as modelo, " +
                            "dpr.dpr_cod as dpr_cod, dpr.dpr_datafinalizar as dataFinalizar, pes.pes_nome as portador, pes.pes_sobrenome as portadorSobrenome, fun.fun_matricula as matriculaPortador, sta.sta_valor as situacao, " +
                                "tra.tra_cod, tra.tra_localAtual as localAtual, tra_dataEnvio, null as observacao, null as dataObservacao " +
                                    "from pro_processo as pro inner join sta_status as sta on sta.sta_cod = pro.sta_cod " +
                                        "inner join mrq_modeloRequerimento as mrq on mrq.mrq_cod = pro.mrq_cod " +
                                            "inner join dpr_detalheProcesso as dpr on dpr.pro_cod = pro.pro_cod inner join tra_tramitacao as tra on tra.dpr_cod = dpr.dpr_cod " +
                                                "inner join fun_funcionario as fun on fun.fun_cod = tra.fun_cod " +
                                                    "inner join pes_pessoa as pes on pes.pes_cod = fun.pes_cod inner join pro_fun as prf on prf.pro_cod = pro.pro_cod " +
                                                        "inner join fun_funcionario as fup on fup.fun_cod = prf.fun_cod inner join pes_pessoa as pep on pep.pes_cod = fup.pes_cod " +
                                                            "inner join req_requerente as req on req.req_cod = pro.req_cod inner join pes_pessoa as per on per.pes_cod = req.pes_cod) as Tramitacao where numeroProcesso = ?codigo group by pro_cod;";

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

    public static DataSet SelectAllPro()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select * from pro_processo;";

        objComando = Mapped.Command(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public static DataSet SelectIndex(string nome)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select pro.pro_numeroProcesso as numeroProcesso, mrq.mrq_descricao as modelo, pes.pes_nome as redator, fun.fun_matricula as matriculaRed, " +
            "sta.sta_valor as staValor, pep.pes_nome as portador from pro_processo as pro inner join mrq_modeloRequerimento as mrq using (mrq_cod) " +
            "inner join pro_fun using (pro_cod) inner join fun_funcionario as fun using (fun_cod) inner join pes_pessoa as pes using (pes_cod) " +
            "inner join sta_status as sta using (sta_cod) inner join dpr_detalheProcesso using (pro_cod) inner join tra_tramitacao as tra using (dpr_cod) " +
            "inner join fun_funcionario as fup on fup.fun_cod = tra.fun_cod inner join pes_pessoa as pep on pep.pes_cod = fup.pes_cod " +
            "where pep.pes_nome = ?nome;";

        objComando = Mapped.Command(sql, objConexao);
        objComando.Parameters.Add(Mapped.Parameter("?nome", nome));
        objDataAdapter = Mapped.Adapter(objComando);
        objComando.ExecuteNonQuery();
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public static DataSet SelectNumProcesso(string pro_numero)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select pes.pes_nome, fun.fun_matricula, pro.pro_cod, pro.pro_numeroProcesso, pro.pro_numeroProtocolo, pro.pro_dataPedido, " +
            "mrq.mrq_modelo, dpr.dpr_dataInicio, " +
                "dpr.dpr_dataFinalizar, tra.tra_localAtual, sta.sta_valor from (Pro_Processo as pro " +
                    "inner join Mrq_ModeloRequerimento as mrq on pro.mrq_cod = mrq.mrq_cod " +
                        "inner join Dpr_DetalheProcesso as dpr on dpr.pro_cod = pro.pro_cod " +
                            "inner join sta_status as sta on sta.sta_cod = pro.sta_cod " +
                                "inner join Tra_Tramitacao as tra on tra.pro_cod = pro.pro_cod " +
                                    "inner join Fun_Funcionario as fun on fun.fun_cod = tra.fun_cod) " +
                                        "inner join Pes_Pessoa as pes on pes.pes_cod = fun.pes_cod " +
                                            "where pro.pro_numeroProcesso = ?pro_numeroProcesso" +
                                                " order by pro.pro_cod;";

        objComando = Mapped.Command(sql, objConexao);
        objComando.Parameters.Add(Mapped.Parameter("?pro_numeroProcesso", pro_numero));
        objComando.ExecuteNonQuery();
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objComando.Dispose();
        objConexao.Dispose();
        objConexao.Close();
        return ds;
    }

    public static DataSet SelectNomProcesso(string pes_nome)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select pes.pes_nome, fun.fun_matricula, pro.pro_cod, pro.pro_numeroProcesso, pro.pro_numeroProtocolo, pro.pro_dataPedido, " +
            "mrq.mrq_descricao, dpr.dpr_dataInicio, " +
                "dpr.dpr_dataFinalizar, tra.tra_localAtual, sta.sta_valor from Pro_Processo as pro " +
                    "inner join Mrq_ModeloRequerimento as mrq on pro.mrq_cod = mrq.mrq_cod " +
                        "inner join Dpr_DetalheProcesso as dpr on dpr.pro_cod = pro.pro_cod " +
                            "inner join Tra_Tramitacao as tra on tra.pro_cod = pro.pro_cod " +
                                "inner join Sta_Status as sta on sta.sta_cod = pro.sta_cod " +
                                    "inner join Fun_Funcionario as fun on fun.fun_cod = tra.fun_cod " +
                                        "inner join Pes_Pessoa as pes on pes.pes_cod = fun.pes_cod " +
                                            "where pes.pes_nome = ?pes_nome" +
                                                " order by pro.pro_cod;";

        objComando = Mapped.Command(sql, objConexao);
        objComando.Parameters.Add(Mapped.Parameter("?pes_nome", pes_nome));
        objComando.ExecuteNonQuery();
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objComando.Dispose();
        objConexao.Dispose();
        objConexao.Close();
        return ds;
    }

    public static DataSet CountProcessos()
    {

        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select sta_valor, count(pro_cod) from sta_status " +
                        "inner join pro_processo using (sta_cod) " +
                            "group by sta_cod;";

        objComando = Mapped.Command(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;

    }

    //select
    public static DataSet SelectRequerimento()
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM mrq_modelorequerimento ORDER BY mrq_descricao", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o DataSet com os dados do BD, 
        //O método Fill é o responsável por preencher o DataSet 
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    public static int Finalizar(int codigo)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update pro_processo set sta_cod = 4 where pro_cod=?codigo";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objComando.ExecuteNonQuery();
            objComando.Dispose();
            objConexao.Dispose();
            objConexao.Close();
        }
        catch (Exception e)
        {
            erro = -2;
        }

        return erro;
    }

    public static Processo Select(int pro_cod)
    {
        Processo pro = null;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from pro_processo where pro_cod=?pro_cod;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?pro_cod", pro_cod));
            objReader = objComando.ExecuteReader();

            int status = 0;
            int modelo = 0;
            int requerente = 0;

            while (objReader.Read())
            {
                pro = new Processo();
                pro.Pro_cod = Convert.ToInt32(objReader["pro_cod"]);
                pro.Pro_numeroProcesso = Convert.ToString(objReader["pro_numeroProcesso"]);
                pro.Pro_dataPedido = Convert.ToString(objReader["pro_dataPedido"]);
                pro.Pro_ativo = Convert.ToString(objReader["pro_ativo"]);
                if (objReader["cod_fun"] == DBNull.Value)
                {
                    pro.Cod_fun = null;
                }
                else
                {
                    pro.Cod_fun = Convert.ToInt32(objReader["cod_fun"]);
                }
                status = Convert.ToInt32(objReader["sta_cod"]);
                modelo = Convert.ToInt32(objReader["mrq_cod"]);
                requerente = Convert.ToInt32(objReader["req_cod"]);
            }

            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();

            pro.Status = StatusDB.Select(status);
            pro.Requerente = RequerenteDB.Select(requerente);

            return pro;
        }
        catch(Exception e)
        {
            return pro = null;
        }
    }
}