using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Modulo
/// </summary>
public class Modulo
{
    private int mod_cod;
    private string mod_descricao;
    private string mod_pagina;
    private int mod_padrao;
    private int? cod_fun;

    public int Mod_cod
    {
        get
        {
            return mod_cod;
        }

        set
        {
            mod_cod = value;
        }
    }

    public string Mod_descricao
    {
        get
        {
            return mod_descricao;
        }

        set
        {
            mod_descricao = value;
        }
    }

    public string Mod_pagina
    {
        get
        {
            return mod_pagina;
        }

        set
        {
            mod_pagina = value;
        }
    }

    public int Mod_padrao
    {
        get
        {
            return mod_padrao;
        }

        set
        {
            mod_padrao = value;
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