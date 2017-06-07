
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Modelo_Requerimento
/// </summary>
public class ModeloRequerimento
{
    private int mrq_cod;
    private string mrq_descricao;
    private int? cod_fun;

    public int Mrq_cod
    {
        get
        {
            return mrq_cod;
        }

        set
        {
            mrq_cod = value;
        }
    }

    public string Mrq_descricao
    {
        get
        {
            return mrq_descricao;
        }

        set
        {
            mrq_descricao = value;
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