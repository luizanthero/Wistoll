using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cargo
/// </summary>
public class Cargo
{
    private int car_cod;
    private string car_descricao;
    private int? cod_fun;

    public int Car_cod
    {
        get
        {
            return car_cod;
        }

        set
        {
            car_cod = value;
        }
    }

    public string Car_descricao
    {
        get
        {
            return car_descricao;
        }

        set
        {
            car_descricao = value;
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