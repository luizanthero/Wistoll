using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Requerente
/// </summary>
public class Requerente
{
    private int req_cod;
    private int? cod_fun;
    private Pessoa _pessoa;

    public int Req_cod
    {
        set { req_cod = value; }

        get { return req_cod; }
    }

    public int? Cod_fun
    {
        set { cod_fun = value; }

        get { return cod_fun;}
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
}