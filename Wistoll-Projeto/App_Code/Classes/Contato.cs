using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Contato
/// </summary>
public class Contato
{
    private int con_cod;
    private string con_tipo;
    private string con_valor;
    private int? cod_fun;
    private Pessoa _pessoa;

    public int Con_cod
    {
        get
        {
            return con_cod;
        }

        set
        {
            con_cod = value;
        }
    }

    public string Con_tipo
    {
        get
        {
            return con_tipo;
        }

        set
        {
            con_tipo = value;
        }
    }

    public string Con_valor
    {
        get
        {
            return con_valor;
        }

        set
        {
            con_valor = value;
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