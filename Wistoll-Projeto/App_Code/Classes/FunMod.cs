using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wistoll.Funcoes;

/// <summary>
/// Summary description for FunMod
/// </summary>
public class FunMod
{
    private Funcionario _funcionario;
    private Modulo _modulo;
    private int? cod_fun;

    public string AlteraSenha(string senha)
    {
        _funcionario.Fun_senha = Funcoes.HashTexto(senha);
        string nova = Funcoes.HashTexto(senha);
        return nova;
    }

    public Funcionario Funcionario
    {
        get
        {
            return _funcionario;
        }

        set
        {
            _funcionario = value;
        }
    }

    public Modulo Modulo
    {
        get
        {
            return _modulo;
        }

        set
        {
            _modulo = value;
        }
    }

    public int? Cod_fun
    {
        get
        {
            return cod_fun;
        }

        set
        {
            cod_fun = value;
        }
    }
}