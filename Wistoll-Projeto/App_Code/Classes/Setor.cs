using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Setor
/// </summary>
public class Setor
{
    private int set_cod;
    private string set_nome;
    private string set_descricao;
    private string set_ativo;
    private int? cod_fun;
    private Departamento _departamento;

    public int Set_cod
    {
        get
        {
            return set_cod;
        }

        set
        {
            set_cod = value;
        }
    }

    public string Set_nome
    {
        get
        {
            return set_nome;
        }

        set
        {
            set_nome = value;
        }
    }

    public string Set_descricao
    {
        get
        {
            return set_descricao;
        }

        set
        {
            set_descricao = value;
        }
    }

    public Departamento Departamento
    {
        get
        {
            return _departamento;
        }

        set
        {
            _departamento = value;
        }
    }

    public string Set_ativo
    {
        get
        {
            return set_ativo;
        }

        set
        {
            set_ativo = value;
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