using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DetalhesProcesso
/// </summary>
public class DetalhesProcesso
{
    private int dpr_cod;
    private string dpr_dataFinalizar;
    private int pro_cod;
    private int? fun_cod;

    public int Dpr_cod
    {
        set { dpr_cod = value; }
        get { return dpr_cod; }
    }

    public string Dpr_dataFinalizar
    {
        set { dpr_dataFinalizar = value; }
        get { return dpr_dataFinalizar; }
    }

    public int Pro_cod
    {
        set { pro_cod = value; }
        get { return pro_cod; }
    }

    public int? Fun_cod
    {
        set { fun_cod = value; }
        get { return fun_cod; }
    }

}