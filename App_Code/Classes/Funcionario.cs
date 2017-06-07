using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Funcionario
/// </summary> 
public class Funcionario
{
    private int fun_cod;
    private string fun_matricula;
    private string fun_senha;
    private bool fun_chefeDepartamento;
    private bool fun_chefeSetor;
    private int? cod_fun;
    private bool fun_primeiroAcesso;
    private Pessoa _pessoa;
    private Cargo _cargo;
    private Setor _setor;
    private Perfil _perfil;

    public string Fun_matricula
    {
        get
        {
            return fun_matricula;
        }

        set
        {
            fun_matricula = value;
        }
    }

    public virtual string Fun_senha
    {
        get
        {
            return fun_senha;
        }

        set
        {
            fun_senha = value;
        }
    }

    public Pessoa Pessoa
    {
        get
        {
            return _pessoa;
        }

        set
        {
            _pessoa = value;
        }
    }

    public int Fun_cod
    {
        get
        {
            return fun_cod;
        }

        set
        {
            fun_cod = value;
        }
    }

    public Cargo Cargo
    {
        get
        {
            return _cargo;
        }

        set
        {
            _cargo = value;
        }
    }

    public Setor Setor
    {
        get
        {
            return _setor;
        }

        set
        {
            _setor = value;
        }
    }

    public bool Fun_chefeDepartamento
    {
        get
        {
            return fun_chefeDepartamento;
        }

        set
        {
            fun_chefeDepartamento = value;
        }
    }

    public bool Fun_chefeSetor
    {
        get
        {
            return fun_chefeSetor;
        }

        set
        {
            fun_chefeSetor = value;
        }
    }

    public Perfil Perfil
    {
        get
        {
            return _perfil;
        }

        set
        {
            _perfil = value;
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

    public bool Fun_primeiroAcesso
    {
        get
        {
            return fun_primeiroAcesso;
        }

        set
        {
            fun_primeiroAcesso = value;
        }
    }
}