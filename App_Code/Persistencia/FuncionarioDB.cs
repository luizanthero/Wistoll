using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FuncionarioDB
/// </summary>
public class FuncionarioDB
{
    public static string Insert(FunMod fmp, string listaContato, string listaPermissao)
    {
        string retorno = ""; // 0 = OK / -2 = Erro

        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;

            string sql = "call CadastroUsuario(?pes_nome, ?pes_sobrenome, ?pes_dataNascimento, ?pes_rua, ?pes_numero, ?pes_complemento, ?pes_bairro, ?pes_cep, " +
                            "?pes_cidade, ?pes_estado, ?pes_rg, ?pes_cpf, ?pes_sexo, ?pes_cnpj, ?pes_sigla, ?pes_razaoSocial, ?pes_tipo, ?pes_ativo, ?pes_fun, ?fun_matricula, " +
                                "?fun_senha, ?fun_chefeSetor, ?fun_chefeDepartamento, ?set_cod, ?car_cod, ?pfl_cod, ?fun_fun, ?listaContato, ?listaPermissao); ";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pes_nome", fmp.Funcionario.Pessoa.Pes_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_sobrenome", fmp.Funcionario.Pessoa.Pes_sobrenome));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_dataNascimento", fmp.Funcionario.Pessoa.Pes_dataNascimento));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_rua", fmp.Funcionario.Pessoa.Pes_rua));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_numero", fmp.Funcionario.Pessoa.Pes_numero));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_complemento", fmp.Funcionario.Pessoa.Pes_complemento));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_bairro", fmp.Funcionario.Pessoa.Pes_bairro));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_cep", fmp.Funcionario.Pessoa.Pes_cep));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_cidade", fmp.Funcionario.Pessoa.Pes_cidade));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_estado", fmp.Funcionario.Pessoa.Pes_estado));
            if (fmp.Funcionario.Pessoa.Pes_rg != null)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_rg", fmp.Funcionario.Pessoa.Pes_rg));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_rg", null));
            }
            if (fmp.Funcionario.Pessoa.Pes_cpf != null)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_cpf", fmp.Funcionario.Pessoa.Pes_cpf));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_cpf", null));
            }
            objCommand.Parameters.Add(Mapped.Parameter("?pes_sexo", fmp.Funcionario.Pessoa.Pes_sexo));
            if (fmp.Funcionario.Pessoa.Pes_cnpj != null)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_cnpj", fmp.Funcionario.Pessoa.Pes_cnpj));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_cnpj", null));
            }
            if (fmp.Funcionario.Pessoa.Pes_sigla != null)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_sigla", fmp.Funcionario.Pessoa.Pes_sigla));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_sigla", null));
            }
            if (fmp.Funcionario.Pessoa.Pes_razaoSocial != null)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_razaoSocial", fmp.Funcionario.Pessoa.Pes_razaoSocial));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_razaoSocial", null));
            }
            objCommand.Parameters.Add(Mapped.Parameter("?pes_tipo", fmp.Funcionario.Pessoa.Pes_tipo));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_ativo", fmp.Funcionario.Pessoa.Pes_ativo));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_fun", fmp.Funcionario.Pessoa.Cod_fun));
            objCommand.Parameters.Add(Mapped.Parameter("?fun_matricula", fmp.Funcionario.Fun_matricula));
            objCommand.Parameters.Add(Mapped.Parameter("?fun_senha", fmp.Funcionario.Fun_senha));
            if(fmp.Funcionario.Fun_chefeSetor != false)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?fun_chefeSetor", 1));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?fun_chefeSetor", 0));
            }
            if(fmp.Funcionario.Fun_chefeDepartamento != false)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?fun_chefeDepartamento", 1));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?fun_chefeDepartamento", 0));
            }
            objCommand.Parameters.Add(Mapped.Parameter("?set_cod", fmp.Funcionario.Setor.Set_cod));
            objCommand.Parameters.Add(Mapped.Parameter("?car_cod", fmp.Funcionario.Cargo.Car_cod));
            objCommand.Parameters.Add(Mapped.Parameter("?pfl_cod", fmp.Funcionario.Perfil.Pfl_cod));
            objCommand.Parameters.Add(Mapped.Parameter("?fun_fun", fmp.Funcionario.Cod_fun));
            objCommand.Parameters.Add(Mapped.Parameter("?listaContato", listaContato));
            objCommand.Parameters.Add(Mapped.Parameter("?listaPermissao", listaPermissao));
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

    public static string Update(FunMod fmp, string listaPermissao)
    {
        string retorno = ""; // 0 = OK / -2 = Erro

        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;

            string sql = "call UpdateUsuario(?pes_cod, ?pes_nome, ?pes_sobrenome, ?pes_dataNascimento, ?pes_rua, ?pes_numero, ?pes_complemento, ?pes_bairro, ?pes_cep, " +
                            "?pes_cidade, ?pes_estado, ?pes_rg, ?pes_cpf, ?pes_sexo, ?pes_cnpj, ?pes_sigla, ?pes_razaoSocial, ?pes_tipo, ?pes_ativo, ?pes_fun, ?fun_cod, ?fun_matricula, " +
                                "?fun_chefeSetor, ?fun_chefeDepartamento, ?set_cod, ?car_cod, ?pfl_cod, ?fun_fun, ?listaPermissao); ";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pes_cod", fmp.Funcionario.Pessoa.Pes_cod));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_nome", fmp.Funcionario.Pessoa.Pes_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_sobrenome", fmp.Funcionario.Pessoa.Pes_sobrenome));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_dataNascimento", fmp.Funcionario.Pessoa.Pes_dataNascimento));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_rua", fmp.Funcionario.Pessoa.Pes_rua));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_numero", fmp.Funcionario.Pessoa.Pes_numero));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_complemento", fmp.Funcionario.Pessoa.Pes_complemento));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_bairro", fmp.Funcionario.Pessoa.Pes_bairro));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_cep", fmp.Funcionario.Pessoa.Pes_cep));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_cidade", fmp.Funcionario.Pessoa.Pes_cidade));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_estado", fmp.Funcionario.Pessoa.Pes_estado));
            if (fmp.Funcionario.Pessoa.Pes_rg != null)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_rg", fmp.Funcionario.Pessoa.Pes_rg));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_rg", null));
            }
            if (fmp.Funcionario.Pessoa.Pes_cpf != null)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_cpf", fmp.Funcionario.Pessoa.Pes_cpf));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_cpf", null));
            }
            objCommand.Parameters.Add(Mapped.Parameter("?pes_sexo", fmp.Funcionario.Pessoa.Pes_sexo));
            if (fmp.Funcionario.Pessoa.Pes_cnpj != null)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_cnpj", fmp.Funcionario.Pessoa.Pes_cnpj));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_cnpj", null));
            }
            if (fmp.Funcionario.Pessoa.Pes_sigla != null)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_sigla", fmp.Funcionario.Pessoa.Pes_sigla));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_sigla", null));
            }
            if (fmp.Funcionario.Pessoa.Pes_razaoSocial != null)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_razaoSocial", fmp.Funcionario.Pessoa.Pes_razaoSocial));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?pes_razaoSocial", null));
            }
            objCommand.Parameters.Add(Mapped.Parameter("?pes_tipo", fmp.Funcionario.Pessoa.Pes_tipo));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_ativo", fmp.Funcionario.Pessoa.Pes_ativo));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_fun", fmp.Funcionario.Pessoa.Cod_fun));
            objCommand.Parameters.Add(Mapped.Parameter("?fun_cod", fmp.Funcionario.Fun_cod));
            objCommand.Parameters.Add(Mapped.Parameter("?fun_matricula", fmp.Funcionario.Fun_matricula));
            if (fmp.Funcionario.Fun_chefeSetor != false)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?fun_chefeSetor", 1));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?fun_chefeSetor", 0));
            }
            if (fmp.Funcionario.Fun_chefeDepartamento != false)
            {
                objCommand.Parameters.Add(Mapped.Parameter("?fun_chefeDepartamento", 1));
            }
            else
            {
                objCommand.Parameters.Add(Mapped.Parameter("?fun_chefeDepartamento", 0));
            }
            objCommand.Parameters.Add(Mapped.Parameter("?set_cod", fmp.Funcionario.Setor.Set_cod));
            objCommand.Parameters.Add(Mapped.Parameter("?car_cod", fmp.Funcionario.Cargo.Car_cod));
            objCommand.Parameters.Add(Mapped.Parameter("?pfl_cod", fmp.Funcionario.Perfil.Pfl_cod));
            objCommand.Parameters.Add(Mapped.Parameter("?fun_fun", fmp.Funcionario.Cod_fun));
            objCommand.Parameters.Add(Mapped.Parameter("?listaPermissao", listaPermissao));
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

    public static Funcionario Select(int fun_cod)
    {
        Funcionario fun = null;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from fun_funcionario where fun_cod=?fun_cod;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?fun_cod", fun_cod));
            objReader = objComando.ExecuteReader();

            int pessoa = 0;
            int cargo = 0;
            int setor = 0;
            int perfil = 0;

            while (objReader.Read())
            {
                fun = new Funcionario();
                fun.Fun_cod = Convert.ToInt32(objReader["fun_cod"]);
                fun.Fun_matricula = Convert.ToString(objReader["fun_matricula"]);
                fun.Fun_senha = Convert.ToString(objReader["fun_senha"]);
                if (objReader["fun_chefeDepartamento"].Equals(false))
                {
                    fun.Fun_chefeDepartamento = false;
                }
                else
                {
                    fun.Fun_chefeDepartamento = true;
                }
                if (objReader["fun_chefeSetor"].Equals(false))
                {
                    fun.Fun_chefeSetor = false;
                }
                else
                {
                    fun.Fun_chefeSetor = true;
                }
                if (objReader["fun_primeiroAcesso"].Equals(false))
                {
                    fun.Fun_primeiroAcesso = false;
                }
                else
                {
                    fun.Fun_primeiroAcesso = true;
                }
                if (objReader["cod_fun"] == DBNull.Value)
                {
                    fun.Cod_fun = null;
                }
                else
                {
                    fun.Cod_fun = Convert.ToInt32(objReader["cod_fun"]);
                }
                pessoa = Convert.ToInt32(objReader["pes_cod"]);
                cargo = Convert.ToInt32(objReader["car_cod"]);
                setor = Convert.ToInt32(objReader["set_cod"]);
                perfil = Convert.ToInt32(objReader["pfl_cod"]);
            }

            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            fun.Pessoa = PessoaDB.Select(pessoa);
            fun.Cargo = CargoDB.Select(cargo);
            fun.Setor = SetorDB.Select(setor);
            fun.Perfil = PerfilDB.Select(perfil);
            return fun;
        }
        catch
        {
            return fun = null;
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

            string sql = "select * from fun_funcionario;";

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

            if (ativo != "Ativo" && ativo != "Inativo")
            {
                if (ativo != null)
                {
                    sql = "select * from pes_pessoa inner join fun_funcionario using(pes_cod) " +
                        "inner join pfl_perfil using(pfl_cod) where pfl_descricao = ?ativo and pes_ativo <> 'Inativo';";
                }
                else
                {
                    sql = "select * from pes_pessoa inner join fun_funcionario using(pes_cod) " + 
                        "inner join pfl_perfil using(pfl_cod) where pes_ativo <> 'Inativo';";
                }
            }
            else
            {
                if(ativo == "Ativo")
                {
                    sql = "select * from pes_pessoa inner join fun_funcionario using(pes_cod) " +
                    "inner join pfl_perfil using(pfl_cod) where pes_ativo = ?ativo and pfl_descricao <> 'Administrador';";
                }
                else
                {
                    sql = "select * from pes_pessoa inner join fun_funcionario using(pes_cod) " +
                    "inner join pfl_perfil using(pfl_cod) where pes_ativo = ?ativo;";
                }
            }

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

    public static DataSet CountUsuarios()
    {

        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select pfl_descricao, count(fun_cod) from pfl_perfil " +
                        "inner join fun_funcionario using (pfl_cod) inner join pes_pessoa using(pes_cod) " +
                            "where pes_ativo <> 'Inativo' group by pfl_cod;";

        objComando = Mapped.Command(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;

    }

    public static DataSet CountUsuariosInativo()
    {

        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();

        string sql = "select count(fun_cod) from fun_funcionario inner join pes_pessoa using(pes_cod) " +
                        "where pes_ativo = 'Inativo';";

        objComando = Mapped.Command(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;

    }

    public static int AlterarSenha(FunMod fmp)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update fun_funcionario set fun_primeiroAcesso=false, cod_fun=?cod_fun, fun_senha=?senha where fun_cod=?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?codigo", fmp.Funcionario.Fun_cod));
            objComando.Parameters.Add(Mapped.Parameter("?cod_fun", fmp.Funcionario.Cod_fun));
            objComando.Parameters.Add(Mapped.Parameter("?senha", fmp.Funcionario.Fun_senha));
            objComando.ExecuteNonQuery();
            objComando.Dispose();
            objConexao.Dispose();
            objConexao.Close();
        }
        catch (Exception error)
        {
            erro = -2;
        }

        return erro;
    }

    public static int RedefinirSenha(int pes_cod, string senha)
    {
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update fun_funcionario set fun_Senha = ?senha, fun_primeiroAcesso = 1 where pes_cod = ?pes_cod;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?pes_cod", pes_cod));
            objComando.Parameters.Add(Mapped.Parameter("?senha", senha));
            objComando.ExecuteNonQuery();
            objComando.Dispose();
            objConexao.Dispose();
            objConexao.Close();
        }
        catch (Exception e)
        {
            pes_cod = 0;
        }

        return pes_cod;
    }

    public static int RedefinirSenhaContato(string email)
    {
        int codigo = 0;        
        DataSet ds = null;

        try
        {
            ds = new DataSet();
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();


            string sql = "select * from con_contato where con_valor = ?email";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?email", email));
            objReader = objComando.ExecuteReader();

            while (objReader.Read())
            {
                codigo = Convert.ToInt32(objReader["pes_cod"]);
            }

            
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();


        }
        catch (Exception e)
        {
            ds = null;
        }

        return codigo;
    }
}