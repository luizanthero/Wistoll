using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for LoginDB
/// </summary>
public class LoginDB
{ 

    public static Funcionario SelectLogin(Funcionario fun)
    {
        return SelectLogin(fun.Fun_matricula, fun.Fun_senha);
    }

    public static Funcionario SelectLogin(string matricula, string senha)
    {
        Funcionario fun = null;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from fun_funcionario where fun_matricula=?matricula and fun_senha=?senha;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?matricula", matricula));
            objComando.Parameters.Add(Mapped.Parameter("?senha", senha));
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
                if (Convert.ToInt32(objReader["fun_chefeDepartamento"]) == 0)
                {
                    fun.Fun_chefeDepartamento = false;
                }
                else
                {
                    fun.Fun_chefeDepartamento = true;
                }
                if (Convert.ToInt32(objReader["fun_chefeSetor"]) == 0)
                {
                    fun.Fun_chefeDepartamento = false;
                }
                else
                {
                    fun.Fun_chefeDepartamento = true;
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

            Sessão(fun.Fun_cod);

            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            fun.Pessoa = PessoaDB.Select(pessoa);
            fun.Cargo = CargoDB.Select(cargo);
            fun.Setor = SetorDB.Select(setor);
            fun.Perfil = PerfilDB.Select(perfil);
            return fun;
        }
        catch(Exception e)
        {
            return fun = null;
        }
    }

    public static FunMod Sessão(int fun_cod)
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

            int funcionario = 0;
            int modulo = 0;

            while (objReader.Read())
            {
                fmp = new FunMod();
                funcionario = Convert.ToInt32(objReader["fun_cod"]);
                modulo = Convert.ToInt32(objReader["mod_cod"]);
                if(objReader["cod_fun"] == DBNull.Value)
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
        catch
        {
            return fmp = null;
        }
    }

}