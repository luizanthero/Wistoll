using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Status
/// </summary>
public class Status
{
    private int sta_cod;
    private string sta_valor;
    private int? cod_fun;

    public int Sta_cod
    {
        get
        {
            return sta_cod;
        }

        set
        {
            sta_cod = value;
        }
    }

    public string Sta_valor
    {
        get
        {
            return sta_valor;
        }

        set
        {
            sta_valor = value;
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