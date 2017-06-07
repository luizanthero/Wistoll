using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PessoaDB
/// </summary>
public class PessoaDB
{

    public static Pessoa Select(int pes_cod)
    {
        Pessoa pes = null;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from pes_pessoa WHERE pes_cod=?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?codigo", pes_cod));
            //objComando.Parameters.Add(Mapped.Parameter("?senha", senha));
            objReader = objComando.ExecuteReader();

            while (objReader.Read())
            {
                pes = new Pessoa();
                pes.Pes_cod = Convert.ToInt32(objReader["pes_cod"]);
                pes.Pes_nome = Convert.ToString(objReader["pes_nome"]);
                pes.Pes_sobrenome = Convert.ToString(objReader["pes_sobrenome"]);
                pes.Pes_dataNascimento = Convert.ToString(objReader["pes_dataNascimento"]);
                pes.Pes_estado = Convert.ToString(objReader["pes_estado"]);
                pes.Pes_cidade = Convert.ToString(objReader["pes_cidade"]);
                pes.Pes_bairro = Convert.ToString(objReader["pes_bairro"]);
                pes.Pes_rua = Convert.ToString(objReader["pes_rua"]);
                pes.Pes_numero = Convert.ToString(objReader["pes_numero"]);
                pes.Pes_complemento = Convert.ToString(objReader["pes_complemento"]);
                pes.Pes_cep = Convert.ToString(objReader["pes_cep"]);
                pes.Pes_ativo = Convert.ToString(objReader["pes_ativo"]);
                pes.Pes_cpf = Convert.ToString(objReader["pes_cpf"]);
                pes.Pes_rg = Convert.ToString(objReader["pes_rg"]);
                pes.Pes_cnpj = Convert.ToString(objReader["pes_cnpj"]);
                pes.Pes_sigla = Convert.ToString(objReader["pes_sigla"]);
                pes.Pes_razaoSocial = Convert.ToString(objReader["pes_razaoSocial"]);
                pes.Pes_tipo = Convert.ToString(objReader["pes_tipo"]);
                pes.Pes_sexo = Convert.ToString(objReader["pes_sexo"]);
                if (objReader["cod_fun"] == DBNull.Value)
                {
                    pes.Cod_fun = null;
                }
                else
                {
                    pes.Cod_fun = Convert.ToInt32(objReader["cod_fun"]);
                }
            }

            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            return pes;
        }
        catch
        {
            return pes = null;
        }
    }

    public static int Excluir(Pessoa pes)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update pes_pessoa set pes_ativo = 'Inativo' where pes_cod = ?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?codigo", pes.Pes_cod));
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

    public static int Ativar(Pessoa pes)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update pes_pessoa set pes_ativo = 'Ativo' where pes_cod = ?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?codigo", pes.Pes_cod));
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

    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

            string sql = "select * from pes_pessoa;";

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