using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Anexos
/// </summary>
public class Anexos
{
    private int anx_cod;
    private string anx_descricao;
    private string anx_nome;
    private int dpr_cod;
    private int? cod_fun;

    public int Anx_cod
    {
        set { anx_cod = value; }
    
        get { return anx_cod; }
    }

    public string Anx_descricao
    {
        set { anx_descricao = value; }

        get { return anx_descricao; }
    }

    public int Dpr_cod
    {
        set { dpr_cod = value; }

        get { return dpr_cod; }
    }

    public int? Cod_fun
    {
        set { cod_fun = value; }

        get { return cod_fun; }
    }

    public string Anx_nome
    {
        get
        {
            return anx_nome;
        }

        set
        {
            anx_nome = value;
        }
    }
}