using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Perfil
/// </summary>
public class Perfil
{
    private int pfl_cod;
    private string pfl_descricao;
    private string pfl_imagem;
    private int? cod_fun;

    public int Pfl_cod
    {
        get
        {
            return pfl_cod;
        }

        set
        {
            pfl_cod = value;
        }
    }

    public string Pfl_descricao
    {
        get
        {
            return pfl_descricao;
        }

        set
        {
            pfl_descricao = value;
        }
    }

    public string Pfl_imagem
    {
        get
        {
            return pfl_imagem;
        }

        set
        {
            pfl_imagem = value;
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