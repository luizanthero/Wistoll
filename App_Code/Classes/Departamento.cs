using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Departamento
/// </summary>
public class Departamento
{
    private int dep_cod;
    private string dep_nome;
    private string dep_descricao;
    private string dep_ativo;
    private int? cod_fun;

    public int Dep_cod
    {
        get
        {
            return dep_cod;
        }

        set
        {
            dep_cod = value;
        }
    }

    public string Dep_nome
    {
        get
        {
            return dep_nome;
        }

        set
        {
            dep_nome = value;
        }
    }

    public string Dep_descricao
    {
        get
        {
            return dep_descricao;
        }

        set
        {
            dep_descricao = value;
        }
    }

    public string Dep_ativo
    {
        get
        {
            return dep_ativo;
        }

        set
        {
            dep_ativo = value;
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