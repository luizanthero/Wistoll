using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RequerenteDB
/// </summary>
public class RequerenteDB
{
    public static string Insert(Requerente req, string listaContato)
    {
        string retorno = ""; // 0 = OK / -2 = Erro

        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;

            string sql = "call CadastroRequerente(?pes_nome, ?pes_sobrenome, ?pes_dataNascimento, ?pes_rua, ?pes_numero, ?pes_complemento, ?pes_bairro, ?pes_cep, " +
                            "?pes_cidade, ?pes_estado, ?pes_rg, ?pes_cpf, ?pes_sexo, ?pes_cnpj, ?pes_sigla, ?pes_razaoSocial, ?pes_tipo, ?pes_ativo, ?pes_fun, ?req_fun, ?listaContato); ";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pes_nome", req.Pessoa.Pes_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_sobrenome", req.Pessoa.Pes_sobrenome));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_dataNascimento", req.Pessoa.Pes_dataNascimento));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_rua", req.Pessoa.Pes_rua));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_numero", req.Pessoa.Pes_numero));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_complemento", req.Pessoa.Pes_complemento));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_bairro", req.Pessoa.Pes_bairro));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_cep", req.Pessoa.Pes_cep));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_cidade", req.Pessoa.Pes_cidade));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_estado", req.Pessoa.Pes_estado));
            if (req.Pessoa.Pes_rg != null)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_rg", req.Pessoa.Pes_rg));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_rg", null));
            }
            if (req.Pessoa.Pes_cpf != null)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_cpf", req.Pessoa.Pes_cpf));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_cpf", null));
            }
            objCommand.Parameters.Add(Mapped.Parameter("?pes_sexo", req.Pessoa.Pes_sexo));
            if (req.Pessoa.Pes_cnpj != null)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_cnpj", req.Pessoa.Pes_cnpj));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_cnpj", null));
            }
            if (req.Pessoa.Pes_sigla != null)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_sigla", req.Pessoa.Pes_sigla));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_sigla", null));
            }
            if (req.Pessoa.Pes_razaoSocial != null)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_razaoSocial", req.Pessoa.Pes_razaoSocial));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_razaoSocial", null));
            }
            objCommand.Parameters.Add(Mapped.Parameter("?pes_tipo", req.Pessoa.Pes_tipo));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_ativo", req.Pessoa.Pes_ativo));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_fun", req.Pessoa.Cod_fun));
            objCommand.Parameters.Add(Mapped.Parameter("?req_fun", req.Cod_fun));
            objCommand.Parameters.Add(Mapped.Parameter("?listaContato", listaContato));
            //objCommand.ExecuteNonQuery();
            retorno = objCommand.ExecuteScalar().ToString();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
        }
        catch (Exception e)
        {
            retorno = "Erro ao chamar procedure";
        }
        return retorno;
    }

    public static DataSet CountRequerentes()
    {

        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select count(req_cod) from req_requerente inner join pes_pessoa using(pes_cod) " +
                        "where pes_ativo <> 'Inativo';";

        objComando = Mapped.Command(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public static DataSet CountRequerentesInativos()
    {

        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select count(req_cod) from req_requerente inner join pes_pessoa using(pes_cod) " +
                        "where pes_ativo = 'Inativo';";

        objComando = Mapped.Command(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;

    }


    public static DataSet Consulta(string ativo)
    {
        string sql = "";

        DataSet ds = new DataSet();
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();
                        
            sql = "select * from pes_pessoa inner join req_requerente using(pes_cod) where pes_ativo = ?ativo;";                
            
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?ativo", ativo));
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

    public static Requerente Select(int req_cod)
    {
        Requerente req = null;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from req_requerente where req_cod = ?req_cod;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?req_cod", req_cod));
            objReader = objComando.ExecuteReader();

            int pessoa = 0;
            

            while (objReader.Read())
            {
                req = new Requerente();
                req.Req_cod = Convert.ToInt32(objReader["req_cod"]);
               
                
                pessoa = Convert.ToInt32(objReader["pes_cod"]);
              
            }

            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            req.Pessoa = PessoaDB.Select(pessoa);

            
            return req;
        }
        catch
        {
            return req = null;
        }
    }

    public static DataSet SelectAll()
    {
        DataSet ds;
        try
        {
            ds = new DataSet();
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

            string sql = "select * from req_requerente inner join pes_pessoa using(pes_cod);";

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
        DataSet ds;
        try
        {
            ds = new DataSet();
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

            string sql = "select * from req_requerente inner join pes_pessoa using(pes_cod) where pes_ativo = 'Ativo';";

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